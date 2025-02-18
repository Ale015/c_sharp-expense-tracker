using ExpenseTracker.Services;
using ExpenseTracker.Models;
using System.Buffers;
using System.Security.AccessControl;
using System.Reflection;

var operationService = new OperationService();
bool operationStatus = true;
while (operationStatus){
    System.Console.WriteLine("");
    System.Console.WriteLine("-----------------------");
    Console.WriteLine("Expense Tracker: ");
    System.Console.WriteLine("-----------------------");

    System.Console.WriteLine("Escolha a Operação Desejada: ");
    System.Console.WriteLine("1 - Exibir todas as Despesas.");
    System.Console.WriteLine("2 - Adicionar Despesa.");
    System.Console.WriteLine("3 - Deletar Despesa.");
    System.Console.WriteLine("4 - Sair");

    string opcaoEscolhida = Console.ReadLine();
    opcaoEscolhida.Trim().ToLower();

    List<string> opcoesValidas = ["1", "2", "3", "4"];

    if(opcoesValidas.Contains(opcaoEscolhida)){
        if(opcaoEscolhida == "1"){
            while(true){
                System.Console.WriteLine("Gostaria de filtrar por mês?");
                System.Console.WriteLine("S / N");
                string resposta = Console.ReadLine();

                if(resposta.Trim().ToLower() == "s" || resposta.Trim().ToLower() == "sim"){
                    System.Console.WriteLine("Qual mês deseja filtrar?");
                    System.Console.WriteLine("(Informe o valor decimal do mês correspondente)");
                    string mes = Console.ReadLine();

                    if (int.TryParse(mes, out int intMonth))
                    {   

                        if(intMonth < 1 || intMonth > 12){
                            System.Console.WriteLine("Por favor informe um mês válido de 1 (Jan) a 12 (Dez).");
                            continue;
                        }

                        operationService.SummarizeDespesas(intMonth);
                        break;

                    } else{
                        System.Console.WriteLine("Informe um valor decimal válido por favor.");
                        continue;
                    }


                } else if (resposta.Trim().ToLower() == "n" || resposta.Trim().ToLower() == "nao"){
                    operationService.SummarizeDespesas();
                    break;
                } else {
                    System.Console.WriteLine("Por favor digite uma opção válida.");
                    continue;
                }
            }
        } else if (opcaoEscolhida == "2"){
             operationService.AdicionarDespesa();   
        } else if (opcaoEscolhida == "3"){
            operationService.DeletarDespesa();
        } else if (opcaoEscolhida == "4"){
            System.Console.WriteLine("Programa finalizado. ");
            operationStatus = false;
            break;
        } else {
            System.Console.WriteLine("Por favor selecione uma opção válida.");
        }
    } else {

    }
    

}
