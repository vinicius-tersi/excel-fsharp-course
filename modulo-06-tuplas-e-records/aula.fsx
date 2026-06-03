// =============================================================================
// Módulo 6 — Tuplas e records (dados com múltiplos campos)
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
//   Duas planilhas:
//     A) sem cabeçalho — só as linhas
//        15/01/2025   3500,00   Aluguel       Despesa
//        20/01/2025  10000,00   Serviços ABC  Receita
//
//     B) com cabeçalho
//        Data        Valor      Descrição     Conta
//        15/01/2025   3500,00   Aluguel       Despesa
//        20/01/2025  10000,00   Serviços ABC  Receita
//
//   B é trivialmente melhor. F# também tem duas formas de agrupar
//   dados de uma linha: tupla (sem cabeçalho) e record (com cabeçalho).
//   Vamos ver lado a lado e decidir.
// =============================================================================


// --- Tupla: linha sem cabeçalho ----------------------------------------------
//
// Parênteses e vírgulas amarram vários valores num só.

let lancamentoComoTupla =
    (System.DateTime(2025, 1, 15), 3500.0, "Aluguel", "Despesa")

// O que é 3500.0? E "Aluguel"? Você precisa LEMBRAR a ordem.
// Para acessar, destruturação posicional:

let (dataT, valorT, descricaoT, contaT) = lancamentoComoTupla
printfn "[tupla] %s — R$ %.2f" descricaoT valorT
printfn ""

// Se um dia precisar de mais um campo (NF-e, por exemplo), todo
// lugar que usa essa tupla precisa mudar. Frágil.


// --- Record: linha COM cabeçalho ---------------------------------------------
//
// `type` define o "cabeçalho" do registro. Cada campo tem nome e tipo.

type Lancamento = {
    Data: System.DateTime
    Valor: float
    Descricao: string
    Conta: string
}

// Construir um lançamento — campos com nome, na ordem que você quiser:

let lancamentoComoRecord = {
    Data = System.DateTime(2025, 1, 15)
    Valor = 3500.0
    Descricao = "Aluguel"
    Conta = "Despesa"
}

// Acessar por nome:

printfn "[record] %s — R$ %.2f (%s)"
    lancamentoComoRecord.Descricao
    lancamentoComoRecord.Valor
    lancamentoComoRecord.Conta
printfn ""

// Sem ambiguidade. Auto-documentado. Imune à ordem.


// --- Records também são imutáveis (volta o Módulo 1) -------------------------
//
// Para "corrigir" um campo, NÃO se sobrescreve. Cria-se um novo
// record com a sintaxe `with`:

let lancamentoOriginal = {
    Data = System.DateTime(2025, 1, 25)
    Valor = 800.0
    Descricao = "Conta de luz"
    Conta = "Despesa"
}

let lancamentoCorrigido = { lancamentoOriginal with Valor = 850.0 }

printfn "Original:  R$ %.2f — %s" lancamentoOriginal.Valor lancamentoOriginal.Descricao
printfn "Corrigido: R$ %.2f — %s" lancamentoCorrigido.Valor lancamentoCorrigido.Descricao
printfn ""

// Os DOIS lançamentos continuam existindo. O original fica para
// auditoria. O corrigido segue para os cálculos. Nada some.


// --- Records em listas: a vida real do contador ------------------------------

let lancamentosJaneiro : Lancamento list = [
    { Data = System.DateTime(2025, 1, 5);  Valor = 3500.0;  Descricao = "Aluguel";        Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 10); Valor = 10000.0; Descricao = "Serviços ABC";   Conta = "Receita" }
    { Data = System.DateTime(2025, 1, 15); Valor = 800.0;   Descricao = "Conta de luz";   Conta = "Despesa" }
    { Data = System.DateTime(2025, 1, 20); Valor = 7500.0;  Descricao = "Serviços XYZ";   Conta = "Receita" }
    { Data = System.DateTime(2025, 1, 28); Valor = 1200.0;  Descricao = "Material esc.";  Conta = "Despesa" }
]

// Como vimos no Módulo 3: filter, map, sum, com funções nomeadas.

let ehReceita lancamento = lancamento.Conta = "Receita"
let valorDe lancamento = lancamento.Valor

let totalReceitas =
    lancamentosJaneiro
    |> List.filter ehReceita
    |> List.map valorDe
    |> List.sum

printfn "Total de receitas de Janeiro: R$ %.2f" totalReceitas
printfn ""


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Tentar mutação direta (proibida pelo Módulo 1).
//
//   Descomente. Erro de compilação:

//lancamentoOriginal.Valor <- 850.0

//   Records são imutáveis por padrão. Para "alterar", use `with`.
//
// -----------------------------------------------------------------------------
//
// Experimento 2 — Total de despesas.
//
//   Espelho do total de receitas. Defina a função que reconhece
//   despesa e some os valores. Descomente:

//let ehDespesa lancamento = lancamento.Conta = "Despesa"
//
//let totalDespesas =
//    lancamentosJaneiro
//    |> List.filter ehDespesa
//    |> List.map valorDe
//    |> List.sum
//
//printfn "Total de despesas de Janeiro: R$ %.2f" totalDespesas

// -----------------------------------------------------------------------------
//
// Experimento 3 — Provocação para o Módulo 7.
//
//   Adicione esta linha à lista de lançamentos e rode. O que aconteceu?

//{ Data = System.DateTime(2025, 1, 30); Valor = 500.0; Descricao = "Lanche"; Conta = "receita" }

//   O F# aceitou sem reclamar. "receita" (minúsculo) virou uma conta
//   nova, diferente de "Receita". O cálculo das receitas vai IGNORAR
//   essa linha. Erro silencioso — exatamente o tipo de problema
//   que os tipos do Módulo 4 nos prometeram resolver.
//
//   Por que escapou? Porque `Conta` é uma STRING. Qualquer string
//   é válida. No próximo módulo (Discriminated Unions) vamos
//   tornar IMPOSSÍVEL escrever uma conta que não exista.
//
// =============================================================================
// A regra do módulo:
//   Tupla é linha sem cabeçalho — frágil, evite. Record é linha
//   com cabeçalho — auto-documentado, imutável, "altera-se" criando
//   um novo com `with`. É a forma normal de representar dados
//   estruturados em F#.
// =============================================================================
