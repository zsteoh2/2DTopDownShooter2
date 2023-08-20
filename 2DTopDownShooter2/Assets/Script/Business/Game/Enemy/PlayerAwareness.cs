using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectiontoPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectiontoPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
