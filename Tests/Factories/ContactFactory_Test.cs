using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class ContactFactory_Test
{

    [Fact]
    public void Create_ShouldReturnUserRegistrationForm()
    {
        // Act
        var result = ContactFactory.Create();

       // Assert
       Assert.NotNull(result);
       Assert.IsType<UserRegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnContact_WhenUserRegistrationFormIsProvided()
    {
        // Arrange
        var userRegistrationForm = new UserRegistrationForm()
        {
            FirstName = "Jannika",
            LastName = "Guidsson",
            Email = "Jannika@domain.com"
        };

        // Act
        var result = ContactFactory.Create(userRegistrationForm);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactEntity>(result);
        Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(userRegistrationForm.LastName, result.LastName);
        Assert.Equal(userRegistrationForm.Email, result.Email);
    }
}
