namespace DeppoControlBackend.Entities.Dto
{
    public class GetLicenceDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VKN_TCKN { get; set; } = string.Empty;
        public string LicenceKey { get; set; } = string.Empty; 
    }
}
