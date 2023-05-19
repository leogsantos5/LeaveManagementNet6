using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "77eae6e4-0be1-4571-880d-3dc46a5d7b68", // Leo
                    UserId = "6ea6b6e6-afb5-4c39-a617-05831df08c9e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "7a50dfae-598c-4aaa-95a1-51afdfeecfe2", // Carla
                    UserId = "09fe4c69-49dc-47a9-9c50-5708b4a0fc83"
                });
        }
    }
}