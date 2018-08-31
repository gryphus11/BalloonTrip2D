using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneGnerate : MonoBehaviour
{

    public Transform _generatePosition;
    public float _topGenerateRange;
    public float _bottomgenerateRange;

    public GameObject[] _planePrefabs;
    public float _createStartTime;
    public float _createDelayTime;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreatePlane", _createStartTime, _createDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.IsGameStop)
            CancelInvoke();
    }

    private void CreatePlane()
    {
        Vector3 randomPosition = new Vector3(0.0f, Random.Range(_bottomgenerateRange, _topGenerateRange));
        int prefabsIndex = Random.Range(0, _planePrefabs.Length);
        Instantiate(_planePrefabs[prefabsIndex], _generatePosition.position + randomPosition, Quaternion.identity);
    }
}
