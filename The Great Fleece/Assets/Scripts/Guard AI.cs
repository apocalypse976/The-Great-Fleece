using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private int _currentIndex;
    private NavMeshAgent _agent;
    private bool _reverse=true;
    private bool _targetReached;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        
       
    }
    private void Update()
    {
        if ( _waypoints.Count > 0&& _waypoints[_currentIndex] != null)
        {
          _agent.SetDestination(_waypoints[_currentIndex].position);
          float distance= Vector3.Distance(transform.position, _waypoints[_currentIndex].position);
            
            if (distance < 3&&!_targetReached)
            {
               _targetReached= true;

                if(_reverse)
                {
                    Debug.Log("reverse");
                    StartCoroutine(IdleRoutine());
                    if (_currentIndex == 0)
                    {
                        _currentIndex =0;
                        _reverse = false;
                    }
                   
                }
               
                else if(!_reverse)
                {
                    Debug.Log("!reverse");
                    StartCoroutine(IdleRoutine());
                    if (_currentIndex == _waypoints.Count||_currentIndex==1)
                    {
                         StartCoroutine(IdleRoutine());
                        _currentIndex =0 ;

                        _reverse = true;
                    }
                }
               
                 
            }
        }

    }
    IEnumerator IdleRoutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Coroutine");
        if (_reverse )
        {
            if (_currentIndex == _waypoints.Count)
            {
                _targetReached = false;
                _currentIndex -= 2;
                
            }
            

        }
        else if(!_reverse && _currentIndex==0)
        {
          _currentIndex++;
            _targetReached = false;
        }

    }
}
