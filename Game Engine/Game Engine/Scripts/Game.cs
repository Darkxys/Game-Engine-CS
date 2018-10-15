using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace Game_Engine
{
    class Game : GameWindow
    {
        Texture2D texture;
        View view;

        public Game(int width, int height)
            : base(width, height)
        {
            GL.Enable(EnableCap.Texture2D);
            view = new View(Vector2.Zero,1,0);
            Input.Initialize(this);
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            texture = ContentPipe.LoadTexture("tileSetCol.jpg");
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            /* Exemple pour check les input
            
            if (Input.MousePress(MouseButton.Left))
            {
                Vector2 pos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y) - new Vector2(this.Width, this.Height) / 2f;
                pos = view.ToWorld(pos);

                view.SetPosition(pos, TweenType.QuadraticInOut, 60);
            }*/

            view.Update();
            Input.Update();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            Spritebatch.Begin(this.Width, this.Height);
            view.ApplyTransform();

            Spritebatch.Draw(texture,Vector2.Zero, new Vector2(0.5f, 0.5f),Color.White, new Vector2(10, 50));
            
            this.SwapBuffers();
        }

    }
}
