using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCard : MonoBehaviour
{
    [SerializeField] private GameObject _grabCardCutscene,_errorMSG;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            _grabCardCutscene.SetActive(true);
            GameManager.Singleton.HasKey = true;
            _errorMSG.SetActive(false);
        }
    }
}
