using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public float playerVelocity = 10;
    bool isWalking = false;

    public PlayerAnimationController playerAnim;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            SetIsWalking(true);
            transform.position -= transform.right * (Time.deltaTime * playerVelocity);
            return;
        }
        else if (Input.GetKey(moveRight))
        {
            SetIsWalking(true);
            transform.position += transform.right * (Time.deltaTime * playerVelocity);
            return;
        }
        
        SetIsWalking(false);  
    }

    private void SetIsWalking(bool value)
    {
        if (value != isWalking)
        {
            if (value)
            {
                playerAnim.PlayAnimation("playerWalk");
            } 
            else
            {
                playerAnim.PlayAnimation("playerIdle");
            }
        }
        isWalking = value;
    }
}
