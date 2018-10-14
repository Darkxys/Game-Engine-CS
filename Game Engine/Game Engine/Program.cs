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
    class Program
    {
        private static GameWindow window;
        static void Main(string[] args)
        {
            
            window = new GameWindow(1280, 720, GraphicsMode.Default, "Game Engine");
            window.Resize += OnResize;
            window.UpdateFrame += OnUpdateFrame;
            window.RenderFrame += OnRenderFrame;

            window.Run();
        }

        private static void OnResize(object sender, EventArgs e)
        {
        }

        private static void OnRenderFrame(object sender, FrameEventArgs e)
        {

            GL.ClearColor(0,0,0,0);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            window.SwapBuffers();
        }

        private static void OnUpdateFrame(object sender, FrameEventArgs e)
        {
        }
    }
}
