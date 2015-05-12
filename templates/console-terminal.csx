#!/usr/bin/csexec -t

using System;

public class Program
{
    public static void Main (string [] args)
    {
        Console.WriteLine ("Hello, world!");
        Console.WriteLine ("Arguments: " + string.Join (", ", args));

        Console.Write ("Press any key to quit...");
        Console.ReadKey (true);
    }
}
