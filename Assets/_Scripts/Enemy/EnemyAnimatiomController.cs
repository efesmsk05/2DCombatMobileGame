using UnityEngine;

public class EnemyAnimatiomController : MonoBehaviour
{
    public Enemy enemy; // Reference to the Enemy script
    public Animator animator; // Reference to the Animator component
    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void EnemyTakeDamage()
    {
        enemy.ChangeState(new EnemyIdleState(enemy)); // Change to Take Damage state
    }

    public void EnemyDied()
    {
        animator.SetBool("Died" , true);

    }
}
