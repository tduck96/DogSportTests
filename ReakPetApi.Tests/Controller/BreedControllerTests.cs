using System;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RealPetApi.Controllers;
using RealPetApi.Dtos;
using RealPetApi.Interfaces;
using RealPetApi.Models;

namespace ReakPetApi.Tests.Controller
{
	public class BreedControllerTests
	{
        private readonly IBreedRepository _breedRepository;
        private readonly IMapper _mapper;
        private readonly BreedController _breedController;

        public BreedControllerTests()
		{
			// Dependencies

			_breedRepository = A.Fake<IBreedRepository>();
			_mapper = A.Fake<IMapper>();

			// Sut

			_breedController = new BreedController(_breedRepository, _mapper);

		}

		[Fact]
		public void BreedController_GetBreeds_ReturnsOk()
		{
			//Arrange

			var breeds = A.Fake<IEnumerable<Breed>>();
			var breedMap = A.Fake<List<BreedDto>>();
			A.CallTo(() => _mapper.Map<List<BreedDto>>(breeds)).Returns(breedMap);

			var controller = new BreedController(_breedRepository, _mapper);

			//Act

			var result = controller.GetBreeds();

			//Assert

			result.Should().BeOfType<Task<ActionResult<BreedDto>>>();


		}

		[Fact]
		public void BreedController_GetBreed_ReturnsOk()
		{
			//Arrange
			var id = 1;
			var breed = A.Fake<Breed>();
			A.CallTo(() => _breedRepository.GetBreed(id)).Returns(breed);

			var breedMap = A.Fake<BreedDto>();
			A.CallTo(() => _mapper.Map<BreedDto>(breed)).Returns(breedMap);

			//Act
			var result = _breedController.GetBreed(id);

			//Assert

			result.Should().BeOfType<Task<ActionResult<BreedDto>>>();

		}


		[Fact]
		public void BreedController_CreateBreed_ReturnsOk()
		{
			//Arrange

			var breed = A.Fake<BreedDto>();
			A.CallTo(() => _breedRepository.CreateBreed(breed)).Returns(true);

			//Act
			var result = _breedController.CreateBreed(breed);

			//Assert
			result.Should().BeOfType<Task<ActionResult<Breed>>>();
		}

		[Fact]
		public void BreedController_DeleteBreed_ReturnsOk()
		{
			//Arrange
			var id = 1;
			A.CallTo(() => _breedRepository.DeleteBreed(id)).Returns(true);

			//Act
			var result = _breedController.DeleteBreed(id);

			//Assert
			result.Should().BeOfType<Task<ActionResult>>();
		}

	}
}

