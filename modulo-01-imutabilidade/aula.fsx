// =============================================================================
// Módulo 1 — `let` é para sempre (imutabilidade como garantia)
// =============================================================================
//
// Como rodar este arquivo:
//   1. Abra este arquivo no editor.
//   2. Aperte Ctrl+Shift+B.
//   3. O resultado aparece no painel inferior.
//
// =============================================================================
// O que aconteceu antes deste arquivo:
//
//   No quadro, o instrutor mostrou uma planilha de fechamento mensal de
//   tributos com 12 linhas (Jan a Dez), e simulou um "ajuste manual":
//   substituiu a fórmula da linha de Março por um número fixo.
//   A planilha aceitou em silêncio. Quando a alíquota do ISS mudou
//   depois, todos os meses recalcularam — menos Março. A linha mente
//   sem aviso.
//
//   Este arquivo é a mesma conta, em F#. Vamos ver o que acontece
//   quando o instrutor tenta a mesma sabotagem aqui.
// =============================================================================

// --- Constantes da empresa (definidas UMA vez, valem para todo o script) ---
let aliqISS = 0.05
let aliqPIS = 0.0065
let aliqCOFINS = 0.03
let aliqTotal = aliqISS + aliqPIS + aliqCOFINS

// --- Cálculo do mês de Março ---
let receitaMarco = 11_800.0
let tributosMarco = receitaMarco * aliqTotal
let liquidoMarco = receitaMarco - tributosMarco

printfn "=== Março ==="
printfn "Receita:    %10.2f" receitaMarco
printfn "Tributos:   %10.2f" tributosMarco
printfn "Líquido:    %10.2f" liquidoMarco


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Mudar um valor de entrada e rodar de novo.
//
//   Mude `aliqISS` na linha 28 de 0.05 para 0.06.
//   Rode com Ctrl+Shift+B.
//   Observe: o valor de `tributosMarco` mudou junto, sem você precisar
//   tocar em mais nada. Foi o `let` que recalculou.
//   Depois, volte para 0.05.
//
// -----------------------------------------------------------------------------
//
// Experimento 2 — Tentar a sabotagem que funcionou no Sheets.
//
//   Remova o // da linha abaixo e rode.

//tributosMarco <- 850.0

//   O compilador recusa. Leia a mensagem de erro: "This value is not
//   mutable". Em português: "este valor não é mutável".
//
//   No Sheets, sobrescrever uma fórmula com um número é silencioso.
//   Em F#, é IMPOSSÍVEL — a não ser que você diga explicitamente que
//   quer que aquele nome seja mutável. Não diremos.
//
//   Coloque o // de volta antes de seguir.
//
// -----------------------------------------------------------------------------
//
// Experimento 3 — "Mas e se eu PRECISO de um ajuste manual?"
//
//   Dê um nome próprio ao ajuste. Adicione abaixo:

//let tributosMarcoCorrigido = 850.0
//printfn "Tributos (ajustado): %10.2f" tributosMarcoCorrigido

//   Agora o script mostra os DOIS valores: o calculado e o ajustado.
//   Um auditor olhando o código vê os dois lado a lado. Nada some,
//   nada é silenciosamente sobrescrito. O ajuste tem nome, lugar
//   e justificativa (que você escreve em um comentário).
//
// =============================================================================
// A regra do módulo:
//   `let` LIGA um nome a um valor. Essa ligação não desfaz nunca.
//   Se você quer um valor diferente, cria um nome diferente.
// =============================================================================
