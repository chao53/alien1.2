using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class continue2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadScene("0.5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
