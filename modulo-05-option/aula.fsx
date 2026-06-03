// =============================================================================
// Módulo 5 — Option: a célula que pode estar vazia
// =============================================================================
//
// Como rodar este arquivo:
//   1. Abra este arquivo no editor.
//   2. Aperte Ctrl+Shift+B.
//   3. O resultado aparece no painel inferior.
//
// =============================================================================
// O que vimos no quadro antes deste arquivo:
//
//   Uma planilha de cadastro de clientes (CNPJ → Razão Social).
//
//   PROCV de um CNPJ existente → razão social.
//   PROCV de um CNPJ não cadastrado → #N/A.
//
//   Solução de todo dia: =SE.ERRO(PROCV(...); "NÃO ENCONTRADO")
//
//   Mas: =COMPRIMENTO(SE.ERRO(PROCV(...); "NÃO ENCONTRADO"))
//   devolve 15 (o tamanho de "NÃO ENCONTRADO"), como se fosse
//   uma string válida. A AUSÊNCIA foi disfarçada de string —
//   o mesmo problema do Módulo 4, com cara nova.
//
//   F# tem um tipo dedicado à ausência: Option.
// =============================================================================


// --- A função buscarRazaoSocial em F# ----------------------------------------
//
// O tipo de retorno é `string option` — "ou uma string, ou nada".
// `Some valor` = encontrou. `None` = não encontrou.

let buscarRazaoSocial (cnpj: string) : string option =
    match cnpj with
    | "12.345.678/0001-99" -> Some "Empresa A LTDA"
    | "98.765.432/0001-11" -> Some "Empresa B LTDA"
    | "55.444.333/0001-22" -> Some "Empresa C LTDA"
    | _                    -> None   // qualquer outro CNPJ

// O `_` é "qualquer outro caso". É o ELSE final do match.


// --- Tratamento com match ----------------------------------------------------
//
// Mesmo gesto do Módulo 4. Compilador exige tratar os DOIS casos.

let consultar cnpj =
    match buscarRazaoSocial cnpj with
    | Some razao -> printfn "%s → %s" cnpj razao
    | None       -> printfn "%s → CLIENTE NÃO CADASTRADO" cnpj

consultar "12.345.678/0001-99"
consultar "00.000.000/0001-00"
printfn ""


// --- Option ou Result? -------------------------------------------------------
//
//   Result  →  pode falhar E DÁ PRA EXPLICAR por quê
//                 (alíquota fora da faixa → "viola LC 116/2003")
//
//   Option  →  pode não ter valor, E A AUSÊNCIA FALA POR SI
//                 (PROCV não achou → "não tem nada a explicar")
//
// Mesma família, escolhe pelo que cabe à situação.


// --- Lista de Options: o caso real -------------------------------------------
//
// Fechamento parcial de 2025: Set–Dez ainda não fecharam.

let receitas2025Parcial : float option list =
    [ Some 10_000.0; Some 12_500.0; Some 11_800.0
      Some 9_500.0;  Some 13_200.0; Some 14_100.0
      Some 11_000.0; Some 10_800.0
      None;          None;          None;         None ]

// Pergunta: "Qual a média das receitas que já fecharam?"
// Antes de fazer média, preciso descartar os None e desembrulhar os Some.
// É exatamente o que List.choose id faz:

let receitasFechadas = receitas2025Parcial |> List.choose id

let mediaAteAgora = List.average receitasFechadas

printfn "Meses fechados: %d" (List.length receitasFechadas)
printfn "Receita média (até agora): R$ %.2f" mediaAteAgora
printfn ""

// `List.choose id`:
//   - `List.choose f` aplica `f` em cada item e mantém só os Some
//   - `id` é a função identidade: devolve o que recebeu
//   - resultado: mantém os Some já desembrulhados, descarta os None
//
// É o irmão de List.filter, que SÓ filtra. Choose filtra E desembrulha.


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Tentar usar o resultado direto como string.
//
//   Descomente. A Ionide pinta de vermelho:

//let saudacao = "Bom dia, " + buscarRazaoSocial "12.345.678/0001-99"

//   Razão: o tipo é `string option`, não `string`. Você não pode
//   concatenar com string sem primeiro extrair o valor do Some.
//   É a mesma proteção do Módulo 4: o tipo te obriga a tratar.
//
// -----------------------------------------------------------------------------
//
// Experimento 2 — Adicionar uma quarta empresa.
//
//   Adicione uma linha no `match` de buscarRazaoSocial. Por exemplo:
//
//     | "11.222.333/0001-44" -> Some "Empresa D LTDA"
//
//   Antes do `_`. Depois, descomente:

//consultar "11.222.333/0001-44"

// -----------------------------------------------------------------------------
//
// Experimento 3 — Total das receitas fechadas.
//
//   Compose com pipe: pega a lista de Options, descarta os None,
//   soma. Descomente:

//let totalFechado =
//    receitas2025Parcial
//    |> List.choose id
//    |> List.sum
//printfn "Total fechado até agora: R$ %.2f" totalFechado

// =============================================================================
// A regra do módulo:
//   Option declara que um valor pode estar ausente. Quem usa é
//   obrigado a tratar Some e None. Não confunda com Result:
//   Result tem motivo (Error), Option não — só a ausência (None).
// =============================================================================
