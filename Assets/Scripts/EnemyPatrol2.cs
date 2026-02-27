using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftSide;
    [SerializeField] private Transform rightSide;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftSide.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightSide.position.x)

                MoveInDirection(1);

            else
            {
                DirectionChange();

            }
        }


    }

    private void DirectionChange()
    {
        anim.SetBool("Moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;


    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);


        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);


    }
}
