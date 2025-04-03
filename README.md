This C# program implements the Analytic Hierarchy Process (AHP) to evaluate and rank investment options based on multiple criteria. Here's what it does step by step:

1. Define the Decision Criteria
The program evaluates investments based on four criteria:

ROI (Return on Investment)

Risk Level

Liquidity

Time Horizon

2. Construct the Pairwise Comparison Matrix
A pairwise comparison matrix is used to quantify the relative importance of each criterion using the Saaty scale (used in AHP). The matrix is:

swift
Copy
Edit
{ 1,   5,   3,   7   }  // ROI
{ 1/5, 1,   1/3, 3   }  // Risk Level
{ 1/3, 3,   1,   5   }  // Liquidity
{ 1/7, 1/3, 1/5, 1   }  // Time Horizon
A higher value means that the row criterion is more important than the column criterion.

For example, ROI is 5 times more important than Risk Level.

3. Calculate the Priority Vector
The priority vector represents the relative importance of each criterion. It is computed by:

Summing each column.

Normalizing the matrix by dividing each element by its column sum.

Averaging each row to get the final weight for each criterion.

4. Evaluate Investment Options
Three investments are scored based on the criteria:

Investment 1: { 0.8, 0.4, 0.7, 0.6 }

Investment 2: { 0.9, 0.6, 0.5, 0.7 }

Investment 3: { 0.7, 0.5, 0.8, 0.5 }

Each investment’s final score is computed as a weighted sum of its scores, using the priority vector.

5. Determine the Best Investment
The program compares the final scores and selects the highest-scoring investment as the best option.

Summary
Uses AHP to rank investment options.

Computes priority weights for criteria using pairwise comparisons.

Scores investments using weighted sums.

Determines the best investment based on the highest score.

Would you like a more detailed breakdown of the calculations or an example output? 🚀
