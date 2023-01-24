using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{

    private TextMeshProUGUI LevelCompleteText;

    void Start()
    {
        LevelCompleteText = GetComponent<TextMeshProUGUI>();

        LevelCompleteText.text = "";
    }

    public void LevelCompleted() 
    {
        LevelCompleteText.text = "Level Complete";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
