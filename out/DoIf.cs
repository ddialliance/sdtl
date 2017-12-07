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
    public class DoIf : TransformBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public ExpressionBase Condition { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public List<TransformBase> Commands { get; set; } = new List<TransformBase>();
        public bool ShouldSerializeCommands() { return Commands.Count > 0; }

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
            if (Condition != null) { xEl.Add(Condition.ToXml("Condition")); }
            if (Commands != null && Commands.Count > 0)
            {
                foreach (var item in Commands)
                {
                    xEl.Add(item.ToXml("Commands"));
                }
            }
            return xEl;
        }
    }
}

