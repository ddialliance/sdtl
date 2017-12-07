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
    public class SetDatasetProperty : TransformBase
    {
        /// <summary>
        /// The name of the property to be set (for example, 'Title' or 'Subtitle').
        /// <summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// The value of the property.
        /// <summary>
        public string Value { get; set; }

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
            if (PropertyName != null)
            {
                xEl.Add(new XElement(ns + "PropertyName", PropertyName));
            }
            if (Value != null)
            {
                xEl.Add(new XElement(ns + "Value", Value));
            }
            return xEl;
        }
    }
}

