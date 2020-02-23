using System;
using System.Collections.Generic;

namespace APIDashboard.Models
{
    public partial class TdCombustibles
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
