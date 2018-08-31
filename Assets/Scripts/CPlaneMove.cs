using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneMove : CMoveObject, ITargetable
{
    public float speedMinRange = 0.0f;
    public float speedMaxRange = 0.0f;
    public float gravityMinRange = 0.0f;
    public float gravityMaxRange = 0.0f;
    public float randomGravityStartTime = 0.0f;
    public float randomGravityDelayTime = 0.0f;
    public GameObject _burstEffect = null;

    // 플레이어에 근접하게 다가가는 비행기를 위한 타겟
    private Transform _playerPosition = null;

    public CPlaneMove()
    {

    }

    public CPlaneMove(Transform playerTransform)
    {
        _playerPosition = playerTransform;
    }

    // Use this for initialization
    protected override void Start()
    {
        if (_playerPosition == null)
        {
            Debug.Log("Scene 에서 타겟을 탐색 (Plane)");
            GameObject playerObject = GameObject.Find("BalloonMan");
            _playerPosition = playerObject == null ? null : playerObject.transform;
        }

        speed = Random.Range(speedMinRange, speedMaxRange);

        if (_playerPosition == null)
        {
            direction = Vector2.left;
        }
        else
        {
            //Debug.Log(_playerPosition.name);
            direction = _playerPosition.position - transform.position;
        }

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

    public void InitTarget(Transform playerTransform)
    {
        _playerPosition = playerTransform;
    }

    private void RandomGravity()
    {
        _rigidbody2d.gravityScale = Random.Range(gravityMinRange, gravityMaxRange);
    }

    private void PlaneStop()
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
