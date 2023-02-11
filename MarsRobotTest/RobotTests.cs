using MarsRobot;

namespace MarsRobotTest;
public class RobotTests
{
    private readonly Robot robot;

    public RobotTests()
    {
        robot = new Robot();
    }

    [Fact]
    public void BigPlateauGoNorth()
    {
        string result = robot.NavigateRobotToMars((X: 10, Y: 10).ToTuple(), "RFLFRFLFRFLFRFLRFLFRFLFRF");
        Assert.Equal("8, 6, East", result);
    }

    [Fact]
    public void SmallPlateauGoWest()
    {
        string result = robot.NavigateRobotToMars((X: 5, Y: 7).ToTuple(), "RFLFRFLFRFLFL");
        Assert.Equal("4, 4, West", result);
    }

    [Fact]
    public void BigPlateauGoSouth()
    {
        string result = robot.NavigateRobotToMars((X: 5, Y: 7).ToTuple(), "FFFFFFRFFR");
        Assert.Equal("3, 7, South", result);
    }

    [Fact]
    public void SmallPlateauGoEast()
    {
        string result = robot.NavigateRobotToMars((X: 5, Y: 5).ToTuple(), "FFFFFFRFF");
        Assert.Equal("3, 5, East", result);
    }

    [Fact]
    public void ShouldWorkWithLetterInLower()
    {
        string result = robot.NavigateRobotToMars((X: 5, Y: 5).ToTuple(), "ffrflflf");
        Assert.Equal("1, 4, West", result);
    }
}