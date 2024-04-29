using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private GameObject[] _allPrefabs;
    [SerializeField] private GameObject _gameOverScene;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            for(int i=0;i< _allPrefabs.Length; i++)
            {
                _allPrefabs[i].gameObject.SetActive(false);
            }
            _gameOverScene.SetActive(true);
        }
    }

}
