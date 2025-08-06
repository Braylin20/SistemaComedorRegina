using SistemaComedorRegina.Domain.Models;

namespace SistemaComedorRegina.Domain.Dtos;

public class VentasDto
{
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }

    public Ventas ToEntity()
    {
        return new Ventas
        {
            Monto = this.Monto,
            Fecha = this.Fecha
        };
    }
}
