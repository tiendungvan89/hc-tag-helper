using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperEx.Models
{
    public enum ITEM_TYPE
    {
        TEXT = 1,
        NUMERIC = 2,
        FRACTION = 3,
        SELECT = 4,
        CHECKBOX = 5,
        RADIO = 6,
        LABEL = 7
    }

    public class ItemModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public object DefaultValue { get; set; }
    }
}
