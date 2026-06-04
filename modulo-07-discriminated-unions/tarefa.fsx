// =============================================================================
// Tarefa do Módulo 7 — Razão de Janeiro com DU
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
//   É o mesmo Janeiro do Módulo 6, mas agora a Conta é um DU em
//   vez de uma string. E agora você precisa diferenciar:
//
//     - Receita        (dinheiro entrou de cliente)
//     - Despesa        (dinheiro saiu para fornecedor)
//     - Transferencia  (dinheiro mudou de conta da própria empresa)
//
//   Transferências NÃO entram no saldo do mês — são só remanejamento
//   interno.
//
// =============================================================================
// Sua tarefa:
//
//   1. Defina `type Conta = Receita | Despesa | Transferencia`.
//
//   2. Defina `type Lancamento` com Data, Valor, Descricao e Conta
//      (usando o DU).
//
//   3. Reconstrua a lista de Janeiro com os mesmos lançamentos do
//      Módulo 6, agora usando os valores do DU (Receita, Despesa)
//      no lugar das strings.
//
//   4. Adicione DUAS transferências novas:
//        - 07/01: R$ 5.000,00 — "Transf. p/ poupança"
//        - 24/01: R$ 2.000,00 — "Transf. p/ aplicação"
//
//   5. Calcule e imprima:
//        - Total de Receitas
//        - Total de Despesas
//        - Total de Transferências
//        - Saldo do mês (= Receitas − Despesas; transferências NÃO entram)
//
//   6. Bônus — A AUDITORIA AUTOMÁTICA DO COMPILADOR:
//
//      Volte ao type Conta e adicione um quarto caso:
//
//          | Investimento
//
//      Antes de adicionar QUALQUER lançamento desse tipo na lista,
//      rode o script com Ctrl+Shift+B. Olhe para a Ionide: ela
//      vai pintar de amarelo os match que ficaram incompletos
//      (esqueceram de tratar Investimento).
//
//      Vá em cada um desses match e adicione o caso Investimento.
//      Decida com base no enunciado: investimento entra como
//      receita? Como despesa? Como nenhum dos dois (igual à
//      transferência)?
//
//      Anote a sua decisão em comentário no final do arquivo.
//
//      Esse é o argumento de venda do DU: a refatoração é guiada
//      pelo compilador. Você não tem como esquecer um caso.
//
// =============================================================================
// Dica: se travar, abra `modulo-07-discriminated-unions/aula.fsx` —
// tem todos os padrões de DU, match exaustivo e refatoração de
// função de string para DU.
// =============================================================================

// Comece aqui:
type Conta =
    | Receita
    | Despesa
    | Transferencia
// continue...
