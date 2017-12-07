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
    /// Describes the assignment of a label to a variable.

    /// <summary>
    public class SetVariableLabel : TransformBase
    {
        /// <summary>
        /// The name of the variable to which a label will be assigned
        /// <summary>
        public string VariableName { get; set; }
        /// <summary>
        /// The label to be assigned to the variable
        /// <summary>
        public string Label { get; set; }

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
            if (VariableName != null)
            {
                xEl.Add(new XElement(ns + "VariableName", VariableName));
            }
            if (Label != null)
            {
                xEl.Add(new XElement(ns + "Label", Label));
            }
            return xEl;
        }
    }
}

