namespace Data.Models.Scholarship
{
    public interface ICommonProperty
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}