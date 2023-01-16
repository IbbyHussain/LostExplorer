using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Slider HPBarSlider;

    // Set Max health
    public void SetMaxHealth(float Value) 
    {
        HPBarSlider.maxValue = Value;
        HPBarSlider.value = Value;
    }

    // Set current Health
    public void SetCurrentHealth(float Value)
    {
        HPBarSlider.value = Value;
    }

    private void Start()
    {
        HPBarSlider = GetComponent<Slider>();
    }
}
