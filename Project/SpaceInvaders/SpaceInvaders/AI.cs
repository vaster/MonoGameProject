using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class AI
    {
        public abstract void Update(IEnumerable<GameObject> gameObjects, GameTime gameTimer);

        public sealed class EnemyDispatcher : AI
        {
            private ICollection<EnemyPack> enemyPacks;
            private int nextUpdate;
            private int lastUpatedPackIndex;

            private EnemyDispatcher()
            {
                nextUpdate = 0;
                lastUpatedPackIndex = 0;
            }

            public override void Update(IEnumerable<GameObject> gameObjects, GameTime gameTime)
            {
                if (this.enemyPacks == null)
                {
                    this.InitializeEnemyPacks(gameObjects as IEnumerable<Enemy>);
                }

                if (nextUpdate <= gameTime.TotalGameTime.TotalSeconds)
                {

                    this.Move(this.enemyPacks.ElementAt(lastUpatedPackIndex), gameTime);
                    lastUpatedPackIndex++;
                    nextUpdate = nextUpdate + 1;
                    if (lastUpatedPackIndex >= this.enemyPacks.Count)
                    {
                        lastUpatedPackIndex = 0;
                    }
                }
            }
            private void Move(EnemyPack enemyPack, GameTime gameTime)
            {
                bool toMoveDown = false;

                if (enemyPack.Leader.PositionX >= Hud.ScreenWidth - UnitInitialData.EnemyWidth - UnitInitialData.EnemyWidth ||
                                                                             enemyPack.Leader.PositionX <= UnitInitialData.EnemySpeedX)
                {
                    toMoveDown = true;
                    if (enemyPack.Direction == Direction.Right)
                    {
                        enemyPack.Direction = Direction.Left;
                        enemyPack.Leader = enemyPack.Enemies.First();

                    }
                    else if (enemyPack.Direction == Direction.Left)
                    {
                        enemyPack.Direction = Direction.Right;
                        enemyPack.Leader = enemyPack.Enemies.Last();
                    }
                }

                foreach (var enemy in enemyPack.Enemies)
                {
                    enemy.Update(gameTime);

                    if (enemyPack.Direction == Direction.Right)
                    {
                        enemy.SpeedX = UnitInitialData.EnemySpeedX;
                    }
                    else if (enemyPack.Direction == Direction.Left)
                    {
                        enemy.SpeedX = -UnitInitialData.EnemySpeedX;
                    }

                    else if (!toMoveDown)
                    {
                        enemy.SpeedY = 0;
                    }

                    if (toMoveDown)
                    {
                        enemy.SpeedY = UnitInitialData.EnemySpeedY;
                    }
                }
            }
            private bool CanShoot(Enemy enemy)
            {
                throw new NotImplementedException();
            }
            private void Shoot()
            {
            }
            private void InitializeEnemyPacks(IEnumerable<Enemy> enemies)
            {
                this.enemyPacks = new List<EnemyPack>();
                EnemyPack currEnemyPack = null;
                for (int enemyPackIndex = 0; enemyPackIndex < UnitInitialData.EnemyPacks; enemyPackIndex++)
                {
                    int toTake = UnitInitialData.EnemiesCount / UnitInitialData.EnemyPacks;
                    int toSkip = this.enemyPacks.Count * toTake;
                    currEnemyPack = new EnemyPack(enemies.Skip(toSkip).Take(toTake).ToList());
                    currEnemyPack.CanMove = true;
                    this.enemyPacks.Add(currEnemyPack);
                }
            }

            private static AI current;
            public static AI Current
            {
                get
                {
                    if (EnemyDispatcher.current == null)
                    {
                        EnemyDispatcher.current = new EnemyDispatcher();
                    }
                    return EnemyDispatcher.current;
                }
            }
        }

        private class EnemyPack
        {
            public Enemy Leader { get; set; }
            public IEnumerable<Enemy> Enemies { get; set; }
            public Direction Direction { get; set; }
            public bool CanMove { get; set; }

            public EnemyPack(IEnumerable<Enemy> enemies)
            {
                if (enemies == null || enemies.Count() == 0)
                {
                    throw new ArgumentNullException("enemies", "Empty collection is not allowed.");
                }
                this.Enemies = enemies;
                this.Leader = this.Enemies.Last();
                this.Direction = Direction.Right;
            }
        }

        private enum Direction
        {
            Left,
            Right,
        }
    }
}
