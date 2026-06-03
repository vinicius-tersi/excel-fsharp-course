// =============================================================================
// Módulo 4 — Tipos e tratamento de erros
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
//   No Google Sheets, criamos uma Função Nomeada para o ISS:
//
//     =SE(E(aliquota >= 2%; aliquota <= 5%);
//         preco_do_servico * aliquota;
//         SE(TIPO(aliquota) = 1;
//            "ERRO: aliquota do ISS deve ser entre 2% e 5%";
//            "ERRO: aliquota precisa ser um numero de 2% a 5%"))
//
//   Funciona. Mas tem um problema sério:
//
//     =TRIBUTAR_ISS(1000; 0,03)   →  30           (número)
//     =TRIBUTAR_ISS(1000; 0,07)   →  "ERRO: ..."  (texto)
//
//   A função devolve UM ENTRE DOIS TIPOS DIFERENTES. Quem chamar e
//   esquecer de checar:
//
//     =TRIBUTAR_ISS(1000; 0,07) * 2   →  #VALOR!
//
//   O Sheets aceita escrever isso. Só vai gritar depois, quando rodar.
//   Pode demorar dias até alguém perceber.
//
//   F# resolve esse problema de RAIZ, em duas camadas:
//      1. TIPOS — o compilador sabe quem aceita o quê, antes de rodar.
//      2. RESULT — quando uma função pode falhar, ela DECLARA isso
//         no tipo de retorno. Quem usa É OBRIGADO a tratar.
// =============================================================================


// --- Camada 1: tipos ---------------------------------------------------------
//
// No Sheets, qualquer coisa pode chegar numa célula. Por isso a função
// precisava de SE(TIPO(aliquota) = 1; ...) para checar.
//
// Em F#, a função DECLARA o que aceita:

let aplicarISSsemValidacao (aliquota: float) (preco: float) =
    preco * aliquota

// Os "(aliquota: float)" e "(preco: float)" são CONTRATOS. Tentar:
//
//     aplicarISSsemValidacao "abc" 1000.0
//
// não compila. A Ionide pinta a linha de vermelho enquanto você
// digita. A checagem de TIPO desapareceu — virou trabalho do compilador.
//
// Mas... esta função aceita alíquota = 0.07 (que é ILEGAL pela LC 116):

let issIlegal = aplicarISSsemValidacao 0.07 1000.0
printfn "ISS calculado com alíquota ilegal: %.2f" issIlegal
printfn "(o cálculo é matematicamente correto, mas legalmente inválido)"
printfn ""

// O tipo float não cobre regras de negócio. Para isso, precisamos de
// validação de DOMÍNIO.


// --- Camada 2: Result --------------------------------------------------------
//
// Reescrevendo a função com validação de domínio, devolvendo um
// resultado que pode ser sucesso OU erro:

let aplicarISS (aliquota: float) (preco: float) =
    if aliquota >= 0.02 && aliquota <= 0.05 then
        Ok (preco * aliquota)
    else
        Error "alíquota deve estar entre 2% e 5% (LC 116/2003)"

// O tipo do retorno agora é Result<float, string>.
// Lê-se: "Ou Ok com um float, ou Error com uma string".
//
// A diferença está no TIPO. Quem chamar a função sabe, antes de rodar,
// que o resultado pode ser sucesso ou erro. Não dá pra esquecer.


// --- Como o consumidor usa: match --------------------------------------------
//
// match é um SE multifuncional. Cada `|` é um caso. Para Result, são
// dois casos: Ok e Error. O compilador OBRIGA a tratar os dois — se
// você esquecer um, ele avisa.

let resultadoValido = aplicarISS 0.03 1000.0

match resultadoValido with
| Ok valor       -> printfn "ISS a recolher: R$ %.2f" valor
| Error mensagem -> printfn "Não foi possível calcular: %s" mensagem

let resultadoInvalido = aplicarISS 0.07 1000.0

match resultadoInvalido with
| Ok valor       -> printfn "ISS a recolher: R$ %.2f" valor
| Error mensagem -> printfn "Não foi possível calcular: %s" mensagem

printfn ""


// =============================================================================
// EXPERIMENTOS PARA FAZER AO VIVO
// =============================================================================
//
// Experimento 1 — Quebrar o contrato de tipo.
//
//   Descomente a linha abaixo. Antes de rodar, olhe para a Ionide:
//   ela deve sublinhar de vermelho. Passe o mouse em cima da linha
//   sublinhada e leia o aviso do compilador.

//let teste1 = aplicarISS "três por cento" 1000.0

//   Esse é o tipo de erro que o Sheets só descobriria em runtime, e
//   que F# pega ANTES DE RODAR. Coloque o // de volta para seguir.
//
// -----------------------------------------------------------------------------
//
// Experimento 2 — Esquecer um caso do match.
//
//   Descomente o bloco abaixo. Antes de rodar, olhe para o WARNING
//   amarelo que a Ionide mostra: "Incomplete pattern matches".
//   Ele está te dizendo que você esqueceu o Error.

//match aplicarISS 0.07 1000.0 with
//| Ok valor -> printfn "ISS: %.2f" valor

//   O compilador adverte. No Sheets, isso nunca acontece — a
//   responsabilidade de checar é toda do programador, sem rede.
//   Coloque o // de volta.
//
// -----------------------------------------------------------------------------
//
// Experimento 3 — Tentar usar o Result direto como se fosse float.
//
//   Descomente a linha abaixo:

//let dobroDoISS = aplicarISS 0.03 1000.0 * 2.0

//   Erro de compilação: o tipo do retorno é Result<float, string>,
//   não float. Não dá pra multiplicar. É exatamente isso que protege
//   contra o `#VALOR!` que apareceu no Sheets quando alguém
//   multiplicou uma string por 2.
//
// =============================================================================
// A regra do módulo:
//   - Quando uma função declara um tipo, o compilador checa por você.
//   - Quando uma função pode falhar, ela devolve Result e quem usa
//     tem que tratar os dois lados — sucesso E erro. Sem exceção.
// =============================================================================
