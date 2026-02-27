using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerlayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private PlayerHealth playerhealth;
    private EnemyPatrol enemyPatrol;
    private EnemyPatrol2 enemyPatrol2;
    [SerializeField] private AudioSource bossSFX;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        enemyPatrol2 = GetComponentInParent<EnemyPatrol2>();
    }

    // Update is called once per frame
    void Update()
    {

        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                bossSFX.Play();
                anim.SetTrigger("Attack");

            }

        }
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
        else if (enemyPatrol2 != null)
            enemyPatrol2.enabled = !PlayerInSight();



    }


    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerlayer);

        if (hit.collider != null)
            playerhealth = hit.transform.GetComponent<PlayerHealth>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerhealth.TakeDamage(damage);

    }

}
