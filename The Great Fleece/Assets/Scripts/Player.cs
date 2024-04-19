using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _dareen;
    private NavMeshAgent _agent;
    private Animator _anim;
    private float _distance;
    private Vector3 _target;
    private void Start()
    {
        _agent = GetComponentInChildren<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Movements();
    }

    void Movements()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               _agent.SetDestination(hit.point);
                _anim.SetBool("Walk", true);
                _target = hit.point;

            }

        }
        //_distance = Vector3.Distance(transform.position, _target);
        //Debug.Log(_distance);
        //if (_distance < 1.0f)
        //{
        //    _anim.SetBool("Walk", false);
        //    Debug.Log("Distance Reached");
        //}
        if (_dareen.transform.position == _target)
        {
            Debug.Log("Distance Reached");
        }
    }
}

