using System.Diagnostics;

namespace SpaceBattle.Lib.Tests;

public class StopCommandTests
{
    [Fact]
    public void StopCommand_RemovesKeyFromDictionary()
    {
        var gameObject = new Dictionary<string, object>();
        gameObject["repeatableMove"] = new object();

        var stopCommand = new StopCommand(gameObject, "Move");
        stopCommand.Execute();

        Assert.False(gameObject.ContainsKey("repeatableMove"));
    }

    [Fact]
    public void StopCommand_DoesNothingIfKeyNotExists()
    {
        var gameObject = new Dictionary<string, object>();

        var stopCommand = new StopCommand(gameObject, "Move");

        var exception = Record.Exception(() => stopCommand.Execute());

        Assert.Null(exception);
    }
}
