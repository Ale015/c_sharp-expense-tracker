using System;
using System.Text.Json;
using ExpenseTracker.Models;


namespace ExpenseTracker.Services {
    public class OperationService {
        private const string FilePath = "../bancoDeDespesas.json";


        public List<Despesa> CarregarDespesas(){
           
            if(!File.Exists(FilePath)){
                return new List<Despesa>();
            }
           
           
            var jsonTxt = File.ReadAllText(FilePath);

            if(string.IsNullOrWhiteSpace(jsonTxt)){
                return new List<Despesa>();
            }

            var listaDesserializada = JsonSerializer.Deserialize<List<Despesa>>(jsonTxt) ?? new List<Despesa>();


            return listaDesserializada;
        }

        public List<Despesa> SalvarDespesas(List<Despesa> listaDespesas){
            var jsonSerialized = JsonSerializer.Serialize<List<Despesa>>(listaDespesas);
            File.WriteAllText(FilePath, jsonSerialized);
            return listaDespesas;
        }



        public void AdicionarDespesa() {

            System.Console.WriteLine("Informe o nome da Despesa: ");
            string nome = Console.ReadLine();

            System.Console.WriteLine("Informe o valor da despesa: ");
            string valorInput = Console.ReadLine();


            if(decimal.TryParse(valorInput, out decimal valorDecimal)){

                List<Despesa> listaDespesas = CarregarDespesas();

                int novoId = listaDespesas.Any() ? listaDespesas.Max(d => d.Id) + 1 : 1; 

                Despesa novaDespesa = new Despesa {
                    Id = novoId,
                    Name = nome,
                    Value = valorDecimal,
                    Date = DateTime.Now
                };
                


                listaDespesas.Add(novaDespesa);

                SalvarDespesas(listaDespesas);

                System.Console.WriteLine("Despesa adicionada com sucesso! ");
                System.Console.WriteLine("");
                SummarizeDespesas();


            }   else {
                Console.WriteLine("Valor inválido. Tente novamente.");
            }
           
    

        }

        public void DeletarDespesa(){
            SummarizeDespesas();

            bool loopDelete = true;
            while(loopDelete){

                SummarizeDespesas();
                System.Console.WriteLine("Para sair, digite 'exit'... ");
                System.Console.WriteLine("Por favor informe o Id do item a ser excluído: ");
                string decision = Console.ReadLine();

                if(decision.Trim().ToLower() == "exit"){
                    System.Console.WriteLine("Cancelando operação.");
                    break;
                }
                int intDelete; 
                bool sucesso = int.TryParse(decision, out intDelete);

                if(sucesso){

                    List<Despesa> listaDespesas = CarregarDespesas();
                    Despesa despesaToDelete = listaDespesas.FirstOrDefault(d => d.Id == intDelete);

                    if(despesaToDelete != null){
                        listaDespesas.Remove(despesaToDelete);
                        
                        SalvarDespesas(listaDespesas);

                        Console.WriteLine("Despesa deletada com sucesso!");
                        SummarizeDespesas();
                        break;
                    } else {
                        Console.WriteLine("Despesa não encontrada. Tente novamente.");
                    }

                } else {
                    System.Console.WriteLine("Por favor informe um valor válido.");
                    continue;
                }

            }



        }

         public void SummarizeDespesas(int month = 0){
            var listaCarregada = CarregarDespesas();
            List<Despesa> listaFiltrada = new List<Despesa>();


            if (month != 0){
                foreach(Despesa despesa in listaCarregada){
                    if(despesa.Date.Month == month){
                        listaFiltrada.Add(despesa);
                    }
                }

            } else {
                listaFiltrada = listaCarregada;
            }

            if(listaFiltrada.Count <= 0){
                Console.WriteLine("Nenhuma tarefa cadastrada.");
            }
            

            decimal total = 0;

            System.Console.WriteLine("");
            Console.WriteLine("# ID   Date          Name                         Amount");
            
            foreach(Despesa despesa in listaFiltrada){
                string nameSpaced = TextFormatter.espaçoDedicado(despesa.Name);
                Console.WriteLine($"# {despesa.Id}    {despesa.Date:dd/MM/yyyy}    {nameSpaced}         {despesa.Value:F2}");
            
                total += despesa.Value;
            
            }      
            System.Console.WriteLine("------------------------------");
            System.Console.WriteLine($"Total de despesas: R$ {total}");
            System.Console.WriteLine("------------------------------");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            

        }




    }

}