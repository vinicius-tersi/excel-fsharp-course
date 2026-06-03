// =============================================================================
// Módulo 0 — A planilha que você já usa É programação
// =============================================================================
//
// Como rodar este arquivo:
//   1. Abra este arquivo no editor.
//   2. Aperte Ctrl+Shift+B.
//   3. O resultado aparece no painel inferior.
//
// =============================================================================
// A planilha que estamos traduzindo:
//
//   A                       B
//   Receita Bruta           10.000,00
//   Alíquota ISS            0,05
//   Alíquota PIS            0,0065
//   Alíquota COFINS         0,03
//
//   ISS a recolher          = Receita * AliqISS
//   PIS a recolher          = Receita * AliqPIS
//   COFINS a recolher       = Receita * AliqCOFINS
//   Total de tributos       = SOMA(ISS; PIS; COFINS)
//   Receita líquida         = Receita - Total
//
// Cada `let` abaixo é um intervalo nomeado. Cada expressão é uma fórmula.
// =============================================================================

// --- Valores nomeados (= intervalos nomeados no Sheets) ---
let receita = 10_000.0
let aliqISS = 0.05
let aliqPIS = 0.0065
let aliqCOFINS = 0.03

// --- Fórmulas que combinam os valores acima ---
let iss = receita * aliqISS
let pis = receita * aliqPIS
let cofins = receita * aliqCOFINS
let totalTributos = iss + pis + cofins
let receitaLiquida = receita - totalTributos

// --- Mostrar o resultado ---
printfn "Receita bruta:        %10.2f" receita
printfn "ISS a recolher:       %10.2f" iss
printfn "PIS a recolher:       %10.2f" pis
printfn "COFINS a recolher:    %10.2f" cofins
printfn "Total de tributos:    %10.2f" totalTributos
printfn "Receita líquida:      %10.2f" receitaLiquida
