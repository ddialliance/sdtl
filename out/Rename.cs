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
    public class Rename : TransformBase
    {
        /// <summary>
        /// A list of variable rename objects, which includes the old name and the new name.
        /// <summary>
        public List<RenamePair> Renames { get; set; } = new List<RenamePair>();
        public bool ShouldSerializeRenames() { return Renames.Count > 0; }

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
            if (Renames != null && Renames.Count > 0)
            {
                foreach (var item in Renames)
                {
                    xEl.Add(item.ToXml("Renames"));
                }
            }
            return xEl;
        }
    }
}

