using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace crudApp.Models
{
    public class EtudiantInfo 
    {
        public int ID { set; get; }
        [Required]
        public String Nom { set; get; }
        [Required]
        public String Prenom { set; get; }
        [Required]
        public String Cin { set; get; }
        [Required]
        public String Adress{ set; get; }
      

    }
}
