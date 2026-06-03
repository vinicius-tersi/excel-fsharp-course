// =============================================================================
// Tarefa do Módulo 4 — Validar as três alíquotas do regime cumulativo
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
//   Cada tributo tem suas próprias regras:
//
//     ISS     — entre 2% e 5%        (LC 116/2003)
//     PIS     — exatamente 0,65%     (regime cumulativo)
//     COFINS  — exatamente 3%        (regime cumulativo)
//
//   No Módulo 1 tratamos as três como constantes fixas. Agora vamos
//   tratá-las como ENTRADAS validadas: a função aceita a alíquota
//   como parâmetro, verifica se está dentro da regra, e devolve
//   Result<float, string>.
//
// =============================================================================
// Sua tarefa:
//
//   1. Crie três funções, cada uma devolvendo Result<float, string>:
//
//        aplicarISS    (aliquota: float) (preco: float)
//        aplicarPIS    (aliquota: float) (preco: float)
//        aplicarCOFINS (aliquota: float) (preco: float)
//
//      Cada uma valida a alíquota segundo a regra correspondente.
//      Para PIS e COFINS, "exatamente" significa igual ao valor (use =).
//
//   2. Para uma receita de R$ 10.000,00 e alíquotas VÁLIDAS
//      (3% para ISS, 0,65% para PIS, 3% para COFINS):
//      chame as três funções, trate cada Result com match, e imprima.
//
//   3. Repita o exercício com UMA alíquota INVÁLIDA por vez
//      (ISS = 7%, PIS = 1%, COFINS = 4%). Você deve ver a mensagem
//      de erro de cada uma aparecer.
//
//   4. Bônus — TESTE OS LIMITES.
//      Para o ISS, teste as alíquotas exatas 2% e 5%. Ambas DEVEM
//      ser aceitas (a lei diz "entre 2% e 5%", inclusive). Se a sua
//      função estiver rejeitando alguma delas, conserte.
//      Em programação chamamos isso de "teste de borda" — verificar
//      o que acontece nos limites exatos da regra.
//
// =============================================================================
// Dica: se travar, abra `modulo-04-tipos-e-erros/aula.fsx` — a função
// aplicarISS lá já está pronta e serve de modelo para PIS e COFINS.
// =============================================================================

let receita = 10_000.0

// Comece aqui:
let aplicarISS (aliquota: float) (preco: float) =
    if aliquota >= 0.02 && aliquota <= 0.05 then
        Ok (preco * aliquota)
    else
        Error "alíquota deve estar entre 2% e 5% (LC 116/2003)"

// continue...
