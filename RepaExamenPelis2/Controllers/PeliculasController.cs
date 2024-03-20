using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepaExamenPelis2.Extensions;
using RepaExamenPelis2.Filters;
using RepaExamenPelis2.Models;
using RepaExamenPelis2.Repositories;

namespace RepaExamenPelis2.Controllers
{
    public class PeliculasController : Controller
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Pelicula> list = await this.repo.PeliculasGeneroall();
            return View(list);
        }
        [AuthorizeUsuarios]
        public IActionResult Perfil()
        {
            return View();
        }
        public async Task<IActionResult> PeliculaGenero(int id)
        {
            List<Pelicula> pelis = await this.repo.PeliculasGenero(id);
            return View(pelis);
        }

        public async Task<IActionResult> DetallesPelicula(int id)
        {
            Pelicula peli = await this.repo.PeliculasGeneroDetalles(id);
            return View(peli);
        }


        public IActionResult GuardarPeliculaCarrito(int? idPelicula)
        {
            if (idPelicula != null)
            //GUARDAMOS EL PRODUCTO EN EL CARRITO
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                {
                    carrito = new List<int>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                }
                carrito.Add(idPelicula.Value);
                HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Carrito(int? idPeliculaEliminar)
        {
            //LE PASAMOS EL CARRITO
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            //TIENES QUE CREAR PARA AÑADIR DATOS AL CARRITO
            if (carrito == null)
            {
                return View();
            }
            else
            {
                if (idPeliculaEliminar != null)
                {
                    carrito.Remove(idPeliculaEliminar.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }
                List<Pelicula> peliculas = this.repo.GetPeliculasCarrito(carrito);
                return View(peliculas);
            }
        }
        [AuthorizeUsuarios]
        public IActionResult Pedidos()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            List<Pelicula> peliculas = this.repo.GetPeliculasCarrito(carrito);
            HttpContext.Session.Remove("CARRITO");
            return View(peliculas);
        }
    }
}
