using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonWebsite.Data.Entities
{
    public class Setting
    {
        public string Key { get; set; }
        public string Notes { get; set; }
        public string Value { get; set; }

        public Setting()
        {
        }

        public Setting(string key, string value, string notes)
        {
            Key = key;
            Value = value;
            Notes = notes;
        }
    }
}