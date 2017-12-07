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
    /// Describes recoding values in one or more variables according to a specified mapping.

    /// <summary>
    public class Recode : TransformBase
    {
        /// <summary>
        /// The variables that will have their values recoded. The resulting values may be either stored in the same variable, or a newly created destination variable
        /// <summary>
        public List<RecodeVariable> RecodedVariables { get; set; } = new List<RecodeVariable>();
        public bool ShouldSerializeRecodedVariables() { return RecodedVariables.Count > 0; }
        /// <summary>
        /// A range of variables to which the recode rules are applied. The resulting values are stored in the same variable.
        /// <summary>
        public VariableRangeExpression TargetVariables { get; set; }
        /// <summary>
        /// A mapping describing which values will be recoded to which new values
        /// <summary>
        public List<RecodeRule> Rules { get; set; } = new List<RecodeRule>();
        public bool ShouldSerializeRules() { return Rules.Count > 0; }

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
            if (RecodedVariables != null && RecodedVariables.Count > 0)
            {
                foreach (var item in RecodedVariables)
                {
                    xEl.Add(item.ToXml("RecodedVariables"));
                }
            }
            if (TargetVariables != null) { xEl.Add(TargetVariables.ToXml("TargetVariables")); }
            if (Rules != null && Rules.Count > 0)
            {
                foreach (var item in Rules)
                {
                    xEl.Add(item.ToXml("Rules"));
                }
            }
            return xEl;
        }
    }
}

