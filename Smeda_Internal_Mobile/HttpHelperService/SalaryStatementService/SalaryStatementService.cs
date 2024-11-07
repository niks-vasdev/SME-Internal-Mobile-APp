using Data.Models;
using Data.Models.Leave;
using Data.Models.SalaryStatementService;
using Microsoft.Extensions.Configuration;
using SmedaInternalMobile.ApiManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmedaInternalMobile.HttpHelperService.SalaryStatementService
{
	public class SalaryStatementService : ISalaryStatementService
	{
		private readonly IConfiguration _configuration;
		private readonly IApiManager _apiManager;
		public SalaryStatementService(IConfiguration configuration, IApiManager apiManager)
		{
			_apiManager = apiManager;
			_configuration = configuration;

		}
		public async Task<GenericResponse<Guid>> AddSalaryStatement(SalaryStatementViewModel salaryStatementViewModel)
		{
			try
			{
				var response = await _apiManager.PostAsync<GenericResponse<Guid>>(_configuration["BaseUrl"] + "SalaryStatement/AddSalaryStatement", salaryStatementViewModel);
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<Guid>() { Success = false, Error = ex.Message };
			}
		}

		public async Task<GenericResponse<List<SalaryStatementHistoryViewModel>>> GetAllSalaryStatement(bool isArabic)
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<SalaryStatementHistoryViewModel>>>(_configuration["BaseUrl"] + $"SalaryStatement/GetAllSalaryStatement/{isArabic}");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<SalaryStatementHistoryViewModel>> { Success = false, Error = ex.Message };
			}
		}
		public async Task<GenericResponse<List<SalaryStatementHistoryViewModel>>> ApproverSalaryStatement(bool isArabic)
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<SalaryStatementHistoryViewModel>>>(_configuration["BaseUrl"] + $"SalaryStatement/ApproverSalaryStatement/{isArabic}");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<SalaryStatementHistoryViewModel>> { Success = false, Error = ex.Message };
			}
		}
		public async Task<GenericResponse<SalaryStatementHistoryViewModel>> GetSalaryStatementById(Guid id, bool isArabic)
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<SalaryStatementHistoryViewModel>>(_configuration["BaseUrl"] + $"SalaryStatement/GetSalaryStatementById/{id}/{isArabic}");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<SalaryStatementHistoryViewModel> { Success = false, Error = ex.Message };
			}
		}
		public async Task<GenericResponse<string>> SalaryStatementAction(SalaryStatementHistoryViewModel salaryStatement)
		{
			try
			{
				var response = await _apiManager.PostAsync<GenericResponse<string>>(_configuration["BaseUrl"] + "SalaryStatement/SalaryStatementAction", salaryStatement);
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<string> { Success = false, Error = ex.Message };
			}
		}

		public async Task<GenericResponse<List<StatusViewModal>>> GetStatusDetail(Guid id, bool isArabic)
		{
			try
			{
				var response = await _apiManager.GetAsync<GenericResponse<List<StatusViewModal>>>(_configuration["BaseUrl"] + $"SalaryStatement/GetStatusDetail/{id}/{isArabic}");
				return response;
			}
			catch (Exception ex)
			{
				return new GenericResponse<List<StatusViewModal>> { Success = false, Error = ex.Message };
			}
		}
	}
}
