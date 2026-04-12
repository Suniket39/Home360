namespace Home360.Domain.Entities
{
    public class ScreenMaster : CommonEntity
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string ScreenCode { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string RoutingURL { get; set; }
        public string MenuIcon { get; set; }
        public int Sequence { get; set; }
        public virtual ICollection<RoleAccessManager> RoleAccessManagers { get; set; }
    }
}
