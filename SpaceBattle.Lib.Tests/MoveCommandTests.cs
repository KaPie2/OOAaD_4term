using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Moq; 
using SpaceBattle.Lib;

namespace SpaceBattle.Lib.Tests;

public class MoveCommandTests
{
    [Fact]
    public void VectorMovingIsCorrect()
    {
        var vector = new Mock<IMovingObject>();

        vector.Setup(x => x.Position).Returns(new NVector(new int[]{12, 5}));
        vector.Setup(x => x.Velocity).Returns(new NVector(new int[]{-4, 1}));

        var moveCommand = new MoveCommand(vector.Object);  

        moveCommand.Execute();

        vector.VerifySet(x => x.Position = new NVector(new int[]{8, 6}), Times.Once);

    }

    [Fact]
    public void UnknownPositionThrowsException()
    {
        var vector = new Mock<IMovingObject>();

        vector.Setup(x => x.Position).Returns((NVector)null);
        vector.Setup(x => x.Velocity).Returns(new NVector(new int[]{-4, 1}));

        var moveCommand = new MoveCommand(vector.Object);  

        Assert.Throws<ArgumentNullException>(() => moveCommand.Execute());

        
    }

    [Fact]
    public void UnknownVelocityThrowsException()
    {
        var vector = new Mock<IMovingObject>();

        vector.Setup(x => x.Position).Returns(new NVector(new int[]{-4, 1}));
        vector.Setup(x => x.Velocity).Returns((NVector)null);

        var moveCommand = new MoveCommand(vector.Object);  

        Assert.Throws<ArgumentNullException>(() => moveCommand.Execute());

        
    }

    [Fact]
    public void ThrowsExceptionWhenUnableToChangePosition()
    {
        var vector = new Mock<IMovingObject>();

        vector.Setup(x => x.Position).Returns(new NVector(new int[]{12, 5}));
        vector.Setup(x => x.Velocity).Returns(new NVector(new int[]{-4, 1}));

        vector.SetupSet(x => x.Position = It.IsAny<NVector>()).Throws<InvalidOperationException>();

        var moveCommand = new MoveCommand(vector.Object);  

        Assert.Throws<InvalidOperationException>(() => moveCommand.Execute());
    }
}