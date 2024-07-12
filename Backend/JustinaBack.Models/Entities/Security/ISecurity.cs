

namespace JustinaBack.Models
{
    public interface IAuditable
    {
        DateTime Created { get; set; }
        ISecurityUserInfo CreatedBy { get; set; }
        DateTime Modified { get; set; }
        ISecurityUserInfo ModifiedBy { get; set; }
        DateTime? Deleted { get; set; }
        ISecurityUserInfo DeletedBy { get; set; }
        DateTime? Locked { get; set; }
        ISecurityUserInfo LockedBy { get; set; }
    }

    public interface IPublicKey
    {
        string PublicKey { get; set; }
    }

    public interface IDisplayName
    {
        string DisplayName { get; set; }
    }

    public interface IImageable
    {
        string ImageUrl { get; set; }
        string ThumbnailUrl { get; set; }
    }

    public interface IValidatable
    {
        DateTime? Validated { get; set; }
        ISecurityUserInfo ValidatedBy { get; set; }
    }

    public interface ISecurityUserInfo
    {
        string PublicKey { get; set; }
        string LoginName { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string ThumbnailUrl { get; set; }
    }
}
