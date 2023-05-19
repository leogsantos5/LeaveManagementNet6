using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(new Employee
            {
                Id = "6ea6b6e6-afb5-4c39-a617-05831df08c9e",
                Email = "leogsantos5@gmail.com",
                NormalizedEmail = "leogsantos5@gmail.com".ToUpper(),
                UserName = "leogsantos5@gmail.com",
                NormalizedUserName = "LEOGSANTOS5@GMAIL.COM",
                Name = "Leonardo Santos",
                PasswordHash = hasher.HashPassword(null, "Pterodactil123-"), 
                EmailConfirmed = true
            },
            new Employee
            {
                Id = "09fe4c69-49dc-47a9-9c50-5708b4a0fc83",
                Email = "carlafilipa206@gmail.com",
                NormalizedEmail = "carlafilipa206@gmail.com".ToUpper(),
                UserName = "carlafilipa206@gmail.com",
                NormalizedUserName = "CARLAFILIPA206@GMAIL.COM".ToUpper(),
                Name = "Carla Cunha",
                PasswordHash = hasher.HashPassword(null, "Duklind&Leunád!"),
                EmailConfirmed = true
            });
        }
    }
}