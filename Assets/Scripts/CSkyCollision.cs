using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSkyCollision : MonoBehaviour {

    public CInputMove _player;
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
            CGameManager.IsGameStop = true;
            _player.GameOver();
        }

        Destroy(collision.gameObject);
    }
}
