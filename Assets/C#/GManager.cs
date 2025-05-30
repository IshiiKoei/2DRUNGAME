using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public int score;
    public int stageNum;
    public int continueNum;
    [SerializeField] GameObject gameoverCanvas;
    [SerializeField] Transform playerTransform;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void GameOver()
    {
        playerTransform.gameObject.SetActive(false);
        gameoverCanvas.SetActive(true);
    }
  
}





    
