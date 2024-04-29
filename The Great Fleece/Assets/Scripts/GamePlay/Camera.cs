using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startPos;
    private void Start()
    {
        transform.position= _startPos.position;
        transform.rotation= _startPos.rotation;
    }

    private void Update()
    {
        transform.LookAt(_player);
    }
}
