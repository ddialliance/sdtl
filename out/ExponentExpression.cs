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
    public class ExponentExpression : ExpressionBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Base { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Exponent { get; set; }

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
            if (Base != null) { xEl.Add(Base.ToXml("Base")); }
            if (Exponent != null) { xEl.Add(Exponent.ToXml("Exponent")); }
            return xEl;
        }
    }
}

