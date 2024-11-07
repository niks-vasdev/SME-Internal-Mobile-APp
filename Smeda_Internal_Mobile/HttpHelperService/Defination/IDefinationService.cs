using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.Defination
{
	public interface IDefinationService
	{
		Task<Result> InsertDataIntoDatabase(List<DefinationViewModel> villageData);
		Task<List<DefinationViewModel>> GetGender();
		Task<List<DefinationViewModel>> GetGrade();
		Task<List<DefinationViewModel>> GetGovernate();
		Task<List<DefinationViewModel>> GetVillage();
		Task<List<DefinationViewModel>> GetDesignation();
		//Task<List<TrainingCoursesDefinationViewModel>> GetDesignations();
		Task<List<DefinationViewModel>> GetDepartment();
		Task<GenericResponse<List<DefinationViewModel>>> GetDepartmentData();
		Task<List<DefinationViewModel>> GetSection(Guid departmentId);
		Task<List<DefinationViewModel>> GetSectionData();
		//Task<List<TrainingCoursesDefinationViewModel>> GetDepartments();
		//Task<List<EventCalendarDefinationViewModel>> GetGrades();
		Task<List<DefinationViewModel>> GetMaritalStatus();
		Task<List<DefinationViewModel>> GetSurname();
		Task<List<DefinationViewModel>> GetEmployeeType();
		Task<List<DefinationViewModel>> GetReligion();
		Task<List<DefinationViewModel>> GetTrainingType();
		Task<List<DefinationViewModel>> GetEmployeeTerm();

		Task<List<DefinationViewModel>> GetLeaveTypes();

		Task<List<DefinationViewModel>> GetNationality();
		Task<List<DefinationViewModel>> GetEntity();
		//Task<List<ActionViewModel>> GetAction(bool isArabic);
		//Task<List<IdentityRole>> GetRoles();
		//Task<List<RoleDataViewModel>> GetRoles(bool isArabic);
		Task<List<DefinationViewModel>> GetParentAuthority();
		Task<List<DefinationViewModel>> GetActive();

		Task<List<DefinationViewModel>> GetAllVehicleType();
		//Task<List<VehicleModelViewModel>> GetAllVehicleModel();
		Task<List<DefinationViewModel>> GetAllStatus();
		Task<List<DefinationViewModel>> GetAllRequestType();
		Task<List<DefinationViewModel>> GetAllSalaryStatementType();
		Task<List<DefinationViewModel>> GetAllLevelOfDegree();
		Task<List<DefinationViewModel>> GetAllDegreeStatus();
		Task<List<DefinationViewModel>> GetAllBudgetTypes();
		Task<List<DefinationViewModel>> GetAllAccountNumberType();
		//Task<List<AccountNumberViewModel>> GetAccountNumber(Guid accountTypeId);
		//Task<List<AccountNumberViewModel>> GetAllAccountNumber();
		Task<GenericResponse<List<DefinationViewModel>>> GetDispatchCategory();
		Task<GenericResponse<List<DefinationViewModel>>> GetDispatchType();
		Task<GenericResponse<List<DefinationViewModel>>> GetDispatchRequirement();
		Task<GenericResponse<List<DefinationViewModel>>> GetTransferData();
		Task<GenericResponse<List<DefinationViewModel>>> GetWilayat(Guid id);
		Task<GenericResponse<List<DefinationViewModel>>> GetWilayatData();
		Task<GenericResponse<List<DefinationViewModel>>> GetDirectorateData();
	}
}
