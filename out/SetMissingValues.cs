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
    public class SetMissingValues : TransformBase
    {
        /// <summary>
        /// The list of variables to which the missing values are assigned
        /// <summary>
        public VariableListExpression VariableList { get; set; }
        /// <summary>
        /// The range of variables, each of which is to have the missing values assigned
        /// <summary>
        public VariableRangeExpression VariableRange { get; set; }
        /// <summary>
        /// The values to be considered as missing values
        /// <summary>
        public List<string> Value { get; set; } = new List<string>();
        public bool ShouldSerializeValue() { return Value.Count > 0; }
        /// <summary>
        /// The range of values to be considered as missing values
        /// <summary>
        public List<ValueRange> ValueRange { get; set; } = new List<ValueRange>();
        public bool ShouldSerializeValueRange() { return ValueRange.Count > 0; }

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
            if (Value != null && Value.Count > 0)
            {
                xEl.Add(
                    from item in Value
                    select new XElement(ns + "Value", item.ToString()));
            }
            if (ValueRange != null && ValueRange.Count > 0)
            {
                foreach (var item in ValueRange)
                {
                    xEl.Add(item.ToXml("ValueRange"));
                }
            }
            return xEl;
        }
    }
}

