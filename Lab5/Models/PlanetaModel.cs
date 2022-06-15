using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    public class PlanetaModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del planeta")]
        [Display(Name = "Ingrese el nombre del planeta")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Necesario que indique el tipo de planeta")]
        [Display(Name = "Ingrese el yipo del planeta")]
        public string tipo { get; set; }
        [Required(ErrorMessage = "Necesario que indique el numero de anillos")]
        [Display(Name = "Ingrese el numero de anillos del planeta")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar numeros")]
        public int numeroAnillos { get; set; }
        // de momento no se va trabajar con el archivo...
        [Required(ErrorMessage = "Debe agregar un archivo")]
        [Display(Name = "Ingrese el archivo con los detalles del planeta")]
        public HttpPostedFileBase archivo { get; set; }

        public string tipoArchivo { get; set; }

    }
}