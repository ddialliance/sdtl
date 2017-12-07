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
    public class FunctionCallExpression : ExpressionBase
    {
        /// <summary>
        /// The name of the function being called.
        /// <summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of parameters to the function.
        /// <summary>
        public List<ExpressionBase> Parameters { get; set; } = new List<ExpressionBase>();
        public bool ShouldSerializeParameters() { return Parameters.Count > 0; }

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
            if (Name != null)
            {
                xEl.Add(new XElement(ns + "Name", Name));
            }
            if (Parameters != null && Parameters.Count > 0)
            {
                foreach (var item in Parameters)
                {
                    xEl.Add(item.ToXml("Parameters"));
                }
            }
            return xEl;
        }
    }
}

