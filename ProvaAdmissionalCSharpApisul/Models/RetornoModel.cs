using System.Collections.Generic;

namespace ProvaAdmissionalCSharpApisul.Models
{
    public class RetornoModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal PercentualUso { get; set; }
        public List<int> Andares { get; set; }
        public List<char> Elevadores { get; set; }
        public List<char> Turnos { get; set; }

    }
}
