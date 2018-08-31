using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveObject : MonoBehaviour
{

    public float _speed;
    public Vector2 _direction;
    public Rigidbody2D _rigidbody2d;
    // Use this for initialization
    protected virtual void Start()
    {
        _rigidbody2d.velocity = _direction.normalized * _speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (CGameManager.IsGameStop)
            _rigidbody2d.velocity = Vector2.zero;
    }
}
