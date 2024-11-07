using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.DropDown
{
    public class DropDownData
    {
        List<DropDownModel> VehicleType = new List<DropDownModel>()
        {
            new DropDownModel() {Id= new Guid("a44ac798-1b0b-41e0-8f5d-36f090f6bea9"),Name="BMW" },
            new DropDownModel() {Id= new Guid("b5657662-2b96-480c-99d8-e138430917da"),Name = "Mercedes" },
            new DropDownModel() {Id= new Guid("75c702f6-ea6f-45bb-b2f4-dbd732d2102f"),Name="Izusu" },
            new DropDownModel() {Id= new Guid("b2157c98-08f2-4abe-8544-6752b312fc90"),Name = "Land Rover" },
            new DropDownModel() {Id= new Guid("57da4798-9c56-4a18-a445-e499fec96041"),Name="Range Rover" }
        };

        List<DropDownModel> Models = new List<DropDownModel>()
        {
            new DropDownModel() {Id= new Guid("a44ac798-1b0b-41e0-8f5d-36f054f6bea9"),Name="Sports" },
            new DropDownModel() {Id= new Guid("b5657662-2b96-480c-99d8-e138a40917da"),Name = "Top" },
            new DropDownModel() {Id= new Guid("f4c702f6-ea6f-45bb-b2f4-dbd732d2102f"),Name="Base" },
            new DropDownModel() {Id= new Guid("84d57c98-08f2-4abe-8544-6752b312fc90"),Name = "XT" },
        };

        List<DropDownModel> Status = new List<DropDownModel>()
        {
            new DropDownModel() {Id= new Guid("a44ac798-1b0b-41e0-8f5d-36f054f6bea9"),Name="Active" },
            new DropDownModel() {Id= new Guid("b5657662-2b96-480c-99d8-e138a40917da"),Name = "UnActive" },
        };

        List<DropDownModel> AccountNo = new List<DropDownModel>()
        {
            new DropDownModel() {Id= Guid.NewGuid(),Name="2015524200001" },
            new DropDownModel() {Id= Guid.NewGuid(),Name = "245640025121" },
            new DropDownModel() {Id= Guid.NewGuid(),Name = "545003464654" },
            new DropDownModel() {Id= Guid.NewGuid(),Name = "75435434152" },
            new DropDownModel() {Id= Guid.NewGuid(),Name = "1005743545674" },
        };


        List<DropDownModel> applicationType = new List<DropDownModel>()
        {
            new DropDownModel(){ Id = new Guid("1eccad8e-a416-40b2-95e4-399bad256898"), Name = "Education Payment", ArabicName = "تحمل تكاليف دراسية - منحة دراسية بعد استكمال المؤهل"},
            new DropDownModel(){ Id = new Guid("422c8d11-0b37-436c-ad31-099a9b85d202"), Name = "Scholarship payment", ArabicName = "طلب الحصول على منحة دراسية"},

        };








        List<DropDownModel> typeOfRequest = new List<DropDownModel>()
        {
            new DropDownModel(){ Id = new Guid("80a65b81-eaeb-41d3-95aa-d94c159a3ba4"), Name = "During Work Hours", ArabicName = "خلال ساعات العمل"},
            new DropDownModel(){ Id = new Guid("e685b95b-624e-41ef-9b37-a3580f2b62f0"), Name = "After Working Hours", ArabicName = "بعد ساعات العمل"},

        };

        public async Task<List<DropDownModel>> GetVehicleList()
        {
            return await Task.FromResult(VehicleType);
        }

        public async Task<List<DropDownModel>> GetAccountNo()
        {
            return await Task.FromResult(AccountNo);
        }
        public async Task<List<DropDownModel>> GetModels()
        {
            return await Task.FromResult(Models);
        }
        public async Task<List<DropDownModel>> GetStatus()
        {
            return await Task.FromResult(Status);
        }

        public async Task<List<DropDownModel>> GetApplicationType()
        {
            return await Task.FromResult(applicationType);
        }

        public async Task<List<DropDownModel>> GetTypeOfRequestType()
        {
            return await Task.FromResult(typeOfRequest);
        }
    


  

      

    }
}
