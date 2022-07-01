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
            Console.WriteLine("Finish");
        }
    }

    class PollFall{
        int[,] maps;
        int maze_width,maze_height;
        Random rd = new Random();

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

        public void MakeWall(){
            for(int _x = 2;_x<maze_width;_x+=2){
                for(int _y = 2;_y< maze_height;_y+=2){
                    maps[_x,_y] = 1;
                }
            }
            for(int _x = 2;_x<maze_width;_x+=2){
                for(int _y = 2;_y< maze_height;_y+=2){
                    if(_x == 2){
                        switch (rd.Next(0,4)){//上下左右
                            case 0:
                                if(maps[_x,_y+1]==1){
                                    _y-=2;
                                }else{
                                    maps[_x,_y+1] = 1;
                                }
                                break;

                            case 1:
                                if(maps[_x,_y-1]==1){
                                    _y-=2;
                                }else{
                                    maps[_x,_y-1] = 1;
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
                        switch (rd.Next(0,3)){//下左右
                            case 0:
                                if(maps[_x,_y-1]==1){
                                    _y-=2;
                                }else{
                                    maps[_x,_y-1] = 1;
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
        public void WriteDate(){
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"./CompMaze.txt",true);
                for(int _y = 0;_y<maze_height;_y++){
                    for(int _x = 0;_x < maze_width;_x++){
                        sw.Write(maps[_x,_y]);
                    }
                    sw.Write("\n");
                }
            sw.Close();
        }
    }

    class ExtendWall{//ToDo 個室が作られる。壁に到達した際にエラーが発生する。
        int[,] maps;
        int maze_width,maze_height,sx,sy;
        Random rd = new Random();
        bool finish = false;
        private int t = 0;

        public void Initialize(int width,int height){
            maze_width = width;
            maze_height = height;
            if((width%2 != 1 || height%2 != 1)||(width>4||height>4)){
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

        public void MakeWall(){
            sx = rd.Next(1,maze_width);
            sy = rd.Next(1,maze_height);
            maps[sx,sy] = 1;
            while(!finish){
                switch(rd.Next(0,4)){//上下左右
                    case 0:
                        if(sy+2 >= maze_height-1){
                            break;
                        }
                        if(maps[sx,sy+2]==1){
                            break;
                        }
                        t = 0;
                        maps[sx,sy+1] = 1;
                        maps[sx,sy+2] = 1;
                        sy+=2;
                        break;

                    case 1:
                        if(sy-2 <= 0){
                            break;
                        }
                        if(maps[sx,sy-2]==1){
                            break;
                        }
                        t=1;
                        maps[sx,sy-1] = 1;
                        maps[sx,sy-2] = 1;
                        sy-=2;
                        break;

                    case 2:
                        if(sx-2 <= 0){
                            break;
                        }
                        if(maps[sx-2,sy]==1){
                            break;
                        }
                        t=2;
                        maps[sx-1,sy] = 1;
                        maps[sx-2,sy] = 1;
                        sx-=2;
                        break;

                    case 3:
                        if(sx+2 >= maze_width-1){
                            break;
                        }
                        if(maps[sx+2,sy]==1){
                            break;
                        }
                        t=3;
                        maps[sx+1,sy] = 1;
                        maps[sx+2,sy] = 1;
                        sx+=2;
                        break;
                }
                for(int _y = 0;_y<maze_height;_y++){
                    for(int _x = 0;_x < maze_width;_x++){
                        Console.Write(maps[_x,_y]);
                    }
                    Console.Write("\n");
                }
                Console.Write("\n\n");
                if(!CheckWall(sx,sy,t)){
                    sx = rd.Next(1,maze_width);
                    sy = rd.Next(1,maze_height);
                }
                if(FinishCheck()){
                    break;
                }
            }
        }

        public bool CheckWall(int _x,int _y,int forward_t){
            bool ret = true;
            if((maps[_x+1,_y] == 1&&t!=2)||(maps[_x-1,_y] == 1&&t!=3)||(maps[_x,_y+1] == 1&&t!=1)||(maps[_x,_y-1] == 1&&t!=0)){
                ret = false;
            }
            return ret;
        }

        public bool FinishCheck(){
            bool ret = true;
            for(int _x= 0;_x<maze_width;_x++){
                for(int _y = 0;_y < maze_height;_y++){
                    if(!((_x+2 >= maze_width||maps[_x+2,_y]==1)&&(_x-2 <= 0||maps[_x-2,_y]==1)&&(_y-2 <= 0||maps[_x,_y-2]==1)&&(_y+2 >= maze_height||maps[_x,_y+2]==1))){
                        ret = false;
                    }
                }
            }
            return ret;
        }

        public void WriteDate(){
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"./CompMaze.txt",true);
                for(int _y = 0;_y<maze_height;_y++){
                    for(int _x = 0;_x < maze_width;_x++){
                        sw.Write(maps[_x,_y]);
                    }
                    sw.Write("\n");
                }
            sw.Close();
        }
    }
}
