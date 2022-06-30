using Internal;
using System;

namespace MazeArgorism
{
    class Program
    {
        int[,] maps = new int[,];
        int maze_width,maze_height;
        static void Main(string[] args){
            Console.WriteLine("Set Map Height.");
            maze_height = int.Parse(Console.ReadLine());
            Console.WriteLine("Set Map Width.");
            maze_width = int.Parse(Console.ReadLine());
            maps = new int[maze_width,maze_height];
            for(int _x =0;_x<maze_width;_x++){
                for(int _y = 0;_y < maze_height;_y++){
                    maps[_x,_y] = 0;
                }
            }
        }
    }
}
