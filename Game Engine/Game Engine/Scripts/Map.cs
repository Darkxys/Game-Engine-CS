using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;
using System.IO;

namespace Game_Engine
{
   struct Map
   {
      private Block[,] grid;
      private string fileName;
      public Point playerStartPos;

      public Block this[int x, int y]{
         get{
            return grid[x, y];
         }
         set{
            grid[x, y] = value;
         }
      }
      public string FileName{
         get{
            return fileName;
         }
      }
      public int Width{
         get{
            return grid.GetLength(0);
         }
      }
      public int Height
      {
         get
         {
            return grid.GetLength(1);
         }
      }

      public Map(int width, int height){
         grid = new Block[width, height];
         fileName = "none";
         playerStartPos = new Point(1, 1);

         for (int x = 0; x < width; x++)
         {
            for (int y = 0; y < height; y++)
            {
               if(x==0||y==0||x==width-1||y==height-1){
                  grid[x, y] = new Block(BlockType.Solid, x, y);
               } else{    
                  grid[x, y] = new Block(BlockType.Empty, x, y);
               }
            }
         }
      }
   }
   public enum BlockType{
      Solid,
      Empty,
      Platform,
      Stairs   
   }
   struct Block{
      private BlockType type;
      private int posX, posY;
      private bool isSolid, isPlatform, isStairs;
                  
      public BlockType Type{
         get{ return type; }
      }
      public int X
      {
         get { return posX; }
      }
      public int Y
      {
         get { return posY; }
      }
      public bool IsStairs
      {
         get { return isStairs; }
      }
      public bool IsPlatform
      {
         get { return isPlatform; }
      }
      public bool IsSolid
      {
         get { return isSolid; }
      }

      public Block(BlockType bType,int x, int y){
         type = bType;
         posX = x;
         posY = y;

         isStairs = false;
         isPlatform = false;
         isSolid = false;

         switch(bType){
            case BlockType.Stairs:
               isStairs = true;
               break;
            case BlockType.Platform:
               isPlatform = true;
               break;   
            case BlockType.Solid:
               isSolid = true;
               break;
            default:
               break;
               
         }
      }
   }
}
