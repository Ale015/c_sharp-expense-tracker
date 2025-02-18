using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Despesa
    {   
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public string Name {get; set;}
        public decimal Value {get; set;}
    }
}