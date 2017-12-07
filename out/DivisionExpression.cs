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
    public class DivisionExpression : ExpressionBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Dividend { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Divisor { get; set; }

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
            if (Dividend != null) { xEl.Add(Dividend.ToXml("Dividend")); }
            if (Divisor != null) { xEl.Add(Divisor.ToXml("Divisor")); }
            return xEl;
        }
    }
}

