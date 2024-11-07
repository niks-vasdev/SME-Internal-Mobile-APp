using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Employee
{
    public interface IEmployeeService
    {
  
        Task<GenericResponse<List<EmployeeDesignationData>>> GetAllEmployeeAndDesignation(bool isArabic);
    
        Task<GenericResponse<EmployeeDesignationData>> GetAllEmployeeDesignationData(bool arabic);
      
    }
}
