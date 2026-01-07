namespace Home360.API.Core.Helper
{
    public static class JwtHelper
    {
        private static readonly string _tokenSecrete = "Put_Your_Secrete_Token_Here";

        public static string GetSecrete()
        {
            return _tokenSecrete;
        }
    }
}
