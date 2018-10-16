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
         public static int GRIDSIZE = 32;
         GameObject[] layers;
         Texture2D texture,tileset;
         Map map;
         public MainGame(int width, int height) : base(width, height) { }
         protected override void toLoadStart()
         {
            layers = new GameObject[4];
            GameObject go = new GameObject(ContentPipe.LoadTexture("tileSetTest.png"), Vector2.Zero, new Vector2(1, 1));
            tileset = ContentPipe.LoadTexture("tileSetTest.png");
            map = new Map(20, 20);
         }
         protected override void UpdateData()
         {

         }
         protected override void UpdateRender()
         {
            //Spritebatch.Draw(texture, Vector2.Zero, new Vector2(0.5f, 0.5f), Color.White);
            
         }
     }
     
}
