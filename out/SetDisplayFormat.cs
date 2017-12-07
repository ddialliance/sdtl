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
    public class SetDisplayFormat : TransformBase
    {
        /// <summary>
        /// The list of variables that will have their format set
        /// <summary>
        public VariableListExpression VariableList { get; set; }
        /// <summary>
        /// The range of variables, each of which is to have the format assigned
        /// <summary>
        public VariableRangeExpression VariableRange { get; set; }
        /// <summary>
        /// The name of the format to be assigned to the variable(s). This name is system dependent.
        /// <summary>
        public string Format { get; set; }

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
            if (VariableList != null) { xEl.Add(VariableList.ToXml("VariableList")); }
            if (VariableRange != null) { xEl.Add(VariableRange.ToXml("VariableRange")); }
            if (Format != null)
            {
                xEl.Add(new XElement(ns + "Format", Format));
            }
            return xEl;
        }
    }
}

