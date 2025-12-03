using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MelodyManager : MonoBehaviour
{
    /*
    public static MelodyManager instance;
    MelodyManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    */

    public static List<string> currentMelody = new List<string>();
    public static List<string> neededMelody = new List<string>();
    private void Start()
    {
        neededMelody.Add("1");
        neededMelody.Add("2");
        neededMelody.Add("3");
        Debug.Log(neededMelody[0]+ neededMelody[1]+ neededMelody[2]);
    }

    public static void AddMelody(string melodyCode)
    {
        currentMelody.Add(melodyCode);


        if(currentMelody.Count == neededMelody.Count)
        {
            if (currentMelody.SequenceEqual(neededMelody))
            {
                //eventi tetikle
                Debug.Log("a");
            }
            else
            {
                currentMelody.Clear();
            }
        }
    }
}

//çok paramýz olunca vakumlu kaplama makinasý alacaðýz