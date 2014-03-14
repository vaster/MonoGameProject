namespace SpaceInvaders
{
    public class Weapon 
    {
        public Weapon() { }

        public Weapon(Bullet bullet)
        {
            this.WeaponBullet = bullet;
        }

        public Bullet WeaponBullet { get; private set; }

        public int Damage { get; set; }        
    }
}
