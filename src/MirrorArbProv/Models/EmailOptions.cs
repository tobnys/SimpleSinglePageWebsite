using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MirrorArbProv.Models
{
    public class EmailOptions
    {
        public string Namn { get; set; }
        public string Epost { get; set; }
        public string Telefon { get; set; }
        public string Company { get; set; }
        public string Meddelande { get; set; }
    }
}
