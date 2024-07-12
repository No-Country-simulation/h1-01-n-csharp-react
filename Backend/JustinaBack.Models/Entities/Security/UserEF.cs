

using Microsoft.AspNetCore.Identity;

namespace JustinaBack.Models
{
    public class UserEF : IdentityUser<int>, IPublicKeyEntity, IAuditEntity
    {
        public override int Id { get; set; }

        public int? LoginTypeId { get; set; }
        public string LoginTypeDisplay
        {
            get
            {
                if (LoginTypeId == null)
                    return LoginType.Unknown.ToString();

                return ((LoginType)LoginTypeId!).ToString();
            }
        }

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

        #region EF
        public ContactEF Contact { get; set; }
        #endregion
    }

    public enum LoginType
    {
        Unknown = 0,
        Email = 1,
        Google = 2,
        Facebook = 3,
        Apple = 4,
    }
}
