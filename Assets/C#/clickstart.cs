using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickstart : MonoBehaviour
{
    [SerializeField] GManager manager;
    //[SerializeField] GameObject GameObject;
    
     void Start()
    {
        //manager.score = 0;
    } 
    /*void Update()
    {
        manager.score = 0;
    */
    // Start is called before the first frame update
    public void Restart()
    {
        int resetscore;
        resetscore = manager.score;
        resetscore = 0;
        Debug.Log(resetscore);
       GManager.instance.Startgame();
       // GManager.instance.IsActive = true;
        SceneManager.LoadScene("2d");
        //manager.score = 0;
    }
}
