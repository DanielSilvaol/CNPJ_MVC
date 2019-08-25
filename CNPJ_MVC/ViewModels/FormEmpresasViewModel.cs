using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CNPJ_MVC.Models;

namespace CNPJ_MVC.ViewModels
{
    public class FormEmpresasViewModel
    {
        public int id { get; set; }
        [Display(Name = "Data Situação:")]
        public string data_situacao { get; set; }

        [Display(Name = "Atividade Principal:")]
        public List<AtividadePrincipal> atividade_principal { get; set; }

        [Display(Name = "Atividades Segundarias:")]
        public List<AtividadesSecundarias> atividades_secundarias { get; set; }

        [Display(Name = "Líder:")]
        public List<Qsa> qsa { get; set; }

        [Display(Name = "Complemento:")]
        public string complemento { get; set; }

        [Display(Name = "Nome:")]
        public string nome { get; set; }

        [Display(Name = "UF:")]
        public string uf { get; set; }

        [Display(Name = "Telefone:")]
        public string telefone { get; set; }

        [Display(Name = "E-mail:")]
        public string email { get; set; }

        [Display(Name = "Situação:")]
        public string situacao { get; set; }

        [Display(Name = "Bairro:")]
        public string bairro { get; set; }

        [Display(Name = "Logradouro:")]
        public string logradouro { get; set; }

        [Display(Name = "Número:")]
        public string numero { get; set; }

        [Display(Name = "Cep:")]
        public string cep { get; set; }

        [Display(Name = "Município:")]
        public string municipio { get; set; }

        [Display(Name = "Porte:")]
        public string porte { get; set; }

        [Display(Name = "Abertura:")]
        public string abertura { get; set; }

        [Display(Name = "Natureza Jurídica:")]
        public string natureza_juridica { get; set; }

        [Display(Name = "CNPJ:")]
        public string cnpj { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Última Atualização:")]
        public DateTime ultima_atualizacao { get; set; }

        [Display(Name = "Tipo:")]
        public string tipo { get; set; }

        [Display(Name = "Nome Fantasia:")]
        public string fantasia { get; set; }

        [Display(Name = "Ente Federativo Responsável:")]
        public string efr { get; set; }

        [Display(Name = "Motivo Situação:")]
        public string motivo_situacao { get; set; }

        [Display(Name = "Data Situação Especial:")]
        public string data_situacao_especial { get; set; }

        [Display(Name = "Capital Social:")]
        public string capital_social { get; set; }

        public string message { get; set; }

        public string cnpjInvalid { get; set; }

    }
}