using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PlatformerGame
{
    internal class Camera
    {
        private Matrix transform;  //håller en transformation från position i spelvärden till position i fönstret. 
        private Vector2 position;  //spelarens position
        private Viewport view;     //kamera vyn (det av världen man ser)

        public Matrix Transform
        {
            get { return transform; }
        }
        public Camera(Viewport view)
        {
            this.view = view;
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
            transform = Matrix.CreateTranslation(-position.X + view.Width / 2, -position.Y + view.Height / 2, 0);
        }
    }

}
