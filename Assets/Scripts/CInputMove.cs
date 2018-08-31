using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CInputMove : MonoBehaviour
{
    public float riseForce = 0.0f;
    public float moveSpeed = 0.0f;
    public GameObject twoBalloons = null;
    public GameObject oneBalloon = null;
    public CGameManager gameManager = null;
    public GameObject getBalloonEffect = null;
    public GameObject explosionEffect = null;

    private Rigidbody2D _rigidbody2d = null;
    private int _lifeCount = 0;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        _lifeCount = 2;
        twoBalloons.SetActive(true);
        oneBalloon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CGameManager.isGameStop)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 newVelocity = new Vector2(_rigidbody2d.velocity.x, 0.0f);
            _rigidbody2d.velocity = newVelocity;
            _rigidbody2d.AddForce(Vector2.up * riseForce);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            _rigidbody2d.AddForce(Vector2.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = Vector3.one;
            _rigidbody2d.AddForce(Vector2.right * moveSpeed);
        }

        //경계에 도달시 튕겨나가기
        if (transform.position.x < -8.3f)
            _rigidbody2d.velocity = Vector2.right;
        if (transform.position.x > 8.3f)
            _rigidbody2d.velocity = Vector2.left;
        if (transform.position.y > 4.2f)
            _rigidbody2d.velocity = Vector2.down;
    }

    public void GameOver()
    {
        gameManager.EndGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Planes")
        {
            Hit(collision);
        }

        if (collision.transform.tag == "Missile")
        {
            Destroy(collision.gameObject);
            Hit(collision);
            CEffectManager.OneTimeEffectOn(explosionEffect, transform.position, transform.rotation, 1.5f);
        }
    }

    public void Hit(Collision2D collision)
    {
        --_lifeCount;

        collision.collider.isTrigger = true;

        if (_lifeCount > 0)
        {
            twoBalloons.SetActive(false);
            oneBalloon.SetActive(true);
        }
        else
        {
            oneBalloon.SetActive(false);
            CGameManager.isGameStop = true;
            Invoke("GameOver", 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "GreenBalloon")
        {
            Destroy(collision.gameObject);
            CEffectManager.OneTimeEffectOn(getBalloonEffect, transform.position, Quaternion.identity, 1.2f);
            gameManager.ScoreUp();
        }
                
    }

    
}
