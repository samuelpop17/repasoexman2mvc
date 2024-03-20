using RepaExamenPelis2.Data;
using RepaExamenPelis2.Models;

namespace RepaExamenPelis2.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;
        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }


        public List<Genero> GetGeneros()
        {
            return this.context.Generos.ToList();
        }


        public async Task<List<Pelicula>> PeliculasGenero(int idgenero)
        {
            var consulta = from datos in context.Peliculas
                           where datos.IdGenero == idgenero
                           select datos;
            return consulta.ToList();
        }

        public async Task<List<Pelicula>> PeliculasGeneroall()
        {
            var consulta = from datos in context.Peliculas
                           select datos;
            return consulta.ToList();
        }
        public async Task<Pelicula> PeliculasGeneroDetalles(int id)
        {
            var consulta = from datos in context.Peliculas
                           where datos.IdPelicula == id
                           select datos;
            return consulta.FirstOrDefault();
        }


        public List<Pelicula> GetPeliculasCarrito(List<int> idPelicula)
        {

            var consulta = from datos in context.Peliculas
                           where idPelicula.Contains(datos.IdPelicula)
                           select datos;
            return consulta.ToList();
        }
    }

    
}
