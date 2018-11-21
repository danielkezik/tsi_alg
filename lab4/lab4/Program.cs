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
        private static List<Edge> _edges;
        private static List<int> _queue;

        private static void InitGraphData() {
            _isInQueue = new List<bool>();
            foreach (var unused in _graph) { _isInQueue.Add(false); }
            _edges = new List<Edge>();
            for (var i = 0; i < _graph.Max(l => l.Max()) + 1; i++) _edges.Add(new Edge { a = -1, b = -1 });
            for (var i = 0; i < _graph.Count; i++) {
                foreach (var edge in _graph[i]) {
                    if (_edges[edge].a < 0) {
                        _edges[edge].a = i;
                    } else {
                        _edges[edge].b = i;
                    }
                }
            }
        }

        private static void Bfs() {
            while (_queue.Count > 0) {
                var v = _queue.First();
                Console.WriteLine(v);
                foreach (var edge in _graph[v]) {
                    var tmp = _edges[edge].a == v ? _edges[edge].b : _edges[edge].a;
                    if (!_isInQueue[tmp]) {
                        _queue.Add(tmp);
                        _isInQueue[tmp] = true;
                    }
                }
                _queue.RemoveAt(0);
            }
        }

        static void Main(string[] args) {
            Console.WriteLine("Lab4. Daniels Keziks. 4701BD. 21.11.2018");

            _graph = new List<List<int>> {
                new List<int> {0},
                new List<int> {1},
                new List<int> {2, 3, 4},
                new List<int> {3},
                new List<int> {11, 13},
                new List<int> {0, 2},
                new List<int> {1, 5, 7, 9},
                new List<int> {4, 5, 6},
                new List<int> {12, 13},
                new List<int> {9, 10, 11, 12},
                new List<int> {8, 10},
                new List<int> {6, 7, 8}
            };
            InitGraphData();
            _queue = new List<int> {0};
            Bfs();

            Console.ReadKey();
        }
    }
}
