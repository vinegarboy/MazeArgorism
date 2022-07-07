using System;

namespace MazeArgorism
{
    class Program
    {
        static void Main(string[] args){
            PollFall ew = new PollFall();
            Console.WriteLine("Set Map Height.");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Set Map Width.");
            int width = int.Parse(Console.ReadLine());
            ew.Initialize(width,height);
            ew.MakeWall();
            ew.WriteDate();
            ew.WriteCube();
            Console.WriteLine("Finish");
        }
    }

    internal class MakeWallFunc{
        internal int[,] maps;
        internal int maze_width,maze_height;
        internal Random rd = new Random();

        public void Initialize(int width,int height){
            maze_width = width;
            maze_height = height;
            if((width%2 != 1 || height%2 != 1)||(width<5||height<5)){
                throw new Exception("The size of the maze must be odd and at least 5 blocks.");
            }
            maps = new int[maze_width,maze_height];
            for(int _x =0;_x<maze_width;_x++){
                for(int _y = 0;_y < maze_height;_y++){
                    maps[_x,_y] = 0;
                }
            }
            for(int i = 0;i<maze_width;i++){
                maps[i,0] = 1;
                maps[i,maze_height-1] = 1;
            }
            for(int i = 0;i<maze_height;i++){
                maps[0,i] = 1;
                maps[maze_width-1,i]= 1;
            }
        }

        public void WriteDate(){
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"./CompMaze.txt",false);
            for(int _y = 0;_y<maze_height;_y++){
                for(int _x = 0;_x < maze_width;_x++){
                    sw.Write(maps[_x,_y]);
                }
                sw.Write("\n");
            }
            sw.Close();
        }

        public void WriteCube(){
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"./CompMaze_Cube.txt",false);
            for(int _y = 0;_y<maze_height;_y++){
                for(int _x = 0;_x < maze_width;_x++){
                    if(maps[_x,_y]==0){
                        sw.Write("□");
                    }else{
                        sw.Write("■");
                    }
                }
                sw.Write("\n");
            }
            sw.Close();
        }

    }

    class PollFall:MakeWallFunc{
        public void MakeWall(){
            for(int _x = 2;_x<maze_width;_x+=2){
                for(int _y = 2;_y< maze_height;_y+=2){
                    maps[_x,_y] = 1;
                }
            }
            for(int _x = 2;_x<maze_width-1;_x+=2){
                for(int _y = 2;_y< maze_height-1;_y+=2){
                    if(_x == 1){
                        rd = new Random();
                        switch (rd.Next(0,4)){//上下左右
                            case 0:
                                if(maps[_x,_y-1]==1){
                                    _y-=2;
                                }else{
                                    maps[_x,_y-1] = 1;
                                }
                                break;

                            case 1:
                                if(maps[_x,_y+1]==1){
                                    _y-=2;
                                }else{
                                    maps[_x,_y+1] = 1;
                                }
                                break;

                            case 2:
                                if(maps[_x-1,_y]==1){
                                    _y-=2;
                                }else{
                                    maps[_x-1,_y] = 1;
                                }
                                break;

                            case 3:
                                if(maps[_x+1,_y]==1){
                                    _y-=2;
                                }else{
                                    maps[_x+1,_y] = 1;
                                }
                                break;
                        }
                    }else{
                        rd = new Random();
                        switch (rd.Next(0,3)){//下左右
                            case 0:
                                if(maps[_x,_y+1]==1){
                                    _y-=2;
                                }else{
                                    maps[_x,_y+1] = 1;
                                }
                                break;

                            case 1:
                                if(maps[_x-1,_y]==1){
                                    _y-=2;
                                }else{
                                    maps[_x-1,_y] = 1;
                                }
                                break;

                            case 2:
                                if(maps[_x+1,_y]==1){
                                    _y-=2;
                                }else{
                                    maps[_x+1,_y] = 1;
                                }
                                break;
                        }
                    }
                }
            }
        }
    }

    class ExtendWall:MakeWallFunc{//ToDo 個室が作られる。
        int sx,sy;
        bool finish = false;

        public void MakeWall(){
            sx = 2*rd.Next(1,(int)(maze_width-2)/2);
            sy = 2*rd.Next(1,(int)(maze_height-2)/2);
            maps[sx,sy] = 1;
            while(!finish){
                maps[sx,sy] = 1;
                //DebugDate();
                rd = new Random();
                switch(rd.Next(0,4)){//上下左右
                    case 0:
                        if(maps[sx,sy-2] == 1){
                            while((maps[sx,sy] == 1)&&!FinishCheck()){
                                sx = 2*rd.Next(1,(int)(maze_width-2)/2);
                                sy = 2*rd.Next(1,(int)(maze_height-2)/2);
                            }
                            break;
                        }
                        maps[sx,sy-1] = 1;
                        maps[sx,sy-2] = 1;
                        sy-=2;
                        break;

                    case 1:
                        if(maps[sx,sy+2] == 1){
                            while((maps[sx,sy] == 1)&&!FinishCheck()){
                                sx = 2*rd.Next(1,(int)(maze_width-2)/2);
                                sy = 2*rd.Next(1,(int)(maze_height-2)/2);
                            }
                            break;
                        }
                        maps[sx,sy+1] = 1;
                        maps[sx,sy+2] = 1;
                        sy+=2;
                        break;

                    case 2:
                        if(maps[sx-2,sy] == 1){
                            while((maps[sx,sy] == 1)&&!FinishCheck()){
                                sx = 2*rd.Next(1,(int)(maze_width-2)/2);
                                sy = 2*rd.Next(1,(int)(maze_height-2)/2);
                            }
                            break;
                        }
                        maps[sx-1,sy] = 1;
                        maps[sx-2,sy] = 1;
                        sx-=2;
                        break;

                    case 3:
                        if(maps[sx+2,sy] == 1){
                            while((maps[sx,sy] == 1)&&!FinishCheck()){
                                sx = 2*rd.Next(1,(int)(maze_width-2)/2);
                                sy = 2*rd.Next(1,(int)(maze_height-2)/2);
                            }
                            break;
                        }
                        maps[sx+1,sy] = 1;
                        maps[sx+2,sy] = 1;
                        sx+=2;
                        break;
                }
                if(TouchWall(sx,sy)){
                    while((maps[sx,sy] == 1)&&!FinishCheck()){
                        sx = 2*rd.Next(1,(int)(maze_width-2)/2);
                        sy = 2*rd.Next(1,(int)(maze_height-2)/2);
                    }
                }
                if(FinishCheck()){
                    break;
                }else if(!CanMakeCheck(sx,sy)){
                    sx = 2*rd.Next(1,(int)(maze_width-2)/2);
                    sy = 2*rd.Next(1,(int)(maze_height-2)/2);
                }
            }
        }

        private bool TouchWall(int _x,int _y){
            if((_x==0||_x==maze_width-1)||(_y==0||_y==maze_height-1)){
                return true;
            }else{
                return false;
            }

        }
        private bool CanMakeCheck(int _x,int _y){
            int count = 0;
            if(maps[_x-1,_y] == 1){
                count++;
            }
            if(maps[_x+1,_y] == 1){
                count++;
            }
            if(maps[_x,_y-1] == 1){
                count++;
            }
            if(maps[_x,_y+1] == 1){
                count++;
            }
            if(count >= 2){
                return false;
            }else{
                return true;
            }
        }

        private bool FinishCheck(){
            bool ret = true;
            for(int _x= 2;_x<maze_width-1;_x+=2){
                for(int _y = 2;_y < maze_height-1;_y+=2){
                    if(!((_x+2 >= maze_width||maps[_x+2,_y]==1)&&(_x-2 <= 0||maps[_x-2,_y]==1)&&(_y-2 <= 0||maps[_x,_y-2]==1)&&(_y+2 >= maze_height||maps[_x,_y+2]==1))){
                        ret = false;
                    }
                }
            }
            return ret;
        }

        private void DebugDate(){
            for(int _y = 0;_y<maze_height;_y++){
                for(int _x = 0;_x < maze_width;_x++){
                    if(maps[_x,_y]==0){
                        Console.Write("□");
                    }else{
                        Console.Write("■");
                    }
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

    }

    class DigWall:MakeWallFunc{
    }
}
