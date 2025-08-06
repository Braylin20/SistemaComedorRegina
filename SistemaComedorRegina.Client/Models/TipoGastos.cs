
using System.ComponentModel.DataAnnotations;

namespace SistemaComedorRegina.Domain.Models;

public class TipoGastos
{
    [Key]
    public int TipoGastoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
}
