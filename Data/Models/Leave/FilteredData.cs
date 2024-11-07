using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class FilteredData<T>
    {
        public List<T> FilterData { get; set; }
        public int Count { get; set; }
    }
}
