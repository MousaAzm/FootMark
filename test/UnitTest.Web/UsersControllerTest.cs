using FluentValidation.Results;
using FootMark.Application.Interfaces;
using FootMark.Application.ViewModels;
using FootMark.Domain.Commands;
using FootMark.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Web
{
    public class UsersControllerTest
    {
        private readonly Mock<IUserService> _mockService;
        private readonly UsersController _controller;

        public UsersControllerTest()
        {
            _mockService = new Mock<IUserService>();
            _controller = new UsersController(_mockService.Object);
        }
  

        [Fact]
        public async Task Index_ActionExecutes_ReturnsAListOfUsers()
        {
            var result = await _controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Get_Index_ActionExecutes_ReturnsNumberOfUsers()
        {
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<UserViewModel>() 
            {   new UserViewModel(), 
                new UserViewModel(),
                new UserViewModel()         
            });

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var users = Assert.IsType<List<UserViewModel>>(viewResult.Model);
            Assert.Equal(3, users.Count);
        }

        [Fact]
        public async Task Get_Details_ActionExecutes_ReturnsNotFound_WhenUserIdIsNull()
        {                    
            var result = await _controller.Details(id:null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Details_ActionExecutes_ReturnsNotFound_WhenUserIsNull()
        {
            var userId = Guid.NewGuid();
            _mockService.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync((UserViewModel)null);

            var result = await _controller.Details(userId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Details_ActionExecutes_ReturnsViewResult_WithUserViewModel()
        {
            var userId = Guid.NewGuid();
            var user = new UserViewModel { Id = userId , Name = "User_1", Email = "User1@gmail.com" };
            _mockService.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
 
            var result = await _controller.Details(userId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<UserViewModel>(viewResult.ViewData.Model);
            Assert.Equal("User_1", model.Name);
            Assert.Equal("User1@gmail.com", model.Email);
            Assert.Equal(userId, model.Id);

        }

        [Fact]
        public void Get_Create_ActionExecutes_ReturnsView()
        {
            var result =  _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Post_Create_ActionExecutes_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "The Name is Required");
            var user = new UserViewModel { Email = "User1@gmail.com" };

            var result = await _controller.Create(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testUser = Assert.IsType<UserViewModel>(viewResult.Model);
            Assert.Equal(user.Email, testUser.Email);
            
        }

        [Fact]
        public async Task Post_Create_ActionExecutes__CreateEmployeeNeverExecutes()
        {
            _controller.ModelState.AddModelError("Name", "The Name is Required");
            var user = new UserViewModel { Email = "User1@gmail.com" };

            await _controller.Create(user);

            _mockService.Verify(x => x.AddAsync(It.IsAny<UserViewModel>()), Times.Never);

        }

        [Fact]
        public async Task Post_Create_ActionExecutes_ReturnsWhenANewUserAdded()
        {
            UserViewModel user = null;

            _mockService.Setup(u => u.AddAsync(It.IsAny<UserViewModel>()))
                .Callback<UserViewModel>(m => user = m);
            var newUser = new UserViewModel {Id = Guid.NewGuid(), Name = "User_1", Email = "User1@gmail.com" };

            await _controller.Create(newUser);
       
            Assert.Equal(user.Name, newUser.Name);
            Assert.Equal(user.Email, newUser.Email);
        }

        [Fact]
        public async Task Post_Create_ActionExecuted_RedirectsToIndexAction()
        {
            var user = new UserViewModel { Name = "User_1", Email = "User1@gmail.com" };

            var result = await _controller.Create(user);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Get_Edit_ActionExecutes_ReturnsNotFound_WhenUserIdIsNull()
        {
            var result = await _controller.Edit(id: null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Edit_ActionExecutes_ReturnsNotFound_WhenUserIsNull()
        {
            var userId = Guid.NewGuid();
            _mockService.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync((UserViewModel)null);

            var result = await _controller.Edit(userId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Edit_ActionExecutes_ReturnsView_ForEditUserViewModel()
        {
            var userId = Guid.NewGuid();
            var user = new UserViewModel { Id = userId, Name = "User_1", Email = "User1@gmail.com" };
            _mockService.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);

            var result = await _controller.Edit(userId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<UserViewModel>(viewResult.ViewData.Model);
            Assert.Equal("User_1", model.Name);
            Assert.Equal("User1@gmail.com", model.Email);
            Assert.Equal(userId, model.Id);

        }

        [Fact]
        public async Task Post_Edit_ActionExecutes_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Email", "The Email is Required");
            var user = new UserViewModel { Name = "User_4" };

            var result = await _controller.Edit(user);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testUser = Assert.IsType<UserViewModel>(viewResult.Model);
            Assert.Equal(user.Name, testUser.Name);

        }

        [Fact]
        public async Task Post_Edit_ActionExecutes_ReturnsWhenUserUpdated()
        {
            var user = new UserViewModel { Id = Guid.NewGuid(), Name = "User_1", Email = "User1@gmail.com" };
            _mockService.Setup(u => u.UpdateAsync(user))
                .Callback<UserViewModel>(x => user.Name = "User_Changed");
                         
            await _controller.Edit(user);
    
            Assert.NotEqual("User_1", user.Name);
            Assert.Equal("User_Changed", user.Name);

        }

        [Fact]
        public async Task Post_Edit_ActionExecuted_RedirectsToIndexAction()
        {
            var user = new UserViewModel { Name = "User_2", Email = "User2@gmail.com" };

            var result = await _controller.Edit(user);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Get_Delete_ActionExecutes_ReturnsNotFound_WhenUserIdIsNull()
        {
            var result = await _controller.Delete(id: null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Delete_ActionExecutes_ReturnsNotFound_WhenUserIsNull()
        {
            var userId = Guid.NewGuid();
            _mockService.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync((UserViewModel)null);

            var result = await _controller.Delete(userId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Delete_ActionExecutes_ReturnsView_UserFound()
        {
            var userId = Guid.NewGuid();
            var user = new UserViewModel { Id = userId, Name = "User_7", Email = "User7@gmail.com" };
            _mockService.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);

            var result = await _controller.Delete(userId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<UserViewModel>(viewResult.ViewData.Model);
            Assert.Equal("User_7", model.Name);
            Assert.Equal("User7@gmail.com", model.Email);
            Assert.Equal(userId, model.Id);

        }

        [Fact]
        public async Task Post_Delete_ActionExecutes_UserRemoved()
        {
            var userId = Guid.NewGuid();
            _mockService.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(new UserViewModel() { });
            _mockService.Setup(repo => repo.RemoveAsync(It.IsAny<Guid>()));

            await _controller.DeleteConfirmed(userId);

            _mockService.Verify(repo => repo.RemoveAsync(It.IsAny<Guid>()), Times.Once);

        }

        [Fact]
        public async Task Post_Delete_ActionExecuted_RedirectsToIndexAction()
        {
            var userId = Guid.NewGuid();

            var result = await _controller.DeleteConfirmed(userId);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
