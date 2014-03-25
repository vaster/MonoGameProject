namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Diagnostics;
    using System.Threading;    

    public class Player : GameObject, IMovable
    {
        private Weapon weapon;
        private bool isFireKeyPress = false;
        private TimeSpan isTimeForFire;

        public float SpeedX { get; set; }

        public float SpeedY { get; set; }  
          
        public Player()
        {
            // To do: change the magic numbers with constants
            this.SpeedX = InitialData.UnitData.PlayerSpeedX;
            this.SpeedY = InitialData.UnitData.PlayerSpeedY;
            this.Height = InitialData.UnitData.PlayerHeight;
            this.Width = InitialData.UnitData.PlayerWidth;
            this.ScaleX = InitialData.UnitData.PlayerScaleX;
            this.ScaleY = InitialData.UnitData.PlayerScaleY;
            this.Position = new Vector2(InitialData.UnitData.PlayerPositionX, InitialData.UnitData.PlayerPositionY);
            this.SpritePath = InitialData.SpriteData.Player;
            this.PlayerWeapon = new Weapon(new Bullet(InitialData.SpriteData.Bullet, this.Position));
        }

        public Player(float rotation) 
            : this()
        {
            this.Rotation = rotation;
        }

        public Weapon PlayerWeapon
        {
            get { return this.weapon; }
            private set { this.weapon = value; } 
        }

        public Bullet Shot()
        {
            if (this.PlayerWeapon.WeaponBullet.Texture != null && isFireKeyPress)
            {
                var bulletPosition = new Vector2(this.PositionX + this.Width / 2 - InitialData.UnitData.BulletWidth / 2,
                                                this.PositionY - InitialData.UnitData.BulletHeight / 2);
                var bullet = new Bullet(this.PlayerWeapon.WeaponBullet.Texture, bulletPosition);
                return bullet;
            }
            // To do: a better return value when the isTimeForFite is equal to false
            return null;
        }


        public override void Update(GameTime gameTime)
        {
            // Logic for the delay between shots (To do: to put out the whole logic in a separate function)
            this.isFireKeyPress = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && gameTime.TotalGameTime > this.isTimeForFire)
            {
                this.isTimeForFire = gameTime.TotalGameTime + InitialData.UnitData.DelayBetweenShotsMillisecond;
                this.isFireKeyPress = true;
            }

            CheckForPressedMoveKey();
            CheckPlayerScreenPosition();
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, null, Color.White, 0.0f, this.Origin, this.Scale, SpriteEffects.None, 0);
        }

        private void CheckForPressedMoveKey()
        {
            // Checks if left arrow key or right arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.PositionX -= this.SpeedX;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.PositionX += this.SpeedX;
            }
        }             

        private void CheckPlayerScreenPosition()
        {
            // Checks whether the player has left the screen or not
            if (this.Position.X > InitialData.Hud.ScreenWidth)
            {
                this.PositionX = -this.Width;
            }
            else if (0 > this.Position.X + this.Width)
            {
                this.PositionX = InitialData.Hud.ScreenWidth;
            }
        }
    }
}
