using App;
using App.Scopes;

namespace SpaceBattle.Lib;

public class RegisterIoCDependencyMacroCommand : ICommand
{
    public void Execute()
    {
        // Сначала получаем команду регистрации из IoC
        var registerCommand = Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Commands.Macro",
            (object[] args) =>
            {
                // Правильно распаковываем аргументы
                var commands = (ICommand[])args[0];
                return new MacroCommand(commands);
            }
        );
        
        // Затем выполняем регистрацию
        registerCommand.Execute();
    }
}
