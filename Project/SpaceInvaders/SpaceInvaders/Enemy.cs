namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics; 

    public class Enemy : GameObject, IMovable
    {
        private const string defaultSpritePath = InitialData.SpriteData.DefaultInvader;

        public float SpeedX { get; set; }
        public float SpeedY { get; set; }

        public Enemy(string spritePath = defaultSpritePath, float rotation = 0f)
        {
            this.SpritePath = spritePath;
            this.Position = new Vector2(this.PositionX, this.PositionY);
            this.Rotation = rotation;
        }

        public override void Update(GameTime gameTime)
        {
            this.PositionX = this.PositionX + this.SpeedX;
            this.PositionY = this.PositionY + this.SpeedY;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, null, Color.White, this.Rotation,
                this.Origin, .5f, SpriteEffects.None, 0f);
        }
    }
}
