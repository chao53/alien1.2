using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class chooseScript : MonoBehaviour
{
    public GameObject choosePanel;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        choosePanel.SetActive(false);
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!flag)
        {
            choosePanel.SetActive(true);
        }
        else
        {
            choosePanel.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        flag = choosePanel.activeSelf;
    }
}
