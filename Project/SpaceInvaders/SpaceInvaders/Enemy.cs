namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics; 

    public class Enemy : GameObject, IMovable
    {
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }

        public Enemy()
        {
            this.SpritePath = "PlayerSprite\\PlayerShip";
            this.Position = new Vector2(this.PositionX, this.PositionY);
        }

        public override void Update(GameTime gameTime)
        {
            this.PositionX = this.PositionX + this.SpeedX;
            this.PositionY = this.PositionY + this.SpeedY;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }
    }
}
