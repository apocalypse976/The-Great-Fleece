using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _singleton;
    public static UIManager Singleton
    {
        get
        {
            if (_singleton == null)
            {
                Debug.Log("UI Manager is null");
            }
                return _singleton;
        }
    }

    private void Awake()
    {
        _singleton=this;
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
