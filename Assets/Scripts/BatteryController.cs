using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryController : MonoBehaviour
{
    public Slider Battery;
    public Gradient gradient;
    public Image fill;

    public void SetMaxBattery(int Maxbattery)
    {
        Battery.maxValue = Maxbattery;
        Battery.value = Maxbattery;
        fill.color = gradient.Evaluate(1F);
    }
    public void SetBattery(int CurrentBattery)
    {
        Battery.value = CurrentBattery;
        fill.color = gradient.Evaluate(Battery.normalizedValue);
    }

}
