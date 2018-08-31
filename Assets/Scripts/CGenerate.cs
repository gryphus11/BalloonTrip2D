using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGenerate : MonoBehaviour
{
    public float startDelayTime = 0.0f;
    public float generateDelayTime = 0.0f;
    public Transform generatePosition = null;
    public float topGenerateRange = 0.0f;
    public float bottomGenerateRange = 0.0f;
    public GameObject generateObject = null;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObject", startDelayTime, generateDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.isGameStop)
            CancelInvoke();
    }

    private void CreateObject()
    {
        Vector2 genPos = new Vector2(generatePosition.position.x,
            generatePosition.position.y + (Random.Range(bottomGenerateRange, topGenerateRange)));
        Instantiate(generateObject, genPos, Quaternion.identity);
    }
}
