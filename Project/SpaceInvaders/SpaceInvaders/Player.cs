namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : GameObject, IMovable
    {
        public float SpeedX { get; set; }

        public float SpeedY { get; set; }

        public Player()
        {
            this.Initialize();
        }

        public override void Initialize()
        {
            // To change magic numbers with constants
            this.SpeedX = 5.0f;
            this.SpeedY = 0.0f;
            this.Height = 120; // To do...
            this.Width = 120; // To do...
            this.Position = new Vector2(Hub.ScreenWidth / 1.9f, Hub.ScreenHeight / 1.2f);
            this.SpritePath = "PlayerSprite\\PlayerShip";
        }

        public override void Update()
        {
            CheckForPressedKey();
        }

        public override void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void CheckForPressedKey()
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
