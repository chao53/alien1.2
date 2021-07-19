using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mutebuttonScript : MonoBehaviour
{

    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!flag)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = false;
            flag = true;
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = true;
            flag = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
