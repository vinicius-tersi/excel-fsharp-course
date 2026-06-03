// =============================================================================
// Tarefa do Módulo 3 — Receitas mensais de 2025
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
//   Esta é a lista de receitas mensais que a empresa recebeu em 2025:

let receitas2025 =
    [ 10_000.0; 12_500.0; 11_800.0; 9_500.0; 13_200.0; 14_100.0
      11_000.0; 10_800.0; 12_300.0; 13_900.0; 15_200.0; 16_500.0 ]

let aliqTotal = 0.0865   // ISS + PIS + COFINS (do Módulo 1)

// =============================================================================
// Sua tarefa:
//
//   1. Crie a função `calcularTributo` (recebe uma receita, devolve o
//      tributo correspondente).
//
//   2. Use List.map para gerar a lista de tributos de cada mês.
//
//   3. Crie a função `calcularLiquido` (recebe uma receita, devolve a
//      receita menos o tributo).
//
//   4. Use List.map para gerar a lista de líquidos de cada mês.
//
//   5. Use List.sum para imprimir os totais anuais de:
//        - receita bruta
//        - tributos
//        - líquido
//
//   6. Use List.filter para listar (e contar) os meses com receita
//      acima de R$ 12.000. Imprima o número de meses.
//
//   7. Bônus: descubra a receita MÉDIA do ano.
//      Dica: existe uma função chamada `List.average`.
//
// =============================================================================
// Dica: se travar, abra `modulo-03-listas/aula.fsx` — tem todos os
// padrões que você precisa.
// =============================================================================

// Comece aqui:
let calcularTributo receita = receita * aliqTotal
// continue...
