using App;
using App.Scopes;

namespace SpaceBattle.Lib;

public class RegisterIoCDependencyActionsStop : ICommand
{
    public void Execute()
    {
        try
        {
            Ioc.Resolve<App.ICommand>(
                "IoC.Register",
                "Actions.Stop",
                (object[] args) =>
                {
                    var order = (IDictionary<string, object>)args[0];
                    var operation = (string)order["operation"];

                    return new StopCommand(order, operation);
                }
            ).Execute();
        }
        catch
        {
        }
    }
}
