using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovePlayerTargetObject : CMoveObject, ITargetable
{

    private Transform _playerTr = null;

    // Use this for initialization
    protected override void Start ()
    {
        if (_playerTr == null)
        {
            Debug.Log("Scene 에서 타겟을 탐색 (Object)");
            GameObject playerObject = GameObject.Find("BalloonMan");
            _playerTr = playerObject == null ? null : playerObject.transform;
        }

        if (_playerTr == null)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = _playerTr.position - transform.position;
        }

        base.Start();

        InvokeRepeating("AddGravity", 1.0f, 1.0f);
	}

    protected override void Update()
    {
        
    }

    public void InitTarget(Transform playerTransform)
    {
        _playerTr = playerTransform;
    }

    private void AddGravity()
    {
        _rigidbody2d.gravityScale += 0.5f;
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
