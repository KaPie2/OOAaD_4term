using Moq;
using Xunit;
using App.Scopes;
using App;

namespace SpaceBattle.Lib.Tests;

public class RegisterIoCDependencyMacroCommandTests
{
    public RegisterIoCDependencyMacroCommandTests()
    {
        new InitCommand().Execute();
    }

    [Fact]
    public void RegisterDependencyMacroCommand_ResolveDependency()
    {
        // Arrange
        Mock<ICommand> cmd1 = new Mock<ICommand>();
        Mock<ICommand> cmd2 = new Mock<ICommand>();
        var commands = new[] { cmd1.Object, cmd2.Object };

        // Act
        new RegisterIoCDependencyMacroCommand().Execute();
        var macro = Ioc.Resolve<ICommand>("Commands.Macro", commands);

        // Assert
        Assert.NotNull(macro);
        macro.Execute();

        cmd1.Verify(c => c.Execute(), Times.Once());
        cmd2.Verify(c => c.Execute(), Times.Once());
    }
}
