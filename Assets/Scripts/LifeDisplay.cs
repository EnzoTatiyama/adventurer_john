using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    public Sprite[] animationSprites;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.animationSprites[0];
    }

    public void ChangeLife(int health)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.animationSprites[this.animationSprites.Length - health];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
