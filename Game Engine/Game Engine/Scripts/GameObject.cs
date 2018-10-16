using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Game_Engine
{
   struct GameObject
   {
      public Texture2D texture{ get; set; }
      public Vector2 position { get; set; }
      public Vector2 scale { get; set; }

      public GameObject(Texture2D tex, Vector2 pos, Vector2 sc) {
          texture = tex;
          position = pos;
          scale = sc;
      }
   }
}
