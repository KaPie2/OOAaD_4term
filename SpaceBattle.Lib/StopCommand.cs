namespace SpaceBattle.Lib;

public class StopCommand : ICommand
{
    private readonly IDictionary<string, object> _gameObject;
    private readonly string _cmdType;

    public StopCommand(IDictionary<string, object> gameObject, string cmdType)
    {
        _gameObject = gameObject;
        _cmdType = cmdType;
    }

    public void Execute()
    {
        var key = $"repeatable{_cmdType}";

        if (_gameObject.ContainsKey(key))
        {
            _gameObject.Remove(key);
        }
    }
}
