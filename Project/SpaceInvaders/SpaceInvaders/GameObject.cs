namespace SpaceInvaders
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;    

    public abstract class GameObject 
    {
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public IEnumerable<int> CanCollideWith { get; set; }

        public abstract void Initialize();        

        public abstract void Update();

        public abstract void Draw();
    }
}
