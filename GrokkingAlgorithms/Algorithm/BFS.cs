using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingAlgorithms.Algorithm
{
    public class BFS
    {
        public static List<string> Search(Dictionary<string, List<string>> graph, string start, string target)
        {
            var queue = new Queue<string>();
            foreach (var neighbor in graph[start])
            {
                queue.Enqueue(neighbor);
            }

            var visited = new HashSet<string>();
            while (queue.Count > 0)
            {
                var person = queue.Dequeue();
                if (!visited.Contains(person))
                {
                    if (person == target)
                    {
                        Console.WriteLine($"{target} found!");
                        return visited.ToList();
                    }
                    else
                    {
                        foreach (var neighbor in graph[person])
                        {
                            queue.Enqueue(neighbor);
                        }
                        visited.Add(person);
                        Console.WriteLine($"Visited: {person}");
                    }
                }
            }

            return null;
        }
    }
}
