using SistemaComedorRegina.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SistemaComedorRegina.Domain.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public double Monto { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha { get; set; }

    public VentasDto ToDto()
    {
        return new VentasDto
        {
            Monto = this.Monto,
            Fecha = this.Fecha
        };
    }
}
