using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CNPJ_MVC.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CNPJ_MVC.Models;
using CNPJ_MVC.ViewModels;

namespace CNPJ_MVC.Controllers
{
    public class EmpresasController : Controller
    {


        private readonly CnpjContext _context;
        public EmpresasController(CnpjContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = await EmpresaDAL.ListarEmpresas(_context);

            return View(viewModel);
        }
        public async Task<IActionResult> Details(string cnpj)
        {
            var empresa = await DAL.EmpresaDAL.buscarEmpresa(cnpj, _context);
            
            if (string.IsNullOrEmpty(cnpj))
            {
                empresa = await DAL.EmpresaDAL.buscarEmpresas(_context);
                if (empresa.Count == 0)
                {
                    return RedirectToAction(nameof(Info), new { msg = "Nenhum registro salvo." });
                }
            }

            if (empresa.Count == 0)
            {
                return RedirectToAction(nameof(Info), new { msg = "Cnpj inválido." });
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string cnpj)
        {
            var msg = DAL.EmpresaDAL.InsertEmpresa(cnpj, _context);
            return RedirectToAction(nameof(Info),new{msg = msg});
        }

        public IActionResult Info(string msg)
        {
            var viewModel = new ErrorViewModel
            {
                Message = msg,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            };

            return View(viewModel);
        }


    }
}
