using Data.Models;
using Data.Models.Leave;
using Data.Models.SalaryStatementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.SalaryStatementService
{
	public interface ISalaryStatementService
	{
		Task<GenericResponse<Guid>> AddSalaryStatement(SalaryStatementViewModel salaryStatementViewModel);
		Task<GenericResponse<List<SalaryStatementHistoryViewModel>>> GetAllSalaryStatement(bool isArabic);
		Task<GenericResponse<List<SalaryStatementHistoryViewModel>>> ApproverSalaryStatement(bool isArabic);
		Task<GenericResponse<SalaryStatementHistoryViewModel>> GetSalaryStatementById(Guid id, bool isArabic);
		Task<GenericResponse<string>> SalaryStatementAction(SalaryStatementHistoryViewModel salaryStatement);
		Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic);

	}
}
