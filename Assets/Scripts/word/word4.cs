using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word4 : MonoBehaviour
{
    //word
    public GameObject word;
    private float wordtimer = 0;
    private int isTalking = 0;
    // Start is called before the first frame update
    void Start()
    {
        word.SetActive(false);
    }

    //讲话
    public void Talk()
    {
        wordtimer = 0.9f;
        isTalking = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking == 1)
        {
            wordtimer -= Time.deltaTime;
            word.SetActive(true);
        }
        if (wordtimer <= -0.1f)
        {
            isTalking = 0;
            word.SetActive(false);
        }
    }
}
