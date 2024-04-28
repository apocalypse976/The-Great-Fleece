using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movements();
        Animations();
    }

    void Movements()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }

        }
    
    }
    void Animations()
    {
        if (_agent.velocity.magnitude > 0)
        {
            _anim.SetBool("Walk", true);
        }
        else if( _agent.velocity.magnitude<= 0)
        {
            _anim.SetBool("Walk", false);
        }
    }
}

