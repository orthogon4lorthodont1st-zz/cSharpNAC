using System;
namespace ConsoleApplication{
    public class Program{
        public static void Main(string[] args){ 
            bool isWinner = GameMethods.checkWinner();
            while(isWinner == false){
                GameMethods.printBoard();
                string[] moves = GameMethods.getPlayerMove();
                int x = int.Parse(moves[0]);
                int y = int.Parse(moves[1]);
                GameMethods.updateBoard(x, y, "X");
                GameMethods.computerMove();
                isWinner = GameMethods.checkWinner(); 
            }
            return;                         
        }
    }
    public class GameMethods{
        static bool[,] squaresState = new bool[3, 3];
        static int[,] myMoves = {};
        static string[,] squares = new string[3, 3] { {" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "} };
        public static void printBoard(){
            Console.WriteLine("Current State: \n " );
            Console.WriteLine( " " + squares[0,0] + "  |  " + squares[0,1] + "  |  " + squares[0,2] );
            Console.WriteLine( "---------------" );
            Console.WriteLine( " " + squares[1,0] + "  |  " + squares[1,1] + "  |  " + squares[1,2] );
            Console.WriteLine( "---------------" );
            Console.WriteLine( " " + squares[2,0] + "  |  " + squares[2,1] + "  |  " + squares[2,2] + "\n" );
        }
        public static void updateBoard(int x, int y, string player){
            squaresState[x,y] = true;
            squares[x,y] = player;
            Console.WriteLine("Current State: \n " );
            Console.WriteLine( " " + squares[0,0] + "  |  " + squares[0,1] + "  |  " + squares[0,2] );
            Console.WriteLine( "---------------" );
            Console.WriteLine( " " + squares[1,0] + "  |  " + squares[1,1] + "  |  " + squares[1,2] );
            Console.WriteLine( "---------------" );
            Console.WriteLine( " " + squares[2,0] + "  |  " + squares[2,1] + "  |  " + squares[2,2] + "\n" );        
        }
        public static string[] getPlayerMove(){
            Console.WriteLine("The co-ords (0,0) are the top left. Please enter co-ords of your move, e.g. '2,1'. \n");
            string[] moves = Console.ReadLine().Split(',');
            Console.WriteLine("moves 0: " + moves[0]);
            if(moves.Length == 2){
                if(int.Parse(moves[0]) >= 0 && int.Parse(moves[0]) <= 2 && int.Parse(moves[1]) >= 0 && int.Parse(moves[1]) <= 2){
                    if(squaresState[int.Parse(moves[0]),int.Parse(moves[1])] !=true){
                        return moves;
                    }
                }
            }
            Console.WriteLine("Please choose correctly \n \n");
            return getPlayerMove();    
        }
        public static void computerMove(){
            Random rand = new Random();
            int x = rand.Next(0,3);
            int y = rand.Next(0,3);
            if(squaresState[x,y] == false){
                updateBoard(x, y, "O"); 
                return;
            }
            computerMove();
        }
        public static bool checkWinner(){
            int[,] winMatrix = { {0,1,2},{3,4,5},{6,7,8},{0,3,6},{1,4,7},{2,5,8},{0,4,8},{2,4,6} };
            if( (squares[0,0] == "O" && squares[0,1] == "O" && squares[0,2] == "O") ||
                (squares[1,0] == "O" && squares[1,1] == "O" && squares[1,2] == "O") ||
                (squares[2,0] == "O" && squares[2,1] == "O" && squares[2,2] == "O") ||
                (squares[0,0] == "O" && squares[1,0] == "O" && squares[2,0] == "O") ||
                (squares[0,1] == "O" && squares[1,1] == "O" && squares[2,1] == "O") ||
                (squares[0,2] == "O" && squares[1,2] == "O" && squares[2,2] == "O") ||
                (squares[0,0] == "O" && squares[1,1] == "O" && squares[2,2] == "O") ||
                (squares[0,2] == "O" && squares[1,1] == "O" && squares[2,0] == "O") ){
                Console.WriteLine("Winner O");
                return true;
            }
            else if( (squares[0,0] == "X" && squares[0,1] == "X" && squares[0,2] == "X") ||
                (squares[1,0] == "X" && squares[1,1] == "X" && squares[1,2] == "X") ||
                (squares[2,0] == "X" && squares[2,1] == "X" && squares[2,2] == "X") ||
                (squares[0,0] == "X" && squares[1,0] == "X" && squares[2,0] == "X") ||
                (squares[0,1] == "X" && squares[1,1] == "X" && squares[2,1] == "X") ||
                (squares[0,2] == "X" && squares[1,2] == "X" && squares[2,2] == "X") ||
                (squares[0,0] == "X" && squares[1,1] == "X" && squares[2,2] == "X") ||
                (squares[0,2] == "X" && squares[1,1] == "X" && squares[2,0] == "X") ){
                Console.WriteLine("Winner X");
                return true;
            }else{
                Console.WriteLine("no winner");
                return false;
            }
        }
    } 
}
