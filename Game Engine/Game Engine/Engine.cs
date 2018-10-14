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
using Game_Engine.Graphics.Drawer2D;
using Game_Engine.Graphics.Shaders;
using Game_Engine.Graphics.Textures;

namespace Game_Engine
{
    class Engine
    {
        private static GameWindow window;
        private static imageDrawer drawer;
        private static Shader shader;
        private static Texture text;
        
        static void Main(string[] args)
        {

            drawer = new imageDrawer();
            window = new GameWindow(1280, 720, GraphicsMode.Default, "Game Engine");
            text = new Texture("testTiles.jpg");
            window.Resize += OnResize;
            window.UpdateFrame += OnUpdateFrame;
            window.RenderFrame += OnRenderFrame;

            shader = new Shader();
            
            window.Run();
        }

        private static void OnResize(object sender, EventArgs e)
        {
            
        }

        private static void OnRenderFrame(object sender, FrameEventArgs e)
        {

            GL.ClearColor(0,0,0,0);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            shader.Bind();
            text.Bind();
            drawer.DrawImage(0,0,1,1);



            window.SwapBuffers();
        }

        private static void OnUpdateFrame(object sender, FrameEventArgs e)
        {
        }
    }
}
