
namespace JustinaBack.Models;
    public interface IAuditEntity
    {
        DateTime Created { get; set; }
        int CreatedBy { get; set; }
        DateTime Modified { get; set; }
        int ModifiedBy { get; set; }
        DateTime? Deleted { get; set; }
        int? DeletedBy { get; set; }
        DateTime? Locked { get; set; }
        int? LockedBy { get; set; }
    }

    public interface IDisplayNameEntity
    {
        string? DisplayName { get; set; }
    }

    public interface IIdentifierEntity
    {
        int Id { get; set; }
    }

    public interface IImageEntity
    {
        string? ImageUrl { get; set; }
        string? ThumbnailUrl { get; set; }
    }

    public interface IPublicKeyEntity
    {
        Guid EntityPublicKey { get; set; }
    }

