using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class mileage : MonoBehaviour
{
    
    [SerializeField]
    Text mileageText;
   public int mileagea = 0;
   public bool timerIsActive = false;
    public Coroutine timer;
    float secondsPerMeter = 0.1f;
    public static mileage instance;
    public GameObject player;
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
    // Start is called before the first frame update
    public int Mileage
    {
        get
        {
            return mileagea;
        }
        set
        {
            mileagea = Mathf.Max(value, 0);

            UpdateMileageUI();
        }
    }

    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!timerIsActive)
        {
            timer =
                StartCoroutine(nameof(MileageTimer));
        }
    }
    public void Startgame()
    {
        InitGame();
    }
    void InitGame()
    {
        Mileage = 0;
        timerIsActive = false ;
    }
    IEnumerator MileageTimer()
    {
        timerIsActive = true;
        Mileage++;
        yield return new WaitForSeconds(secondsPerMeter);
        timerIsActive =false ;
        
    }
    void UpdateMileageUI()
    {
        mileageText.text = mileagea.ToString() + "m";
    }
}
