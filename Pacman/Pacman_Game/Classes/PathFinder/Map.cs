using Pacman_Game.Classes.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Game.Classes.PathFinder
{
    public static class Map
    {
        public static readonly int Tile_Size = 20; // 20 pixels
        public static readonly string Path = "../../Classes/Resources/";
        public static readonly string file = "Map.txt";
        public static List<Abstract_Entity> entities = null;
        public static int MaxRows; //
        public static int MaxColumns;
        
        public static void LoadData()
        {
            Map.entities = new List<Abstract_Entity>();
            //lê o arquivo Map.txt e se basea na quantidade de linha e colunas q ele tem 
            //para montar o tamanho do cenário
            //as letras q estão nesse arquivo significam peças diferentes do cenário
            string[] lines = File.ReadAllLines(Map.Path + Map.file); //tamanho de y
            Map.MaxRows = lines.Length; //tamanho de x
            int row = 0;
            
            foreach(string line in lines)
            {
                char[] chars = line.ToCharArray();
                Map.MaxColumns = chars.Length;
                int column = 0;
                foreach (char character in chars)
                {
                    //Aqui ele começa a interpretar o arquivo e ir montanto cara 
                    //um dos elementos do cenário
                    Abstract_Entity obj = null;
                    switch (character)
                    {
                        case 'W': //Create Wall
                            obj = new Wall(row, column);
                            break; 
                        case 'D': //Create dot
                            obj = new Dot(row, column);
                            break;
                        case 'B': //Create booster
                            obj = new Booster(row, column);
                            break;
                        case 'F': //Create fruit
                            obj = new Fruits(row, column);
                            break;
                        case 'R': //Create ghost room
                            obj = new Ghost_Room(row, column);
                            break;
                        case 'T': //Create empty tile
                            obj = new Empty_Tile(row, column);
                            break;
                        case 'P': //Create Pacman
                            obj = new Pacman(row, column);
                            break;

                    }
                    Map.entities.Add(obj);
                    column++;
                }
                row++;
            }   
        }
    }
}
