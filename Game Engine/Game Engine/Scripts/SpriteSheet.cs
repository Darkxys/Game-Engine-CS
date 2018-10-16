using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;

namespace Game_Engine.Scripts
{
   class SpriteSheet
   {
      private Bitmap texImg;
      private Texture2D texture;
      public Vector2 scale{ get; set; }

      public SpriteSheet(Vector2 sc,string path){
         texture = ContentPipe.LoadTexture(path);
         scale = sc;
         texImg = new Bitmap(path);
      }
      
   }
}
