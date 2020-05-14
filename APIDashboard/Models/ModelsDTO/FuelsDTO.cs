using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDashboard.Models.ModelsDTO
{
    public class FuelsDTO
    {
        public int Id { get; set; }
        public decimal? CodigoDate { get; set; }
        public string Combustible { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaSemana { get; set; }
        public string SemanaLabel { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
