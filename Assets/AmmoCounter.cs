using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TPS_Controller TPS;

    private TextMeshProUGUI AmmoCounterText;
    void Start()
    {
        AmmoCounterText = GetComponent<TextMeshProUGUI>();

        UpdateAmmoCounterText();
    }

    public void UpdateAmmoCounterText() 
    {
        string Ammo = TPS.CurrentAmmo.ToString() + " / " + TPS.MaxAmmo.ToString();
        AmmoCounterText.text = Ammo;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
