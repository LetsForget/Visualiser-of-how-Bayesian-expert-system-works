﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayesian.Logic
{
    public class Expression
    {
        #region Fields
        public List<Event> PossibleEvents;
        public List<Event> ExactEvents;
        public double Probability;
        public Expression Parent;
        public List<Expression> ChildExpressions;
        #endregion

        #region Constructors
        public Expression()
        {
            PossibleEvents = new List<Event>();
            ExactEvents = new List<Event>();
            ChildExpressions = new List<Expression>();
            Probability = -1;
        }
        #endregion

        #region Methods
        public string Write()
        {
            if (Probability == 1)
                return "1";
            if (PossibleEvents.Count == 0)
                throw new Exception("Empty expression!");
            string temp;
            temp = "p(";

            foreach (Event t in PossibleEvents)
                temp += " " + t.Name + " &";
            temp = temp.Remove(temp.LastIndexOf("&"), 1);

            if (ExactEvents.Count > 0)
            {
                temp += " | ";
                foreach (Event t in ExactEvents)
                    temp += " " + t.Name + " &";
                temp = temp.Remove(temp.LastIndexOf("&"), 1);
            }
            temp += ")";
            return temp;
        }
        #endregion
    }
}
