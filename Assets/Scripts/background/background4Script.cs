using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background4Script : MonoBehaviour
{
    private int change = 0;
    public Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/b5");
    }

    void changeSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/b5.5");
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(change == 0)
        {
            transform.position = new Vector3(0.68f * _Player.position.x + 1f, 0.525f * _Player.position.y + 5.4f, 10);
        }
        if(change == 1)
        {
            transform.position = new Vector3(0.66f * _Player.position.x + 30f, 0.525f * _Player.position.y - 8.4f, 10);
        }
        
        if (_Player.position.y < -10 && change == 0)
        {
            changeSprite();
            change = 1;
        }


    }
}
