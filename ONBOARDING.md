# Primeiro acesso — como abrir seu ambiente

Este guia é só para a **primeira vez**. Ele te leva do zero até rodar o
Módulo 0. Depois disso, o dia a dia (salvar e entregar tarefas) está no
[README](README.md#como-salvar-e-entregar-sua-tarefa).

Você **não precisa instalar nada** no seu computador. Tudo roda no navegador.
Só precisa de uma conta no GitHub e do link do curso que o instrutor mandou.

---

## Passo a passo

### 1. Abra o repositório do curso

Clique no link que o instrutor compartilhou. Ele abre a página do curso no
GitHub. Se pedir login, entre com sua conta.

### 2. Abra o Codespace

1. No topo direito da página, clique no botão verde **`< > Code`**.
2. Na caixinha que abre, clique na aba **`Codespaces`**.
3. Clique em **`Create codespace on main`** (ou, se já tiver criado antes,
   clique no nome do Codespace que aparece na lista para reabri-lo).

Uma nova aba abre com o VS Code rodando dentro do navegador.

> 📌 **Crie sempre a partir da `main`.** Sua branch de trabalho (onde você
> guarda as tarefas) ainda não existe agora — você vai criá-la *dentro* do
> Codespace, mais tarde, seguindo o passo "criar sua branch" do
> [README](README.md#-uma-vez-só-antes-da-primeira-tarefa-criar-sua-branch).
> A partir do 2º dia, ao **reabrir** o Codespace você já volta na sua branch,
> de onde parou — não estranhe se não estiver mais na `main`.

### 3. Espere o ambiente montar ⏳

**Na primeira vez, isso leva de 1 a 3 minutos.** É normal — o ambiente de
F# está sendo preparado só para você. Você pode ver mensagens de
"Setting up your codespace" ou uma barra de progresso. Só aguarde.

> 💡 Da segunda vez em diante, reabrir o mesmo Codespace é **bem mais rápido**
> (uns 10–20 segundos). A demora é só na criação inicial.

Quando terminar, você vê o editor com a lista de pastas à esquerda
(`modulo-00-ambiente`, `modulo-01-...` e assim por diante).

### 4. Rode o Módulo 0

1. Na lista à esquerda, clique na pasta **`modulo-00-ambiente`**.
2. Clique no arquivo **`aula.fsx`** para abri-lo.
3. Aperte **`Ctrl+Shift+B`**.
4. Um painel abre embaixo. **A primeira execução demora uns 10–30 segundos**
   (o F# está "esquentando"). As próximas são quase instantâneas.
5. Quando aparecer a tabela de tributos com os valores calculados, **deu certo** —
   seu ambiente está funcionando. 🎉

---

## Deu algum problema?

- **"A tela ficou em branco / travou no carregamento"** — feche a aba e reabra
  o Codespace pela lista (passo 2). Se persistir, avise o instrutor.
- **"Apertei Ctrl+Shift+B e não aconteceu nada"** — confirme que o arquivo
  aberto é um `.fsx` e que ele está em foco (clique no texto dele antes).
  Espere: a primeira execução demora um pouco.
- **"Pediu para escolher uma tarefa de build"** — escolha
  **`Rodar script F# atual`**.
- **Qualquer outra coisa** — chame o instrutor. Não tem como você "quebrar"
  nada; no pior caso a gente apaga o Codespace e cria outro.

---

## E agora?

Seu ambiente está pronto. Antes da **primeira tarefa**, siga o passo
"criar sua branch" no
[README](README.md#-uma-vez-só-antes-da-primeira-tarefa-criar-sua-branch) —
é lá que fica seu trabalho salvo.
