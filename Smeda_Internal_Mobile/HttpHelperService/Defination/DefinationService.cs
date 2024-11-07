using Data.Models;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Defination
{
	public class DefinationService : IDefinationService
	{
		private readonly IConfiguration _configuration;
		private readonly IApiManager _apiManager;
		public DefinationService(IConfiguration configuration, IApiManager apiManager)
		{
			_configuration = configuration;
			_apiManager = apiManager;
		}
		public async Task<List<DefinationViewModel>> GetGender()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllGender");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetGrade()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllGrade");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetGovernate()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllGovernate");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetVillage()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllVillage");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetDesignation()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllDesignation1");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetDepartment()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllDepartment");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<GenericResponse<List<DefinationViewModel>>> GetDepartmentData()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetAllDepartmentData");

				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}

		public async Task<List<DefinationViewModel>> GetSection(Guid departmentId)
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + $"data/GetSection/{departmentId}");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetSectionData()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetSectionData");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetMaritalStatus()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllMaritalStatus");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetSurname()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllSurname");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetEmployeeType()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllEmployeeType");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetReligion()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllReligion");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetLeaveTypes()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetLeaveTypes");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetEmployeeTerm()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetEmployeeTerm");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetNationality()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllNationality");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		//public async Task<List<IdentityRole>> GetRoles()
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<IdentityRole>>(_configuration["BaseUrl"] + "authentication/GetRoles");

		//		return response;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		//public async Task<List<RoleDataViewModel>> GetRoles(bool isArabic)
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<RoleDataViewModel>>(_configuration["BaseUrl"] + $"authentication/GetRoles/{isArabic}");

		//		return response;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		public async Task<List<DefinationViewModel>> GetParentAuthority()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetParentAuthority");
				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetActive()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetActiveUser");
				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetEntity()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetEntity");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		//public async Task<List<ActionViewModel>> GetAction(bool isArabic)
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<ActionViewModel>>(_configuration["BaseUrl"] + $"data/GetAction/{isArabic}");

		//		return response;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		public async Task<List<DefinationViewModel>> GetAllVehicleType()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllVehicleType");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		//public async Task<List<VehicleModelViewModel>> GetAllVehicleModel()
		//{

		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<VehicleModelViewModel>>(_configuration["BaseUrl"] + "data/GetAllVehicleModel");

		//		return response;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		public async Task<List<DefinationViewModel>> GetAllStatus()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllStatus");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task<List<DefinationViewModel>> GetAllRequestType()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllRequestType");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task<List<DefinationViewModel>> GetAllSalaryStatementType()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllSalaryStatementType");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetTrainingType()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetTrainingType");

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		//public async Task<List<TrainingCoursesDefinationViewModel>> GetDesignations()
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<TrainingCoursesDefinationViewModel>>(_configuration["BaseUrl"] + "data/GetDesignations");

		//		return response;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		//public async Task<List<TrainingCoursesDefinationViewModel>> GetDepartments()
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<TrainingCoursesDefinationViewModel>>(_configuration["BaseUrl"] + "data/GetDepartments");

		//		return response;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		public async Task<List<DefinationViewModel>> GetAllLevelOfDegree()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllLevelOfDegree");
				return response;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetAllDegreeStatus()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllDegreeStatus");
				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		//public async Task<List<EventCalendarDefinationViewModel>> GetGrades()
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<EventCalendarDefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllGrade");
		//		return response;

		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}

		public async Task<List<DefinationViewModel>> GetAllBudgetTypes()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetBudgetTypes");
				return response;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		//public async Task<List<AccountNumberViewModel>> GetAccountNumber(Guid accountTypeId)
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<AccountNumberViewModel>>(_configuration["BaseUrl"] + $"data/GetAccountNumber/{accountTypeId}");
		//		return response;
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new Exception(ex.Message);
		//	}
		//}

		//public async Task<List<AccountNumberViewModel>> GetAllAccountNumber()
		//{
		//	try
		//	{
		//		var response = await _apiManager.GetAsync<List<AccountNumberViewModel>>(_configuration["BaseUrl"] + "data/GetAllAccountNumber");
		//		return response;
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new Exception(ex.Message);
		//	}
		//}


		public async Task<List<DefinationViewModel>> GetAllAccountTypes()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllAccountTypes");
				return response;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<Result> InsertDataIntoDatabase(List<DefinationViewModel> villageData)
		{
			try
			{
				var response = await _apiManager.PostAsync<Result>(_configuration["BaseUrl"] + "data/AddDefinationList", villageData);

				return response;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<DefinationViewModel>> GetAllAccountNumberType()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<DefinationViewModel>>(_configuration["BaseUrl"] + "data/GetAllAccountTypes");
				return response;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<GenericResponse<List<DefinationViewModel>>> GetDispatchCategory()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetDispatchCategory");
				return response;
			}
			catch (Exception ex)
			{

				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}

		public async Task<GenericResponse<List<DefinationViewModel>>> GetDispatchType()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetDispatchType");
				return response;
			}
			catch (Exception ex)
			{

				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}

		public async Task<GenericResponse<List<DefinationViewModel>>> GetDispatchRequirement()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetDispatchRequirement");
				return response;
			}
			catch (Exception ex)
			{

				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}
		public async Task<GenericResponse<List<DefinationViewModel>>> GetTransferData()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetTransferData");
				return response;
			}
			catch (Exception ex)
			{

				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}
		public async Task<GenericResponse<List<DefinationViewModel>>> GetWilayat(Guid id)
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + $"data/GetWilayat/{id}");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}

		public async Task<GenericResponse<List<DefinationViewModel>>> GetWilayatData()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetWilayatData");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}
		public async Task<GenericResponse<List<DefinationViewModel>>> GetDirectorateData()
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<DefinationViewModel>>>(_configuration["BaseUrl"] + "data/GetDirectorateData");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<DefinationViewModel>> { Success = false, Error = ex.Message };
			}
		}
	}
}
