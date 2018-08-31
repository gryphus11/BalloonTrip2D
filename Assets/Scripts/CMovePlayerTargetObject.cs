using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovePlayerTargetObject : CMoveObject {
    private Transform _playerTr;
	// Use this for initialization
	protected override void Start () {
        _playerTr = GameObject.Find("BalloonMan").transform;
        _direction = _playerTr.position - transform.position;
        base.Start();

        InvokeRepeating("AddGravity", 1.0f, 1.0f);
	}

    protected override void Update()
    {
        
    }

    void AddGravity()
    {
        _rigidbody2d.gravityScale += 0.5f;
    }
    // Update is called once per frame
}
