using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProyectoEvaluacionParserV2
{
    internal class Automata : AUTOMATABaseVisitor<string>
    {
        public string circle = "";
        public string doublecircle = "";
        int count = 0;
        public override string VisitAcceptance([NotNull] AUTOMATAParser.AcceptanceContext context)
        {
            return base.VisitAcceptance(context);
        }

        public override string VisitAutomata([NotNull] AUTOMATAParser.AutomataContext context)
        {
            var state = context.state();
            if(state != null)
            {
                for(int i = 0; i < state.Length; i++)
                {
                    var acceptance = state[i].id().prop()?.acceptance();
                    var name = state[i].id().state_name();
                    if (acceptance != null)
                    {
                        if (count == 0)
                        {
                            doublecircle = $"{name.GetText()}";
                        }
                        else
                        {
                            doublecircle += $",{name.GetText()}";
                        }
                        count++;
                    }
                }
            }
            doublecircle += ";";

            return base.VisitAutomata(context);
        }

        public override string VisitId([NotNull] AUTOMATAParser.IdContext context)
        {
            return base.VisitId(context);
        }

        public override string VisitInitial([NotNull] AUTOMATAParser.InitialContext context)
        {
            return base.VisitInitial(context);
        }

        public override string VisitInput([NotNull] AUTOMATAParser.InputContext context)
        {
            return base.VisitInput(context);
        }

        public override string VisitProp([NotNull] AUTOMATAParser.PropContext context)
        {
            return base.VisitProp(context);
        }

        public override string VisitState([NotNull] AUTOMATAParser.StateContext context)
        {
            var initial = context.id().prop()?.initial();
            var name = context.id().state_name();
            if (initial != null)
            {
                circle = $"\ninicio -> {name.GetText()};";
            }
            var transitions = context.transitions();
            if(transitions != null)
            {
                var transition = transitions.transition();
                for (int i = 0; i< transition.Length; i++)
                {
                    var input = transition[i].input().GetText();
                    var state_name = transition[i].state_name();
                    for(int j = 0; j< state_name.Length; j++)
                    {
                        circle += $"\n{name.GetText()} -> {state_name[j].GetText()} [label = \"{input}\"];";
                    }
                }
                
            }
            return base.VisitState(context);
        }

        public override string VisitState_name([NotNull] AUTOMATAParser.State_nameContext context)
        {
            return base.VisitState_name(context);
        }

        public override string VisitTransition([NotNull] AUTOMATAParser.TransitionContext context)
        {
            return base.VisitTransition(context);
        }

        public override string VisitTransitions([NotNull] AUTOMATAParser.TransitionsContext context)
        {
            return base.VisitTransitions(context);
        }
    }
}
