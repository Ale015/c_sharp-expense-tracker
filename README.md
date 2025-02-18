# Expense Tracker em .NET (C#)

Este é um projeto de um rastreador de despesas desenvolvido em .NET (C#) no terminal, que salva os dados em um arquivo JSON externo.
A ideia foi seguir uma arquitetura simples inspirada em modelos MVC mas sem utilização de banco de Dados para treinar apenas POO com arquivos JSON.

---  
## Funcionalidades Implementadas
- **CarregarDespesas**: Lê o arquivo JSON e carrega as despesas provenientes do arquivo.
- **SalvarDespesas**: Salva a lista de despesas no arquivo JSON.
- **AdicionarDespesa**: Permite adicionar uma nova despesa.
- **DeletarDespesa**: Exclui uma despesa pelo ID.
- **SummarizeDespesas**: Exibe o resumo das despesas, com opção de filtrar por mês.

---

## Como Executar o Projeto
1. Clone o repositório.
2. Navegue até a pasta do projeto.
3. Execute o programa pelo terminal usando o .NET CLI:
```
dotnet run

```

---

## Detalhes Técnicos

- As despesas são armazenadas no arquivo bancoDeDespesas.json.
- O programa oferece um menu interativo no terminal.

- Cada despesa inclui:
- - **Id**: Identificador único da despesa.
- - **Name**: Nome da despesa.
- - **Value**: Valor da despesa formatado com duas casas decimais.
- - **Date**: Data de registro.