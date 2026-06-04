// =============================================================================
// Módulo 7 — Discriminated Unions (a validação que viaja com o dado)
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
//   No Módulo 6, sobrou um problema: a Conta era uma string.
//   Qualquer coisa entrava — inclusive "receita" minúsculo, que o
//   F# aceitou sem reclamar e que SUMIU dos cálculos de receita.
//
//   No Sheets, vocês têm a Validação de Dados:
//
//      Dados → Validação de dados → Critério: Menu suspenso
//      Valores: Receita, Despesa, Transferência
//      → Aplicar
//
//   A célula passa a aceitar só os três valores. Bom — mas a
//   validação fica PRESA na célula. Se você copia o valor para
//   outra planilha ou carrega num script, a validação não viaja.
//
//   F# resolve com Discriminated Union: a validação VIAJA junto
//   com o dado, garantida pelo compilador.
// =============================================================================


// --- Definindo um Discriminated Union ----------------------------------------
//
// Lê-se: "Conta é Receita OU Despesa OU Transferencia. Só."

type Conta =
    | Receita
    | Despesa
    | Transferencia

// Não existe outro valor. "receita", "REC", "Receite" — nada disso
// compila. Só os três acima.


// --- Refazendo o record com o DU no lugar da string -------------------------

type Lancamento = {
    Data: System.DateTime
    Valor: float
    Descricao: string
    Conta: Conta          // ← era string, virou DU
}

// Construir: sem aspas. Receita, Despesa e Transferencia são VALORES
// do tipo Conta, não strings.

let lancamentosJaneiro : Lancamento list = [
    { Data = System.DateTime(2025, 1, 5);  Valor = 3500.0;  Descricao = "Aluguel";        Conta = Despesa }
    { Data = System.DateTime(2025, 1, 10); Valor = 10000.0; Descricao = "Serviços ABC";   Conta = Receita }
    { Data = System.DateTime(2025, 1, 15); Valor = 800.0;   Descricao = "Conta de luz";   Conta = Despesa }
    { Data = System.DateTime(2025, 1, 20); Valor = 7500.0;  Descricao = "Serviços XYZ";   Conta = Receita }
    { Data = System.DateTime(2025, 1, 25); Valor = 5000.0;  Descricao = "Transf. p/ poup."; Conta = Transferencia }
]


// --- match sobre DU ----------------------------------------------------------
//
// A função do Módulo 6 (que comparava string) vira um match exaustivo
// sobre os casos do DU. O compilador EXIGE tratar todos.

let ehReceita lancamento =
    match lancamento.Conta with
    | Receita        -> true
    | Despesa        -> false
    | Transferencia  -> false

let ehDespesa lancamento =
    match lancamento.Conta with
    | Receita        -> false
    | Despesa        -> true
    | Transferencia  -> false

let valorDe lancamento = lancamento.Valor


// --- Cálculos ----------------------------------------------------------------

let totalReceitas =
    lancamentosJaneiro
    |> List.filter ehReceita
    |> List.map valorDe
    |> List.sum

let totalDespesas =
    lancamentosJaneiro
    |> List.filter ehDespesa
    |> List.map valorDe
    |> List.sum

let saldo = totalReceitas - totalDespesas

printfn "Total de receitas:  R$ %.2f" totalReceitas
printfn "Total de despesas:  R$ %.2f" totalDespesas
printfn "Saldo do mês:       R$ %.2f" saldo
printfn ""
printfn "(Transferências não entram no saldo — são só remanejamento)"
printfn ""


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Tentar burlar o DU com uma string.
//
//   Descomente. Erro vermelho na hora — não compila:

//let lancamentoInvalido =
//    { Data = System.DateTime(2025, 1, 31); Valor = 100.0; Descricao = "Teste"; Conta = "Receita" }

//   "Receita" com aspas é uma string. Conta espera o VALOR do DU
//   Receita, sem aspas. Voltando ao Módulo 4: tipos não combinam.
//
// -----------------------------------------------------------------------------
//
// Experimento 2 — Forçar a exaustividade do match.
//
//   Descomente o bloco abaixo. A Ionide pinta de AMARELO (warning)
//   avisando que falta o caso `Transferencia`.

//let ehReceitaIncompleto lancamento =
//    match lancamento.Conta with
//    | Receita -> true
//    | Despesa -> false

//   No Sheets, "esquecer um caso" não tem aviso — só dá erro lá
//   na frente, quando alguém finalmente cair naquele caso.
//   Aqui, o compilador aponta antes de rodar.
//
// -----------------------------------------------------------------------------
//
// Experimento 3 — A maior virada: adicionar um caso novo ao DU.
//
//   Volte ao type Conta lá em cima e adicione | Investimento ao
//   final da lista. Salve. Rode.
//
//   A Ionide PINTA DE AMARELO todos os match que não trataram o
//   caso novo. É uma auditoria automática: ela te leva pelo
//   código nos lugares exatos onde a lógica precisa ser atualizada.
//
//   Nenhum SE aninhado no Sheets faz isso. É a principal razão
//   pela qual DUs valem o esforço.
//
//   Quando terminar, REMOVA o `| Investimento` para voltar ao
//   estado original.
//
// =============================================================================
// Nota — DUs com dados associados (curso avançado):
//
//   DUs também podem CARREGAR valor:
//
//      type Status =
//          | Aprovado
//          | Reprovado of motivo: string
//
//   `Aprovado` não leva nada. `Reprovado` leva uma string com o
//   motivo da reprovação. O match sobre essa DU desembrulha o
//   motivo no caso Reprovado. Fica para depois.
//
// =============================================================================
// A regra do módulo:
//   DU é a forma de declarar "este campo só pode ser uma destas
//   coisas, e o compilador garante". Quando precisar adicionar um
//   caso novo, o compilador te leva pelos lugares onde mexer.
//   É validação de dados que viaja com o dado.
// =============================================================================
