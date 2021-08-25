using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Shared.Data.Entidades
{
    [Index(nameof(Id), Name = "UQ_Compra_IdCompra", IsUnique = true)]
    public class Compra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio.")]
        public int Producto { get; set; }

        [Required(ErrorMessage = "Tiene que ingresar una cantidad.")]
        [MaxLength(3, ErrorMessage = "El campo tiene como maximo {3} caracteres.")]
        public int Cant { get; set; }
    }
}
