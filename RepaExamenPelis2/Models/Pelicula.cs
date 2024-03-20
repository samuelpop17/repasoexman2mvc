﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepaExamenPelis2.Models
{
    [Table("PELICULAS")]
    public class Pelicula
    {
        [Key]
        [Column("IdPelicula")]
        public int IdPelicula { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Director")]
        public string Director { get; set; }
        [Column("Imagen")]
        public string Imagen { get; set; }
        [Column("Sinopsis")]
        public string Sinopsis { get; set; }
        [Column("Precio")]
        public int Precio { get; set; }
        [Column("IdGenero")]
        public int IdGenero { get; set; }
    }
}
