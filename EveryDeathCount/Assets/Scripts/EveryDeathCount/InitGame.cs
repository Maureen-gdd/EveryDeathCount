using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string playerChoicesFile = Application.dataPath + "/playerChoices.txt";
        if (File.Exists(playerChoicesFile)) 
        {
            File.Delete(playerChoicesFile);
        }
    }
}
