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
            Camera.main.transform.position=_myCam.transform.position;
            Camera.main.transform.rotation=_myCam.transform.rotation;
        }
    }
}
