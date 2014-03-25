namespace SpaceInvaders
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;    

    public class ExplodedBullet : Bullet
    {
        public ExplodedBullet()
        {
            this.Height = InitialData.UnitData.ExplodedBulletHeight;
            this.Width = InitialData.UnitData.ExplodedBulletWidth;
        }

        public ExplodedBullet(string spritePath, Vector2 position)
            : base(spritePath, position) { }
    }
}
