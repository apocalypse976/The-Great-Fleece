using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _singleton;
    public static GameManager Singleton 
    {
         get
        {
            return _singleton;
        }
    }
    public bool HasKey { get; set; }
    private void Awake()
    {
        if(_singleton == null)
        {
            _singleton = this;
        }
        else if(_singleton != null)
        {
            Destroy(gameObject);
        }
       

    }
  

    

}
