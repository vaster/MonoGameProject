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
        // To do: try to make exploded bullet internal of the future class for the collisions
        private ExplodedBullet explodedBullet = new ExplodedBullet();

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
            Hud.ScreenHeight = GraphicsDevice.Viewport.Bounds.Height;
            Hud.ScreenWidth = GraphicsDevice.Viewport.Bounds.Width;

            // This initialization is not necessary because the player have empty constructor 
            // It's used for setting the start position of the player           

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            this.player.Texture = Content.Load<Texture2D>(this.player.SpritePath);
            var bulletTexture = Content.Load<Texture2D>(this.player.PlayerWeapon.WeaponBullet.SpritePath);
            this.player.PlayerWeapon.WeaponBullet.Texture = bulletTexture;

            // To do: it is only with test purpose
            var explodedBulletTexture = Content.Load<Texture2D>("Bullets\\LaserRedShot");
            this.explodedBullet.Texture = explodedBulletTexture;

            this.InitlizeEnemies();
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
            this.player.Update(gameTime);

            var playerBullet = this.player.Shot();
            if (playerBullet != null)
            {
                this.bullets.Add(playerBullet);
            }

            foreach (var bullet in this.bullets)
            {
                bullet.Update(gameTime);
            }

            AI.EnemyDispatcher.Current.Update(this.enemies as IEnumerable<Enemy>, gameTime);

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

            this.player.Draw(_spriteBatch);

            foreach (var bullet in this.bullets)
            {
                bullet.Draw(_spriteBatch);
            }

            this.explodedBullet.Draw(_spriteBatch);

            foreach (var enemy in this.enemies)
            {
                enemy.Draw(this._spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void InitlizeEnemies()
        {
            this.enemies = new List<Enemy>();

            int currEnemyXPosition = Hud.ScreenWidth / UnitInitialData.EnemiesCount;
            int currEnemyYPosition = UnitInitialData.EnemyHeight;

            Enemy currEnemy = null;
            for (int currEnemyIndex = 1; currEnemyIndex <= UnitInitialData.EnemiesCount; currEnemyIndex++)
            {
                currEnemy = new Enemy();
                currEnemy.PositionX = currEnemyXPosition;
                currEnemy.PositionY = currEnemyYPosition / 5;

                currEnemyXPosition = currEnemyXPosition + UnitInitialData.EnemyWidth;
                if (currEnemyIndex % (UnitInitialData.EnemiesCount / UnitInitialData.EnemyPacks) == 0)
                {
                    currEnemyYPosition = currEnemyYPosition + UnitInitialData.EnemyHeight * 5;
                    currEnemyXPosition = Hud.ScreenWidth / UnitInitialData.EnemiesCount;
                }

                currEnemy.Texture = Content.Load<Texture2D>(currEnemy.SpritePath);
                this.enemies.Add(currEnemy);
            }
        }
    }
}