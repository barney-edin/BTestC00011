using System;

public class floodFill
{

    public int Gridsize { get; set; }
    public int maximumColours { get; set; }
    public int[,] colourGrid { get; set; }
    public bool[,] completedGrid { get; set; }

    Random rndcol = new Random();

    public floodFill(int gridsize, int maximumcolours)
    {
        Gridsize = gridsize;
        maximumColours = maximumcolours;
        colourGrid = new int[gridsize, gridsize];
        completedGrid = new bool[gridsize, gridsize];

        initialiseGrid();
    }


    private void initialiseGrid()
    {
        for (int x = 0; x < Gridsize; x++)
        {
            for (int y = 0; y < Gridsize; y++)
            {
                colourGrid[x, y] = rndcol.Next(1, (maximumColours + 1));
                completedGrid[x, y] = false;
            }
        }
    }

    //Need to check if a square is part of the colourGrid.
    bool isValidSquare(int x, int y)
    {
        if ((x < 0) || (y < 0))
        {
            return false;
        }
        else if ((x >= Gridsize) | (y >= Gridsize))
        {
            return false;
        }
        return true;
    }

    public int getTopLeftColour()
    {
        return colourGrid[0, 0];
    }
    //Checks for continous area
    public void updateContinuousArea(int topLeftColour, int xCord, int yCord)
    {
        if (isValidSquare(xCord, yCord))
        {
            //Console.WriteLine($"Square: {xCord},{yCord}");
            if ((colourGrid[xCord, yCord] == topLeftColour) && (completedGrid[xCord, yCord] == false))
            {
                completedGrid[xCord, yCord] = true;
                updateContinuousArea(topLeftColour, xCord + 1, yCord);
                updateContinuousArea(topLeftColour, xCord - 1, yCord);
                updateContinuousArea(topLeftColour, xCord, yCord + 1);
                updateContinuousArea(topLeftColour, xCord, yCord - 1);
            }
        }
    }

    public bool completed()
    {
        int topleftcol = colourGrid[0, 0];
        int count = 0;
        for (int x = 0; x < Gridsize; x++)
        {
            for (int y = 0; y < Gridsize; y++)
            {
                if (colourGrid[x, y] == topleftcol)
                {
                    count++;
                }
            }
        }
        if (count == Gridsize * Gridsize)
        {
            return true;
        }
        return false;
    }

    public void floodWithNewColour(int newColour)
    {
        for (int x = 0; x < Gridsize; x++)
        {
            for (int y = 0; y < Gridsize; y++)
            {
                if (completedGrid[x, y] == true)
                {
                    colourGrid[x, y] = newColour;
                }
            }
        }
    }

    public void resetCompletedGrid()
    {
        for (int x = 0; x < Gridsize; x++)
        {
            for (int y = 0; y < Gridsize; y++)
            {
                completedGrid[x, y] = false;
            }
        }
    }

    public void outputState()
    {
        //Console.Clear();
        for (int x = 0; x < Gridsize; x++)
        {
            for (int y = 0; y < Gridsize; y++)
            {
                Console.Write(colourGrid[x, y] + "\t");
            }
            Console.Write("\n");
        }
    }
}
