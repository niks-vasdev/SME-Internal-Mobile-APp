using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Result
    {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public object ResponseData { get; set; }
    }
}
