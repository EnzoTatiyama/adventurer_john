using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode space = KeyCode.Space;
    public KeyCode cKey = KeyCode.C;
    
    private int attackPower = 5;
    private float playerVelocity = 200f;
    private float jumpForce = 250f;
    private float moveX;
    private bool isGrounded;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;

    public GameManager gameManager;

    public EnemyControl enemyControl;

    private bool isCollidingEnemy;
    private bool canAttack;

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        anim.SetBool("playerWalk", false);
        moveX = Input.GetAxisRaw("Horizontal");

        if (moveX != 0) {
            anim.SetBool("playerWalk", true);
            rb.velocity = new Vector2(moveX * playerVelocity * Time.fixedDeltaTime, rb.velocity.y);
        }

        Flip();
        Jump();
    }

    void Jump()
    {
        if (Input.GetKey(space) && isGrounded) {
            anim.SetBool("playerJump", true);
            rb.velocity = transform.up * jumpForce * Time.fixedDeltaTime;
            isGrounded = false;
        }
    }

    void Attack()
    {
        anim.SetTrigger("playerAttack");
    }

    void Flip()
    {
        if (moveX >= 1) {
            sprite.flipX = false;
        } else if (moveX <= -1) {
            sprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            anim.SetBool("playerJump", false);
            isGrounded = true;
        } else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy 2") {
            isCollidingEnemy = true;
            if (anim.GetBool("playerAttack") && canAttack) {
                enemyControl.TakeDamage(attackPower);
                canAttack = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            isCollidingEnemy = false;
        }
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1.5f);
        gameManager.PlayerDied();
    }

    public void PlayerDie()
    {
        anim.SetTrigger("playerDie");
        StartCoroutine(DieDelay());
    }

    public void GetSword()
    {
        anim.SetBool("playerSword", true);
    }

    void Update()
    {
        if (Input.GetKey(cKey)) {
            Attack();
        }

        if (anim.GetBool("playerAttack") == false) {
            canAttack = true;
        }

        if (isCollidingEnemy && anim.GetBool("playerAttack") && canAttack) {
            enemyControl.TakeDamage(attackPower);
            canAttack = false;
        }
    }
}
