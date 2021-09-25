using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Modules
{
    class IComboBoxEditItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string FormatNumber { get; set; }
        public string ColumnRuleName { get; set; }
        public string PercentageRuleName { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
