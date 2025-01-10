//using Business.Interfaces;
//using Business.Models;
//using Business.Services;
//using Moq;

////Lyckades inte med testet men ville försöka

//namespace Tests.Services;

//public class UserFileService_Test
//{
//    private readonly Mock<IFileService> _fileServiceMock;
//    private readonly IUserFileService _userFileService;

//    public UserFileService_Test()
//    {
//        _fileServiceMock = new Mock<IFileService>();
//        _userFileService = new UserFileService(_fileServiceMock.Object);
//    }

//    [Fact]
//    public void Save_ShouldReturnTrue_SaveContactToListAndSaveToFile()
//    {
//        // Arrange
//        var userRegistrationForm = new UserRegistrationForm()
//        {
//            FirstName = "Jannika",
//            LastName = "Guidsson",
//            Email = "jannika@domain.com"
//        };

//        _fileServiceMock.Setup(x => x.SaveContentToFile(It.IsAny<string>())).Returns(true);

//        // Act
//        var result = _userFileService.Save(userRegistrationForm);

//        // Assert
//        Assert.True(result);
//        _fileServiceMock.Verify(x => x.SaveContentToFile(It.IsAny<string>()), Times.Once);

//    }
//}
