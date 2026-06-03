// =============================================================================
// Módulo 3 — Listas são colunas
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
//   Três gestos que vocês fazem todo dia no Sheets:
//
//     1. ARRASTAR uma fórmula coluna abaixo
//        (a mesma fórmula aplicada em cada linha)
//
//     2. AUTOFILTRO ("mostrar só linhas com receita > 10.000")
//
//     3. =SOMA(B6:B17)
//        (totalizar uma coluna)
//
//   Em F#, esses três gestos têm nome:
//
//     ARRASTAR    →  List.map
//     AUTOFILTRO  →  List.filter
//     SOMA        →  List.sum
//
//   E uma coluna inteira de dados é uma LISTA.
// =============================================================================

// --- Constantes da empresa (vindo do Módulo 1) ---
let aliqISS = 0.05
let aliqPIS = 0.0065
let aliqCOFINS = 0.03
let aliqTotal = aliqISS + aliqPIS + aliqCOFINS

// --- Uma lista é uma coluna ---
//
// Colchetes delimitam. Ponto-e-vírgula separa os itens.
// Esta é a coluna B (Receita) da nossa planilha de 2025:

let receitas =
    [ 10_000.0; 12_500.0; 11_800.0; 9_500.0; 13_200.0; 14_100.0
      11_000.0; 10_800.0; 12_300.0; 13_900.0; 15_200.0; 16_500.0 ]

// --- SOMA = List.sum ---

let totalReceita = List.sum receitas
printfn "Total anual de receita: R$ %.2f" totalReceita
printfn ""

// --- Arrastar fórmula = List.map ---
//
// Definimos a fórmula UMA vez (igual ao Módulo 2):

let aplicarTributo receita = receita * aliqTotal

// E "arrastamos" para a coluna inteira:

let tributos = receitas |> List.map aplicarTributo

// Imprimir mês a mês:
let meses =
    [ "Janeiro"; "Fevereiro"; "Março"; "Abril"; "Maio"; "Junho"
      "Julho"; "Agosto"; "Setembro"; "Outubro"; "Novembro"; "Dezembro" ]

printfn "=== Tributos por mês ==="
List.iter2 (fun mes trib -> printfn "%-12s R$ %.2f" mes trib) meses tributos
printfn ""

// (List.iter2 percorre duas listas em paralelo. Não se preocupe com
// ele agora — só com a ideia: vocês já têm uma LISTA de tributos.)

// --- AutoFiltro = List.filter ---

let ehReceitaAlta receita = receita > 12_000.0

let receitasAltas = receitas |> List.filter ehReceitaAlta

printfn "=== Meses com receita acima de R$ 12.000 ==="
printfn "Quantidade: %d mês(es)" (List.length receitasAltas)
List.iter (fun r -> printfn "  R$ %.2f" r) receitasAltas
printfn ""

// --- Pipe brilha quando você compõe ---
//
// Pergunta: "Quanto a empresa pagou de tributos no ano?"

let totalTributosAno =
    receitas
    |> List.map aplicarTributo
    |> List.sum

printfn "Total de tributos no ano: R$ %.2f" totalTributosAno
printfn ""

// Lê de cima para baixo:
//   pega as receitas,
//   aplica tributo em cada uma,
//   soma tudo.
//
// No Sheets, esse cálculo precisaria de uma coluna auxiliar ou um
// SUMPRODUCT difícil de ler. Em F#, três linhas claras.


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Total dos meses com receita alta.
//
//   Componha: receitasAltas, depois soma. Descomente:

//let totalReceitasAltas =
//    receitas
//    |> List.filter ehReceitaAlta
//    |> List.sum
//printfn "Total dos meses com receita > 12.000: R$ %.2f" totalReceitasAltas

// -----------------------------------------------------------------------------
//
// Experimento 2 — Receita líquida (depois dos tributos), mês a mês.
//
//   Defina uma função para um mês e aplique à coluna. Descomente:

//let calcularLiquido receita = receita - receita * aliqTotal
//
//let liquidos = receitas |> List.map calcularLiquido
//let totalLiquido = List.sum liquidos
//
//printfn "Total líquido anual: R$ %.2f" totalLiquido

// -----------------------------------------------------------------------------
//
// Experimento 3 — Quantos meses ficaram acima da MÉDIA?
//
//   Existe uma função List.average. Descomente:

//let receitaMedia = List.average receitas
//let ehAcimaDaMedia r = r > receitaMedia
//
//let mesesAcimaDaMedia =
//    receitas
//    |> List.filter ehAcimaDaMedia
//    |> List.length
//
//printfn "Receita média: R$ %.2f" receitaMedia
//printfn "Meses acima da média: %d" mesesAcimaDaMedia

// =============================================================================
// A regra do módulo:
//   Coluna do Sheets é lista em F#. Os três gestos do dia a dia
//   (arrastar fórmula, autofiltro, somar coluna) viram três funções
//   (List.map, List.filter, List.sum) que se encadeiam com pipe.
// =============================================================================
