using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputMove : MonoBehaviour
{
    public float _riseForce;
    public float _moveSpeed;
    public Rigidbody2D _rigidbody2d;

    private int _lifeCount;
    public GameObject _twoBalloons;
    public GameObject _oneBalloon;

    public CGameManager _gameManager;

    public GameObject _getBalloonEffect;
    public GameObject _explosionEffect;
    // Use this for initialization
    void Start()
    {
        _lifeCount = 2;
        _twoBalloons.SetActive(true);
        _oneBalloon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CGameManager.IsGameStop)
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
            _rigidbody2d.AddForce(Vector2.up * _riseForce);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            _rigidbody2d.AddForce(Vector2.left * _moveSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = Vector3.one;
            _rigidbody2d.AddForce(Vector2.right * _moveSpeed);
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
        _gameManager.EndGame();
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
            CEffectManager.OneTimeEffectOn(_explosionEffect, transform.position, transform.rotation, 1.5f);
        }
    }

    public void Hit(Collision2D collision)
    {
        --_lifeCount;

        collision.collider.isTrigger = true;

        if (_lifeCount > 0)
        {
            _twoBalloons.SetActive(false);
            _oneBalloon.SetActive(true);
        }
        else
        {
            _oneBalloon.SetActive(false);
            CGameManager.IsGameStop = true;
            Invoke("GameOver", 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "GreenBalloon")
        {
            Destroy(collision.gameObject);
            CEffectManager.OneTimeEffectOn(_getBalloonEffect, transform.position, Quaternion.identity, 1.2f);
            _gameManager.ScoreUp();
        }
                
    }

    
}
