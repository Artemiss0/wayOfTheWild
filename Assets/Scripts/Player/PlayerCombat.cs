using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask enemyLayers;

    public float AttackRange = 0.5f;
    public int AttackDamage = 40;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        // To-Do: Play an attack animation

        //Detect anemies in range of attack
        Collider[] hitEnemenies = Physics.OverlapSphere(AttackPoint.position, AttackRange, enemyLayers);

        //Damage Enemies
        foreach(Collider enemy in hitEnemenies)
        {
            if (enemy.GetComponent<IsDamagable>())
            {
                enemy.GetComponent<IsDamagable>().TakeDamage(AttackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}


