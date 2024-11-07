using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class HolidayViewModel
    {
        public Guid? Id { get; set; }
        [Required]
        public string HolidayName { get; set; }

        [Required(ErrorMessage = "From Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
