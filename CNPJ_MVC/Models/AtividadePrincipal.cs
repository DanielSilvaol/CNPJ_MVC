using System.ComponentModel.DataAnnotations;

namespace CNPJ_MVC.Models
{
    public class AtividadePrincipal
    {
        public int id { get; set; }
        public string code { get; set; }
        public string text { get; set; }
        public int Empresaid { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}