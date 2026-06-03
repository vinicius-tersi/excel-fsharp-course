# Curso de F# para Contadores

Curso interno de F# para contadores da equipe, a partir da experiência que já têm com Google Sheets.

## Como abrir e usar

1. Abrir o link do Codespace que o instrutor compartilhar.
2. Esperar o VS Code carregar no browser (1–3 min na primeira vez — o ambiente está sendo montado).
3. No painel esquerdo, abrir a pasta do módulo da aula (ex.: `modulo-00-ambiente/`).
4. Abrir o arquivo `aula.fsx`.
5. Apertar **Ctrl+Shift+B** para rodar.
6. O resultado aparece no painel inferior.

Não é preciso instalar nada, nem mexer no terminal.

## Estrutura

```
modulo-00-ambiente/   A planilha que você já usa é programação
modulo-01-...         (em construção)
```

Cada módulo tem dois arquivos:

- `aula.fsx` — o que é apresentado em aula.
- `tarefa.fsx` — o exercício para fazer entre encontros.

## Como salvar e entregar sua tarefa

Cada aluno tem uma **branch** própria (uma "via paralela" do projeto). É lá que você guarda seu trabalho, sem mexer no que o instrutor compartilha. Tudo isso pelos botões do VS Code — sem terminal.

### 🔧 Uma vez só, antes da primeira tarefa: criar sua branch

1. No **canto inferior esquerdo** da tela, você vê a palavra **`main`** com um ícone de bifurcação à esquerda dela. Clique nesse `main`.
2. Abre uma caixinha no topo da tela. Clique em **"+ Create new branch..."** (Criar nova branch).
3. Digite o nome da sua branch no formato **`tarefa-seunome`** (tudo minúsculo, sem espaços, sem acento). Exemplo: `tarefa-joana`.
4. Aperte **Enter**.
5. Confira: o canto inferior esquerdo agora mostra `tarefa-seunome` no lugar de `main`. Pronto. Você nunca mais precisa fazer esse passo.

### 💾 A cada tarefa: salvar seu trabalho na sua branch

Depois de editar `tarefa.fsx` e rodar até dar o resultado esperado:

1. **Salve o arquivo** com **Ctrl+S**.

2. Na **barra esquerda da tela**, clique no ícone do **Source Control** — é o terceiro de cima para baixo, parece uma bifurcação com três bolinhas. (Atalho: **Ctrl+Shift+G**.)

3. Abre um painel à esquerda mostrando os arquivos que você mudou. Vai aparecer pelo menos `tarefa.fsx` na lista, com um **M** azul ao lado (de "Modified").

4. Passe o mouse em cima do nome do arquivo. Aparece um botão **`+`** à direita. Clique nele. O arquivo sobe para a seção **"Staged Changes"** (em verde, com um **A** ou **M**). Isso significa "vou incluir esse arquivo no meu próximo salvamento".

5. No **campo de texto** no topo do painel ("Message"), escreva uma frase curta descrevendo o que você fez. Exemplo: `Tarefa módulo 2 — hora extra com função`.

6. Clique no botão **`✓ Commit`** logo abaixo do campo de texto. O arquivo some da lista — significa que ficou registrado.

7. Agora aparece um botão azul **"Sync Changes"** (ou, na primeira vez, **"Publish Branch"**). Clique nele. Pode demorar 2–10 s.

8. Pronto. Seu trabalho está salvo na sua branch, no GitHub. Pode fechar o Codespace tranquilo — quando voltar, está tudo lá.

### 👀 Como o instrutor vê o seu trabalho

Ele abre o repositório no GitHub, clica em **`main ▾`** no topo, e escolhe sua branch (`tarefa-joana`, etc.). Vê seu `tarefa.fsx` como você deixou.

### ⚠️ Se algo deu errado

- **"Esqueci de criar a branch e mexi tudo na `main`"** — chama o instrutor antes de fazer mais qualquer coisa. Tem conserto, mas é melhor não improvisar.
- **"Salvei errado, quero recomeçar essa tarefa"** — abra o arquivo `aula.fsx` ao lado e copie o que você precisa. Não tem como "desfazer" o commit sozinho — pede ajuda.
- **"O botão Sync Changes pediu login"** — só clicar em **"Sign in with browser"** e autorizar. Acontece uma vez por Codespace.

## Por que Ctrl+Shift+B (e não F5)

F5 é o atalho de depuração do VS Code e não permite ser reconfigurado por projeto. Ctrl+Shift+B roda a tarefa de build padrão — no caso, executa o `.fsx` aberto via `dotnet fsi`. Funciona em qualquer máquina e dentro do Codespace, sem ajustes.

## Para o instrutor

- Ambiente: devcontainer com .NET 10 SDK + extensão Ionide pré-instalada (`.devcontainer/devcontainer.json`).
- Atalho de execução: definido como tarefa padrão de build em `.vscode/tasks.json`.
- Toda mudança aqui só vale no Codespace após `git push` e reabertura/rebuild do container.
