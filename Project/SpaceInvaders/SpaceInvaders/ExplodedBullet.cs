namespace SpaceInvaders
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ExplodedBullet : Bullet
    {
        public ExplodedBullet()
        {
            this.Height = UnitInitialData.ExplodedBulletHeight;
            this.Width = UnitInitialData.ExplodedBulletWidth;
        }

        public ExplodedBullet(string spritePath, Vector2 position)
            : base(spritePath, position) { }
    }
}
