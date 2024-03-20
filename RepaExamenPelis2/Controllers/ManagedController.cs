using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RepaExamenPelis2.Models;
using RepaExamenPelis2.Repositories;
using System.Security.Claims;

namespace RepaExamenPelis2.Controllers
{
    public class ManagedController : Controller
    {
        private RepositoryUsuarios repo;

        public ManagedController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login
    (string email, string password)
        {
            Usuario user = await this.repo.GetUserByEmailPassword(email, password);

            if (user != null)
            {
                //SEGURIDAD
                ClaimsIdentity identity = new ClaimsIdentity( CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name, ClaimTypes.Role);
                //CREAMOS EL CLAIM PARA EL NOMBRE (nombre)
                Claim claimName =
                    new Claim("nombre", user.Nombre);
                identity.AddClaim(claimName);
                Claim claimId =
                    new Claim("id",user.IdUsuario.ToString());
                identity.AddClaim(claimId);
               
              
               
                //COMO POR AHORA NO VOY A UTILIZAR NI SE UTILIZAR ROLES
                //NO LO INCLUIMOS
                ClaimsPrincipal userPrincipal =
                    new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal);
                //LO VAMOS A LLEVAR A UNA VISTA CON LA INFORMACION
                //QUE NOS DEVUELVE EL FILTER EN TEMPDATA
                string controller = TempData["controller"].ToString();
                string action = TempData["action"].ToString();


                if (TempData["id"] != null)
                {
                    string id = "";
                    id = TempData["id"].ToString();
                    return RedirectToAction(action, controller, new { id = id });
                }
                else
                {
                    return RedirectToAction(action, controller);
                }
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Peliculas");
        }

       

        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
