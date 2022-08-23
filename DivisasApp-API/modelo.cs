using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modelo de la response de nuestra API
namespace modelo
{
    public class Query
    {
        public string from { get; set; }
        public string to { get; set; }
        public double amount { get; set; }
    }
    public class Info
    {
        public int timestamp { get; set; }
        public double rate { get; set; }
    }

    public class Root
    {
        public string @base { get; set; }
        public bool success { get; set; }
        public Query query { get; set; }
        public Info info { get; set; }
        public string date { get; set; }        
        public double result { get; set; }
    }
}