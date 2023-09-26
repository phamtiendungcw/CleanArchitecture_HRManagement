using AutoMapper;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.Management.Application.MappingProfiles;
using HR.Management.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.Management.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypesListQueryHandler>> _logger;

        public GetLeaveTypeQueryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<LeaveTypeProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<IAppLogger<GetLeaveTypesListQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypesListQueryHandler(_mockRepo.Object, _mapper, _logger.Object);
            var result = await handler.Handle(new GetLeaveTypesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeListDto>>();
            result.Count.ShouldBe(3);
        }
    }
}