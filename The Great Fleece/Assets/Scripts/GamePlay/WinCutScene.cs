using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCutScene : MonoBehaviour
{
    [SerializeField] private GameObject _winCutScene;
    [SerializeField] private TextMeshProUGUI _msg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Win Trigger");
            if (GameManager.Singleton.HasKey)
            {
                _winCutScene.SetActive(true);
            }
            else
            {
                _msg.gameObject.SetActive(true);
                _msg.text = "You need the key.";
            }
        }
    }
}
