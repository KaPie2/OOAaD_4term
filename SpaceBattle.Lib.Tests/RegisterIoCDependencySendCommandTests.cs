using App;
using App.Scopes;
using Moq;

namespace SpaceBattle.Lib.Tests;

public class RegisterIoCDependencySendCommandTests
{
    public RegisterIoCDependencySendCommandTests()
    {
        new InitCommand().Execute();
    }

    [Fact]
    public void RegisterIoCDependencySendCommand_DependencyResolves()
    {
        var registerCommand = new RegisterIoCDependencySendCommand();
        registerCommand.Execute();

        var mockCommand = new Mock<ICommand>();
        var mockReceiver = new Mock<ICommandReceiver>();

        var resolvedCommand = Ioc.Resolve<ICommand>("Commands.Send", mockCommand.Object, mockReceiver.Object);

        Assert.IsType<SendCommand>(resolvedCommand);
    }
}
