using System;
using System.Linq;  // I needed to insert this line;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        // foreach (int count in birdsPerDay) {
        //     if (count == 0) {
        //         return true; // Found a day without birds
        //     }
        // }
        // return false;
        return birdsPerDay.Contains(0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birdCounter = 0;    
        for (int i = 0; i < numberOfDays; ++i) {
            birdCounter += birdsPerDay[i];
        }
        return birdCounter;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach (int birds in birdsPerDay) {
            if (birds >= 5) busyDays += 1;
        }
        return busyDays;
    }
}