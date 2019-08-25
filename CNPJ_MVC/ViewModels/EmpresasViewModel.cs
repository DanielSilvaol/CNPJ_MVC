using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CNPJ_MVC.ViewModels
{
    public class EmpresasViewModel
    {
        public int id { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }
        [Display(Name = "Data situação")]
        public string data_situacao { get; set; }
    }
}