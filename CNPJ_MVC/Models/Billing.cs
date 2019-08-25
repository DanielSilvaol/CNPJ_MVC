using System.ComponentModel.DataAnnotations;

namespace CNPJ_MVC.Models
{
    public class Billing
    {
        [Key]
        public int id { get; set; }
        public bool free { get; set; }
        public bool database { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}