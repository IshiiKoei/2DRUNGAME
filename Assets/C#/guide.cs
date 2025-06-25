using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guide : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _canvas;
    public void Guidebutton()
    {
       _canvas.SetActive(true);
    }
}
