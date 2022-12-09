
using System;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RealPetApi.Data;
using RealPetApi.Dtos;
using RealPetApi.Interfaces;
using RealPetApi.Models;
using Xunit;

namespace ReakPetApi.Tests.Controller
{
	public class ClubControllerTests
	{
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly ClubController _clubController;

        public ClubControllerTests()
		{
			//Dependencies
			_clubRepository = A.Fake<IClubRepository>();
			_mapper = A.Fake<IMapper>();
			_locationRepository = A.Fake<ILocationRepository>();

			//Sut

			_clubController = new RealPetApi.Data.ClubController(_clubRepository, _mapper, _locationRepository);
		}

		[Fact]
		public void ClubContoller_GetClubs_ReturnsOk()
		{
			//Arrange

			var clubs = A.Fake<List<ClubDto>>();

			A.CallTo(() => _clubRepository.GetClubDtos()).Returns(clubs);

			//Act

			var result = _clubController.GetClubs();

			//Assert

			result.Should().BeOfType<Task<ActionResult<ClubDto>>>();
		}

		[Fact]

		public void ClubController_GetClub_ReturnsOk()
		{

			//Arrange

			int id = 1;
			var clubDto = A.Fake<ClubDto>();

			//Act
			var result = _clubController.GetClub(id);

			//Assert

			result.Should().BeOfType<Task<ActionResult<ClubDto>>>();

		}

		[Fact]
		public void ClubController_GetSportsByClub_ReturnsOk()
		{
			//Arrange
			var id = 1;
			var clubs = A.Fake<List<Sport>>();
			A.CallTo(() => _clubRepository.GetSportsByClub(id)).Returns(clubs);

		}
	}

}

