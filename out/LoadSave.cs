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
    public class LoadSave : TransformBase
    {
        /// <summary>
        /// The name of the file
        /// <summary>
        public string FileName { get; set; }
        /// <summary>
        /// The name of the file format, or the software package that works with the file.
        /// <summary>
        public string Software { get; set; }
        /// <summary>
        /// Indicates whether the file format is compressed.
        /// <summary>
        public bool IsCompressed { get; set; }
        /// <summary>
        /// A list of names of variables that will be dropped during the save operation.
        /// <summary>
        public List<string> DropVariables { get; set; } = new List<string>();
        public bool ShouldSerializeDropVariables() { return DropVariables.Count > 0; }
        /// <summary>
        /// A list of names of variables that will be kept during the save operation. All other variables will be dropped.
        /// <summary>
        public List<string> KeepVariables { get; set; } = new List<string>();
        public bool ShouldSerializeKeepVariables() { return KeepVariables.Count > 0; }
        /// <summary>
        /// A list of variables that will be renamed as part of the save operation.
        /// <summary>
        public List<RenamePair> RenameVariables { get; set; } = new List<RenamePair>();
        public bool ShouldSerializeRenameVariables() { return RenameVariables.Count > 0; }

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
            if (FileName != null)
            {
                xEl.Add(new XElement(ns + "FileName", FileName));
            }
            if (Software != null)
            {
                xEl.Add(new XElement(ns + "Software", Software));
            }
            xEl.Add(new XElement(ns + "IsCompressed", IsCompressed));
            if (DropVariables != null && DropVariables.Count > 0)
            {
                xEl.Add(
                    from item in DropVariables
                    select new XElement(ns + "DropVariables", item.ToString()));
            }
            if (KeepVariables != null && KeepVariables.Count > 0)
            {
                xEl.Add(
                    from item in KeepVariables
                    select new XElement(ns + "KeepVariables", item.ToString()));
            }
            if (RenameVariables != null && RenameVariables.Count > 0)
            {
                foreach (var item in RenameVariables)
                {
                    xEl.Add(item.ToXml("RenameVariables"));
                }
            }
            return xEl;
        }
    }
}

