using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //蒙皮
    public GameObject skin;
    //剑
    public GameObject rsword;
    public GameObject lsword;
    public GameObject rswordDam;
    public GameObject lswordDam;
    public GameObject rswordXDam;
    public GameObject lswordXDam;

    public AudioSource music;
    //枪声
    public AudioClip gunMusic;
    public AudioClip laserMusic;
    //剑声
    public AudioClip swordMusic;
    public AudioClip sword2Music;

    //cooltime罩子
    public GameObject cooltime;
    // 渲染网格
    private MeshRenderer meshRenderer;
    //引用CharacterController
    CharacterController characterController;
    //重力
    public float gravity = 10;
    //水平移动的速度
    public float walkSpeed = 5;
    //弹跳高度
    public float jumpHeight = 7;
    //攻守姿态盾0枪1剑2蓄力剑3斩4蓄力斩5蓄力枪6
    private int state = 1;
    //拾取开关
    private int picking = 0;
    //武器枪0剑1
    private int weapon = 0;
    //盾
    private int denfending = 0;
    //清凉时间
    private float cooltimer = -1;
    // 控制角色的移动方向
    Vector3 moveDirection = Vector3.zero;
    float horizontal = 0;
    //朝向
    int direction = 1;
    //姿势变换
    private float postureltimer = 0.3f;
    private int post = 1;
    //出剑时间
    private float swordtimer = 0.25f;
    //出剑动画
    private float swordtimer1 = 0;
    //出剑间隔
    private float swordtimer2 = 0.57f;
    private int swordpost = 1;
    //蓄力时间
    private float poisedtimer = 1.0f;
    private int poiseding = 0;
    private int ispoised = 0;

    private void changeMaterial(string posture1, string posture2)
    {
        if (posture1.Equals("U"))
        {
            if (direction == 1)
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rwd");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rwg");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rws");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rwx");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rwa");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rwz");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rwj");
                        break;
                }
            }
            else if (direction == -1)
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lwd");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lwg");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lws");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lwx");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lwa");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lwz");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lwj");
                        break;
                }
            }
        }
        else if (posture2.Equals("R"))
        {
            if(post == 1)
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1d");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1g");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1s");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1x");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1a");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1z");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r1j");
                        break;
                }
            }
            else
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2d");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2g");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2s");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2x");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2a");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2z");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/r2j");
                        break;
                }
            }
        }
        else if (posture2.Equals("L"))
        {
            if(post == 1)
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1d");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1g");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1s");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1x");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1a");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1z");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l1j");
                        break;
                }
            }
            else
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2d");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2g");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2s");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2x");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2a");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2z");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/l2j");
                        break;
                }
            }
            
        }
        else
        {
            if (direction == 1)
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rsd");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rsg");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rss");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rsx");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rsa");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rsz");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/rsj");
                        break;
                }
            }
            else if (direction == -1)
            {
                switch (state)
                {
                    case 0:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lsd");
                        break;
                    case 1:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lsg");
                        break;
                    case 2:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lss");
                        break;
                    case 3:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lsx");
                        break;
                    case 4:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lsa");
                        break;
                    case 5:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lsz");
                        break;
                    case 6:
                        skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/player/lsj");
                        break;
                }
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        gunMusic = Resources.Load<AudioClip>("music/gun1");
        laserMusic = Resources.Load<AudioClip>("music/laser");
        swordMusic = Resources.Load<AudioClip>("music/sword");
        sword2Music = Resources.Load<AudioClip>("music/sword1");

        //收剑
        rsword.SetActive(false);
        lsword.SetActive(false);
        rswordDam.SetActive(false);
        lswordDam.SetActive(false);
        rswordXDam.SetActive(false);
        lswordXDam.SetActive(false);

        cooltime.SetActive(false);

        music.playOnAwake = false;
    }
    //喝雪碧
    public void drinkXb(float cotime)
    {
        cooltimer = cotime;
    }
    //拾取
    public int ReturnPicking()
    {
        return picking;
    }
    // Update is called once per frame
    void Update()
    {
        if(cooltimer > 0)
        {
            cooltime.SetActive(true);
            cooltimer -= Time.deltaTime;
        }
        if(cooltimer <= 0)
        {
            cooltime.SetActive(false);
        }

        postureltimer -= Time.deltaTime;
        if(postureltimer <= 0)
        {
            postureltimer = (Input.GetKey(KeyCode.LeftShift) ? 0.16f:0.3f);
            post *= -1;
        }

        string posture1 = "S";
        string posture2 = "S";
        //shift加速
        float runSpeed = walkSpeed + (Input.GetKey(KeyCode.LeftShift)?4-4*denfending:0);
        
        //控制角色的移动
        characterController.Move(moveDirection * Time.deltaTime);
        horizontal = Input.GetAxis("Horizontal");
        //控制角色的重力
        moveDirection.y -= gravity * Time.deltaTime;
        //控制角色右移（按d键）  在这里不直接使用0而是用0.01f是因为使用0之后会持续移动，无法静止
        if (horizontal > 0.01f)
        {
            moveDirection.x = horizontal * runSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            posture2 = "R";
            direction = 1;
        }

        //控制角色左移（按a键）
        if (horizontal < 0.01f)
        {
            moveDirection.x = horizontal * runSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            posture2 = "L";
            direction = -1;
        }
        // 弹跳控制
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                moveDirection.y = jumpHeight;
            }
        }
        
        if (!characterController.isGrounded)
        {
            posture1 = "U";
        }

        //切换武器
        if (Input.GetKeyUp(KeyCode.Q))
        {
           if(weapon == 1)
            {
                weapon = 0;
            }
            else
            {
                weapon = 1;
            }
        }

        //拾取道具
        if (Input.GetKeyDown(KeyCode.S))
        {
            picking = 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            picking = 0;
        }

        //开挂
        if (Input.GetKeyUp(KeyCode.O))
        {
            drinkXb(7);
            this.gameObject.GetComponent<HpScript>().xb(7);
        }


        //右键开盾
        if (Input.GetMouseButtonDown(1))
        {
            ispoised = 0;
            poiseding = 0;
            poisedtimer = 1.2f;
            denfending = 1;
            this.gameObject.GetComponent<HpScript>().changState(0);
        }
        if (Input.GetMouseButtonUp(1))
        {
            denfending = 0;
            this.gameObject.GetComponent<HpScript>().changState(1);

        }

        //蓄力
        if (Input.GetMouseButtonDown(0) && denfending != 1)
        {
       
            poiseding = 1;
        }

        if (poiseding == 1)
        {
            poisedtimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) && denfending != 1)
        {
            poiseding = 0;
            if(weapon == 0)
            {
                Vector3 p = new Vector3(0, -0.1f, 0);
                Vector3 p2 = new Vector3(direction*6.4f, -0.1f, 0);
                if (poisedtimer > 0)
                {
                    // 初始化子弹
                    Rigidbody bulletInstance = Instantiate(Resources.Load<Rigidbody>("Prefabs/bullet"), transform.position + p, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
                    // velocity直接给物体一个固定的移动速度
                    bulletInstance.velocity = new Vector2(10 * direction, 0);
                    music.clip = gunMusic;
                    //播放音效
                    music.Play();
                }
                else//蓄力攻击
                {
                    music.clip = laserMusic;
                    //播放音效
                    music.Play();
                    // 初始化子弹
                    GameObject laser = Instantiate(Resources.Load<GameObject>("Prefabs/laser"), transform.position + p2, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            }
            else if(weapon == 1)
            {
                if (swordpost == 1)
                {
                    //出剑
                    if (direction == 1)
                    {
                        rsword.SetActive(true);
                    }
                    else
                    {
                        lsword.SetActive(true);
                    }

                    if (poisedtimer > 0)
                    {
                        music.clip = swordMusic;
                        //播放音效
                        music.Play();
                        if (direction == 1)
                        {
                            rswordDam.SetActive(true);
                        }
                        else
                        {
                            lswordDam.SetActive(true);
                        }
                        ispoised = 0;
                    }
                    else//蓄力攻击
                    {
                        music.clip = sword2Music;
                        //播放音效
                        music.Play();
                        if (direction == 1)
                        {
                            rswordXDam.SetActive(true);
                        }
                        else
                        {
                            lswordXDam.SetActive(true);
                        }
                        ispoised = 1;
                    }
                    swordtimer1 = 0.2f;
                    swordpost = 0;
                }
            }
            poisedtimer = 1.0f;
        }

        if (swordpost == 0)
        {
            swordtimer -= Time.deltaTime;
            swordtimer1 -= Time.deltaTime;
            swordtimer2 -= Time.deltaTime;
            if (swordtimer <= 0)
            {
                //收剑
                rsword.SetActive(false);
                lsword.SetActive(false);
                rswordDam.SetActive(false);
                lswordDam.SetActive(false);
                rswordXDam.SetActive(false);
                lswordXDam.SetActive(false);
            }
            
            if (swordtimer2 <= 0)
            {
                //备剑
                swordpost = 1;
                swordtimer = 0.25f;
                swordtimer1 = 0f;
                swordtimer2 = 0.57f;
                ispoised = 0;
            }
        }

        //贴图控制
        if (denfending == 1)
        {
            state = 0;
        }
        else if (denfending == 0)
        {
            if (weapon == 0)
            {
                if (poisedtimer > 0)
                {
                    state = 1;
                }
                else
                {
                    state = 6;
                }
                
            }
            else if (weapon == 1)
            {
                if(swordtimer1 > 0)
                {
                    if(ispoised == 0)
                    {
                        state = 4;
                    }
                    else
                    {
                        state = 5;
                    }
                }
                else
                {
                    if (poisedtimer > 0)
                    {
                        state = 2;
                    }
                    else
                    {
                        state = 3;
                    }
                }
            }
        }
        changeMaterial(posture1,posture2);
    }
}