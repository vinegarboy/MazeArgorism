using System;

namespace MazeArgorism
{
    class Program
    {
        int[,] maps = new int[,];
        //0=通路 1=壁
        int maze_width,maze_height,sx,sy;
        bool finish = false;
        static void Main(string[] args){
            Console.WriteLine("Set Map Height.");
            maze_height = int.Parse(Console.ReadLine());
            Console.WriteLine("Set Map Width.");
            maze_width = int.Parse(Console.ReadLine());
            maps = new int[maze_width,maze_height];
            for(int _x =0;_x<maze_width;_x++){
                for(int _y = 0;_y < maze_height;_y++){
                    maps[_x,_y] = 0;
                    if((_x == 0||_x == maze_width-1)||(_y == 0||_y == maze_height-1)){
                        maps[_x,_y] = 1;
                    }
                }
            }
            Random rd = new Random();
            sx = rd.Next(1,maze_width);
            sy = rd.Next(1,maze_height);
            while(!finish){
                switch(rd.Next(0,4)){//上下左右
                    case 0:
                        if(sy+2 >= maze_height){
                            break;
                        }
                        if(maps[sx,sy+2]==1){
                            break;
                        }
                        break;

                    case 1:
                        if(sy-2 <= 0){
                            break;
                        }
                        if(maps[sx,sy-2]==1){
                            break;
                        }
                        break;

                    case 2:
                        if(sx-2 <= 0){
                            break;
                        }
                        if(maps[sx-2,sy]==1){
                            break;
                        }
                        break;

                    case 3:
                        if(sx+2 >= maze_height){
                            break;
                        }
                        if(maps[sx+2,sy]==1){
                            break;
                        }
                        break;
                }
                if(!ret){
                    
                }
            }
        }

        public bool CheckWall(int _x,int _y){
            bool ret = true;
            if((_x+2 >= maze_height||maps[_x+2,_y]==1)&&(_x-2 <= 0||maps[_x-2,_y]==1)&&(_y-2 <= 0||maps[_x,_y-2]==1)&&(_y+2 >= maze_height||maps[_x,_y+2]==1)){
                ret = false;
            }
            return ret;
        }
    }
}
