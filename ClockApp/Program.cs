
bool runAgain = true;

while (runAgain)
{
    try
    {
        Console.Clear();

        Console.WriteLine("Please enter hours:");
        int hours = IsHoursInputValid(Console.ReadLine());

        Console.WriteLine("Please enter minutes:");
        int minutes = IsMinutesInputValid(Console.ReadLine());

        double angle = CalculateAngle(hours, minutes);

        Console.WriteLine($"The lesser angle is {angle}\u00B0");

        Console.WriteLine("Do you wanna run again y/n?");
        string answer = Console.ReadLine();

        if (answer == "y" || answer == "Y")
        {
            runAgain = true;
        }
        else
        {
            runAgain = false;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        runAgain = true;
        Console.ReadLine();
    }
    
}

static double CalculateAngle(int hours, int minutes)
{
    double angle = 0;
    double circle = 360;

    double hoursAngle = (30 * hours) + (0.5 * minutes);

    double minutesAngle = minutes * 6;

    if (minutesAngle > hoursAngle)
    {
        angle = hoursAngle + circle - minutesAngle;

        if (angle > 180)
        {
            angle = circle - angle;
        }
    }

    if (hoursAngle > minutesAngle)
    {
        angle = hoursAngle - minutesAngle; 
    }

    return angle;
}

static int IsHoursInputValid(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        throw new Exception("Please enter input");
    }

    if (!int.TryParse(input, out int hours))
    {
        throw new Exception("Please enter number");
    }

    if (hours > 11 || hours < 0)
    {
        throw new Exception("Please insert from 0-11");
    }

    return hours;
}


static int IsMinutesInputValid(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        throw new Exception("Please enter input");
    }

    if (!int.TryParse(input, out int minutes))
    {
        throw new Exception("Please enter number");
    }

    if (minutes > 59 || minutes < 0)
    {
        throw new Exception("Please insert from 0-59");
    }

    return minutes;
}