using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebApplicationTurnos.Models;

namespace WebApplicationTurnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurnosContext _context;

        public LoginController(TurnosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                //EncriptarPassword
                string passwordEncriptado = Encriptar(login.Password);
                var loginUsuario = _context.Login
                    .Where(l => l.Usuario == login.Usuario && l.Password == passwordEncriptado)
                    .FirstOrDefault();

                if(loginUsuario != null)
                {
                    HttpContext.Session.SetString("usuario", loginUsuario.Usuario); //variable de sesion
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["errorLogin"] = "Los datos ingresados son incorrectos";
                    return View("Index");
                }
            }
            return View("Index");
        }

        public string Encriptar(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                
                for(int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2")); //el x2 convierte binario en hexadecimal
                }
                return sb.ToString();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
