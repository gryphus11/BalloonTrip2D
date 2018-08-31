using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGenerate : MonoBehaviour
{

    public float _startDelayTime;

    public float _generateDelayTime;

    public Transform _generatePosition;

    public float _topGenerateRange;

    public float _bottomGenerateRange;

    public GameObject _generateObject;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObject", _startDelayTime, _generateDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.IsGameStop)
            CancelInvoke();
    }

    private void CreateObject()
    {
        Vector2 genPos = new Vector2(_generatePosition.position.x,
            _generatePosition.position.y + (Random.Range(_bottomGenerateRange, _topGenerateRange)));
        Instantiate(_generateObject, genPos, Quaternion.identity);
    }
}
