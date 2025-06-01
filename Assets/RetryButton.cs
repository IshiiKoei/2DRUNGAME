using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    [SerializeField] GManager manager;
    public void RetryGame()
    {
        SceneManager.LoadScene("restrat");
        manager.score = 0;
    }
}
