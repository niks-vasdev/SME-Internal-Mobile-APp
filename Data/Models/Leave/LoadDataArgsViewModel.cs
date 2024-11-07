using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class LoadDataArgsViewModel
    {
        public int Skip { get; set; } = 0;
        public int Top { get; set; } = 10;
        public string Sort { get; set; } = "";
        public List<FilterParameterViewModel> Parameter { get; set; }
    }
}
