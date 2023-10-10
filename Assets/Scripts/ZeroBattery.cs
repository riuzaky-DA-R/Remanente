using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZeroBattery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Text ExitText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            ExitText.text = "[ You have quitted the game ]";
            Application.Quit();
        }
    }
}
