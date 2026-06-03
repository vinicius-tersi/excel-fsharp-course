// =============================================================================
// Módulo 2 — Funções são fórmulas com nome
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
//   1. SOMA, MÉDIA, SE, PROCV são FUNÇÕES. Têm nome, recebem entradas,
//      devolvem uma saída.
//
//   2. O Google Sheets te deixa criar as SUAS próprias funções. Quase
//      ninguém usa. Acabamos de aprender:
//
//      ----------------------------------------------------------------
//      Como criar uma Função Nomeada no Google Sheets:
//
//         a) Menu  Dados → Funções nomeadas
//         b) Adicionar nova função
//         c) Nome:                  TRIBUTAR
//         d) Descrição:             Calcula tributo dado valor e alíquota.
//         e) Marcadores:            valor, aliquota
//         f) Definição da fórmula:  =valor * aliquota
//         g) Próximo → Criar
//
//      Depois, em qualquer célula:  =TRIBUTAR(B6; 0,0865)
//      ----------------------------------------------------------------
//
//   3. Em F#, o mesmo gesto cabe em uma linha. É isso que vamos ver aqui.
//
// =============================================================================

// --- Constantes da empresa (Módulo 1) ---
let aliqISS = 0.05
let aliqPIS = 0.0065
let aliqCOFINS = 0.03
let aliqTotal = aliqISS + aliqPIS + aliqCOFINS

// --- Nossa primeira função: o equivalente em F# de TRIBUTAR ---
//
//   No Sheets:  TRIBUTAR(valor; aliquota) = valor * aliquota
//   Em F#:
let tributar valor aliquota = valor * aliquota

// --- Usar a função em vários meses, sem repetir a fórmula ---
let tributosJan = tributar 10_000.0 aliqTotal
let tributosFev = tributar 12_500.0 aliqTotal
let tributosMar = tributar 11_800.0 aliqTotal

printfn "=== Tributos por mês ==="
printfn "Janeiro:   %10.2f" tributosJan
printfn "Fevereiro: %10.2f" tributosFev
printfn "Março:     %10.2f" tributosMar
printfn ""


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 0 — No Google Sheets (NÃO em F#):
//
//   Abra a planilha de fechamento da aula. Crie uma função nomeada:
//
//      Nome:        LIQUIDO
//      Marcadores:  valor, aliqTotal
//      Fórmula:     =valor - valor * aliqTotal
//
//   Use em uma célula:  =LIQUIDO(B6; 0,0865)
//   Sinta quantos cliques foram necessários para uma fórmula tão curta.
//
// -----------------------------------------------------------------------------
//
// Experimento 1 — A mesma função LIQUIDO, em F#:
//
//   Descomente as linhas abaixo e rode.

//let calcularLiquido valor aliqTotal = valor - valor * aliqTotal
//
//let liquidoJan = calcularLiquido 10_000.0 aliqTotal
//let liquidoFev = calcularLiquido 12_500.0 aliqTotal
//let liquidoMar = calcularLiquido 11_800.0 aliqTotal
//
//printfn "=== Líquidos por mês ==="
//printfn "Janeiro:   %10.2f" liquidoJan
//printfn "Fevereiro: %10.2f" liquidoFev
//printfn "Março:     %10.2f" liquidoMar
//printfn ""

//   Compare: no Sheets foram 7 passos em um painel lateral. Aqui foi UMA
//   linha. As duas formas fazem a mesma coisa.
//
// -----------------------------------------------------------------------------
//
// Experimento 2 — Arredondar o resultado (jeito aninhado).
//
//   Descomente e rode.

//let arredondar (valor: float) = System.Math.Round(valor, 2)
//
//let liquidoMarAninhado = arredondar (calcularLiquido 11_800.0 aliqTotal)
//
//printfn "Líquido Março (aninhado): %10.2f" liquidoMarAninhado

//   Para ler `arredondar (calcularLiquido ...)`, você começa pelos
//   parênteses de DENTRO e vai abrindo. É a fórmula horrível do Sheets,
//   só que escrita.
//
//   (A anotação `(valor: float)` em `arredondar` é necessária aqui porque
//   o System.Math.Round aceita vários tipos de número, e o F# precisa
//   saber qual. Normalmente ele adivinha sozinho.)
//
// -----------------------------------------------------------------------------
//
// Experimento 3 — A mesma coisa, com pipe (|>).
//
//   Descomente e rode.

//let liquidoMarComPipe =
//    11_800.0
//    |> calcularLiquido <| aliqTotal   // (não use assim — veja abaixo)
//    |> arredondar
//
//printfn "Líquido Março (com pipe): %10.2f" liquidoMarComPipe

//   ⚠ ATENÇÃO: o experimento acima NÃO compila. É proposital.
//
//   O pipe (|>) joga o valor da esquerda como ÚLTIMO argumento da função
//   à direita. `calcularLiquido` espera dois argumentos. Quando a gente
//   escreve `11_800.0 |> calcularLiquido`, sobra um argumento faltando.
//
//   Para isso funcionar, vamos reescrever `calcularLiquido` de um jeito
//   que case com o pipe: a "coisa que está sendo transformada" (o valor)
//   vira o ÚLTIMO parâmetro, não o primeiro.
//
//   Apague o bloco do Experimento 3 acima e use este:

//let aplicarLiquido aliqTotal valor = valor - valor * aliqTotal
//
//let liquidoMarComPipeOK =
//    11_800.0
//    |> aplicarLiquido aliqTotal
//    |> arredondar
//
//printfn "Líquido Março (pipe OK): %10.2f" liquidoMarComPipeOK

//   Agora sim. Leia de cima para baixo:
//      pega 11.800,00,
//      aplica o cálculo do líquido com a alíquota total,
//      arredonda.
//
//   Mesma resposta do Experimento 2. Mas dá pra ler na ordem que pensa.
//
// =============================================================================
// A regra do módulo:
//   Função é uma fórmula com nome e parâmetros. Em F# cabe em uma linha.
//   Pipe (|>) encadeia funções na ordem em que você pensa, em vez de
//   te obrigar a aninhar parênteses de dentro para fora.
// =============================================================================
