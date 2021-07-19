using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class authorButton : MonoBehaviour
{
    public GameObject authorPanel;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        authorPanel.SetActive(false);
    }

    private void OnClick()
    {
        if (!flag)
        {
            authorPanel.SetActive(true);
        }
        else
        {
            authorPanel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        flag = authorPanel.activeSelf;
    }
}
