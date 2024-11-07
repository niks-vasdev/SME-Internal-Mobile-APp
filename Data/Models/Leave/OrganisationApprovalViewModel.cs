namespace Data.Models.Leave
{
    public class OrganisationApprovalViewModel
    {
        public Guid Id { get; set; }
        public Guid? OrganisationId { get; set; }
        public Guid? ActiveApprovarId { get; set; }
        public string? RoleId { get; set; }
        public string Role { get; set; }
        public int Priority { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}