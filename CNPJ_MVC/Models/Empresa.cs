using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CNPJ_MVC.ViewModels;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CNPJ_MVC.Models
{
    public class Empresa
    {
        [Key]
        public int id { get; set; }
        public List<AtividadePrincipal> atividade_principal { get; set; }
        public string data_situacao { get; set; }
        public string complemento { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<AtividadesSecundarias> atividades_secundarias { get; set; }
        public List<Qsa> qsa { get; set; }
        public string situacao { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string municipio { get; set; }
        public string porte { get; set; }
        public string abertura { get; set; }
        public string natureza_juridica { get; set; }
        public string cnpj { get; set; }
        public DateTime ultima_atualizacao { get; set; }
        public string status { get; set; }
        public string tipo { get; set; }
        public string fantasia { get; set; }
        public string efr { get; set; }
        public string motivo_situacao { get; set; }
        public string data_situacao_especial { get; set; }
        public string capital_social { get; set; }

        public int extraid { get; set; }
        [ForeignKey("extraid")]
        public virtual Extra extra { get; set; }

        public int billingid { get; set; }
        [ForeignKey("billingid")]
        public virtual Billing billing { get; set; }


        public static FormEmpresasViewModel BuscarCNPJ(string cnpj)
        {
            var apiUrl = string.Format("{0}{1}", "https://www.receitaws.com.br/v1/cnpj/", cnpj);
            var entities = new FormEmpresasViewModel();
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiUrl).Result;
                var retorno = response.Content.ReadAsStringAsync().Result;
                entities = Newtonsoft.Json.JsonConvert.DeserializeObject<FormEmpresasViewModel>(retorno);
            }

            return entities;
        }
    }
}