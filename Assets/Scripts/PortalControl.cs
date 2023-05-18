using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public GameManager gameManager;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("COLLID");
        if (scene.name == "Level 2") {
            gameManager.GoToLevel3();
        } else if (scene.name == "Level 1") {
            gameManager.GoToLevel2();
        }
    }
}
