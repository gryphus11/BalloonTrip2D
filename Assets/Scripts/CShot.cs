using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShot : MonoBehaviour {

    public Transform[] genPositions = null;
    public GameObject shotPrefab = null;
    public float shotStartTime = 0.0f;
    public float shotDelayTime = 0.0f;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void CreateShot()
    {
        for (int i = 0; i < genPositions.Length; ++i)
        {
            Instantiate(shotPrefab, genPositions[i].position, genPositions[i].rotation);
        }
    }
}
