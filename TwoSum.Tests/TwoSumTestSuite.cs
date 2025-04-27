namespace TwoSum.Tests;

using TwoSum;
using NUnit.Framework;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestTargetSum7ReturnsTrue()
    {
        int[] numbers = [1, 2, 3, 4, 5];
        Assert.That(TwoSumExists.IsTwoSum(numbers, 7), Is.True); // 2 + 5 = 7 OR 3 + 4 = 7
    }

    [Test]
    public void TestTargetSum10ReturnsFalse()
    {
        int[] numbers = [1, 2, 3, 4, 5];
        Assert.That(TwoSumExists.IsTwoSum(numbers, 10), Is.False);
    }

    [Test]
    public void TestTargetSum7ShouldReturnTrue()
    {
        int[] numbers = [1, 5, 2, 3, 4];
        Assert.That(TwoSumExists.IsTwoSum(numbers, 7), Is.True); // 5 + 2 = 7
    }

    [Test]
    public void TestTargetSum1ShouldReturnFalse()
    {
        int[] numbers = [1, 2, 3];
        Assert.That(TwoSumExists.IsTwoSum(numbers, 1), Is.False);
    }

    [Test]
    public void TestEmptyArrayShouldReturnFalse()
    {
        int[] numbers = [];
        Assert.That(TwoSumExists.IsTwoSum(numbers, 5), Is.False);
    }

    [Test]
    public void TestNullArrayShouldReturnFalse()
    {
        int[]? numbers = null;
        Assert.That(TwoSumExists.IsTwoSum(numbers, 5), Is.False);
    }
}
