using Microsoft.AspNetCore.Mvc;
using RepaExamenPelis2.Models;
using RepaExamenPelis2.Repositories;

namespace RepaExamenPelis2.ViewComponents
{
    public class DesplegableGenerosViewComponent : ViewComponent
    {
        private RepositoryPeliculas repo;

        public DesplegableGenerosViewComponent(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = this.repo.GetGeneros();
            return View(generos);
        }
    }
}
