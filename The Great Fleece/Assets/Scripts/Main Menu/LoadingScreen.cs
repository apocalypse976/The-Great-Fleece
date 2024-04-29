using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    private void Start()
    {
        StartCoroutine (LoadLevelAsync ());
    }
    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        while (!asyncOperation.isDone)
        {
            _progressBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
      
    }
}
