
using DG.Tweening;

namespace TestTask.Movement
{

    public class FlyingEnemy : Enemy
    {
        public override void EnemyAttack()
        {
            transform.DOMove(player.position, 1f);          
        }
      
    }
}
