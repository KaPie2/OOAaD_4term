using App;
using Moq;
using App.Scopes;

namespace SpaceBattle.Lib.Tests;

public class RegisterIoCDependencyMacroMoveRotateTests
{
    public RegisterIoCDependencyMacroMoveRotateTests()
    {
        new InitCommand().Execute();
    }

    [Fact]
    public void RegisterMacroMoveRotate_ResolvesDependency()
    {
        // Arrange
        // регистрируем Specs.Move (список команд для движения)
        var moveSpecName = "MoveSpec_" + Guid.NewGuid().ToString("N");
        var moveCmd1Name = "MoveCmd1_" + Guid.NewGuid().ToString("N");
        var moveCmd2Name = "MoveCmd2_" + Guid.NewGuid().ToString("N");

        var moveCmd1 = new Mock<ICommand>();
        var moveCmd2 = new Mock<ICommand>();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Specs.Move",
            (object[] args) => new string[] { moveCmd1Name, moveCmd2Name }
        ).Execute();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            moveCmd1Name,
            (object[] args) => moveCmd1.Object
        ).Execute();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            moveCmd2Name,
            (object[] args) => moveCmd2.Object
        ).Execute();

        // регистрируем Specs.Rotate (список команд для вращения)
        var rotateSpecName = "RotateSpec_" + Guid.NewGuid().ToString("N");
        var rotateCmd1Name = "RotateCmd1_" + Guid.NewGuid().ToString("N");
        var rotateCmd2Name = "RotateCmd2_" + Guid.NewGuid().ToString("N");

        var rotateCmd1 = new Mock<ICommand>();
        var rotateCmd2 = new Mock<ICommand>();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Specs.Rotate",
            (object[] args) => new string[] { rotateCmd1Name, rotateCmd2Name }
        ).Execute();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            rotateCmd1Name,
            (object[] args) => rotateCmd1.Object
        ).Execute();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            rotateCmd2Name,
            (object[] args) => rotateCmd2.Object
        ).Execute();

        // Act
        new RegisterIoCDependencyMacroMoveRotate().Execute();

        var macroMove = Ioc.Resolve<ICommand>("Macro.Move", new object[] { });
        var macroRotate = Ioc.Resolve<ICommand>("Macro.Rotate", new object[] { });

        // Assert
        Assert.NotNull(macroMove);
        Assert.NotNull(macroRotate);

        macroMove.Execute();
        macroRotate.Execute();

        moveCmd1.Verify(c => c.Execute(), Times.Once);
        moveCmd2.Verify(c => c.Execute(), Times.Once);
        rotateCmd1.Verify(c => c.Execute(), Times.Once);
        rotateCmd2.Verify(c => c.Execute(), Times.Once);
    }
}
