using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEvaluacionParcialParser
{
    internal class GraphvizFormat
    {
        public string result = "";
        public GraphvizFormat(string doubleCircle, string circle)
        {
            result = @"digraph ejercicio_automata {
    rankdir=LR;
    node [shape = none, height=0, width=0]; inicio [label=""""];
    node [shape = doublecircle];" + $"{doubleCircle}" +
   @"
    node [shape = circle]; 
    " + $"{circle}" + @"

}";
        }
        
    }
}
