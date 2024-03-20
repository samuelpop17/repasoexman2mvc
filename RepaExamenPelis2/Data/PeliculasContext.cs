using Microsoft.EntityFrameworkCore;
using RepaExamenPelis2.Models;

namespace RepaExamenPelis2.Data
{
    public class PeliculasContext:DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options) : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
