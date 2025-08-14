using SistemaComedorRegina.Domain.Models;

namespace SistemaComedorRegina.Domain.Dtos;

public class GastosDto
{
    public int GastoId { get; set; }
    public int TipoGastoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Fecha { get; set; }

    public Gastos ToEntity()
    {
        return new Gastos
        {
            GastoId = this.GastoId,
            Descripcion = this.Descripcion,
            Monto = this.Monto,
            Fecha = this.Fecha,
            TipoGastoId = this.TipoGastoId
        };
    }
}
