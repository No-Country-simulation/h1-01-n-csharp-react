using Microsoft.Data.SqlClient;
using System.Data;


namespace JustinaBack.Models
{
    public class BaseDAC
    {
        public SqlTransaction Transaction { get; set; }
        public FrameworkDatabase Database;

        #region PrivateConstString
        public const string COLUMN_PUBLIC_KEY = "public_key";
        public const string PARAMETER_PUBLIC_KEY = "@" + COLUMN_PUBLIC_KEY;

        public const string COLUMN_DISPLAY_NAME = "display_name";
        public const string PARAMETER_DISPLAY_NAME = "@" + COLUMN_DISPLAY_NAME;

        public const string COLUMN_CREATED = "created";
        public const string PARAMETER_CREATED = "@" + COLUMN_CREATED;

        public const string COLUMN_CREATED_BY = "created_by";
        public const string PARAMETER_CREATED_BY = "@" + COLUMN_CREATED_BY;

        public const string COLUMN_MODIFIED = "modified";
        public const string PARAMETER_MODIFIED = "@" + COLUMN_MODIFIED;

        public const string COLUMN_MODIFIED_BY = "modified_by";
        public const string PARAMETER_MODIFIED_BY = "@" + COLUMN_MODIFIED_BY;

        public const string COLUMN_DELETED = "deleted";
        public const string PARAMETER_DELETED = "@" + COLUMN_DELETED;

        public const string COLUMN_DELETED_BY = "deleted_by";
        public const string PARAMETER_DELETED_BY = "@" + COLUMN_DELETED_BY;

        public const string COLUMN_LOCKED = "locked";
        public const string PARAMETER_LOCKED = "@" + COLUMN_LOCKED;

        public const string COLUMN_LOCKED_BY = "locked_by";
        public const string PARAMETER_LOCKED_BY = "@" + COLUMN_LOCKED_BY;

        public const string COLUMN_VALIDATED = "validated";
        public const string PARAMETER_VALIDATED = "@" + COLUMN_VALIDATED;

        public const string COLUMN_VALIDATED_BY = "validated_by";
        public const string PARAMETER_VALIDATED_BY = "@" + COLUMN_VALIDATED_BY;

        public const string COLUMN_IMAGE_URL = "image_url";
        public const string PARAMETER_IMAGE_URL = "@" + COLUMN_IMAGE_URL;

        public const string COLUMN_THUMBNAIL_URL = "thumbnail_url";
        public const string PARAMETER_THUMBNAIL_URL = "@" + COLUMN_THUMBNAIL_URL;

        public const string COLUMN_DESCRIPTION = "description";
        public const string PARAMETER_DESCRIPTION = "@" + COLUMN_DESCRIPTION;


        public const string PARAMETER_CREATED_BY_ID = "(SELECT [user_id] FROM [security].[user] WHERE [public_key] = @created_by)";

        public const string PARAMETER_MODIFIED_BY_ID = "(SELECT [user_id] FROM [security].[user] WHERE [public_key] = @modified_by)";

        public const string PARAMETER_DELETED_BY_ID = "(SELECT [user_id] FROM [security].[user] WHERE [public_key] = @deleted_by)";

        public const string PARAMETER_LOCKED_BY_ID = "(SELECT [user_id] FROM [security].[user] WHERE [public_key] = @locked_by)";
        #endregion

        public Guid SecurityInfoPublicKey(ISecurityUserInfo securityUserInfo)
        {
            Guid guid = Guid.Empty;

            if (securityUserInfo != null && !String.IsNullOrEmpty(securityUserInfo.PublicKey))
                guid = Guid.Parse(securityUserInfo.PublicKey);

            return guid;
        }

        public void AddAuditableParameters(SqlCommand command, IAuditable auditable)
        {
            Database.AddInParameter(command, PARAMETER_CREATED, DbType.DateTime, auditable.Created);
            Database.AddInParameter(command, PARAMETER_CREATED_BY, DbType.Guid, SecurityInfoPublicKey(auditable.CreatedBy));
            Database.AddInParameter(command, PARAMETER_MODIFIED, DbType.DateTime, auditable.Modified);
            Database.AddInParameter(command, PARAMETER_MODIFIED_BY, DbType.Guid, SecurityInfoPublicKey(auditable.ModifiedBy));
            Database.AddInParameter(command, PARAMETER_DELETED, DbType.DateTime, auditable.Deleted);
            Database.AddInParameter(command, PARAMETER_DELETED_BY, DbType.Guid, SecurityInfoPublicKey(auditable.DeletedBy));
            Database.AddInParameter(command, PARAMETER_LOCKED, DbType.DateTime, auditable.Locked);
            Database.AddInParameter(command, PARAMETER_LOCKED_BY, DbType.Guid, SecurityInfoPublicKey(auditable.LockedBy));
        }

        public void AddValidatableAsParameters(SqlCommand command, IValidatable validatable)
        {
            Database.AddInParameter(command, PARAMETER_VALIDATED, DbType.DateTime, validatable.Validated);
            Database.AddInParameter(command, PARAMETER_VALIDATED_BY, DbType.Guid, SecurityInfoPublicKey(validatable.ValidatedBy));
        }

        public void AddAuditableDeleteParameters(SqlCommand command, IAuditable auditable)
        {
            Database.AddInParameter(command, PARAMETER_MODIFIED, DbType.DateTime, auditable.Modified);
            Database.AddInParameter(command, PARAMETER_MODIFIED_BY, DbType.Guid, SecurityInfoPublicKey(auditable.ModifiedBy));
            Database.AddInParameter(command, PARAMETER_DELETED, DbType.DateTime, auditable.Deleted);
            Database.AddInParameter(command, PARAMETER_DELETED_BY, DbType.Guid, SecurityInfoPublicKey(auditable.DeletedBy));
        }
    }
}
