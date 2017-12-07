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
    public class ReshapeLong : TransformBase
    {
        /// <summary>
        /// TODO
        /// <summary>
        public List<string> MakeItems { get; set; } = new List<string>();
        public bool ShouldSerializeMakeItems() { return MakeItems.Count > 0; }
        /// <summary>
        /// TODO
        /// <summary>
        public List<int> IndexValues { get; set; } = new List<int>();
        public bool ShouldSerializeIndexValues() { return IndexValues.Count > 0; }
        /// <summary>
        /// TODO
        /// <summary>
        public string IndexVarName { get; set; }

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
            if (MakeItems != null && MakeItems.Count > 0)
            {
                xEl.Add(
                    from item in MakeItems
                    select new XElement(ns + "MakeItems", item.ToString()));
            }
            xEl.Add(
                from item in IndexValues
                select new XElement(ns + "IndexValues", item));
            if (IndexVarName != null)
            {
                xEl.Add(new XElement(ns + "IndexVarName", IndexVarName));
            }
            return xEl;
        }
    }
}

