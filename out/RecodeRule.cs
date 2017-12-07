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
    /// Describes how values will be recoded.

    /// <summary>
    public class RecodeRule
    {
        /// <summary>
        /// The value or range of values that will be recoded
        /// <summary>
        public List<string> From { get; set; } = new List<string>();
        public bool ShouldSerializeFrom() { return From.Count > 0; }
        /// <summary>
        /// The new value
        /// <summary>
        public string To { get; set; }
        /// <summary>
        /// A value label for the new recoded value, if appropriate
        /// <summary>
        public string Label { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            if (From != null && From.Count > 0)
            {
                xEl.Add(
                    from item in From
                    select new XElement(ns + "From", item.ToString()));
            }
            if (To != null)
            {
                xEl.Add(new XElement(ns + "To", To));
            }
            if (Label != null)
            {
                xEl.Add(new XElement(ns + "Label", Label));
            }
            return xEl;
        }
    }
}

