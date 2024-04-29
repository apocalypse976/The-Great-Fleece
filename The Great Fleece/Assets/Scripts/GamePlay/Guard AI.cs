using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [HideInInspector] public bool coinTossed;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private int _currentIndex;
    private NavMeshAgent _agent;
    private Animator _anim;
  

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();


    }
    private void Update()
    {
        Animations();
        if (_waypoints.Count > 0 && _waypoints[_currentIndex] != null&&!coinTossed)
        {
            if (_waypoints.Count == 2 && _waypoints[_currentIndex] != null)
            {
                StartCoroutine(IdleRoutine());
            }
            else if (_waypoints.Count == 3 && _waypoints[_currentIndex] != null)
            {
                StartCoroutine(IdleRoutineOne());
            }


        }
    }
    IEnumerator IdleRoutine()
    {
        //float distance = Vector3.Distance(transform.position, _waypoints[_currentIndex].position);
        float distance = Vector3.Distance(transform.position, _waypoints[0].position);
        float distancetwo = Vector3.Distance(transform.position, _waypoints[1].position);


        yield return new WaitForSeconds(3);
        if (_currentIndex == 0 && distance <4)
        {
            _currentIndex++;
            _agent.SetDestination(_waypoints[_currentIndex].position);

        }

        else if (_currentIndex == _waypoints.Count - 1 && distancetwo < 4)
        {
            _currentIndex = 0;
            _agent.SetDestination(_waypoints[_currentIndex].position);
        }


    }

    IEnumerator IdleRoutineOne()
    {
        float distance = Vector3.Distance(transform.position, _waypoints[0].position);
        float distance1 = Vector3.Distance(transform.position, _waypoints[1].position);
        float distance2 = Vector3.Distance(transform.position, _waypoints[2].position);

    
       
            yield return new WaitForSeconds(3);
            if (_currentIndex == 0 && distance < 4)
            {
                _currentIndex++;
                _agent.SetDestination(_waypoints[_currentIndex].position);
            }

            else if (_currentIndex == 1 && distance1 < 4)
            {

                _currentIndex = 2;
                _agent.SetDestination(_waypoints[_currentIndex].position);

            }
            else if (_currentIndex == _waypoints.Count-1 && distance2 < 4)
            {
                _currentIndex = 0;
                _agent.SetDestination(_waypoints[_currentIndex].position);
             }
       
    }
   void Animations()
   {
      if (_agent.velocity.magnitude > 0)
      { 
         _anim.SetBool("Walk", true);
      }
      else if (_agent.velocity.magnitude == 0)
      {
         _anim.SetBool("Walk", false);
      }
   }
    
}


