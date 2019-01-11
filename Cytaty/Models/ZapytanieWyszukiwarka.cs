using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//model do obslugi searcha, przekazuje tylko string do formularza. mozna rozbudowac ewentualnie
namespace Cytaty.Models
{
    public class ZapytanieWyszukiwarka
    {
        public string zapytanie { get; set; }
        
    }
}