using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CNPJ_MVC.Models
{
    public class Extra
    {
        
        public int id { get; set; }


        public virtual Empresa Empresa { get; set; }
    }
}