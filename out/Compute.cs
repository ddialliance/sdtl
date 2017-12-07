using System;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using Cogs.SimpleTypes;
using System.Reflection;
using System.Collections;
using Newtonsoft.Json.Linq;
using Cogs.DataAnnotations;
using Cogs.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sdtl
{
    /// <summary>
    /// TODO

    /// <summary>
    public class Compute : TransformBase
    {
        /// <summary>
        /// The name of the variable that is computed.
        /// <summary>
        public string Target { get; set; }
        /// <summary>
        /// The range of variables, each of which is to be computed.
        /// <summary>
        public VariableRangeExpression TargetRange { get; set; }
        /// <summary>
        /// The expression used to compute the value of the variable(s)
        /// <summary>
        public ExpressionBase Formula { get; set; }
        /// <summary>
        /// The condition that must be true in order for the computation to take place
        /// <summary>
        public ExpressionBase Condition { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public override XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            foreach (var el in base.ToXml().Descendants())
            {
                xEl.Add(el);
            }
            if (Target != null)
            {
                xEl.Add(new XElement(ns + "Target", Target));
            }
            if (TargetRange != null) { xEl.Add(TargetRange.ToXml("TargetRange")); }
            if (Formula != null) { xEl.Add(Formula.ToXml("Formula")); }
            if (Condition != null) { xEl.Add(Condition.ToXml("Condition")); }
            return xEl;
        }
    }
}

