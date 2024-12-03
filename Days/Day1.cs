using System;
using System.Collections.Generic;

namespace AdventOfCode2024;

public static class Day1
{
    public static void Run(string input)
    {
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        // PART 1
        int totalDistance = 0;

        foreach (var line in input.Trim().Split('\n'))
        {
            string[] numbersPerLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            leftList.Add(int.Parse(numbersPerLine[0]));
            rightList.Add(int.Parse(numbersPerLine[1]));
        }

        leftList.Sort();
        rightList.Sort();
        
        for (int i = 0; i < leftList.Count; i++)
        {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        Console.WriteLine(totalDistance);

        // PART 2
        int similarityScore = 0;

        foreach (int leftElement in leftList)
        {
            int timesRepeated = 0;
            foreach (int rightElement in rightList)
            {
                if (leftElement == rightElement)
                {
                    timesRepeated++;
                }
            }
            similarityScore += leftElement * timesRepeated;
        }

        Console.WriteLine(similarityScore);
    }
}