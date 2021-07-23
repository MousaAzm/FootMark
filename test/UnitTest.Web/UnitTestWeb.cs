using FootMark.Domain.Entities.Users;
using FootMark.Web.Areas.Admin.Controllers;
using FootMark.Web.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Web
{
    public class UnitTestWeb
    {
        [Fact]
        public void RegisterUserTest()
        {
            AppUser user = new AppUser();
            user.FirstName = "testUser1";
            user.LastName = "testUser2";

            Assert.Equal("testUser1", user.FirstName);
            Assert.Equal("testUser2", user.LastName);

        }

        //[Fact]
        //public async Task UserControllerTest_ByUsersServices_ReturnsAViewResult()
        //{
        //    // Arrange
        //    List<AppUser> users = new List<AppUser>()
        //    {
        //        new AppUser
        //        {   Id = "c343tv4sdgs43",
        //            FirstName = "testuser1",
        //            Email = "test1@gmail.com"
        //        },
        //          new AppUser
        //        {
        //            Id = "c343tvfj4sdgs43",
        //            FirstName = "testuser2",
        //            Email = "test2@gmail.com"
        //        },
        //            new AppUser
        //        {   Id = "c343tv4sdgshefh43",
        //            FirstName = "testuser3",
        //            Email = "test3@gmail.com"
        //        },
        //    };

        //    var mockUserService = new Mock<IUserService>();
        //    mockUserService.Setup(p => p.GetAllAsync()).ReturnsAsync(users);
        //    var controller = new UsersController(mockUserService.Object);
        //    // Act
        //    var result = await controller.Index();

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    Assert.NotNull(result);
        //    var model = Assert.IsAssignableFrom<IEnumerable<UsersViewModel>>(viewResult.ViewData.Model);
        //    Assert.Equal(3, model.Count());
        //}
    }
}
