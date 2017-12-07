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
    public class RenamePair
    {
        /// <summary>
        /// The old name of the variable.
        /// <summary>
        public string OldName { get; set; }
        /// <summary>
        /// The new name of the variable.
        /// <summary>
        public string NewName { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            if (OldName != null)
            {
                xEl.Add(new XElement(ns + "OldName", OldName));
            }
            if (NewName != null)
            {
                xEl.Add(new XElement(ns + "NewName", NewName));
            }
            return xEl;
        }
    }
}

