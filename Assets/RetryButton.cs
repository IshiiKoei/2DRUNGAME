using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    [SerializeField] GManager manager;
     void Start()
    {
        manager.score = 0;
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("restrat");
        
    }
}
