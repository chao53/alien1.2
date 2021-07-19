using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duangScript : MonoBehaviour
{
    public GameObject duang;
    public GameObject duang1;

    private float duangtimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        duang.SetActive(false);
        duang1.SetActive(false);
    }

    public void Duang(int d)
    {
        print("dd");
        if(d == 1)
        {
            duang.SetActive(true);
        }
        else
        {
            duang1.SetActive(true);
        }
        duangtimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(duangtimer > -1)
        {
            duangtimer -= Time.deltaTime;
        }
        if(duangtimer <= 0)
        {
            duang.SetActive(false);
            duang1.SetActive(false);
        }
    }
}
