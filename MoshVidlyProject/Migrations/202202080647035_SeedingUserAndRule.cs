namespace MoshVidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUserAndRule : DbMigration
    {
        public override void Up()
        {
           
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'4c1378fa-0e44-4062-8114-50620d1fdd40', N'customer@gmail.com', 0, N'AMaM5WnmH2i7XYSLdTKMwwYJllRmLjf6/oosyBF+AsB4l2ZFhPoIPfRx7PqTkkwctQ==', N'dcb693a5-86e8-4057-9434-d16359e93287', NULL, 0, 0, NULL, 1, 0, N'customer@gmail.com', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'5ee71640-36da-4405-843c-04fcf49d780e', N'admin@gmail.com', 0, N'AIOxqk05m9f8LLMto5JLhRQaAeyPCZ3GFP2BZhjag5+FFHhXIY7tO6EnAZQH/wi84w==', N'6f4a5c09-4102-4867-8a56-66d8fcdb1a4e', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Discriminator]) VALUES (N'a69436aa-cc80-4e10-9df6-a19f747c0648', N'guest@gmail.com', 0, N'AG+J+PIMfA1GRnmZHWWLYimasxII15kSTt10Fb7L7k8ZiM1nEdMJMDnvDoIvHq0v9Q==', N'8294e10a-7494-40f9-86b6-abc9a414648c', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'13eae9dd-ea79-486d-9906-124f2c45d4dc', N'canManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5ee71640-36da-4405-843c-04fcf49d780e', N'13eae9dd-ea79-486d-9906-124f2c45d4dc')



");
        }
        
        public override void Down()
        {
        }
    }
}
