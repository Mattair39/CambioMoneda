using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioMoneda.Models
{
    public class ConversionDivisas
    {
        public string MonedaBase { get; set; } = "USD";
        public string MonedaACambiar { get; set; } = "EUR";
        public double ValorAcambiar { get; set; }
        public double ValorRecibido { get; set; }

        public string? ChisteChuck { get; set; }

    }
}
