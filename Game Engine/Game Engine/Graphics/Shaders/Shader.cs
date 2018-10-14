using System;
using OpenTK.Graphics.OpenGL;

namespace Game_Engine.Graphics.Shaders
{
    public class Shader
    {
        public int progID;

        public Shader()
        {
            progID = GL.CreateProgram();
            AttachShader(ShaderType.FragmentShader, fragShader.data);
            AttachShader(ShaderType.VertexShader, vertShader.data);

            GL.LinkProgram(progID);
            var infoLog = GL.GetProgramInfoLog(progID);

            if (!string.IsNullOrEmpty(infoLog))
            {
                Console.WriteLine("Shader error:" + infoLog);
            }
        }

        public void Bind() => GL.UseProgram(progID);

        private void AttachShader(ShaderType type, string source)
        {
            var id = GL.CreateShader(type);
            GL.ShaderSource(id, source);
            GL.CompileShader(id);
            GL.AttachShader(progID, id);
        }
    }
}
