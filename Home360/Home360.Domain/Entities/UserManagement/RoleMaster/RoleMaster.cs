namespace Home360.Domain.Entities
{
    public class RoleMaster : CommonEntity
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public string? Description { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
