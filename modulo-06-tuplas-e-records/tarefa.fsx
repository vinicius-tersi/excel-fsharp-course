// =============================================================================
// Tarefa do Módulo 6 — Razão de Janeiro
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
//   Lista completa de lançamentos de Janeiro de 2025.

type Lancamento = {
    Data: System.DateTime
    Valor: float
    Descricao: string
    Conta: string
}

let lancamentos : Lancamento list = [
    { Data = System.DateTime(2025, 1, 3);  Valor = 3500.0;  Descricao = "Aluguel";          Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 7);  Valor = 12000.0; Descricao = "Serviços A";       Conta = "Receita" }
    { Data = System.DateTime(2025, 1, 10); Valor = 800.0;   Descricao = "Conta de luz";     Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 12); Valor = 6500.0;  Descricao = "Serviços B";       Conta = "Receita" }
    { Data = System.DateTime(2025, 1, 15); Valor = 1500.0;  Descricao = "Telefone/Internet";Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 18); Valor = 9000.0;  Descricao = "Serviços C";       Conta = "Receita" }
    { Data = System.DateTime(2025, 1, 22); Valor = 2200.0;  Descricao = "Material esc.";    Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 25); Valor = 4500.0;  Descricao = "Serviços D";       Conta = "Receita" }
    { Data = System.DateTime(2025, 1, 28); Valor = 3000.0;  Descricao = "Salários auxs.";   Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 30); Valor = 11000.0; Descricao = "Serviços E";       Conta = "Receita" }
]

// =============================================================================
// Sua tarefa:
//
//   1. Calcule o TOTAL DE RECEITAS de Janeiro.
//   2. Calcule o TOTAL DE DESPESAS de Janeiro.
//   3. Calcule o SALDO do mês (receitas − despesas).
//      Imprima os três valores claramente identificados.
//
//   4. Liste todos os lançamentos com VALOR ACIMA DE R$ 5.000.
//      Para cada um, imprima:  "Descrição: R$ Valor"
//
//   5. Bônus — Correção contábil:
//      A "Conta de luz" deveria ter sido R$ 850, não R$ 800. Crie um
//      `contaLuzCorrigida` usando `with`, e imprima o original e o
//      corrigido lado a lado.
//      Lembre: NÃO altere o lançamento na lista. Crie um novo.
//
// =============================================================================
// Dica: se travar, abra `modulo-06-tuplas-e-records/aula.fsx` — tem
// os padrões de filter/map/sum em records e a sintaxe `with`.
// =============================================================================

// Comece aqui:
let ehReceita lancamento = lancamento.Conta = "Receita"
// continue...
