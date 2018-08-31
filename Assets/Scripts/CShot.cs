using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShot : MonoBehaviour {
    public Transform[] _genPositions;
    public GameObject _shotPrefab;
    public float _shotStartTime;
    public float _shotDelayTime;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void CreateShot()
    {
        for (int i = 0; i < _genPositions.Length; ++i)
        {
            Instantiate(_shotPrefab, _genPositions[i].position, _genPositions[i].rotation);
        }
    }
}
