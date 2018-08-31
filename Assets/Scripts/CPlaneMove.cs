using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneMove : CMoveObject
{
    public float speedMinRange = 0.0f;
    public float speedMaxRange = 0.0f;
    public float gravityMinRange = 0.0f;
    public float gravityMaxRange = 0.0f;
    public float randomGravityStartTime = 0.0f;
    public float randomGravityDelayTime = 0.0f;
    public GameObject _burstEffect = null;

    private Transform _playerPosition = null;

    // Use this for initialization
    protected override void Start()
    {
        _playerPosition = GameObject.Find("BalloonMan").GetComponent<Transform>();
        speed = Random.Range(speedMinRange, speedMaxRange);
        direction = _playerPosition.position - transform.position;
        _rigidbody2d.velocity = direction.normalized * speed;
        InvokeRepeating("RandomGravity", randomGravityStartTime, randomGravityDelayTime);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (CGameManager.isGameStop)
        {
            CancelInvoke();
            Invoke("PlaneStop", 3.0f);
        }
    }

    void RandomGravity()
    {
        _rigidbody2d.gravityScale = Random.Range(gravityMinRange, gravityMaxRange);
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
