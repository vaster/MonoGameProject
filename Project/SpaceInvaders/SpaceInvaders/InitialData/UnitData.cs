namespace SpaceInvaders.InitialData
{
    using System;

    public static class UnitData
    {
        public const float PlayerPositionX = 1366 / 1.9f;
        public const float PlayerPositionY = 768 / 1.2f;
        public static int PlayerHeight = 40;
        public static int PlayerWidth = 40;
        public const float PlayerSpeedX = 5.0f;
        public const float PlayerSpeedY = 0.0f;
        public static float PlayerScaleX = 0.60f;
        public static float PlayerScaleY = 0.60f;
        public static int BulletHeight = 33;
        public static int BulletWidth = 9;
        public const float BulletSpeed = 5.0f;
        public const int ExplodedBulletHeight = 56;
        public const int ExplodedBulletWidth = 54;
        public static TimeSpan DelayBetweenShotsMillisecond = new TimeSpan(0, 0, 0, 0, 150);

        public const int EnemiesCount = 60;
        public const int EnemyPacks = 6;
        public const float EnemySpeedX = 60;
        public const float EnemySpeedY = 10f;
        public static int EnemyHeight = 120;
        public static int EnemyWidth = 120;
        
    }
}
