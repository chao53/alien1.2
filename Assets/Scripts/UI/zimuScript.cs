using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zimuScript : MonoBehaviour
{
    private int change = 0;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/0");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3 && timer < 6)
        {
            change = 1;
        }
        if (timer >= 6 && timer < 9)
        {
            change = 2;
        }
        if (timer >= 9 && timer < 12)
        {
            change = 3;
        }
        if (timer >= 12 && timer < 15)
        {
            change = 4;
        }
        if (timer >= 15 && timer < 18)
        {
            change = 5;
        }
        if (timer >= 21)
        {
            change = 6;
        }
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/" + change);
    }
}
