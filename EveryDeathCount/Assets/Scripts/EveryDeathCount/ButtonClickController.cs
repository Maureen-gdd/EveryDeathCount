using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickController : MonoBehaviour
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
        Debug.Log("Choix : Prendre l'âme");
        WriteChoiceInFile("0");
    }

    private void OnChoiceButton1Click()
    {
        Debug.Log("Choix : Laisser tranquille");
        WriteChoiceInFile("1");
    }

    private void WriteChoiceInFile(string choice)
    {
        string destination = Application.dataPath + "/playerChoices.txt";
        FileStream file = new FileStream(destination, FileMode.Append, FileAccess.Write, FileShare.None);

        byte[] info = new UTF8Encoding(true).GetBytes(choice+"\n");

        file.Write(info, 0, info.Length);
    }
}
