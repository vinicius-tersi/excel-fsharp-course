// =============================================================================
// Tarefa do Módulo 1 — Hora extra de Janeiro e Fevereiro
// =============================================================================
//
// Como rodar este arquivo:
//   1. Complete o código abaixo.
//   2. Aperte Ctrl+Shift+B.
//   3. Veja o resultado no painel inferior.
//
// =============================================================================
// O cenário:
//
//   A empresa tem constantes que valem para qualquer mês:
//     SalarioHora     = 25,00
//     AdicionalExtra  = 0,5    (50% sobre a hora normal)
//
//   Em Janeiro, o funcionário fez 160h normais e 12h extras.
//   Em Fevereiro,            152h normais e 24h extras.
//
//   Para cada mês:
//     ValorNormais   = SalarioHora * HorasNormais
//     ValorExtras    = SalarioHora * (1 + AdicionalExtra) * HorasExtras
//     SalarioTotal   = ValorNormais + ValorExtras
//
// =============================================================================
// Sua tarefa:
//
//   1. Defina SalarioHora e AdicionalExtra UMA vez no topo. As constantes
//      da empresa não devem ser redefinidas por mês.
//
//   2. Calcule SalarioTotal para Janeiro e para Fevereiro usando essas
//      constantes mais os dados específicos de cada mês.
//
//   3. Imprima os dois totais, claramente identificados, com `printfn`.
//
//   4. Bônus — Encontro deliberado com o compilador:
//      Em algum ponto do script, depois de definir SalarioHora, tente:
//
//          SalarioHora <- 30.0
//
//      Rode. Leia a mensagem de erro completa que o compilador devolve.
//      Cole a mensagem como comentário no fim do arquivo, e depois
//      remova a linha problemática para o script voltar a rodar.
//
// =============================================================================
// Dica: se travar, abra `modulo-01-imutabilidade/aula.fsx` — tem todos
// os padrões que você precisa.
// =============================================================================

// Comece aqui:
let salarioHora = 25.0
// continue...
