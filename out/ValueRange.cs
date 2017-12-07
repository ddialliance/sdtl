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
    public class ValueRange
    {
        /// <summary>
        /// TODO
        /// <summary>
        public string First { get; set; }
        /// <summary>
        /// TODO
        /// <summary>
        public string Last { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            if (First != null)
            {
                xEl.Add(new XElement(ns + "First", First));
            }
            if (Last != null)
            {
                xEl.Add(new XElement(ns + "Last", Last));
            }
            return xEl;
        }
    }
}

