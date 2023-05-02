using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LifeDisplay lifeDisplay;
    public GUISkin layout;

    public bool showAttackMessage = false;
    public bool showMoveMessage = false;
    public float messageTime = 6.0f;
    private float attackMessageTimeLeft;
    private float moveMessageTimeLeft;

    void Start()
    {
        attackMessageTimeLeft = messageTime;
        moveMessageTimeLeft = messageTime;
        showMoveMessage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (showAttackMessage) {
            attackMessageTimeLeft -= Time.deltaTime;

            if (attackMessageTimeLeft < 0) {
                showAttackMessage = false;
            }
        }
        
        if (showMoveMessage) {
            moveMessageTimeLeft -= Time.deltaTime;

            if (moveMessageTimeLeft < 0) {
                showMoveMessage = false;
            }
        }
    }

    public static void PlayerDamage(int health)
    {
        
    }

    public void ShowAttackMessage()
    {
        showAttackMessage = true;
    }

    void OnGUI()
    {
        GUI.skin = layout;

        if (SceneManager.GetActiveScene().name == "Level 1") {
            if (showAttackMessage) {
                GUI.Label(new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 125, 500, 100), "Aperte 'C' para atacar");
            }
            if (showMoveMessage) {
                GUI.Label(new Rect((Screen.width / 2) - 225, (Screen.height / 2) - 125, 700, 100), "Aperte 'A', 'D' e 'Space' para se movimentar");
            }
        } 
    }
}