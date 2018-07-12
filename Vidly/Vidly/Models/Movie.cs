using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Numbers in Stock")]
        [NumberInStockRange]
        public byte? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }

        public static readonly byte NISmin = 1;
        public static readonly byte NISmax = 50;
    }
}