using System;

class Program
{



    public static void Main(string[] args)
    {
        // Console.WriteLine("Hello World");
        Console.WriteLine("Floodfill");

        floodFill FF = new floodFill(4, 6);

        FF.outputState();

        //First check if there are any extra squares in inital area
        FF.updateContinuousArea(FF.getTopLeftColour(), 0, 0);
        int count = 0;

        while (!FF.completed())
        {

            int nextColour = 0;

            while (nextColour == 0)
            {
                Console.WriteLine("Enter number 1 - 6");
                string colourInput = Console.ReadLine();
                if (colourInput == "1") nextColour = 1;
                else if (colourInput == "2") nextColour = 2;
                else if (colourInput == "3") nextColour = 3;
                else if (colourInput == "4") nextColour = 4;
                else if (colourInput == "5") nextColour = 5;
                else if (colourInput == "6") nextColour = 6;
                else nextColour = 0;
            }

            FF.floodWithNewColour(nextColour);
            FF.resetCompletedGrid();
            FF.updateContinuousArea(nextColour, 0, 0);

            FF.outputState();
            count++;

        }
        Console.WriteLine($"Success in: {count}");


        //Console.WriteLine($"Grid is Completed: {FF.completed()}");
        //FF.outputState();

    }
}