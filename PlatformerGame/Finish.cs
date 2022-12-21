using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PlatformerGame
{
    internal class Finish : Tiles
    {
        public Finish(Texture2D texture, Rectangle hitBox) : base(texture, hitBox)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.Green);
        }
    }
}
