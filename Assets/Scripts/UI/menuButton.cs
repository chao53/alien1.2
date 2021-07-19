using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
    public GameObject menuPanel = null;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
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

    // Update is called once per frame
    void Update()
    {
        flag = menuPanel.activeSelf;
    }
}
