using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LifeDisplay lifeDisplay;
    public PlayerControll player;
    public GUISkin layout;
    private Scene scene;

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
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 3" || scene.name == "Level 2") {
            player.GetSword();
        }

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

    public void PlayerDiedAnimation()
    {
        player.PlayerDie();
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void ShowAttackMessage()
    {
        showAttackMessage = true;
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    void OnGUI()
    {
        GUI.skin = layout;

        if (SceneManager.GetActiveScene().name == "Level 1") {
            if (showAttackMessage) {
                if (showMoveMessage) showMoveMessage = false;
                GUI.Label(new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 125, 500, 100), "Aperte 'C' para atacar");
            }
            if (showMoveMessage) {
                GUI.Label(new Rect((Screen.width / 2) - 225, (Screen.height / 2) - 125, 700, 100), "Aperte 'A', 'D' e 'Space' para se movimentar");
            }
        } 
    }
}
