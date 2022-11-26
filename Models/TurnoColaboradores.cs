
using System.ComponentModel.DataAnnotations;
using System.Data;

using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class TurnoColaboradores
    {
        //chave primária
        [Key]
        public int TurnoColaboradoresId  {get;set;}

        [Required]
        public int horas_turno { get; set; }

        [Required]
        public DateTime dataInicio { get; set; }

        [Required]
        public DateTime dataFim { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string turnoEstado { get; set; }
    }
}
