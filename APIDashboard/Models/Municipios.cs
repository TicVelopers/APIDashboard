using System;
using System.Collections.Generic;

namespace APIDashboard.Models
{
    public partial class Municipios
    {
        public int? ProvinciaId { get; set; }
        public int MunicipioId { get; set; }
        public string Municipio { get; set; }
    }
}
