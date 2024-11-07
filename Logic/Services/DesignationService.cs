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

    public class DesignationService 
    {
        private readonly IGenericService<DesignationRequestModel> _genericService;
        public DesignationService(IGenericService<DesignationRequestModel> genericService)
        {
            _genericService = genericService;
        }



        public async Task<List<DesignationRequestModel>> GetFilteredData(RequestType requestStatus)
        {
            List<DesignationRequestModel> allData =  _genericService.GetAll().Result.Where(r => r.RequestStatus == requestStatus).ToList();

            return allData;
            //List<DesignationRequestModel> filteredData = allData.Where(r => r.RequestStatus == requestStatus).ToList();

            //return filteredData;
        }


    }
}
