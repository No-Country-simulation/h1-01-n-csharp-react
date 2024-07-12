
namespace JustinaBack.Models
{
    public class ContactEF : IPublicKeyEntity, IDisplayNameEntity, IAuditEntity, IImageEntity
    {
        public int Id { get; set; }
        public int? ContactTypeId { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? BillingName { get; set; }
        public string? RFC { get; set; }
        public string? CURP { get; set; }
        public bool? IsMainContact { get; set; }
        public string? Email { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? Birthdate { get; set; }
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

        #region EF                
        public List<AddressEF> Addresses { get; set; }
        public List<PhoneEF> Phones { get; set; }
        #endregion
        public string FullName
        {
            get
            {
                var fullName = FirstName;
                fullName += String.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName;
                fullName += " " + FirstLastName + " " + SecondLastName;
                return String.IsNullOrEmpty(fullName.Trim()) ? String.Empty : fullName.Trim();
            }
        }

    }
}
