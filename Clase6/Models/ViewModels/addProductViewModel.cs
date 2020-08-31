using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clase6.Models.ViewModels
{
    public class addProductViewModel
    {   
        [Required]
        public int idProducto { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public double precio { get; set; }
        [Required]
        public int categoria { get; set; }
    }
}