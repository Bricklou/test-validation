﻿namespace SimulationCredits;

public class Program
{
    public static void Main(string[] args)
    {
        var parser = new ArgumentsParser();

        var credit = parser.Parse(args);
    }
}