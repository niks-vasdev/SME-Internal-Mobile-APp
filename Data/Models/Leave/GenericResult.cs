using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class GenericResult<T>
    {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public object ResponseStatus { get; set; }
        public T ResponseData { get; set; }
    }
}
