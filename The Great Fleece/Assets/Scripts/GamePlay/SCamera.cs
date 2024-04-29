using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScene;
    [SerializeField] private GameObject _player;
    private MeshRenderer _mrend;
    private Animator _anim;
    private void Start()
    {
        _mrend = GetComponent<MeshRenderer>();
        _anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Color _col = new Color(0.7f,0.14f, 0.04f, 0.03f);
            _mrend.material.SetColor("_TintColor", _col);
            _anim.enabled = false;
            Invoke("playerDisable", 0.5f);
            
        }
    }
    void playerDisable()
    {
        _gameOverScene.SetActive(true);
        _player.SetActive(false);
    }
}
