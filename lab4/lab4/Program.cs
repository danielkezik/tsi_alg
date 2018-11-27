using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4 {
    class Program {
        private class Edge {
            public int a;
            public int b;
        }
        private static List<List<int>> _graph;
        private static List<bool> _isInQueue;
        private static List<int> _queue;

        private static void InitGraphData() {
            _isInQueue = new List<bool>();
            foreach (var unused in _graph) { _isInQueue.Add(false); }
        }

        private static void Bfs() {
            while (_queue.Count > 0) {
                var v = _queue.First();
                Console.WriteLine(v);
                foreach (var vertex in _graph[v]) {
                    if (!_isInQueue[vertex]) {
                        _queue.Add(vertex);
                        _isInQueue[vertex] = true;
                    }
                }
                _queue.RemoveAt(0);
            }
        }

        static void Main(string[] args) {
            Console.WriteLine("Lab4. Daniels Keziks. 4701BD. 21.11.2018");

            _graph = new List<List<int>> {
                new List<int> {5},
                new List<int> {6},
                new List<int> {3, 5, 7},
                new List<int> {2},
                new List<int> {8, 9},
                new List<int> {0, 2},
                new List<int> {1, 7, 9, 11},
                new List<int> {2, 6, 11},
                new List<int> {4, 9},
                new List<int> {4, 6, 8, 10},
                new List<int> {9, 11},
                new List<int> {6, 7, 10}
            };
            InitGraphData();
            _queue = new List<int> {0};
            _isInQueue[0] = true;
            Bfs();

            Console.ReadKey();
        }
    }
}
