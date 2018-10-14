using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Graphics.Shaders
{
    static class vertShader
    {
        public static string data =
        "#version 430\n" +
         "layout(location = 0) in vec2 in_Vertex;\n" +
         "layout(location = 1) in vec2 in_TexCoord0;\n" +
         "layout(location = 0) out vec2 coordTexture;\n" +
         "void main()\n" +
         "{\n" +
         "gl_Position = vec4(in_Vertex, 0.0, 1.0);\n" +
         "coordTexture = in_TexCoord0;\n" +
         "}";
    }
}
