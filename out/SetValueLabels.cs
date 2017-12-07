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
    /// Describes the assignment of labels to categorical values.

    /// <summary>
    public class SetValueLabels : TransformBase
    {
        /// <summary>
        /// The name of the variable to which a label will be assigned
        /// <summary>
        public VariableRangeExpression VariableRange { get; set; }
        /// <summary>
        /// The label to be assigned to the variable
        /// <summary>
        public List<ValueLabel> Labels { get; set; } = new List<ValueLabel>();
        public bool ShouldSerializeLabels() { return Labels.Count > 0; }

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
            if (VariableRange != null) { xEl.Add(VariableRange.ToXml("VariableRange")); }
            if (Labels != null && Labels.Count > 0)
            {
                foreach (var item in Labels)
                {
                    xEl.Add(item.ToXml("Labels"));
                }
            }
            return xEl;
        }
    }
}

