using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    public int totalHp = 10;

    private int Hp = 10;

    private float dropTimer = 0.2f;

    //清凉时间
    private float xbtimer = 1;

    //受伤间隔
    private float timer0 = 0.05f;
    private int hurtable = 1;

    private int state = 1;

    //血条
    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        Hp = totalHp;
    }
    public void changState(int s)
    {
        state = s;
    } 

    //无敌清凉
    public void xb(float xbt)
    {
        xbtimer = xbt;
    }

    public void Hurt(int dam)
    {
        if(hurtable == 1 && xbtimer < 0)
        {
            hurtable = 0;
            if (state == 1)
            {
                Hp -= dam;
            }
            else if (state == 0)
            {
                Hp -= (dam - 1);
            }
        }
    }

    public void Heal(int blood)
    {
        Hp += blood;
        if(Hp > totalHp)
        {
            Hp = totalHp;
        }
    }

    public int ReturnHp()
    {
        return Hp;
    }

    // Update is called once per frame
    void Update()
    {
        timer0 -= Time.deltaTime;

        if(xbtimer >= -1)
        {
            xbtimer -= Time.deltaTime;
        }
        
        if(timer0 <= 0)
        {
            hurtable = 1;
            timer0 = 0.05f;
        }

        if (this.gameObject.transform.position.y < -35)
        {
            dropTimer -= Time.deltaTime;
            if(dropTimer < 0)
            {
                Hp -= 1;
                dropTimer = 0.2f;
            }      
        }
        if (Hp <= 0)
        {
            if (this.gameObject.name.Equals("player"))
            {
                GameObject.Find("EventSystem").GetComponent<UI>().gameOver(0);
            }
            else if (this.gameObject.name.Equals("fakePlayer2"))
            {
                GameObject.Find("EventSystem").GetComponent<UI>().gameOver(1);
                GameObject.Find("player").SetActive(false);
            }
            else if (this.gameObject.name.Equals("Bboss"))
            {
                GameObject.Find("EventSystem").GetComponent<UI>().enemyDie();
                Destroy(GameObject.Find("fakefloor3"));
            }
            else if (this.gameObject.name.Equals("fakefloor2") || this.gameObject.name.Equals("littleB(Clone)"))
            {
                //
            }
            else
            {
                GameObject.Find("EventSystem").GetComponent<UI>().enemyDie();
            }
            gameObject.SetActive(false);
        }

        blood.transform.localScale = new Vector3(1.0f*Hp/totalHp,0.05f,1);
    }
}
