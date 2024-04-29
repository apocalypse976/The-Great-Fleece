using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _myCam;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            UnityEngine.Camera.main.transform.position= _myCam.transform.position;
            UnityEngine.Camera.main.transform.rotation= _myCam.transform.rotation;
        }
    }
}
