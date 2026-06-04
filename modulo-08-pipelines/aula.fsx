// =============================================================================
// Módulo 8 — Pipelines: tudo junto (síntese do curso)
// =============================================================================
//
// Como rodar este arquivo:
//   1. Abra este arquivo no editor.
//   2. Aperte Ctrl+Shift+B.
//   3. O resultado aparece no painel inferior.
//
// =============================================================================
// O cenário do quadro:
//
//   O sócio mandou esta lista de alíquotas (uma string por linha) e
//   pediu para conferir antes de aplicar nos próximos faturamentos:
//
//     0.03    →  válida
//     0.07    →  fora da faixa LC 116
//     abc     →  nem é número
//     -0.02   →  negativa
//     0.025   →  válida
//     0.05    →  válida (no limite exato)
//
//   Cada alíquota precisa passar por TRÊS checagens:
//
//     1. ser um número (string → float)
//     2. ser positiva
//     3. estar entre 2% e 5% (LC 116/2003)
//
//   No Sheets isso seria SE.ERRO aninhado em três níveis, replicado
//   por linha. Aqui vamos montar um PIPELINE onde cada linha passa
//   pela mesma esteira e o erro propaga sozinho.
// =============================================================================


// --- Etapa 1: parseAliquota --------------------------------------------------
//
// String → float. TryParse devolve uma tupla (bool, valor). A gente
// converte para Result.
//
// ⚠ Nota técnica: precisamos forçar a "cultura invariante" no parse
//   porque, em pt-BR, o ponto é separador de milhar e a vírgula é
//   decimal. Sem isso, "0.03" vira 3 (zero ponto zero três zero).
//   Em produção, a regra é: dados que vêm de FORA do Brasil ou de
//   arquivos técnicos (CSV padrão, JSON, API) usam ponto decimal,
//   e a InvariantCulture é o jeito certo.

let parseAliquota (s: string) : Result<float, string> =
    let cultura = System.Globalization.CultureInfo.InvariantCulture
    let estilo = System.Globalization.NumberStyles.Float
    match System.Double.TryParse(s, estilo, cultura) with
    | true, v  -> Ok v
    | false, _ -> Error (sprintf "'%s' não é um número" s)


// --- Etapa 2: validarPositiva ------------------------------------------------

let validarPositiva (a: float) : Result<float, string> =
    if a > 0.0 then Ok a
    else Error (sprintf "%.4f não é positiva" a)


// --- Etapa 3: validarFaixaISS ------------------------------------------------

let validarFaixaISS (a: float) : Result<float, string> =
    if a >= 0.02 && a <= 0.05 then Ok a
    else Error (sprintf "%.4f está fora da faixa 2%%-5%% (LC 116)" a)


// --- O pipeline: três etapas costuradas com Result.bind ---------------------
//
// Result.bind funciona assim:
//   - Se a etapa anterior devolveu Ok valor, aplica a próxima função.
//   - Se devolveu Error, pula a próxima função e leva o Error adiante.
//
// É o equivalente automático do SE.ERRO em volta de cada etapa.

let validar (input: string) =
    input
    |> parseAliquota
    |> Result.bind validarPositiva
    |> Result.bind validarFaixaISS


// =============================================================================
// Nota — Railway-Oriented Programming:
//
//   O nome técnico do que estamos fazendo é "Railway-Oriented
//   Programming". A imagem é uma estrada com dois trilhos:
//
//     ── trilho de cima (sucesso): Ok → Ok → Ok → Ok
//                                              ↘
//     ── trilho de baixo (erro):                  Error
//
//   Cada Result.bind é um cruzamento. Se você está no trilho de
//   cima, segue para a próxima etapa. Se está no de baixo, fica
//   no de baixo até o fim. Vocês não precisam decorar o nome.
//   Precisam reconhecer o desenho.
// =============================================================================


// --- Aplicar o pipeline em uma lista (volta o Módulo 3) ---------------------

let alíquotasInformadas =
    [ "0.03"; "0.07"; "abc"; "-0.02"; "0.025"; "0.05" ]

let resultados = alíquotasInformadas |> List.map validar


// --- Separar válidas de erros -----------------------------------------------
//
// Cada item de `resultados` é Ok ou Error. Para extrair só os Oks,
// usamos List.choose com uma função que devolve Some para Ok e
// None para Error. Mesmo gesto do Módulo 5, agora aplicado a Result.

let extrairOk r =
    match r with
    | Ok v    -> Some v
    | Error _ -> None

let extrairErro r =
    match r with
    | Ok _    -> None
    | Error m -> Some m

let aliquotasValidas = resultados |> List.choose extrairOk
let mensagensDeErro  = resultados |> List.choose extrairErro


// --- O relatório que o sócio queria -----------------------------------------

printfn "=== RELATÓRIO DE VALIDAÇÃO DE ALÍQUOTAS ==="
printfn ""
printfn "Total informadas: %d" (List.length alíquotasInformadas)
printfn "Válidas:          %d" (List.length aliquotasValidas)
printfn "Inválidas:        %d" (List.length mensagensDeErro)
printfn ""

printfn "--- Alíquotas válidas ---"
aliquotasValidas |> List.iter (fun a -> printfn "  %.2f%%" (a * 100.0))

printfn ""
printfn "--- Motivos de rejeição ---"
mensagensDeErro |> List.iter (fun m -> printfn "  %s" m)
printfn ""


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Adicionar uma quarta validação ao pipeline.
//
//   A Receita Federal só aceita alíquotas com até 4 casas decimais.
//   Adicione esta função e encaixe no pipeline:

//let validarPrecisao (a: float) : Result<float, string> =
//    let arredondado = System.Math.Round(a, 4)
//    if a = arredondado then Ok a
//    else Error (sprintf "%f tem mais de 4 casas decimais" a)
//
//let validarComPrecisao input =
//    input
//    |> parseAliquota
//    |> Result.bind validarPositiva
//    |> Result.bind validarFaixaISS
//    |> Result.bind validarPrecisao
//
//let testePrecisao = validarComPrecisao "0.034567"
//printfn "Teste com 6 casas: %A" testePrecisao

// -----------------------------------------------------------------------------
//
// Experimento 2 — Calcular o tributo médio.
//
//   Aplicar cada alíquota válida em uma receita de R$ 100.000 e
//   tirar a média. Descomente:

//let receitaTeste = 100_000.0
//let aplicarA preco aliquota = aliquota * preco
//let tributos = aliquotasValidas |> List.map (aplicarA receitaTeste)
//let tributoMedio = List.average tributos
//printfn ""
//printfn "Tributo médio (receita R$ 100.000): R$ %.2f" tributoMedio

// -----------------------------------------------------------------------------
//
// Experimento 3 — Trocar a ordem dos validators. O que acontece?
//
//   Reescreva `validar` invertendo validarPositiva e validarFaixaISS:

//let validarOrdemTrocada (input: string) =
//    input
//    |> parseAliquota
//    |> Result.bind validarFaixaISS    // ← agora a faixa vem antes
//    |> Result.bind validarPositiva
//
//let teste1 = validar "-0.02"
//let teste2 = validarOrdemTrocada "-0.02"
//printfn ""
//printfn "Ordem original: %A" teste1
//printfn "Ordem trocada:  %A" teste2

//   As duas chegam ao mesmo veredicto (rejeição), mas com MENSAGENS
//   diferentes. A primeira pega a negatividade primeiro; a segunda
//   pega o "fora da faixa" primeiro. Os dois sucessos seriam
//   indistinguíveis — a ordem só importa para QUAL erro aparece.
//
//   Lição: ordene as etapas pela mensagem que você quer ver primeiro.
//
// =============================================================================
// A regra do módulo:
//   Validações que devolvem Result se encadeiam com Result.bind.
//   O erro flui automaticamente — não precisa de SE.ERRO em cada
//   nível. Aplicar a lista inteira é List.map; separar Oks e
//   Errors é List.choose com uma função extratora. Esse é o jeito
//   de processar dados em F# — vocês acabaram de costurar todo o
//   curso em três telas.
// =============================================================================
