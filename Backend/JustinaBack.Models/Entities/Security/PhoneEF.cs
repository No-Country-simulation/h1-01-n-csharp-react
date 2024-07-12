

namespace JustinaBack.Models
{
    public class PhoneEF : IPublicKeyEntity, IAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public long Number { get; set; }
        public bool IsMobile { get; set; }
        public bool IsMainPhone { get; set; }
        #region IPublicKeyEntity
        public Guid EntityPublicKey { get; set; }
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
    }
}
