using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlatformerGame
{
    internal class Player : GameObject
    {
        Vector2 direction;
        Vector2 velocity;
        Vector2 startPosition;
        float speed;
        Vector2 position;
        bool jumped;
        

        int whichCollision;

        public Player(Texture2D texture, Rectangle hitBox) : base(texture, hitBox)
        {
            speed = 250f;
            position.X = hitBox.X;
            position.Y = hitBox.Y;
            startPosition = position;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                movement.X = -2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                movement.X = 2;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                movement.X = 0;
            }

            whichCollision = CheckCollision(position);

            switch (whichCollision)
            {
                case 1:

                    //collides with top
                    movement.Y = 0;
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        movement.Y = -5;
                    }
                    break;
                case 2:
                    //collides with bottom
                    movement.Y = 0;
                    position.Y += 1;
                    break;
                case 3:
                    //collides with left side
                    movement.X = 0;
                    position.X -= 1;
                        break;
                case 4:
                    //collides with right side
                    movement.X = 0;
                    position.X += 1;
                    break;
                case 0:
                    movement.Y += 0.1f;
                    break;
            }

            Move(gameTime);
        }
        public void Move(GameTime gameTime)
        {

            position += movement;

            hitBox.X = (int)(position.X >= 0 ? position.X + 0.5f : position.X - 0.5f);
            hitBox.Y = (int)(position.Y >= 0 ? position.Y + 0.5f : position.Y - 0.5f);
        }

        public void Death()
        {
            position = startPosition;
            movement = new Vector2(0, 0);
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.White);
        }

    }
}
