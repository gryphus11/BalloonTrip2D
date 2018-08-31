using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneMove : CMoveObject
{
    public float _speedMinRange;
    public float _speedMaxRange;
    private Transform _playerPosition;
    public float _gravityMinRange;
    public float _gravityMaxRange;
    public float _randomGravityStartTime;
    public float _randomGravityDelayTime;
    public GameObject _burstEffect;
    // Use this for initialization
    protected override void Start()
    {
        _playerPosition = GameObject.Find("BalloonMan").GetComponent<Transform>();
        _speed = Random.Range(_speedMinRange, _speedMaxRange);
        _direction = _playerPosition.position - transform.position;
        _rigidbody2d.velocity = _direction.normalized * _speed;
        InvokeRepeating("RandomGravity", _randomGravityStartTime, _randomGravityDelayTime);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (CGameManager.IsGameStop)
        {
            CancelInvoke();
            Invoke("PlaneStop", 3.0f);
        }
    }

    void RandomGravity()
    {
        _rigidbody2d.gravityScale = Random.Range(_gravityMinRange, _gravityMaxRange);
    }

    void PlaneStop()
    {
        _rigidbody2d.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            _rigidbody2d.gravityScale = 5.0f;
            _rigidbody2d.velocity = (Vector3.down * 2.0f * collision.rigidbody.velocity.magnitude);
            CEffectManager.OneTimeEffectOn(_burstEffect, transform.position, Quaternion.identity,1.5f);
            CancelInvoke();
        }
    }
}
