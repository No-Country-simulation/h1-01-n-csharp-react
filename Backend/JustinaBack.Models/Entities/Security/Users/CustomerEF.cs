
namespace JustinaBack.Models;
    public class CustomerEF : IPublicKeyEntity, IAuditEntity
    {
        public int Id { get; set; }
        public int? UserEFId { get; set; }
        public UserEF? User { get; set; }                                    
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

