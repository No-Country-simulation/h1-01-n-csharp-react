
namespace JustinaBack.Models
{
    public class AddressEF : IPublicKeyEntity, IDisplayNameEntity, IAuditEntity
    {
        public int Id { get; set; }
        public string? StreetName { get; set; }
        public string? ExtNumber { get; set; }
        public string? IntNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? References { get; set; }
        public string? State { get; set; }
        public string? Municipality { get; set; }
        public string? Suburb { get; set; }
        public bool? IsMainAddress { get; set; }        
        #region IPublicKeyEntity
        public Guid EntityPublicKey { get; set; }
        #endregion

        #region IDisplayNameEntity
        public string? DisplayName { get; set; }
        #endregion

        #region IAuditEntity
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? Deleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? Locked { get; set; }
        public int? LockedBy { get; set; }
        #endregion

        #region IImageEntity
        public string? ImageUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        #endregion

        public string FullAddress
        {
            get
            {
                var fullAddress = StreetName;
                fullAddress += String.IsNullOrEmpty(ExtNumber) ? "" : " No. " + ExtNumber;
                fullAddress += String.IsNullOrEmpty(IntNumber) ? "" : " No. interior " + IntNumber;
                fullAddress += String.IsNullOrEmpty(ExtNumber) ? "" : " CP " + ZipCode;
                return fullAddress;
            }
        }

    }
}
