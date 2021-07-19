using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word2 : MonoBehaviour
{
    //word
    public GameObject word;

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
        if (wordtimer == 2)
        {
            isTalking = 1;
        }

        if (isTalking == 1)
        {
            wordtimer -= Time.deltaTime;
            if (wordtimer <= 1 && wordtimer > 0)
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
