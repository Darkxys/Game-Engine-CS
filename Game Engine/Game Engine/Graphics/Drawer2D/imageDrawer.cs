using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Game_Engine.Graphics.Drawer2D
{
    public class imageDrawer
    {
        public void DrawImage(float x, float y, float w, float h) {

            float[] vertices = new float[] {
                x + 0.0f,   y + h,
                x + 0.0f,   y + 0.0f,
                x + w,      y + 0.0f,
            
                x + w,      y + 0.0f,
                x + w,      y + h,
                x + 0.0f,   y + h
            };

            float[] coordTexture = {0, 0,   1, 0,   1, 1, 
                                    0, 0,   0, 1,   1, 1};

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, vertices);
                GL.EnableVertexAttribArray(0);
     
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 0, coordTexture);
                GL.EnableVertexAttribArray(1);

            GL.DrawArrays(BeginMode.Triangles, 0, 6);

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);

        }

    }
}
