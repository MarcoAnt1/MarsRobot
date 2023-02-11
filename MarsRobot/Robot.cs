namespace MarsRobot;
public class Robot
{
    private readonly string[] directions = new string[] { "North", "East", "South", "West" };
    private readonly int[][] directionsVectors = new int[][]
    {
        new int[] { 0, 1},
        new int[] { 1, 0},
        new int[] { 0, -1},
        new int[] { -1, 0}
    };

    /// <summary>
    /// This method make a robot navigate to a plateau with different commands
    /// </summary>
    /// <param name="plateauSize"></param>
    /// <param name="commands"></param>
    /// <returns>Final position of robot on the plateau</returns>
    public string NavigateRobotToMars(Tuple<int, int> plateauSize, string commands)
    {
        int facing = 0;
        int x = 1, y = 1;

        foreach (var command in commands.ToUpper())
        {
            switch (command)
            {
                case 'L':
                    facing = (facing + 3) % 4; 
                    break;
                case 'R':
                    facing = (facing + 1) % 4;
                    break;
                case 'F':
                    int[] direction = directionsVectors[facing];
                    int newX = x + direction[0];
                    int newY = y + direction[1];

                    if (IsWithinPlateau(newX, newY, plateauSize))
                    {
                        x = newX;
                        y = newY;
                    }
                    break;
                default:
                    break;
            }
        }

        string finalPosition = $"{x}, {y}, {directions[facing]}"; 
        return finalPosition;
    }

    private bool IsWithinPlateau(int x, int y, Tuple<int, int> plateauSize)
    {
        bool validateX = x >= 1 && x <= plateauSize.Item1;
        bool validateY = y >= 1 && y <= plateauSize.Item2;
        return validateX && validateY;
    }
}
