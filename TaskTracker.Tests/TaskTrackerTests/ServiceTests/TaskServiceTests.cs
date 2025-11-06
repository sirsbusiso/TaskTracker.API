using AutoMapper;
using Moq;
using TaskTracker.API.Exceptions;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Profiles;
using TaskTracker.Application.Services;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Interfaces;
using TaskTracker.Tests.TaskTrackerTests.Helpers;
namespace TaskTracker.Tests.TaskTrackerTests.ServiceTests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock = new();
        private readonly IMapper _mapper;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskTrackerProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _taskService = new TaskService(_taskRepositoryMock.Object,  _mapper);

        }

        [Fact]
        public async Task GetAllTask_Returns_As_Expected()
        {
            //Arrange
            var expectedResult = TaskTrackerTestHelpers.GetAllData();
            _taskRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(expectedResult);

            //Act
            var result = await _taskService.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Task Found", result.Message);
            Assert.Equal(3, result.Data.Count);
        }

        [Fact]
        public async Task Add_New_Task_With_Invalid_Values_Throws_Bad_Request_Exception()
        {
            //Arrange 
            var invalidAddDto = TaskTrackerTestHelpers.InvalidTaskAddDto();
            var invalidTask = _mapper.Map<TaskEntity>(invalidAddDto);
            _taskRepositoryMock.Setup(x => x.AddAsync(invalidTask)).ReturnsAsync(invalidTask);

            //Act & Assert
            var ex = await Assert.ThrowsAsync<ApiException>(() => _taskService.AddAsync(invalidAddDto));

            Assert.Equal(400, ex.StatusCode);
            Assert.Equal("Title and Description are required", ex.Message);
        }
    }
    
}
