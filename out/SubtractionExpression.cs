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
    public class SubtractionExpression : ExpressionBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Term1 { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Term2 { get; set; }

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
            if (Term1 != null) { xEl.Add(Term1.ToXml("Term1")); }
            if (Term2 != null) { xEl.Add(Term2.ToXml("Term2")); }
            return xEl;
        }
    }
}

