// See https://aka.ms/new-console-template for more information
using Antlr4.Runtime;
using ProyectoEvaluacionParcialParser;
using ProyectoEvaluacionParserV2;

ICharStream stream = CharStreams.fromPath(@"..\..\..\Automata.txt");
AUTOMATALexer lexer = new AUTOMATALexer(stream);
CommonTokenStream token = new CommonTokenStream(lexer);
AUTOMATAParser parser = new AUTOMATAParser(token);
AUTOMATAParser.AutomataContext tree = parser.automata();
Automata automata = new Automata();
string result = automata.Visit(tree);
var circle = automata.circle;
var doublecircle = automata.doublecircle;
GraphvizFormat graphviz = new GraphvizFormat(doublecircle, circle);

Console.WriteLine(graphviz.result);

