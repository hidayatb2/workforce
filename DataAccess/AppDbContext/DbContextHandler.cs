
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModelLayer;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;


namespace DataAccess
{
    internal sealed class DbContextHandler
    {

        internal void SetModelBuilderSettings(ModelBuilder modelBuilder)
        {
            foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationShip.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var entityTypes = modelBuilder.Model.GetEntityTypes();

            foreach (var entity in entityTypes)
            {

                var props = entity.ClrType.GetProperties().Where(x => x.IsDefined(typeof(Unique), false));
                if (props.IsNotNullOrEmpty())
                {
                    foreach (var prop in props)
                    {
                        entity.AddIndex(entity.FindProperty(prop)).IsUnique = true;
                    }
                }
            }

            foreach (var prop in entityTypes.SelectMany(x => x.GetProperties()).Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                prop.SetColumnType("DECIMAL(18, 6)");
            }
        }


        internal void SeedInitialData(ModelBuilder modelBuilder)
        {
            // SeedSecurityData(modelBuilder);
            SeedUser(modelBuilder);
        }


        private void SeedUser(ModelBuilder modelBuilder)
        {
            User user = new User
            {
                Id = Guid.Parse(userId),
                Email = "admin@yopmail.com",
                UserName = "admin",
                Salt = AppEncryption.CreateSalt(),
               PhoneNo = "8825084050",
               UserRole=UserRole.Admin,
               UserStatus=UserStatus.Active,
            };
            user.Password = AppEncryption.CreatePasswordHash("admin",user.Salt);
            modelBuilder.Entity<User>().HasData(user);
        }
        


        public const string userId = "87843532-0B93-492D-824B-68BE17A82037";

        public const string hodId = "03abd488-6472-4e9a-baee-54e654a34b6b";

        public const string departmentId = "9b7d9fd4-d81f-4b12-94e1-b9b49ef316aa";

        public const string securityProfileId = "343D6C5F-D359-4EAA-9478-2A1852EBE0F8";

        public const string securityProfileDetailId = "410F4425-EE27-461B-8EB8-63ED8A264894";

    }
}
