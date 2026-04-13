using Home360.Domain.Entities;

namespace Home360.Application.DTOs
{
    public class RoleAccessManagerResponse
    {
        public int RoleAccessManagerId { get; set; }
        public int RoleId { get; set; }
        public int ScreenId { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDeactivate { get; set; }
        public virtual RoleMaster RoleMaster { get; set; }
        public virtual ScreenMaster ScreenMaster { get; set; }
    }
}
