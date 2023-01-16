using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STBar : MonoBehaviour
{
    Slider STBarSlider;

    // Set Max health
    public void SetMaxStamina(float Value)
    {
        STBarSlider.maxValue = Value;
        STBarSlider.value = Value;
    }

    // Set current Health
    public void SetCurrentStamina(float Value)
    {
        STBarSlider.value = Value;
    }

    private void Start()
    {
        STBarSlider = GetComponent<Slider>();
    }
}
