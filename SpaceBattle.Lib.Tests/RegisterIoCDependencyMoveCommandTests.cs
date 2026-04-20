using System.Windows.Input;
using App.Scopes;
using Moq;
using SpaceBattle.Lib;

namespace SpaceBattle.Lib.Tests;

public class RegisterIoCDependencyMoveCommandTests
{
    [Fact]
    public void RegisterIoCDependencyMoveCommand_IsResolvingDependency()
    {
        new RegisterIoCDependencyMoveCommand.Execute();

        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<ICommand>("Commands.MoveCommand").Execute();


        var commandMock = new Mock<ICommand>();
        var cmd = commandMock.Object;

        var movObject = new Mock<IMovingObject>();
        var movObj = movObject.Object;

        Ioc.Resolve<ICommand>(
            "IoC.Register",
            "Commands.MoveCommand",
            (object[] args) => movObj
        ).Execute();

        new MoveCommand(cmd).Execute();

        commandReceiveMock.Verify(r => r.Execute(cmd), Times.Once());

    }
}