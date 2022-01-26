using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("init game");
        string playerChoicesFile = Application.dataPath + "/playerChoices.txt";
        string playerChoicesFileMeta = Application.dataPath + "/playerChoices.txt.meta";
        if (File.Exists(playerChoicesFile)) 
        {
            File.Delete(playerChoicesFile);
            File.Delete(playerChoicesFileMeta);
        }
    }
}
