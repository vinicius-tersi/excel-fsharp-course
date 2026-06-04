// =============================================================================
// Tarefa do Módulo 8 — Pipeline de validação de CNPJs
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
//   A equipe te mandou esta lista de CNPJs para conferir antes de
//   emitir cobranças:

let cnpjsInformados =
    [ "12.345.678/0001-99"
      ""
      "abc"
      "98.765.432/0001-11"
      "00.000.000/0001-00"
      "55.444.333/0001-22" ]

// E você tem a função `buscarRazaoSocial` igual à do Módulo 5:

let buscarRazaoSocial (cnpj: string) : string option =
    match cnpj with
    | "12.345.678/0001-99" -> Some "Empresa A LTDA"
    | "98.765.432/0001-11" -> Some "Empresa B LTDA"
    | "55.444.333/0001-22" -> Some "Empresa C LTDA"
    | _                    -> None

// =============================================================================
// Sua tarefa:
//
//   Antes de buscar o cadastro, cada CNPJ precisa passar por TRÊS
//   validações. Cada uma deve devolver Result<string, string>:
//
//     1. `validarNaoVazio`     — recusa string vazia.
//     2. `validarFormato`      — recusa quem não tem 18 caracteres
//                                (formato esperado XX.XXX.XXX/XXXX-XX).
//                                Dica: para o comprimento, use s.Length.
//     3. `validarCadastrado`   — chama buscarRazaoSocial. Se devolveu
//                                Some razao, retorna Ok razao. Se
//                                devolveu None, retorna Error.
//                                Atenção: o tipo de retorno desta
//                                etapa é Result<string, string> onde
//                                a string Ok é a RAZÃO SOCIAL, não
//                                o CNPJ.
//
//   Junte tudo em uma função `validar` usando |> e Result.bind.
//
//   Aplique com List.map à lista de CNPJs informados.
//
//   Use List.choose com funções extratoras (como no aula.fsx) para
//   separar Oks de Errors. Imprima o relatório:
//
//     - Quantos CNPJs passaram (e a razão social de cada um).
//     - Quantos foram rejeitados (e o motivo de cada um).
//
// =============================================================================
// Bônus — Lista negra:
//
//   Acrescente uma QUARTA validação no pipeline, antes da consulta
//   de cadastro: rejeitar CNPJs que estejam em uma lista de suspensos.

//let suspensos = [ "12.345.678/0001-99" ]
//
//let validarNaoSuspenso (cnpj: string) : Result<string, string> =
//    if List.contains cnpj suspensos then
//        Error (sprintf "%s está suspenso" cnpj)
//    else
//        Ok cnpj

//   Encaixe essa validação ANTES de `validarCadastrado` no pipeline.
//   Rode de novo e veja o que mudou no relatório.
//
// =============================================================================
// Dica: se travar, abra `modulo-08-pipelines/aula.fsx` — o pipeline
// de alíquotas tem exatamente a mesma estrutura.
// =============================================================================

// Comece aqui:
let validarNaoVazio (s: string) : Result<string, string> =
    if s = "" then Error "CNPJ em branco"
    else Ok s
// continue...
