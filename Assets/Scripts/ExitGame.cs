using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        // ≈сли игра запущена в редакторе, просто останавливаем воспроизведение
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ≈сли игра запущена в сборке, выходим из приложени€
            Application.Quit();
#endif
    }
}
