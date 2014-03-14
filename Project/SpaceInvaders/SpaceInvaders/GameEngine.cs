namespace SpaceInvaders
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;    

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private IList<Enemy> enemies;
        private Player player = new Player();
        private IList<Bullet> bullets = new List<Bullet>();

        public GameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Resources";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Initialization of the screen sizes
            Hub.ScreenHeight = GraphicsDevice.Viewport.Bounds.Height;
            Hub.ScreenWidth = GraphicsDevice.Viewport.Bounds.Width;

            // This initialization is not necessary because the player have empty constructor. 
            // It's used for setting the start position of the player.            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            player.Texture = Content.Load<Texture2D>(player.SpritePath);
            var bulletTexture = Content.Load<Texture2D>(player.PlayerWeapon.WeaponBullet.SpritePath);
            player.PlayerWeapon.WeaponBullet.Texture = bulletTexture;            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            TimeSpan elapsedTime = TimeSpan.FromMilliseconds(500);
            //elapsedTime += gameTime.ElapsedGameTime;
            gameTime.ElapsedGameTime += elapsedTime;
            player.Update();

            var bullet = player.Shot();
            if (bullet != null)
            {
                bullets.Add(bullet);
            }

            foreach (var bul in bullets)
            {
                //gameTime.ElapsedGameTime = TimeSpan.FromMilliseconds(500);
                bul.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);			
            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            player.Draw(_spriteBatch);
            
            foreach (var bullet in bullets)
            {
                bullet.Draw(_spriteBatch);
            }
            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
