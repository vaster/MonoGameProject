namespace SpaceInvaders
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : GameObject, IMovable
    {
        private Weapon weapon;
        private bool isTimeForFire = false;

        public float SpeedX { get; set; }

        public float SpeedY { get; set; }  
          
        public Player()
        {
            // To do: change the magic numbers with constants
            this.SpeedX = UnitInitialData.PlayerSpeedX;
            this.SpeedY = UnitInitialData.PlayerSpeedY;
            this.Height = UnitInitialData.PlayerHeight;
            this.Width = UnitInitialData.PlayerWidth;
            this.Position = new Vector2(UnitInitialData.PlayerPositionX, UnitInitialData.PlayerPositionY);
            this.SpritePath = "PlayerSprite\\PlayerShip";
            this.weapon = new Weapon(new Bullet("Bullets\\LaserRedBullet", this.Position));
        }

        public Weapon PlayerWeapon
        {
            get { return this.weapon; }
        }

        public Bullet Shot()
        {
            if (this.PlayerWeapon.WeaponBullet.Texture != null && isTimeForFire)
            {
                var bulletPosition = new Vector2(this.PositionX + this.Width / 2 - UnitInitialData.BulletWidth / 2,
                                                this.PositionY - UnitInitialData.BulletHeight / 2);
                var bullet = new Bullet(this.PlayerWeapon.WeaponBullet.Texture, bulletPosition);
                return bullet;
            }
            // To do: a better return value when the isTimeForFite is equal to false
            return null;
        }

        public override void Update()
        {
            isTimeForFire = false;
            if (CheckForPressedFireKey())
            {
                isTimeForFire = true;                                
            }

            CheckForPressedKey();
            CheckPlayerScreenPosition();
        }

        private bool CheckForPressedFireKey()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                return true;                
            }

            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }

        private void CheckForPressedKey()
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
            if (this.Position.X > Hub.ScreenWidth)
            {
                this.PositionX = -this.Width;
            }
            else if (0 > this.Position.X + this.Width)
            {
                this.PositionX = Hub.ScreenWidth;
            }
        }
    }
}
