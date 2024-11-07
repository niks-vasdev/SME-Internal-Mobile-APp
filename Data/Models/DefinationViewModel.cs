using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
	public class DefinationViewModel
	{
		public Guid? Id { get; set; }
		public string TitleEn { get; set; }
		public string TitleAr { get; set; }
		public bool IsDeleted { get; set; }
		public Guid? ReferenceId { get; set; }
	}
}
