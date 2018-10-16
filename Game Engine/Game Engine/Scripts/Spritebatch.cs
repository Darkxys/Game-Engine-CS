using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Game_Engine
{
    class Spritebatch
    {                       
        public static void Draw(Texture2D texture,Vector2 position,Vector2 scale, Color color,Vector2 origin,RectangleF? sourceRec = null)
        {
            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(0,1)
            };

            Vector2[] text = new Vector2[4]
            {
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(0,0)
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color);

            for (int i = 0; i < 4; i++)
            {
                if(sourceRec == null)
                  GL.TexCoord2(text[i]);
               else{
               GL.TexCoord2(sourceRec.Value.Left + text[i].X * sourceRec.Value.Width,
               sourceRec.Value.Top + text[i].Y * sourceRec.Value.Height);
               }
                vertices[i].X *= texture.Width;
                vertices[i].Y *= texture.Height;   
                vertices[i] *= scale;
                vertices[i] += position;

                GL.Vertex2(vertices[i]);
            }

            GL.End();
        }

        public static void Begin(int screenWidth,int screenHeight)
        {
        int tmp = a
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-screenWidth / 2f, screenWidth / 2f, -screenHeight / 2f, screenHeight / 2f, 0f, 1f);
        }
    }
}
