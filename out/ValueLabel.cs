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
    public class ValueLabel
    {
        /// <summary>
        /// The value to which a label is assigned
        /// <summary>
        public string Value { get; set; }
        /// <summary>
        /// The label to be assigned to the value
        /// <summary>
        public string Label { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            if (Value != null)
            {
                xEl.Add(new XElement(ns + "Value", Value));
            }
            if (Label != null)
            {
                xEl.Add(new XElement(ns + "Label", Label));
            }
            return xEl;
        }
    }
}

