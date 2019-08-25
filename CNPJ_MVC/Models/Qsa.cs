﻿using System.ComponentModel.DataAnnotations;

namespace CNPJ_MVC.Models
{
    public class Qsa
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string qual { get; set; }
        public string pais_origem { get; set; }
        public string nome_rep_legal { get; set; }
        public string qual_rep_legal { get; set; }
        public int Empresaid { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}