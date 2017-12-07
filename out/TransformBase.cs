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
    public abstract class TransformBase
    {
        /// <summary>
        /// The type of transform command
        /// <summary>
        public string Command { get; set; }
        /// <summary>
        /// The language of the original transform (e.g., SPSS, SAS, Stata, R)
        /// <summary>
        public string SourceLanguage { get; set; }
        /// <summary>
        /// The name of the file that contained the original transform code
        /// <summary>
        public string SourceFileName { get; set; }
        /// <summary>
        /// The character index of the beginning of the transform code
        /// <summary>
        public int SourceStartIndex { get; set; }
        /// <summary>
        /// The character index of the end of the transform code
        /// <summary>
        public int SourceStopIndex { get; set; }
        /// <summary>
        /// The original source code of the data transform code
        /// <summary>
        public string SourceText { get; set; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml(string name)
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + name);
            if (Command != null)
            {
                xEl.Add(new XElement(ns + "Command", Command));
            }
            if (SourceLanguage != null)
            {
                xEl.Add(new XElement(ns + "SourceLanguage", SourceLanguage));
            }
            if (SourceFileName != null)
            {
                xEl.Add(new XElement(ns + "SourceFileName", SourceFileName));
            }
            xEl.Add(new XElement(ns + "SourceStartIndex", SourceStartIndex));
            xEl.Add(new XElement(ns + "SourceStopIndex", SourceStopIndex));
            if (SourceText != null)
            {
                xEl.Add(new XElement(ns + "SourceText", SourceText));
            }
            return xEl;
        }
    }
}

