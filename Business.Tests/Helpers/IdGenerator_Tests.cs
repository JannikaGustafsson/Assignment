using Business.Helpers;

namespace Business.Tests.Helpers;

public class IdGenerator_Test
{
    [Fact]
    public void GenerateUniqueId_ShouldReturnStingOfTypeGuid()
    {
        //Act
        string id = IdGenerator.GenerateUniqueId();

        // Assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }
}
