using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    public Button choiceButton1;
    public Button choiceButton2;

    
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = choiceButton1.GetComponent<Button>();
        Button btn2 = choiceButton2.GetComponent<Button>();

        btn1.onClick.AddListener(OnChoiceButton1Click);
        btn2.onClick.AddListener(OnChoiceButton2Click);
    }

    private void OnChoiceButton2Click()
    {
        Debug.Log("Choix : Détruire l'âme");
        // TODO: Implement method
    }

    private void OnChoiceButton1Click()
    {
        Debug.Log("Choix : Laisser tranquille");
        // TODO: Implement method
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
