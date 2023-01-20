using AutoMapper;
using E_Learn.Infrastructure.Specification;
using E_learning.Controllers;
using ELearning.Service.IService;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Test
{
    public class CoursesControllerTest
    {
        private readonly ICourseService _courseService;

        public readonly IMapper _mapper;
        public CoursesControllerTest()
        {
            _courseService = A.Fake<ICourseService>();

            _mapper = A.Fake<IMapper>();    
         }
        [Fact]
        public async void CoursesController_GetAllCourse_ReturnOk()
        {
            //Arrange
            var courseService = A.Fake<ICourseService>();
            var mapper = A.Fake<IMapper>();
            var coursesController = new CoursesController(_courseService,_mapper);

            //Act
            var result = await (coursesController.GetAllCourse(new CourseParams())) as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType( typeof(OkObjectResult));

        }

        [Fact]
        public async void CoursesController_GetAllCourse_ThrowsException_ReturnBadRequest()
        {
            //Arrange
            var courseService = A.Fake<ICourseService>();
            var mapper = A.Fake<IMapper>();
            var coursesController = new CoursesController(_courseService, _mapper);
            string exceptionMessage = "Test Exception";
            A.CallTo(() => _courseService.GetAllCourse(A<CourseParams>._)).Throws(new Exception(exceptionMessage));

            //Act
            var result = await coursesController.GetAllCourse(new CourseParams());

            //Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(exceptionMessage, badRequest.Value);
        }

    }
}
