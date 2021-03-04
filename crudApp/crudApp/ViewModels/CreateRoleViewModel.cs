using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace crudApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public String RoleName { get; set; }


    }
}
