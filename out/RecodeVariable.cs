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
    /// Describes a variable that will have its values recoded.

    /// <summary>
    public class RecodeVariable
    {
        /// <summary>
        /// The name of the variable which will have its values recoded
        /// <summary>
        public string Source { get; set; }
        /// <summary>
        /// The name of the new variable into which the recoded values are inserted. This may be the same as the source variable if values are recoded in place.
        /// <summary>
        public string Target { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            if (Source != null)
            {
                xEl.Add(new XElement(ns + "Source", Source));
            }
            if (Target != null)
            {
                xEl.Add(new XElement(ns + "Target", Target));
            }
            return xEl;
        }
    }
}

