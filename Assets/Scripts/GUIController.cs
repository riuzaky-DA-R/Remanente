using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public Text DistanceA;
    public Text DistanceB;
    public Text DistanceC;
    public Text BatteryPercentage;
    float DA;
    float DB;
    float DC;
    public GameObject ObjectA;
    public GameObject ObjectB;
    public GameObject ObjectC;
    int MaxB = 100;
    int currentBattery;
    public BatteryController Battery;
    float countdown;
    //System Integrity 
    public Text Integrity;
    int SystemIntegrity;
    //WaypointScript
    public Image pointA;
    public Image pointB;
    public Image pointC;
    public Camera cam;
    public Text Windicator;

    float DistanceCalculator(GameObject Object)
    {
        Vector2 ObjectPos = new Vector2(Object.transform.position.x, Object.transform.position.z);
        Vector2 PlayerPos = new Vector2(transform.position.x, transform.position.z);
        return Vector2.Distance(PlayerPos, ObjectPos);
    }
    //ThisFunction Checks if the object is within the plarer's FOV, has to be called in update
    void CheckOnScreen(GameObject Destination, Camera camCheck, Text DistanceDisplay, Image WaypontDisplay) 
    {
        float inFOV = Vector3.Dot((Destination.transform.position - camCheck.transform.position).normalized, camCheck.transform.forward);
        if (inFOV <= 0)
        {
            ToggleUI(WaypontDisplay, false, DistanceDisplay);
        }
        else 
        {
            ToggleUI(WaypontDisplay, true, DistanceDisplay);
            WaypontDisplay.transform.position = cam.WorldToScreenPoint(Destination.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Battery.SetMaxBattery(MaxB);
        currentBattery = 29;
        countdown = 29.0f;
        SystemIntegrity = 80;
    }
    public float BatteryChange(float battery) 
    {
        battery -= Time.deltaTime*0.1f;
        int NewValue;
        NewValue = (int)battery;
        return battery; ;
    }

    //enables and disables the waypoint
    private void ToggleUI(Image WP, bool _Value, Text Distance)
    {
        WP.enabled = _Value;
        Distance.enabled = _Value;
    }

    // Update is called once per frame
    void Update()
    {
        DA = DistanceCalculator(ObjectA);
        DB = DistanceCalculator(ObjectB);
        DC = DistanceCalculator(ObjectC);
        countdown = BatteryChange(countdown);
        currentBattery = (int)countdown;
        Battery.SetBattery(currentBattery);
        CheckOnScreen(ObjectA, cam, DistanceA, pointA);
        CheckOnScreen(ObjectB, cam, DistanceB, pointB);
        CheckOnScreen(ObjectC, cam, DistanceC, pointC);
        DistanceA.text = "S1"+ "\n" + DA.ToString("F2");
        DistanceB.text = "S2"+ "\n" + DB.ToString("F2");
        DistanceC.text = "S3"+ "\n" + DC.ToString("F2");
        BatteryPercentage.text = currentBattery.ToString() + "%";
        Integrity.text = "System integrity... "+ SystemIntegrity.ToString() + "%";
        if (SystemIntegrity <= 0)
        {
            SceneManager.LoadScene("ZeroIntegrity");
        }
        if (currentBattery <= 0) 
        {
            SceneManager.LoadScene("ZeroBattery");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            SystemIntegrity = SystemIntegrity - 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Safeplace")
        {
            Windicator.text = "you are in a Safeplace";
            SceneManager.LoadScene("Win");
        }
    }
}
