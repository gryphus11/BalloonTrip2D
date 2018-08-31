using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSkyCollision : MonoBehaviour {

    public CInputMove playerInputMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CGameManager.isGameStop = true;
            playerInputMove.GameOver();
        }

        Destroy(collision.gameObject);
    }
}
