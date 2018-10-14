using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

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
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.LinearMipmapLinear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Nearest);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.Bitmap, data.Scan0);

        }

        public bool Bind() {
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            return true;
        }
    }
}
