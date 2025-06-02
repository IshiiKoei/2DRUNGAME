using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    //public static GManager instance = null;
    public int score;
    public int stageNum;
    public int continueNum;
    [SerializeField] Button reset;
    [SerializeField] GameObject gameoverCanvas;
    [SerializeField] Transform playerTransform;
    //[SerializeField] GameObject clickstart;
    
    public static  GManager instance;
    public Score point;

    // Start is called before the first frame update

    void Start()
    {
        if(reset != null)
        {
            reset.onClick.AddListener(RetryGame);
        }

    }
    void Awake()
    {
       
        
        
        if (instance != null)
        {
            Destroy(this.gameObject);

        }
        else
        {
            instance = this;
           
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    public void RetryGame()
    {
        point.oldScore = score;
        score = 0;
        SceneManager.LoadScene("restrat");
    }
    public void GameOver()
    {
        playerTransform.gameObject.GetComponent<Renderer>().enabled = false;
            /*SetActive(false);*/
        gameoverCanvas.SetActive(true);
        

    }
    /*public void RetryGame()
    {
        SceneManager.LoadScene("restrat");
        score = 0;

    }
    /*public void Clickstart()
    {
        playerTransform.gameObject.SetActive(true );
        clickstart.SetActive(true);
    }*/
   

}





    
