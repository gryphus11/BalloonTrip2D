using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneGnerate : MonoBehaviour
{
    public Transform playerTransform = null;
    public Transform generatePosition = null;
    public float topGenerateRange = 0.0f;
    public float bottomgenerateRange = 0.0f;
    public GameObject[] planePrefabs = null;
    public float createStartTime = 0.0f;
    public float createDelayTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        if (playerTransform == null)
        {
            Debug.Log("플레이어를 찾을 수 없음.");
            GameObject playerObject = GameObject.Find("BalloonMan");
            playerTransform = playerObject == null ? null : playerObject.transform;
        }

        InvokeRepeating("CreatePlane", createStartTime, createDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (CGameManager.isGameStop)
            CancelInvoke();
    }

    private void CreatePlane()
    {
        Vector3 randomPosition = new Vector3(0.0f, Random.Range(bottomgenerateRange, topGenerateRange));
        int prefabsIndex = Random.Range(0, planePrefabs.Length);
        GameObject newPlane = Instantiate(planePrefabs[prefabsIndex], generatePosition.position + randomPosition, Quaternion.identity);
        ITargetable targetable = newPlane.GetComponent<ITargetable>();
        if (targetable != null)
        {
            targetable.InitTarget(playerTransform);
        }

    }
}
