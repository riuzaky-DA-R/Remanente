using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpawner : MonoBehaviour
{
    float timer;
    public float delaytime;
    public GameObject meteor;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {   if (timer < delaytime)
        {
            timer += Time.deltaTime;
        }
        else if (timer > delaytime)
        {
            GameObject MeteorReady= Instantiate(meteor, transform) as GameObject;
            Rigidbody rb = MeteorReady.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 110;

            timer = 0.0f;
        }
        
    }
}
