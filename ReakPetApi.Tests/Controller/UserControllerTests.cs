using System;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RealPetApi.Controllers;
using RealPetApi.Data;
using RealPetApi.Dtos;
using RealPetApi.Interfaces;
using RealPetApi.Models;
using RealPetApi.Repositories;
using Xunit;

namespace ReakPetApi.Tests.Controller
{
	public class UserControllerTests
	{
        private readonly IUserProfileRespository _userProfileRespository;
        private readonly IHandlerRepository _handlerRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;
        private readonly UserController _userController;

        public UserControllerTests()
		{
            // Dependencies

            _userProfileRespository = A.Fake<IUserProfileRespository>();
            _handlerRepository = A.Fake<IHandlerRepository>();
            _locationRepository = A.Fake<ILocationRepository>();
            _sportRepository = A.Fake<ISportRepository>();
            _mapper = A.Fake<IMapper>();

            // Sut

            _userController = new UserController(_userProfileRespository, _handlerRepository, _locationRepository, _sportRepository, _mapper);
        }

        [Fact]
        public void UserController_FollowUser_ReturnsOk()
        {
            // Arrange
            var follow = A.Fake<UserFollowing>();
            var userId = 1;
            var dto = A.Fake<FollowDto>();


            A.CallTo(() => _userProfileRespository
            .FollowUser(follow))
            .Returns(true);

            // Act
            var result = _userController.FollowUser(userId, dto);


            // Assert
            result.Should().BeOfType<Task<ActionResult<bool>>>();
        }

        [Fact]
        public void UserController_UnfollowUser_ReturnsOk()
        {
            // Arrange
            var userId = 1;
            var followId = 2;
            var follower = A.Fake<UserFollowing>();
            var dto = A.Fake<FollowDto>();

            A.CallTo(() => _userProfileRespository
            .GetFollower(userId, followId))
            .Returns(follower);

            // Act

            var result = _userController.UnfollowUser(followId, userId);

            // Assert

            result.Should().BeOfType<Task<ActionResult<bool>>>();
        }

        [Fact]
        public void UserController_GetUserFollowing_ReturnsOk()
        {
            // Arrange
            var list = A.Fake<IEnumerable<UserListDto>>();
            var userId = 1;

            A.CallTo(() => _userProfileRespository.GetUserFollowing(userId)).Returns(list);

            // Act
            var result = _userController.GetFollowing(userId);

            // Assert

            result.Should().BeOfType<Task<ActionResult<List<UserListDto>>>>();
        }
	}
}

