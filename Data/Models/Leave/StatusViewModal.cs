using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class StatusViewModal
    {
        public string? Role { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public string? Document { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
