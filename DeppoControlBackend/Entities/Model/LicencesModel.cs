namespace DeppoControlBackend.Entities.Model
{
    public class LicencesModel
    {
        public int Id { get; set; }
        public Guid? LicenceKey { get; set; }
        public string ProductKey { get; set; } = string.Empty; 
        public string CustomerName { get; set; } = string.Empty;
        public string VKN_TCKN { get; set; } = string.Empty;
        public string LicenceType { get; set; } = string.Empty;
        public string LicencedModules { get; set; } = string.Empty;
        public int? UserCount { get; set; }
        public bool Active { get; set; }
        public DateTime? LastActivationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DistributorId { get; set; }
    }
}
