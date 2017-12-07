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
    public class MergeDatasets : TransformBase
    {
        /// <summary>
        /// The names of the files to be merged
        /// <summary>
        public List<string> FileName { get; set; } = new List<string>();
        public bool ShouldSerializeFileName() { return FileName.Count > 0; }

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
            if (FileName != null && FileName.Count > 0)
            {
                xEl.Add(
                    from item in FileName
                    select new XElement(ns + "FileName", item.ToString()));
            }
            return xEl;
        }
    }
}

