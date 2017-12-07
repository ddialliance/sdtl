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
    public class NumericConstantExpression : ExpressionBase
    {
        /// <summary>
        /// The type of number (for example 'int' or 'double')
        /// <summary>
        public string Type { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public int IntValue { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public double DoubleValue { get; set; }

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
            if (Type != null)
            {
                xEl.Add(new XElement(ns + "Type", Type));
            }
            xEl.Add(new XElement(ns + "IntValue", IntValue));
            xEl.Add(new XElement(ns + "DoubleValue", DoubleValue));
            return xEl;
        }
    }
}

