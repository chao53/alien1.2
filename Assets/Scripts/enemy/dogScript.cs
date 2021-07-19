using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour
{
    //蒙皮
    public GameObject skin;
   

    //水平移动的速度
    public float walkSpeed = 7;
    //弹跳高度
    public float jumpHeight = 7;
    //攻击距离
    public float attackDistance = 3f;
    //跳跃间隔
    public float jumpTimer = 3f;
    //射击间隔
    public float shootTimer = 1.5f;
    //自救次数
    public int saveTimes = 1;
    //自救水平
    public float saveLevel = -3;

    private float wS = 1;
    private float aD = 1;
    private float timer1 = 1;
    private float timer2 = 1;
    private float saveTimer = 2;
    
    private float haveSave = 0;
    
    private int isWalking = 0;

    private void changeMaterial(string posture1, string posture2)
    {
        if (posture1.Equals("U"))
        {
            if (posture2.Equals("R"))
            {
                skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/dog/rdogj");
            }
            else if (posture2.Equals("L"))
            {
                skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/dog/ldogj");
            }
        }
        else if (posture2.Equals("R"))
        {
            if (isWalking == 1)
            {
                skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/dog/rdog2");
            }
            else
            {
                skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/dog/rdog1");
            }

        }
        else if (posture2.Equals("L"))
        {
            if (isWalking == 1)
            {
                skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/dog/ldog2");
            }
            else
            {
                skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/dog/ldog1");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        wS = walkSpeed;
        aD = attackDistance;
        timer1 = jumpTimer * Random.Range(0.5f, 2);
        timer2 = shootTimer * Random.Range(0.5f, 2);

    }
    // Update is called once per frame

    private string posture1 = "S";
    private float ptimer = 1.4f;
    void Update()
    {

        if (GameObject.Find("player"))
        {
            string posture2 = "S";
            isWalking = 0;
            timer1 -= Time.deltaTime;
            timer2 -= Time.deltaTime;

            if (posture1 == "U")
            {
                ptimer -= Time.deltaTime;
            }

            int direction;

            if ((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > 0)
            {
                direction = -1;
                posture2 = "L";
            }
            else
            {
                direction = 1;
                posture2 = "R";
            }

            if (((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < 11
                && (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > -11)
                && ((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > aD
                || (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < -1 * aD)
                && (((gameObject.transform.position.y - GameObject.Find("player").transform.position.y) < 6)
                && (gameObject.transform.position.y - GameObject.Find("player").transform.position.y) > -6))
            {
                this.gameObject.transform.Translate(wS * direction * Vector3.right * Time.deltaTime);
                isWalking = 1;
            }

            if (timer1 <= 0)
            {
                if (gameObject.transform.position.y + 0.2f < GameObject.Find("player").transform.position.y)
                {
                    this.GetComponent<Rigidbody>().velocity = Vector3.up * jumpHeight;
                    posture1 = "U";
                }
                timer1 = jumpTimer * Random.Range(0.5f, 2);
            }

            if (ptimer <= 0)
            {
                posture1 = "S";
                ptimer = 1.4f;
            }

            if (timer2 <= 0)
            {
                if ((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < 5
                && (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > -5)
                {
                    Vector3 v1 = new Vector3(4 * direction, 1, 0);
                    this.GetComponent<Rigidbody>().velocity = 2.5f * v1;
                    posture1 = "U";
                }
                timer2 = shootTimer * Random.Range(0.5f, 2);
            }

            //自救
            if (transform.position.y <= saveLevel && saveTimes > 0)
            {
                Vector3 v0 = new Vector3(0, 4, 0);
                this.gameObject.transform.Translate(v0);
                Vector3 v1 = new Vector3(4 * direction, 0, 0);
                this.GetComponent<Rigidbody>().velocity = 2.5f * v1;
                posture1 = "U";
                haveSave = 1;
                saveTimes--;
            }
            if (haveSave == 1)
            {
                saveTimer--;
                if (saveTimer <= 0)
                {
                    haveSave = 0;
                    posture1 = "S";
                    saveTimer = 2;
                }
            }


            changeMaterial(posture1, posture2);
        }

        
    }
}
