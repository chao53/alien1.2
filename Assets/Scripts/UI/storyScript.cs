using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyScript : MonoBehaviour
{
    private int change = 1;
    private float timer = 0;
    public GameObject button = null;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/s1");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        timer += Time.deltaTime;
        if (timer >= 4 && timer < 7)
        {
            change = 2;
        }
        if (timer >= 7.5f && timer < 12)
        {
            change = 3;
        }
        if (timer >= 9)
        {
            button.SetActive(true);
        }
        
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/s" + change);
    }
}
