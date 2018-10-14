using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System;

namespace Game_Engine.Graphics.Textures
{
    public class Texture
    {
        private int textureID;
        private Bitmap image;
        private BitmapData data;

        public Texture(string file) {
            image = (Bitmap)Image.FromFile(file);
            data = image.LockBits(new Rectangle(new Point(0), image.Size), 
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            textureID = GL.GenTexture();

            Bind();
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);
            image.UnlockBits(data);
        }

        public void Bind() {
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, textureID);

        }
    }
}
