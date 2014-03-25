namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;  
    using System.Collections.Generic;      

    public abstract class GameObject 
    {
        private Vector2 position;
        private Vector2 scale; // Store the sprite x and y scale
        private Vector2 origin; // 
        private float rotation; // In radian


        public string SpritePath { get; set; }

        public Texture2D Texture { get; set; }        

        public Vector2 Position 
        { 
            get { return this.position; }
            set { this.position = value; }
        }

        public float PositionX
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float PositionY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public Vector2 Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }

        public float ScaleX 
        {
            get { return scale.X; }
            set { scale.X = value; } 
        }

        public float ScaleY
        {
            get { return scale.Y; }
            set { scale.Y = value; }
        }

        public Vector2 Origin
        {
            get { return this.origin; }
            set { this.scale = value; }
        }

        public float OriginX
        {
            get { return origin.X; }
            set { origin.X = value; }
        }

        public float OriginY
        {
            get { return origin.Y; }
            set { origin.Y = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public int Width { get; set; }

        public int Height { get; set; }       

        public IEnumerable<int> CanCollideWith { get; set; }       

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
