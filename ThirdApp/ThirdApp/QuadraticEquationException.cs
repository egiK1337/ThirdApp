using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdApp
{
    public class QuadraticEquationException : Exception
    {
        public Severity Severity { get; set; }
        public Dictionary<string, int> Data { get; set; }

        public QuadraticEquationException(string message, Severity severity, Dictionary<string, int> data)
            : base(message)
        {
            Severity = severity;
            Data = data;
        }
    }
}
