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
    public class ReshapeWide : TransformBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public List<string> KeepItems { get; set; } = new List<string>();
        public bool ShouldSerializeKeepItems() { return KeepItems.Count > 0; }
        /// <summary>
        /// TODO
        /// <summary>
        public string IdVar { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public string IndexVar { get; set; }

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
            if (KeepItems != null && KeepItems.Count > 0)
            {
                xEl.Add(
                    from item in KeepItems
                    select new XElement(ns + "KeepItems", item.ToString()));
            }
            if (IdVar != null)
            {
                xEl.Add(new XElement(ns + "IdVar", IdVar));
            }
            if (IndexVar != null)
            {
                xEl.Add(new XElement(ns + "IndexVar", IndexVar));
            }
            return xEl;
        }
    }
}

