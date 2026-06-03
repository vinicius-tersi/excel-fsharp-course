// =============================================================================
// Tarefa do Módulo 2 — Folha de hora extra, agora com função
// =============================================================================
//
// Como rodar este arquivo:
//   1. Complete o código abaixo.
//   2. Aperte Ctrl+Shift+B.
//   3. Veja o resultado no painel inferior.
//
// =============================================================================
// O cenário (mesmo do Módulo 1):
//
//   Constantes da empresa:
//     SalarioHora     = 25,00
//     AdicionalExtra  = 0,5    (50% sobre a hora normal)
//
//   Janeiro:    160h normais, 12h extras
//   Fevereiro:  152h normais, 24h extras
//
//   Para cada mês:
//     SalarioTotal = SalarioHora * HorasNormais
//                  + SalarioHora * (1 + AdicionalExtra) * HorasExtras
//
// =============================================================================
// Sua tarefa:
//
//   1. Defina SalarioHora e AdicionalExtra UMA vez no topo.
//
//   2. Crie uma função `salarioMes` que recebe `horasNormais` e
//      `horasExtras` e devolve o salário total do mês, usando as
//      constantes acima.
//
//   3. Calcule Janeiro e Fevereiro chamando `salarioMes` duas vezes.
//
//   4. Imprima os dois resultados, claramente identificados.
//
//   5. Defina uma função `arredondar` (igual à da aula) e use pipe para
//      imprimir o salário arredondado de cada mês.
//
//   6. Bônus: adicione um terceiro mês, Março, com 168h normais e 0h
//      extras. Quantas linhas você precisou alterar para incluí-lo?
//      Anote a resposta como comentário no final do arquivo.
//
// =============================================================================
// Dica: se travar, abra `modulo-02-funcoes/aula.fsx` — tem todos os
// padrões que você precisa.
// =============================================================================

// Comece aqui:
let salarioHora = 25.0
// continue...
