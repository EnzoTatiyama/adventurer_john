using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 2;

    public SpriteRenderer sprite;
    
    IEnumerator DamageEffectSequence()
    {
        Color originColor = sprite.color;
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.25f);

        sprite.color = originColor;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        print(health);
        if (health <= 0) {
            Destroy(gameObject);
        }

        StartCoroutine(DamageEffectSequence());
    }
}
