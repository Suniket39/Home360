namespace Home360.Application.DTOs
{
    public class UserAccessDto
    {
        public string ScreenCode { get; set; }
        public string RoutingUrl { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDeactivate { get; set; }
    }

    public class MenuAccessDto
    {
        public string DisplayName { get; set; }
        public int ParentId { get; set; }
        public int SceenId { get; set; }
        public string MenuName { get; set; }
        public string MenuIcon { get; set; }
        public string ScreenCode { get; set; }
        public string RoutingUrl { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDeactivate { get; set; }
        public MenuAccessDto ParentMenu { get; set; }
        public List<MenuAccessDto> Children { get; set; }
    }
}
