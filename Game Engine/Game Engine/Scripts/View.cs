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
    public enum TweenType
    {
        Instant,
        Linear,
        QuadraticInOut,
        CubicInOut,
        QuarticOut,
        BounceOut
    }
    
    class View
    {
        private Vector2 position;
        public double rotation;
        public double zoom;

        private Vector2 positionGoTo, positionFrom;
        private TweenType tweenType;
        private int currentStep, tweenSteps;

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }
        public Vector2 PositionGoTo
        {
            get { return positionGoTo; }
        }

        public Vector2 ToWorld(Vector2 input)
        {
            input /= (float)zoom;
            Vector2 dX = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            Vector2 dY = new Vector2((float)Math.Cos(rotation+MathHelper.PiOver2), (float)Math.Sin(rotation + MathHelper.PiOver2));
            return (this.position + dX * input.X + dY * input.Y);
        }

        public View(Vector2 startPosition,double startZoom=1.0,double startRotation = 0.0)
        {
            this.position = startPosition;
            this.rotation = startRotation;
            this.zoom = startZoom;
        }

        public void Update()
        {
            if(currentStep < tweenSteps)
            {
                currentStep++;
                switch (tweenType)
                {
                    case TweenType.Linear:
                        position = positionFrom + (positionGoTo - positionFrom) * GetLinear((float)currentStep /
                            tweenSteps);
                        break;
                    case TweenType.QuadraticInOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetQuadraticInOut((float)currentStep /
                            tweenSteps);
                        break;
                    case TweenType.CubicInOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetCubicInOut((float)currentStep /
                            tweenSteps);
                        break;
                    case TweenType.QuarticOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetQuarticOut((float)currentStep /
                            tweenSteps);
                        break;
                    case TweenType.BounceOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetBounceOut((float)currentStep /
                            tweenSteps);
                        break;
                }
            }
            else
            {
                position = positionGoTo;
            }
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.position = newPosition;
            this.positionFrom = newPosition;
            this.positionGoTo = newPosition;
            tweenType = TweenType.Instant;
            currentStep = 0;
            tweenSteps = 0;
        }

        public void SetPosition(Vector2 newPosition,TweenType type, int numSteps)
        {
            this.positionFrom = position;
            this.position = newPosition;
            this.positionGoTo = newPosition;
            tweenType = type;
            currentStep = 0;
            tweenSteps = numSteps;
        }

        public float GetLinear(float t)
        {
            return t;
        }

        public float GetQuadraticInOut(float t)
        {
            return (t * t) / ((2 * t * t) - (2 * t) + 1);
        }

        public float GetCubicInOut(float t)
        {
            return (t * t * t) / ((3 * t * t) - (3 * t) + 1);
        }

        public float GetQuarticOut(float t)
        {
            return -((t - 1) * (t - 1) * (t - 1) * (t - 1)) + 1;
        }

        public float GetBounceOut(float t)
        {
            float p = 0.3f;
            return (float)Math.Pow(2, -10 * t) * (float)Math.Sin((t - p / 4) * (2 * Math.PI) / p) + 1;
        }

        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-position.X, -position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ((float)rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom,(float)zoom,1.0f));

            GL.MultMatrix(ref transform);


        }
    }
}
