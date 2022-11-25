
using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class TurnoColaboradores
    {
        //chave primária
        public int TurnoColaboradoresId  {get;set;}

        [Required]
        public int horas_turno { get; set; }

        [Required]
        public int dataInicio { get; set; }

        [Required]
        public int dataFim { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        public string turnoEstado { get; set; }


        [Required]
        public int dataEstado { get; set; }

    }
}
