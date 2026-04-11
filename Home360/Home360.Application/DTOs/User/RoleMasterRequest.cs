namespace Home360.Application.DTOs
{
    public class RoleMasterRequest : CommonEntityModel
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public string? Description { get; set; }
    }

    public class RoleMasterResponse : CommonEntityModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; set; }
    }
}
