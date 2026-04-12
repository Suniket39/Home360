namespace Home360.Application.DTOs
{
    public class ScreenMasterRequest
    {
        public int ScreenId { get; set; }
        public required string ScreenName { get; set; }
        public required string ScreenCode { get; set; }
        public required string MenuName { get; set; }
        public int ParentId { get; set; }
        public string RoutingURL { get; set; }
        public string MenuIcon { get; set; }
        public int Sequence { get; set; }
        public bool IsActive { get; set; }
    }

    public class ScreenMasterResponse : CommonEntityModel
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string ScreenCode { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string RoutingURL { get; set; }
        public string MenuIcon { get; set; }
        public int Sequence { get; set; }
    }
}
