﻿using LaboratorioDeSoftware.Core.Data;
using LaboratorioDeSoftware.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioDeSoftware.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioService userService;
        public LoginController(AppDbContext _context)
        {
            userService = new UsuarioService(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                var usuario = await userService.Autenticar(email, senha);

                HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                HttpContext.Session.SetInt32("TipoUsuario", Convert.ToInt32(usuario.TipoUsuario));
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Index");
            }
        }  

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }      
    }
}
