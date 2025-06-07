using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Totalscore : MonoBehaviour
{
    public Text Totalscoretext;
    public int tscore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tscore = 0;
        Totalscoretext = GetComponent<Text>();
        if (GManager.instance != null)
        {
            Totalscoretext.text = "Totalscore"+ GManager.instance.score*GManager.instance.mileagea;
        }
        else
        {
            Debug.Log("ゲームマネージャーを置き忘れてるよ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tscore != GManager.instance.score)
        {
            Totalscoretext.text = "Totalscore" + GManager.instance.score*GManager.instance.mileagea;
            tscore = GManager.instance.score*GManager.instance.mileagea;
        }
    }
}
