using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Graphics.Shaders
{
    public static class fragShader
    {
        public static string data =
        "#version 430\n" +
        "layout(location = 0) in vec2 coordTexture;\n" +
        "uniform sampler2D texture;\n" +
        "layout(location = 0) out vec4 out_Color;\n" +
        "void main()\n" +
        "{\n" +
        "out_Color = texture(texture, coordTexture);\n" +
        "}";
    }
}
