namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;    

    public class Bullet : GameObject
    {
        public Bullet() 
        {
            this.Height = InitialData.UnitData.BulletHeight;
            this.Width = InitialData.UnitData.BulletWidth;
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
            this.PositionY -= InitialData.UnitData.BulletSpeed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, Color.White);
        }
    }
}
