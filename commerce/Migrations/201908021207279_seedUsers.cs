namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2bea3c97-e053-4293-97cd-250a4a40425b', N'guest@ecommerce.com', 0, N'AJU+dgMZvtQxDtoZ93GtA9Ku3PkZTSOK96IgvxpeEpqWosjyC7AGl4ZiwfrM0oDpzg==', N'8f07bfba-aa85-450f-8cca-e319cfc7b77d', NULL, 0, 0, NULL, 1, 0, N'guest@ecommerce.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7b2d254e-3014-4064-8712-22718b54cbaf', N'productsManger@commerce.com', 0, N'ABdkmduHAl4iFJSyh0yTDwyCfruWYrciExAlr99MvMvWxYO6eF/h0vN2elK6rNEhiw==', N'f2f9e4ab-b93f-4f05-ab35-79f64fa01dfd', NULL, 0, 0, NULL, 1, 0, N'productsManger@commerce.com')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e962b951-ac15-4076-982d-1d79641dab92', N'CanMangeProducts')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7b2d254e-3014-4064-8712-22718b54cbaf', N'e962b951-ac15-4076-982d-1d79641dab92')

");
        }

        public override void Down()
        {
        }
    }
}
