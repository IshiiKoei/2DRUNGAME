using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public void Quitgame()
    {
#if UNITY_EDITOR
        //unityエディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //実際のゲーム終了処理
        Application.Quit();
#endif
    }
}
