namespace SpaceInvaders
{
    using System;

    public static class UnitInitialData
    {
        public const float PlayerPositionX = 1366 / 1.9f;
        public const float PlayerPositionY = 768 / 1.2f;
        public const int PlayerHeight = 120;
        public const int PlayerWidth = 120;
        public const float PlayerSpeedX = 5.0f;
        public const float PlayerSpeedY = 0.0f;
        public const int BulletHeight = 33;
        public const int BulletWidth = 9;
        public const float BulletSpeed = 5.0f;
        public const int ExplodedBulletHeight = 56;
        public const int ExplodedBulletWidth = 54;
        public static TimeSpan DelayBetweenShotsMillisecond = new TimeSpan(0, 0, 0, 0, 150);

        public const int EnemiesCount = 30;
        public const int EnemyPacks = 3;
        public const float EnemySpeedX =60 ;
        public const float EnemySpeedY = 10f;
        public const int EnemyHeight = 120;
        public const int EnemyWidth = 120;
    }
}
