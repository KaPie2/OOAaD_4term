using System;
using System.Reflection;
using Moq;
using SpaceBattle.Lib;

namespace SpaceBattle.Lib.Tests;

public class VectorTests
{
    [Fact]
    public void TwoVectorAddOperationPositive()
    {
        var vector1 = new NVector(new int[]{1, -1, 2});
        NVector vector2 = new NVector(new int[]{-1, 1, -2});

        NVector res = vector1 + vector2;

        Assert.Equal(vector1.dim, res.dim);
        Assert.Equal(res.coords, new int[]{0, 0, 0});
    }

    [Fact]
    public void AddingIncompatibleVectorsThrowsArgumentException()
    {
        NVector vector1 = new NVector(new int[]{1, 2, 3});
        NVector vector2 = new NVector(new int[]{-1, 2});

        Assert.Throws<ArgumentException>(() => vector1 + vector2);
        Assert.Throws<ArgumentException>(() => vector2 + vector1);
    }

    [Fact]
    public void TwoVectorsWithSameCoordsAreEqual()
    {
        NVector vector1 = new NVector(new int[]{1, 2, 3});
        NVector vector2 = new NVector(new int[]{1, 2, 3});

        bool res = vector1.Equals(vector2);

        Assert.True(res);
    }

    [Fact]
    public void TwoVectorsWithDifferentCoordsAreNotEqual()
    {
        NVector vector1 = new NVector(new int[]{1, 2, 3});
        NVector vector2 = new NVector(new int[]{1, 2, 2});

        bool res = vector1.Equals(vector2);

        Assert.False(res);
    }

    [Fact]
    public void EqualityOperatorReturnsTrueIfVectorsAreEqual()
    {
        NVector vector1 = new NVector(new int[]{1, 2, 3});
        NVector vector2 = new NVector(new int[]{1, 2, 3});

        Assert.True(vector1 == vector2);
    }

    [Fact]
    public void EqualityOperatorReturnsFalseIfVectorsAreNotEqual()
    {
        NVector vector1 = new NVector(new int[]{1, 2, 2});
        NVector vector2 = new NVector(new int[]{1, 2, 3});

        Assert.True(vector1 != vector2);
    }

    [Fact]
    public void HashCodeTest()
    {
        Type vectorType = typeof(NVector);

        MethodInfo? method = vectorType.GetMethod("GetHashCode");

        Assert.NotNull(method);
        Assert.True(method.IsPublic);
        Assert.Equal(typeof(int), method.ReturnType);

    }
}