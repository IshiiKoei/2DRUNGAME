using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public void Quitgame()
    {
#if UNITY_EDITOR
        //unity�G�f�B�^�[�ł̓���
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //���ۂ̃Q�[���I������
        Application.Quit();
#endif
    }
}
