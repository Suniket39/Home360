namespace Home360.Application.DTOs
{
    public class UserScreenAccessDto
    {
        public string ScreenCode { get; set; }
        public string RoutingUrl { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDeactivate { get; set; }
    }
}
