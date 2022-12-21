using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace PlatformerGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Player player;

        Texture2D platformTexture, playerTexture, spikeTexture;

        Finish finish;

        bool gameOver;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            platformTexture = Content.Load<Texture2D>("plattform");
            playerTexture = Content.Load<Texture2D>("ball");
            spikeTexture = Content.Load<Texture2D>("plattform");

            ReadFromFile("Map.json");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (!gameOver)
            {

                player.Update(gameTime);

                CheckPlayerCollisions();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            spriteBatch.Begin();

            if (gameOver)
            {
                spriteBatch.Draw(platformTexture, new Rectangle(0, 0, 1920, 1080), Color.Black);
            }
            else
            {

                foreach (Tiles platform in Platform.PlatformList)
                {
                    platform.Draw(spriteBatch);
                }
                foreach (Tiles obstacle in Tiles.ObstacleList)
                {
                    obstacle.Draw(spriteBatch);
                }

                player.Draw(spriteBatch);

                finish.Draw(spriteBatch);


            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        private void ReadFromFile(string fileName)
        {
            Rectangle playerHitbox = JsonParser.GetRectangle(fileName, "player");
            player = new Player(playerTexture, playerHitbox);

            Rectangle finishHitBox = JsonParser.GetRectangle(fileName, "finish");
            finish = new Finish(platformTexture, finishHitBox);

            List<Rectangle> platformHitboxList = JsonParser.GetRectangleList(fileName, "platform");
            foreach (Rectangle platformHitbox in platformHitboxList)
            {
                Platform platform = new Platform(platformTexture, platformHitbox);
                Tiles.PlatformList.Add(platform);
            }
            List<Rectangle> spikeHitboxList = JsonParser.GetRectangleList(fileName, "floorSpike");
            foreach (Rectangle spikeHitbox in spikeHitboxList)
            {
                FloorSpikes spike = new FloorSpikes(spikeTexture, spikeHitbox);
                Tiles.ObstacleList.Add(spike);
            }

        }

        public void CheckPlayerCollisions()
        {
            foreach (Tiles obstacle in Tiles.ObstacleList)
            {
                if (obstacle.HitBox.Intersects(player.HitBox))
                {
                    Debug.WriteLine("Dead");

                    player.Death();

                }
            }

            if (finish.HitBox.Intersects(player.HitBox))
            {
                gameOver = true;
            }
        }



    }
}