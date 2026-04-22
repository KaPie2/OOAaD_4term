using App;
using App.Scopes;
using Moq;
using System.Diagnostics;

namespace SpaceBattle.Lib.Tests;

public class RegisterIoCDependencyActionsStopTests
{
    public RegisterIoCDependencyActionsStopTests()
    {
        new InitCommand().Execute();
    }

    [Fact]
    public void RegisterIoCDependencyActionsStop_DependencyResolves()
    {
        var registerCommand = new RegisterIoCDependencyActionsStop();
        registerCommand.Execute();

        var order = new Dictionary<string, object>
        {
            { "operation", "Rotate" },
            { "obj", new object() }
        };

        var command = Ioc.Resolve<ICommand>("Actions.Stop", order);

        Assert.NotNull(command);
        Assert.IsType<StopCommand>(command);
    }

    [Fact]
    public void StopCommand_ExecutesInConstantTime()
    {
        var registerCommand = new RegisterIoCDependencyActionsStop();
        registerCommand.Execute();

        var order = new Dictionary<string, object>
        {
            { "operation", "Move" },
            { "obj", new object() }
        };

        var stopwatch = Stopwatch.StartNew();

        var command = Ioc.Resolve<ICommand>("Actions.Stop", order);
        command.Execute();

        stopwatch.Stop();

        Assert.True(stopwatch.ElapsedMilliseconds < 100);
    }
}
