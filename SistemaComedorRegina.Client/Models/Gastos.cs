using SistemaComedorRegina.Domain.Dtos;
using SistemaComedorRegina.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaComedorRegina.Domain.Models;

public class Gastos
{
    [Key]
    public int GastoId { get; set; }
    public int TipoGastoId { get; set; }
    [ForeignKey(nameof(TipoGastoId))]
    public TipoGastos? TipoGasto { get; set; } 
    [Required(ErrorMessage ="Este campo es requerido")]
    public string Descripcion { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es requerido")]
    public double Monto { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha { get; set; }


    public GastosDto ToDto()
    {
        return new GastosDto
        {
            Descripcion = this.Descripcion,
            Monto = this.Monto,
            Fecha = this.Fecha,
            TipoGastoId = this.TipoGastoId
        };
    }
}
