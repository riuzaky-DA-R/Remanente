using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public Text Tittle;
    public Text PlayerInstructions;
    public Text SecondText;
    public Text ThirdText;
    // Start is called before the first frame update
    void Start()
    {
        SecondText.enabled = false;
        ThirdText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Tittle.enabled = false;
            PlayerInstructions.enabled = false;
            SecondText.enabled = true;
            Invoke("SetSettings", 3);
            Invoke("GoToWorld", 10);
        }
    }
    void SetSettings()
    {
        ThirdText.enabled = true;
    }
    void GoToWorld()
    {
        SceneManager.LoadScene("Level1");
    }
}
