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

## Por que Ctrl+Shift+B (e não F5)

F5 é o atalho de depuração do VS Code e não permite ser reconfigurado por projeto. Ctrl+Shift+B roda a tarefa de build padrão — no caso, executa o `.fsx` aberto via `dotnet fsi`. Funciona em qualquer máquina e dentro do Codespace, sem ajustes.

## Para o instrutor

- Ambiente: devcontainer com .NET 10 SDK + extensão Ionide pré-instalada (`.devcontainer/devcontainer.json`).
- Atalho de execução: definido como tarefa padrão de build em `.vscode/tasks.json`.
- Toda mudança aqui só vale no Codespace após `git push` e reabertura/rebuild do container.
