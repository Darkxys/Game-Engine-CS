using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Game_Engine
{
    class EngineTest
    {
        static void Main(string[] args)
        {
            GameWindow window = new MainGame(1280, 720);
            //window.WindowState = WindowState.Fullscreen;
            window.Run();
        }
        
    }


    abstract class Game : GameWindow
     {
         public Game(int width, int height)
             : base(width, height)
         {
             GL.Enable(EnableCap.Texture2D);
         GL.Enable(EnableCap.Blend);
         GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
         Input.Initialize(this);
         }

         protected override void OnLoad(EventArgs e)
         {
             base.OnLoad(e);
             toLoadStart();
         }
         protected override void OnUpdateFrame(FrameEventArgs e)
         {
             base.OnUpdateFrame(e);

             UpdateData();
         }
         protected override void OnRenderFrame(FrameEventArgs e)
         {
             base.OnRenderFrame(e);

             GL.Clear(ClearBufferMask.ColorBufferBit);

             Spritebatch.Begin( Width,  Height);

             UpdateRender();

              SwapBuffers();
         }
         protected virtual void toLoadStart() { }
         protected virtual void UpdateData() { }
         protected virtual void UpdateRender() { }

     }

     class MainGame : Game
     {
         public static int GRIDSIZE = 32,TILESIZE = 15;
         GameObject[] layers;
         Texture2D texture,tileset;
         Map map;
      float x1 = 0f;
      float y1 = 0f;
      int wow = 0;
      View view;
         public MainGame(int width, int height) : base(width, height)
      {
         GL.Enable(EnableCap.Texture2D);
         GL.Enable(EnableCap.Blend);
         GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
      }
         protected override void toLoadStart()
         {
            view = new View(Vector2.Zero,1,0);
            layers = new GameObject[4];                                                                                    
            tileset = ContentPipe.LoadTexture("tileSetTest.png");
            map = new Map(20, 20);
         }
         protected override void UpdateData()
         {
            view.SetPosition(new Vector2(wow, wow), TweenType.QuadraticInOut, 60);
            wow+=5;
            view.Update();         
         }
         protected override void UpdateRender()
         {
         view.ApplyTransform();                                                             
         float x2, y2;
         
         for (int x = 0; x < map.Width; x++)
         {
            for (int y = 0; y < map.Height; y++)
            {
               x2 =0.5f;
               y2 =0.5f;
               RectangleF source = new RectangleF(x2, y2, (float)TILESIZE, (float)TILESIZE);


               Spritebatch.Draw(tileset, new Vector2(x * GRIDSIZE, y * GRIDSIZE), new Vector2((float)GRIDSIZE / (float)TILESIZE), Color.White, Vector2.Zero, source);
               x2 = 16.5f;
               y2 = 0.5f;
               RectangleF source1 = new RectangleF(x2, y2, (float)TILESIZE, (float)TILESIZE);

               Spritebatch.Draw(tileset, new Vector2(x * GRIDSIZE, y * GRIDSIZE), new Vector2((float)GRIDSIZE / (float)TILESIZE), Color.White, Vector2.Zero, source1);

            }
         }
         


      }
   }
     
}
