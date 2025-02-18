using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public class TextFormatter
    {
        public static string espaçoDedicado(string name){
            string nameTrim = name.Trim();
            int espaçoDedicado = 20;
            List<char> arrayFinal = new List<char>();

            for(int i = 0; i < espaçoDedicado; i++){
                if(i < nameTrim.Length){
                    arrayFinal.Add(nameTrim[i]);
                } else {
                    arrayFinal.Add(' ');
                }
            }

            return new string(arrayFinal.ToArray());
        }

    }
}