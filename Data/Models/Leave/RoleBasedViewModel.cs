using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Leave
{
    public class RoleBasedViewModel
    {
        public Guid? Id { get; set; }
        public string RoleName { get; set; }
        public string EntityName { get; set; }
        public string ActionName { get; set; }
    }
}
