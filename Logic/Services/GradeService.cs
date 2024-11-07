using Data.Enums;
using Data.Models;
using Logic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class GradeService 
    {
        private readonly IGenericService<GradeRequestModel> _genericService;

        public GradeService(IGenericService<GradeRequestModel> genericService)
        {
            _genericService = genericService;
        }

        public async Task<List<GradeRequestModel>> GetFilteredData(RequestType requestStatus)
        {
            List<GradeRequestModel> allData = _genericService.GetAll().Result.Where(r => r.RequestStatus == requestStatus).ToList();
            return allData; 

            //List<GradeRequestModel> filteredData = allData.Where(r => r.RequestStatus == requestStatus).ToList();

            //return filteredData;
        }
    }

}
