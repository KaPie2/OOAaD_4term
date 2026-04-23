namespace SpaceBattle.Lib;


public class MoveCommand : ICommand
{
    private readonly IMovingObject movingObject;

    public MoveCommand(IMovingObject movingObject)
    {
        this.movingObject = movingObject ?? throw new ArgumentNullException(nameof(movingObject));
    }
    public void Execute()
    {
        var pos = movingObject.Position ?? throw new ArgumentNullException(nameof(movingObject.Position));
        var vel = movingObject.Velocity ?? throw new ArgumentNullException(nameof(movingObject.Velocity));

        var newPos = pos + vel;
        movingObject.Position = newPos ?? throw new Exception(nameof(newPos));
    }
}
