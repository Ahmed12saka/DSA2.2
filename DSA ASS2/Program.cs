using System;
using System.Collections.Generic;

namespace DSA_ASS2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            // Add cities and roads to the graph
            graph.AddRoad("Varna", "Shumen", 87, 120);
            graph.AddRoad("Varna", "Dobrich", 48, 100);
            graph.AddRoad("Varna", "Burgas", 134, 120);
            graph.AddRoad("Burgas", "Yambol", 102, 120);
            graph.AddRoad("Yambol", "Sliven", 66, 100);
            graph.AddRoad("Sliven", "Veliko Trynovo", 78, 120);
            graph.AddRoad("Veliko Trynovo", "Kazanlyk", 63, 100);
            graph.AddRoad("Kazanlyk", "Stara Zagora", 79, 120);
            graph.AddRoad("Stara Zagora", "Tyrgowishte", 109, 120);
            graph.AddRoad("Tyrgowishte", "Razgrad", 23, 60);
            graph.AddRoad("Razgrad", "Shumen", 56, 100);
            graph.AddRoad("Shumen", "Veliko Trynovo", 80, 120);

            // Prompt user to enter the source and destination cities
            Console.Write("Enter the starting city: ");
            string startCity = Console.ReadLine();
            Console.Write("Enter the destination city: ");
            string endCity = Console.ReadLine();

            // Find the shortest path and display it
            List<string> path = graph.ShortestPath(startCity, endCity);

            Console.WriteLine("Shortest path from {0} to {1}:", startCity, endCity);
            Console.WriteLine(string.Join(" -> ", path));
        }
    }
    
}
