using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Text textTrump;
    public Text textTrump2;

    public Text textLecter;
    public Text textLecter2;

    // Start is called before the first frame update
    void Start()
    {
        string file = Application.dataPath + "/playerChoices.txt";

        // Trump
        if (GetLine(file, 1) == "0")
        {
            textTrump.text = "First, you chose to take Donald Trump's soul";
            textTrump2.text = "That was a wise choice, He would have killed millions of Mexicans";
        } else if (GetLine(file, 1) == "1")
        {
            textTrump.text = "First, you chose to spare Donald Trump's soul";
            textTrump2.text = "That was not very wise, he will kill millions of Mexicans tomorrow";
        }

        // Lecter
        if (GetLine(file, 2) == "0")
        {
            textLecter.text = "Then, i see you did not let Lecter alive";
            textLecter2.text = "I see you have a good sense of observation";
        }
        else if (GetLine(file, 2) == "1")
        {
            textLecter.text = "Then, i see you did not kill Lecter";
            textLecter2.text = "This one was pretty obvious, but well, i guess everybody makes mistakes";
        }
    }

    string GetLine(string fileName, int line)
    {
        using (var sr = new StreamReader(fileName))
        {
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return sr.ReadLine();
        }
    }
}
