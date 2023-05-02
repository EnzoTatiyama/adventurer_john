using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageControl : MonoBehaviour
{
    public LifeControl playerLife;
    public int damage = 2;
    public Animator anim;

    public float maxAttackDelay;
    private float delayAttack;

    private bool isColliding;

    void Start()
    {
        delayAttack = maxAttackDelay;
    }

    private IEnumerator DelayedAction() {
        yield return new WaitForSeconds(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            isColliding = false;
            delayAttack = maxAttackDelay;
        }
    }

    void Update() {
        if (isColliding) {
            delayAttack -= Time.deltaTime;

            if (delayAttack < 0) {
                playerLife.TakeDamage(damage);
                anim.SetTrigger("enemyAttack");
                delayAttack = maxAttackDelay;
            }
        }
    }
}
