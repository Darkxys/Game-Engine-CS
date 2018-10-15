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
    class Engine
    {
        static void Main(string[] args)
        {
            GameWindow window = new Game(1280, 720);
            //window.WindowState = WindowState.Fullscreen;
            window.Run();
        }
        
    }
}
