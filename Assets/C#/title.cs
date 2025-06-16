using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    public void titleBottan()
    {
        canvas.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
