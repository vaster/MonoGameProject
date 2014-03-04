namespace SpaceInvaders
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;    

    public abstract class GameObject 
    {
        private Vector2 position;

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

        public int Width { get; set; }

        public int Height { get; set; }

        public IEnumerable<int> CanCollideWith { get; set; }

        public abstract void Initialize();

        public abstract void Update();

        public abstract void Draw();
    }
}
