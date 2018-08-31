using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CMoveObject : MonoBehaviour
{
    public float speed = 0.0f;
    public Vector2 direction = Vector2.zero;

    protected Rigidbody2D _rigidbody2d = null;

    protected virtual void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    protected virtual void Start()
    {
        _rigidbody2d.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (CGameManager.isGameStop)
            _rigidbody2d.velocity = Vector2.zero;
    }
}
