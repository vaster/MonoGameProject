namespace SpaceInvaders
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;     

    public class Bullet : GameObject
    {
        public Bullet() 
        {
            this.Height = UnitInitialData.BulletHeight;
            this.Width = UnitInitialData.BulletWidth;
        }

        public Bullet(string spritePath, Vector2 position)
            : this()
        {
            this.Position = position;
            this.SpritePath = spritePath;
            
        }

        public Bullet(Texture2D texture, Vector2 position)
            : this()
        {
            this.Position = position;
            this.Texture = texture;
        }

        public bool IsExploded { get; set; }

        public override void Update(GameTime gameTime)
        {
            this.PositionY -= UnitInitialData.BulletSpeed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }
    }
}
