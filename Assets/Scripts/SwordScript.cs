using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public PlayerControll playerControll;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player") {
            playerControll.GetSword();
            gameManager.ShowAttackMessage();
            Destroy(gameObject);
        }
    }
}