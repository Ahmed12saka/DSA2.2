using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_ASS2
{
    class Graph
    {
        private Dictionary<string, Dictionary<string, Tuple<int, int>>> roads;

        public Graph()
        {
            roads = new Dictionary<string, Dictionary<string, Tuple<int, int>>>();
        }

        public void AddCity(string cityName)
        {
            if (!roads.ContainsKey(cityName))
            {
                roads.Add(cityName, new Dictionary<string, Tuple<int, int>>());
            }
        }

        public void AddRoad(string sourceCity, string destCity, int distance, int maxSpeed)
        {
            AddCity(sourceCity);
            AddCity(destCity);

            roads[sourceCity][destCity] = Tuple.Create(distance, maxSpeed);
        }

        public List<string> ShortestPath(string startCity, string endCity)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Dictionary<string, string> previous = new Dictionary<string, string>();
            List<string> unvisited = new List<string>();

            foreach (var city in roads.Keys)
            {
                distances[city] = int.MaxValue;
                previous[city] = null;
                unvisited.Add(city);
            }

            distances[startCity] = 0;

            while (unvisited.Count > 0)
            {
                string currentCity = null;
                foreach (var city in unvisited)
                {
                    if (currentCity == null || distances[city] < distances[currentCity])
                    {
                        currentCity = city;
                    }
                }

                if (currentCity == endCity)
                {
                    break;
                }

                unvisited.Remove(currentCity);

                foreach (var neighbor in roads[currentCity])
                {
                    int altDistance = distances[currentCity] + neighbor.Value.Item1;
                    if (altDistance < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = altDistance;
                        previous[neighbor.Key] = currentCity;
                    }
                }
            }

            List<string> path = new List<string>();
            string current = endCity;
            while (current != null)
            {
                path.Insert(0, current);
                current = previous[current];
            }

            return path;
        }
    }
}
