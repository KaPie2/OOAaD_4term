using App;
using App.Scopes;

namespace SpaceBattle.Lib;

public class RegisterIoCDependencyActionsStart : ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Actions.Start",
            (object[] args) =>
            {
                var order = (IDictionary<string, object>)args[0];

                var operation = (string)order["operation"];
                var obj = order["obj"];
                var receiver = Ioc.Resolve<ICommandReceiver>("Game.CommandReceiver");

                ICommand command = operation switch
                {
                    "Move" => Ioc.Resolve<ICommand>("Commands.Move", obj),
                    "Rotate" => Ioc.Resolve<ICommand>("Commands.Rotate", obj),
                    _ => throw new ArgumentException($"Unknown operation: {operation}")
                };

                return new SendCommand(command, receiver);
            }
        ).Execute();
    }
}
