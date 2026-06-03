// =============================================================================
// Tarefa do Módulo 5 — Consulta em lote de CNPJs
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
//   Use a função `buscarRazaoSocial` (idêntica à da aula) para
//   consultar uma lista grande de CNPJs e gerar estatísticas.

let buscarRazaoSocial (cnpj: string) : string option =
    match cnpj with
    | "12.345.678/0001-99" -> Some "Empresa A LTDA"
    | "98.765.432/0001-11" -> Some "Empresa B LTDA"
    | "55.444.333/0001-22" -> Some "Empresa C LTDA"
    | "11.222.333/0001-44" -> Some "Empresa D LTDA"
    | "77.888.999/0001-55" -> Some "Empresa E LTDA"
    | _                    -> None

let cnpjsAConsultar =
    [ "12.345.678/0001-99"     // cadastrada
      "00.000.000/0001-00"     // não cadastrada
      "98.765.432/0001-11"     // cadastrada
      "11.111.111/0001-11"     // não cadastrada
      "55.444.333/0001-22"     // cadastrada
      "22.222.222/0001-22"     // não cadastrada
      "11.222.333/0001-44"     // cadastrada
      "77.888.999/0001-55" ]   // cadastrada

// =============================================================================
// Sua tarefa:
//
//   1. Use `List.map` para aplicar `buscarRazaoSocial` em cada CNPJ.
//      O resultado é uma lista de `string option`. Guarde em uma
//      variável chamada `resultados`.
//
//   2. Use `List.choose id` para extrair só as razões sociais que
//      foram encontradas. Imprima quantas foram (com List.length).
//
//   3. Use `List.filter` com a função `Option.isNone` (já existe em
//      F#) para descobrir quantos CNPJs NÃO foram encontrados.
//      Imprima o número.
//
//   4. Bônus — Listar os CNPJs não encontrados.
//
//      Dica: você precisa filtrar a lista ORIGINAL de CNPJs, não a
//      lista de Options. Crie uma função auxiliar:
//
//         let naoFoiEncontrado cnpj =
//             buscarRazaoSocial cnpj = None
//
//      E aplique com:  cnpjsAConsultar |> List.filter naoFoiEncontrado
//
//      Depois imprima a lista resultante.
//
// =============================================================================
// Dica geral: se travar, abra `modulo-05-option/aula.fsx` — ele tem
// os padrões de `List.choose id` e `match Option` que você precisa.
// =============================================================================

// Comece aqui:
let resultados = cnpjsAConsultar |> List.map buscarRazaoSocial
// continue...
