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
    public class Program : IIdentifiable
    {
        [JsonIgnore]
        public string ReferenceId { get { return $"{ID}"; } }
        /// <summary>
        /// ID of the object being referenced.
        /// <summary>
        public string ID { get; set; }
        /// <summary>
        /// The name of the file containing the source code.
        /// <summary>
        public string SourceFileName { get; set; }
        /// <summary>
        /// The list of commands that make up the program.
        /// <summary>
        public List<TransformBase> Commands { get; set; } = new List<TransformBase>();
        public bool ShouldSerializeCommands() { return Commands.Count > 0; }

        /// <summary>
        /// Used to Serialize this object to XML
        /// <summary>
        public virtual XElement ToXml()
        {
            XNamespace ns = "http://example.org/sdtl";
            XElement xEl = new XElement(ns + "Program");
            xEl.Add(new XElement(ns + "ID", ID));
            if (SourceFileName != null)
            {
                xEl.Add(new XElement(ns + "SourceFileName", SourceFileName));
            }
            if (Commands != null && Commands.Count > 0)
            {
                foreach (var item in Commands)
                {
                    xEl.Add(item.ToXml("Commands"));
                }
            }
            return xEl;
        }
    }
}

