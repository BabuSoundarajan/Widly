namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4eb508e6-3d13-432b-8eee-bd971026798f', N'babusaran11@gmail.com', 0, N'AP7P7+Xb+W3Uj+h+/+iMO4ND1U9YKUDDn+XUPE4CYfPExjJbr69mjU6jtYKRw3+1cg==', N'acee10b5-6353-4460-8612-6efa178167c8', NULL, 0, 0, NULL, 1, 0, N'babusaran11@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b83be694-562c-4c37-8d71-89c12bab10c8', N'babusaran91@gmail.com', 0, N'AIZD2IqLb74HAjD9UnvU8ejhdpJaVhoWg0HNoffg0evcLsgvE5ihLLVHJjh0GUCrzw==', N'd8db8899-96b5-4eb4-8d2e-463bf6f8f1f1', NULL, 0, 0, NULL, 1, 0, N'babusaran91@gmail.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'672d90cb-f8a4-4bd3-a77f-2278f60ec84c', N'CanChangeMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4eb508e6-3d13-432b-8eee-bd971026798f', N'672d90cb-f8a4-4bd3-a77f-2278f60ec84c')

");
        }
        
        public override void Down()
        {
        }
    }
}
