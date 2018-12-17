using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd
{
    class Program
    {
        const int Infinity = int.MaxValue;
        
        static void Main(string[] args)
        {
            double[,] gr = new double[5, 5] { { 0, 12, 5, Infinity, 2 },
                                              { 7, 0, 11, Infinity, 10 },
                                              { 4, 7, 0, Infinity, 17 },
                                              { 19, 2, 5, 0, 4 },
                                              { 15, 8, 1, Infinity, 0} };

            Floyd floyd = new Floyd(5, gr);
            floyd.Calculate();

            Console.ReadKey();
        }

        class Floyd
        {
            public int VertexCount { get; set; }

            public double[,] Graph { get; set; }
            
            public Floyd(int vertexCount, double[,] g)
            {
                this.VertexCount = vertexCount;

                this.Graph = g;
            }

            public void Calculate()
            {
                for (int k = 0; k < this.VertexCount; k++)
                {
                    for (int i = 0; i < this.VertexCount; i++)
                    {
                        for (int j = 0; j < this.VertexCount; j++)
                        {
                            if (this.Graph[i, k] < Infinity && this.Graph[k, j] < Infinity)
                            {
                                this.Graph[i, j] = (this.Graph[i, j] < this.Graph[i, k] + this.Graph[k, j]) ? this.Graph[i, j] : this.Graph[i, k] + this.Graph[k, j];
                            }
                        }
                    }
                }

                for (int i = 0; i < this.VertexCount; i++)
                {
                    if (this.Graph[i, i] < 0)
                    {
                        throw new Exception("Incorrect input!");
                    }
                }

                for (int i = 0; i < this.VertexCount; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < this.VertexCount; j++)
                    {
                        if (this.Graph[i, j] == Infinity)
                        {
                            Console.Write("No ");
                        }
                        else
                        {
                            Console.Write(this.Graph[i, j] + " ");
                        }
                    }
                }              
            }
        }
    }
}
