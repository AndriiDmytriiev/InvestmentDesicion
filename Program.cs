using System;

class Program
{
    static void Main()
    {
        // Step 1: Define Criteria
        string[] criteria = { "ROI", "Risk Level", "Liquidity", "Time Horizon" };

        // Step 2: Pairwise Comparison Matrix (Saaty Scale)
        double[,] pairwiseMatrix = {
            { 1, 5, 3, 7 },  // ROI
            { 1.0/5.0, 1, 1.0/3.0, 3 },  // Risk Level
            { 1.0/3.0, 3, 1, 5 },  // Liquidity
            { 1.0/7.0, 1.0/3.0, 1.0/5.0, 1 }  // Time Horizon
        };

        // Step 3: Calculate Priority Vector (Normalized Eigenvector)
        double[] priorityVector = CalculatePriorityVector(pairwiseMatrix, criteria.Length);

        // Step 4: Display the priority vector
        Console.WriteLine("Priority Vector:");
        for (int i = 0; i < criteria.Length; i++)
        {
            Console.WriteLine($"{criteria[i]}: {priorityVector[i]:F4}");
        }

        // Step 5: Perform Investment Option Evaluation based on weighted criteria
        // Example scores for three investment options on the criteria
        double[] investment1Scores = { 0.8, 0.4, 0.7, 0.6 };
        double[] investment2Scores = { 0.9, 0.6, 0.5, 0.7 };
        double[] investment3Scores = { 0.7, 0.5, 0.8, 0.5 };

        double investment1FinalScore = CalculateFinalScore(investment1Scores, priorityVector);
        double investment2FinalScore = CalculateFinalScore(investment2Scores, priorityVector);
        double investment3FinalScore = CalculateFinalScore(investment3Scores, priorityVector);

        Console.WriteLine($"\nInvestment 1 Final Score: {investment1FinalScore:F4}");
        Console.WriteLine($"Investment 2 Final Score: {investment2FinalScore:F4}");
        Console.WriteLine($"Investment 3 Final Score: {investment3FinalScore:F4}");

        // Step 6: Determine the best investment option
        string bestInvestment = DetermineBestInvestment(investment1FinalScore, investment2FinalScore, investment3FinalScore);
        Console.WriteLine($"\nThe best investment option is: {bestInvestment}");
    }

    static double[] CalculatePriorityVector(double[,] matrix, int size)
    {
        double[] sumOfColumns = new double[size];
        double[] normalizedMatrixSum = new double[size];
        double[] priorityVector = new double[size];

        // Calculate the sum of each column
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < size; i++)
            {
                sumOfColumns[j] += matrix[i, j];
            }
        }

        // Normalize the matrix
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                normalizedMatrixSum[i] += (matrix[i, j] / sumOfColumns[j]);
            }
            // Calculate the priority vector by averaging the rows of the normalized matrix
            priorityVector[i] = normalizedMatrixSum[i] / size;
        }

        return priorityVector;
    }

    static double CalculateFinalScore(double[] scores, double[] priorityVector)
    {
        double finalScore = 0.0;
        for (int i = 0; i < scores.Length; i++)
        {
            finalScore += scores[i] * priorityVector[i];
        }
        return finalScore;
    }

    static string DetermineBestInvestment(double investment1Score, double investment2Score, double investment3Score)
    {
        if (investment1Score > investment2Score && investment1Score > investment3Score)
        {
            return "Investment 1";
        }
        else if (investment2Score > investment1Score && investment2Score > investment3Score)
        {
            return "Investment 2";
        }
        else
        {
            return "Investment 3";
        }
    }
}