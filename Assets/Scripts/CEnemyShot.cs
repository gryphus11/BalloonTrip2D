using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyShot : CShot {
    
	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateShot", shotStartTime, shotDelayTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void CreateShot()
    {
        for (int i = 0; i < genPositions.Length; ++i)
        {
            GameObject bullet = Instantiate(shotPrefab, genPositions[i].position, genPositions[i].rotation);
            ITargetable targetable = bullet.GetComponent<ITargetable>();
            if (targetable != null)
            {
                targetable.InitTarget(CGameManager.playerTransform);
            }
        }
    }
}
