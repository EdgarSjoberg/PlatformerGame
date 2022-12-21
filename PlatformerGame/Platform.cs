using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace PlatformerGame
{
    internal class Platform : Tiles
    {

        public Platform(Texture2D texture, Rectangle hitBox) : base(texture, hitBox)
        {

        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.White);
        }
    }
}
