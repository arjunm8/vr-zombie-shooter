using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class kills : MonoBehaviour {
    public Text killText;
    private int killCount;
    void Start () {
        killCount = 0;
    }

    public void killPlus(){
        killCount++;
        killText.text = killCount.ToString() + " Kills";
    }
}
