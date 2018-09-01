using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSkyCollision : MonoBehaviour {

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
            CInputMove playerInputMove = collision.transform.GetComponent<CInputMove>();
            if (playerInputMove != null)
            {
                playerInputMove.GameOver();
            }
            else
            {
                Debug.Log("플레이어 입력 스크립트를 찾을수 없음.");
            }
        }

        Destroy(collision.gameObject);
    }
}
