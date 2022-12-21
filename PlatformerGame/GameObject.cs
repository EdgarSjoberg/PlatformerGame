using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace PlatformerGame
{
    internal abstract class GameObject
    {
        protected Vector2 direction;
        protected Vector2 velocity;
        protected float speed;
        protected Vector2 position;
        protected Texture2D texture;
        protected Rectangle hitBox;
        public Rectangle HitBox { get { return hitBox;} set { hitBox = value; } }
        protected float gravity = 3f;
        protected Vector2 gravityDirection = new Vector2(0, 1);
        protected Vector2 movement = new Vector2(0, 0);


        protected Vector2 remainder;
        protected float xRemainder;
        protected float yRemainder;

        public GameObject(Texture2D texture, Rectangle hitbox)
        {
            this.texture = texture;
            this.hitBox = hitbox;
            position.X = hitbox.X;
            position.Y = hitbox.Y;
        }

        public virtual void Update(GameTime gameTime)
        {

        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.White);
        }

        public int CheckCollision(Vector2 playerPosition)
        {
            if (TopOfPlatFormCollision(playerPosition))
            {
                return 1;
            }
            if (BottomOfPlatFormCollision(playerPosition))
            {

                return 2;
            }
            if (LeftSideOfPlatFormCollision(playerPosition))
            {

                return 3;
            }
            if (RightSideOfPlatFormCollision(playerPosition))
            {

                return 4;
            }

            return 0;

        }
        public bool TopOfPlatFormCollision(Vector2 playerPosition)
        {
            foreach (Platform platform in Platform.PlatformList)
            {
                if (hitBox.Intersects(platform.hitBox)
                    && playerPosition.Y + 48 >= platform.hitBox.Y
                    && playerPosition.Y + 40 <= platform.hitBox.Y + 10)
                {
                    return true;
                }
            }
            return false;
        }
        public bool BottomOfPlatFormCollision(Vector2 playerPosition)
        {
            foreach (Platform platform in Platform.PlatformList)
            {
                if (hitBox.Intersects(platform.hitBox)
                    && playerPosition.Y + 5 >= platform.hitBox.Y + platform.hitBox.Height - 5
                    && playerPosition.Y + 5 <= platform.hitBox.Y + platform.hitBox.Height)
                {
                    return true;
                }
            }
            return false;
        }
        public bool LeftSideOfPlatFormCollision(Vector2 playerPosition)
        {
            foreach (Platform platform in Platform.PlatformList)
            {
                if (hitBox.Intersects(platform.hitBox)
                    && (playerPosition.X + 48 >= platform.hitBox.X
                    && playerPosition.X + 48 <= platform.hitBox.X + 10))
                {
                    return true;
                }
            }
            return false;
        }
        public bool RightSideOfPlatFormCollision(Vector2 playerPosition)
        {
            foreach (Platform platform in Platform.PlatformList)
            {
                if (hitBox.Intersects(platform.hitBox)
                    && (playerPosition.X <= platform.hitBox.X + platform.hitBox.Width
                    && playerPosition.X >= platform.hitBox.X + platform.hitBox.Width - 10))
                {
                    return true;
                }
            }
            return false;

        }

    }
}



