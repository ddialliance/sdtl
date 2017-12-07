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
    public class VariableListExpression : ExpressionBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public List<string> VariableNames { get; set; } = new List<string>();
        public bool ShouldSerializeVariableNames() { return VariableNames.Count > 0; }

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
            if (VariableNames != null && VariableNames.Count > 0)
            {
                xEl.Add(
                    from item in VariableNames
                    select new XElement(ns + "VariableNames", item.ToString()));
            }
            return xEl;
        }
    }
}

