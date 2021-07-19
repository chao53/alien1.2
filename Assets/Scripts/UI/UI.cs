using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    GameObject menuPanel = null;
    GameObject passPanel = null;
    GameObject gameoverPanel = null;
    GameObject tip = null;
    GameObject tip2 = null;

    public int enemyNum = 5;
    public int isFinal = 0;

    private bool flag = false;
    private bool flag2 = false;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.Find("menuPanel");
        passPanel = GameObject.Find("passPanel");
        gameoverPanel = GameObject.Find("gameoverPanel");
        tip = GameObject.Find("tip");
        tip2 = GameObject.Find("tip2");
        menuPanel.SetActive(false);
        passPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        tip.SetActive(false);
        tip2.SetActive(false);
    }
    public void gameOver(int a)
    {
        if(a == 1)
        {
            tip.SetActive(true);
        }
        gameoverPanel.SetActive(true);
    }
    public void enemyDie()
    {
        enemyNum--;
    }

    // Update is called once per frame
    void Update()
    {
        flag = menuPanel.activeSelf;
        flag2 = passPanel.activeSelf;

        if (GameObject.Find("player"))
        {
            int hp = GameObject.Find("player").GetComponent<HpScript>().ReturnHp();
            Text hpText, enemyNumText;

            hpText = GameObject.Find("Canvas/hp").GetComponent<Text>();
            enemyNumText = GameObject.Find("Canvas/enemyNum").GetComponent<Text>();

            hpText.text = "Hp:" + hp;
            enemyNumText.text = "剩余敌人数:" + enemyNum;

            if (enemyNum <= 0)
            {
                if (isFinal == 0)
                {
                    passPanel.SetActive(true);
                }
                else if (isFinal == 1)
                {
                    tip2.SetActive(true);
                }
            }

            if (flag2)
            {
                Time.timeScale = 0;
            }
            else
            {
                if (flag)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!flag2)
                {
                    if (!flag)
                    {
                        menuPanel.SetActive(true);
                    }
                    else
                    {
                        menuPanel.SetActive(false);
                    }
                }
            }
        }
        

        
    }
}