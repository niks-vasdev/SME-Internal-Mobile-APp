using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
	public enum DefinationTablesEnum
	{
		QuestionType = 1,
		Designation = 2,
		Village = 3,
		Governate = 4,
		SurveyStatus = 5,
		Department = 6,
		Religion = 7,
		EmployeeType = 8,
		Grade = 9,
		MaritalStatus = 10,
		Nationality = 11,
		Surname = 12,
		Gender = 13
	}

	public enum StatusEnum
	{
		Published = 1,
		Draft = 2,
		Expired = 3
	}

	public enum Language
	{ 
		English = 1,
		Arabic 
	}

    public enum LeaveStatus
	{
		Approved = 1,
		Rejected = 2,
		Pending = 3
	}

	public enum ServiceApprover
	{
		TeamLeader = 1,
		Manager = 2,
		GM = 3,
		Committee = 4,
		HR = 5
	}

	public enum ServiceType
	{
		[Display(Name = "End of Service")]
		EndOfService = 1,
		[Display(Name = "Salary Statement Service")]
		SalaryStatement = 2
	}

	public enum RolesName
	{
		Admin,
		Manager,
		HR,
		CEO
	}

	public enum ContractStatus
	{
		Approved = 1,
		Rejected = 2,
		Modify = 3,
		Pending = 4
	}

	public enum StockStatus
	{
		Approved = 1,
		Rejected = 2,
		Edit = 3,
		Released = 4,
		Pending = 5
	}

	public enum EditStatus
	{
		Modified = 1,
		Modify = 2
	}
	public enum RecurringJobEnum
	{
		Monthly = 1, Yearly = 2
	}
	public enum LeaveOperation
	{
		Decremented = 1, Incremented = 2
	}
	public enum NotificationType
	{
		Permissions = 1, Services = 2, NewsAnnouncement = 3, Role = 4, All = 5
	}
}
