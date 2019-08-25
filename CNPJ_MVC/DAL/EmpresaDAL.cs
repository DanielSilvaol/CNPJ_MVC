using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CNPJ_MVC.Models;
using CNPJ_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CNPJ_MVC.DAL
{
    public class EmpresaDAL
    {


        public static async Task<List<ViewModels.EmpresasViewModel>> ListarEmpresas(CnpjContext _context)
        {
            List<EmpresasViewModel> viewModel = new List<EmpresasViewModel>();

            await _context.Empresa.ForEachAsync(x =>
                viewModel.Add(new EmpresasViewModel
                {
                    id = x.id,
                    cnpj = x.cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty),
                    nome = x.nome,
                    data_situacao = x.data_situacao
                })

            );

            return viewModel;

        }

        public static async Task<List<FormEmpresasViewModel>> buscarEmpresa(string cnpj, CnpjContext _context)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                return null;
            }
            var empresas = new List<FormEmpresasViewModel>();
            var cnpjs = cnpj == null ? null : cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty).Split(";");
            var formEmpresa = new FormEmpresasViewModel();

            var cnpjsInvalid = new StringBuilder("Cnpj a baixo invalidos:");

            foreach (var item in cnpjs)
            {
                try
                {
                    if (!empresas.Any(x=>x.cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty) == item))
                    {
                        var empresa = await _context.Empresa.Where(x => x.cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty) == item).ToListAsync();

                        if (empresa.Count == 0 && item != null)
                        {
                            var emp = Empresa.BuscarCNPJ(item);

                            if (emp.message !=null)
                            {
                                throw new System.ArgumentException(emp.message, "original");
                            }

                            formEmpresa = emp;
                        }
                        else if (formEmpresa.message == null)
                        {
                            empresa.ForEach(x =>
                            {
                                formEmpresa.cnpj = x.cnpj;
                                formEmpresa.atividade_principal = _context.AtividadePrincipal.Where(at => at.Empresaid == x.id).ToList();
                                formEmpresa.atividades_secundarias = _context.AtividadesSecundarias.Where(at => at.Empresaid == x.id).ToList();
                                formEmpresa.qsa = _context.Qsa.Where(qs => qs.Empresaid == x.id).ToList();
                                formEmpresa.abertura = x.abertura;
                                formEmpresa.bairro = x.bairro;
                                formEmpresa.capital_social = x.capital_social;
                                formEmpresa.cep = x.cep;
                                formEmpresa.complemento = x.complemento;
                                formEmpresa.data_situacao = x.data_situacao;
                                formEmpresa.data_situacao_especial = x.data_situacao_especial;
                                formEmpresa.efr = x.efr;
                                formEmpresa.email = x.email;
                                formEmpresa.fantasia = x.fantasia;
                                formEmpresa.id = x.id;
                                formEmpresa.nome = x.nome;
                                formEmpresa.uf = x.uf;
                                formEmpresa.telefone = x.telefone;
                                formEmpresa.situacao = x.situacao;
                                formEmpresa.logradouro = x.logradouro;
                                formEmpresa.numero = x.numero;
                                formEmpresa.municipio = x.municipio;
                                formEmpresa.porte = x.porte;
                                formEmpresa.natureza_juridica = x.natureza_juridica;
                                formEmpresa.ultima_atualizacao = x.ultima_atualizacao;
                                formEmpresa.tipo = x.tipo;
                                formEmpresa.motivo_situacao = x.motivo_situacao;

                            });
                        }
                        empresas.Add(formEmpresa);
                    }
                    

                }
                catch (Exception e)
                {
                    cnpjsInvalid.Append(item + "\n");
                }
            }
            return empresas;
        }
        public static async Task<List<FormEmpresasViewModel>> buscarEmpresas(CnpjContext _context)
        {

            var empresaForm = new List<FormEmpresasViewModel>();
            
            var empresa = await _context.Empresa.ToListAsync();

            for (int i = 0; i < empresa.Count; i++)
            {
                var formEmpresa = new FormEmpresasViewModel();
                formEmpresa.cnpj = empresa[i].cnpj;
                formEmpresa.atividade_principal = _context.AtividadePrincipal.Where(at => at.Empresaid == empresa[i].id).ToList();
                formEmpresa.atividades_secundarias = _context.AtividadesSecundarias.Where(at => at.Empresaid == empresa[i].id).ToList();
                formEmpresa.qsa = _context.Qsa.Where(qs => qs.Empresaid == empresa[i].id).ToList();
                formEmpresa.abertura = empresa[i].abertura;
                formEmpresa.bairro = empresa[i].bairro;
                formEmpresa.capital_social = empresa[i].capital_social;
                formEmpresa.cep = empresa[i].cep;
                formEmpresa.complemento = empresa[i].complemento;
                formEmpresa.data_situacao = empresa[i].data_situacao;
                formEmpresa.data_situacao_especial = empresa[i].data_situacao_especial;
                formEmpresa.efr = empresa[i].efr;
                formEmpresa.email = empresa[i].email;
                formEmpresa.fantasia = empresa[i].fantasia;
                formEmpresa.id = empresa[i].id;
                formEmpresa.nome = empresa[i].nome;
                formEmpresa.uf = empresa[i].uf;
                formEmpresa.telefone = empresa[i].telefone;
                formEmpresa.situacao = empresa[i].situacao;
                formEmpresa.logradouro = empresa[i].logradouro;
                formEmpresa.numero = empresa[i].numero;
                formEmpresa.municipio = empresa[i].municipio;
                formEmpresa.porte = empresa[i].porte;
                formEmpresa.natureza_juridica = empresa[i].natureza_juridica;
                formEmpresa.ultima_atualizacao = empresa[i].ultima_atualizacao;
                formEmpresa.tipo = empresa[i].tipo;
                formEmpresa.motivo_situacao = empresa[i].motivo_situacao;


                empresaForm.Add(formEmpresa);

            }
            return empresaForm;

        }

        public static string InsertEmpresa(string cnpj, CnpjContext _context)
        {
            cnpj = cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty);
            if (!EmpresaExists(cnpj,_context))
            {
                var apiUrl = string.Format("{0}{1}", "https://www.receitaws.com.br/v1/cnpj/", cnpj);
                var entities = new Empresa();
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(apiUrl).Result;
                    var retorno = response.Content.ReadAsStringAsync().Result;
                    entities = Newtonsoft.Json.JsonConvert.DeserializeObject<Empresa>(retorno);
                }

                
                _context.Add(entities);
                _context.SaveChangesAsync();
                return "CNPJ salvo com sucesso.";
            }

            return "CNPJ já consta salvo no banco.";

        }

        private static bool EmpresaExists(string cnpj, CnpjContext _context)
        {
            return _context.Empresa.Any(e => e.cnpj.Replace("-", string.Empty).Replace(".", string.Empty).Replace("/", string.Empty) == cnpj);
        }


        
    }
}