using System.Windows.Input;

namespace SpaceBattle.Lib;

public class SimpleMacroCommand: ICommand
{
    private readonly ICommand[] _commands;
    public SimpleMacroCommand(ICommand[] commands)
    {
        _commands = commands;
    }

    public void Execute()
    {
        Array.ForEach(_commands, cmd => cmd.Execute());
    }
}
