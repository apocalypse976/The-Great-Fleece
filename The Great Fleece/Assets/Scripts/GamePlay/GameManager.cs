using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _singleton;
    public static GameManager Singleton 
    {
         get
        {
            return _singleton;
        }
    }
    [SerializeField] private GameObject _introCutScene;
    [SerializeField] private GameObject[] _cutscenes;
    [SerializeField] private PlayableDirector playableDirector;
    public bool HasKey { get; set; }
    private void Awake()
    {
        if (_singleton == null)
        {
            _singleton = this;
        }
        else if (_singleton != null)
        {
            Destroy(gameObject);
        }
        foreach (var cutscene in _cutscenes)
        {
            cutscene.gameObject.SetActive(false);
        }
        Invoke("IntroCutSceneTrigger", 0.01f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            playableDirector.time = 59.0f;
        }
    }
    void IntroCutSceneTrigger()
    {
        _introCutScene.SetActive(true);
    }

    

}
