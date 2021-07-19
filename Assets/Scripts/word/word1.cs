using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word1 : MonoBehaviour
{
    //word
    public GameObject word;
    //switch
    public GameObject switch2;

    private float wordtimer = 2;
    private int isTalking = 0;
    // Start is called before the first frame update
    void Start()
    {
        word.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //讲话
        if (((gameObject.transform.position.x - switch2.transform.position.x) < 1
            && (gameObject.transform.position.x - switch2.transform.position.x) > -1)
            && ((gameObject.transform.position.y - switch2.transform.position.y) < 1
            && (gameObject.transform.position.y - switch2.transform.position.y) > -1)
            && wordtimer == 2)
        {
            isTalking = 1;
        }

        if (isTalking == 1)
        {
            wordtimer -= Time.deltaTime;
            if (wordtimer <= 1.5f && wordtimer > 0)
            {
                word.SetActive(true);
            }
            if (wordtimer <= 0)
            {
                word.SetActive(false);
                wordtimer = 2;
                isTalking = 0;
            }
        }
    }
}
