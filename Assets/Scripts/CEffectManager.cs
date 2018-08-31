using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEffectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void OneTimeEffectOn(GameObject effect, Vector3 position, Quaternion rotate, float destroyTime)
    {
        if (effect != null)
        {
            GameObject effectTemp = Instantiate(effect, position, rotate);
            Destroy(effectTemp, destroyTime);
        }
    }
}
