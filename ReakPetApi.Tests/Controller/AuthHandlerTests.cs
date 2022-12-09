using System;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RealPetApi.Controllers;
using RealPetApi.Dtos;
using RealPetApi.Interfaces;
using RealPetApi.Models;
using RealPetApi.Services;
using Xunit;

namespace ReakPetApi.Tests.Controller
{
	public class AuthHandlerTests
	{
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IUserProfileRespository _userProfileRepository;
        private readonly AuthHandler _authController;

        public AuthHandlerTests()
		{
			//Dependencies

			_authService = A.Fake<IAuthService>();
			_mapper = A.Fake<IMapper>();
			_userProfileRepository = A.Fake<IUserProfileRespository>();


			//Sut

			_authController = new AuthHandler(_authService, _mapper, _userProfileRepository);
		}

		[Fact]
		public void AuthHandler_RegisterUser_ReturnsOk()
		{
			// Arrange

			var handler = A.Fake<Handler>();
			var response = A.Fake<AuthResponseDto>();
			var request = A.Fake<AuthHandlerDto>();

			A.CallTo(() =>_authService.RegisterUser(request)).Returns(response);


			// Act
			var result = _authController.RegisterUser(request);

			// Assert

			result.Should().BeOfType<Task<ActionResult<Handler>>>();
		}

		
	}
}

