using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    private int change = 0;
    public Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/b2");
    }

    void changeSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/b5.5");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (change == 0)
        {
            transform.position = new Vector3(0.936f * _Player.position.x - 1.35f, 0.425f * _Player.position.y + 49.4f, 10);
        }
        if (change == 1)
        {
            transform.position = new Vector3(0.76f * _Player.position.x - 14, 0.425f * _Player.position.y - 2.5f, 10);
        }

        if (_Player.position.y < 14 && change == 0)
        {
            changeSprite();
            change = 1;
        }
        
    }
}
