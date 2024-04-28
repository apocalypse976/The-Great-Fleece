using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private bool _canthrown=true;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private GameObject _coin;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movements();
        Animations();
        CoinDistraction();
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
    void CoinDistraction()
    {
        if(Input.GetMouseButtonDown(1)&&_canthrown)
        {
            _anim.SetTrigger("Throw");
            Ray coinRay= UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(coinRay, out hitInfo))
            {
                Instantiate(_coin, hitInfo.point, Quaternion.identity);
                _canthrown = false;
                AudioManager.Singleton.AudioPlay(_coinSound);
                CoinChase(hitInfo.point);
            }
          
        }
    }
    void CoinChase( Vector3 coinPos)
    {
        GameObject[] Guards = GameObject.FindGameObjectsWithTag("Guard");
        foreach(var guard in Guards)
        {
            GuardAI gurdsAI = guard.GetComponent<GuardAI>();
            NavMeshAgent guardAgent= guard.GetComponent<NavMeshAgent>();
            guardAgent.SetDestination(coinPos);
            gurdsAI.coinTossed = true;
        }
        


    }
}

