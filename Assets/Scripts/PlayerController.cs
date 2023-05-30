using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpForceTrampoline;
    [SerializeField] public float _jumpForceSpring;
    private float _jumpForceRestart = 5;

    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _spawnedPlatforms;
    [SerializeField] private bool  isfacingRight = true;

    private const string Platform = "Platform";
    private const string Trampoline = "Trampoline";
    private const string RestartPlatform = "RestartPlatform";
    private const string Enemy = "Enemy";


    public Transform _player;
    public Rigidbody2D _rb;
    public BoxCollider2D _boxCollider2D;
    public Action OnMovement;

    public static PlayerController inst;


    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

    }

    void FixedUpdate()
    {  
            OnMovement?.Invoke();       
    }


    public void AndroidInputs()
    {
        float tilt = Input.acceleration.x;

        _rb.velocity = new Vector2(tilt * _playerSpeed, _rb.velocity.y);

        if (tilt > 0.1 && !isfacingRight)
        {
            flip();
        }

        if (tilt < 0.1 && isfacingRight)
        {
            flip();
        }
    }

    public void Windowsinputs()
    {
        Debug.Log("MOVING");
        var horizontalInput = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontalInput * _playerSpeed, _rb.velocity.y);

        if (horizontalInput > 0 && !isfacingRight)
        {
            flip();
        }

        if (horizontalInput < 0 && isfacingRight)
        {
            flip();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            transform.position = new Vector3(2.7f, transform.position.y, transform.position.z);
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            transform.position = new Vector3(-2.7f, transform.position.y, transform.position.z);
        }


        if (collision.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.Play("Coin");
            ScoreManager.instance.coin++;
            ScoreManager.instance.UpdateCoinText();
            Destroy(collision.gameObject);
            ScoreManager.instance.Candies = ScoreManager.instance.coin * 2;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Platform) && _rb.velocity.y <= 0)
        {
            AudioManager.instance.Play("DoodleJump");
            Vector2 velocity = _rb.velocity;
            velocity.y = _jumpForce;
            _rb.velocity = velocity;
        }

        //if(collision.gameObject.GetComponent<PlatformBreakable>().gameTags == GameTags.RestartPlatform)
        if(collision.gameObject.CompareTag(Trampoline) && _rb.velocity.y <= 0)
        {
            AudioManager.instance.Play("Trampoline");
            Vector2 velocity = _rb.velocity;
            velocity.y = _jumpForceTrampoline;
            _rb.velocity = velocity;
        }

        if(collision.gameObject.CompareTag(RestartPlatform) && _rb.velocity.y <= 0)
        {
            AudioManager.instance.Play("DoodleJump");
            Vector2 velocity = _rb.velocity;
            velocity.y = _jumpForceRestart;
            _rb.velocity = velocity;
        }

        if(collision.gameObject.CompareTag(Enemy))
        {
            _boxCollider2D.enabled = false;
        }
    }




    public void flip()
    {
        Vector2 currentscale = gameObject.transform.localScale;
        currentscale.x = currentscale.x * -1;
        gameObject.transform.localScale = currentscale;
        isfacingRight = !isfacingRight;

    }


    public void RestartGame()
    {
        ScoreManager.instance.score = 0;
        _player.transform.position = new Vector3(-1.75800002f, -2.19109917f, 0);
        _camera.transform.position = new Vector3(0, 0, -10);
        _boxCollider2D.enabled = true;
        gameObject.SetActive(true);
        ScreenManager.inst.ShowNextScreen(ScreenType.GameScreen);
        PlatformSpawner.inst.LastSpawn = PlatformSpawner.inst.playerTransform.position.y - PlatformSpawner.inst.spawnDistance;

        foreach (Transform child in _spawnedPlatforms.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void PauseGame()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        ScreenManager.inst.ShowNextScreen(ScreenType.PauseScreen);
    }

    public void ResumeGame()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        ScreenManager.inst.ShowNextScreen(ScreenType.GameScreen);
    }

    public void MainMenu()
    {
        ScoreManager.instance.score = 0;
        _player.transform.position = new Vector3(-1.75800002f, -2.19109917f, 0);
        _camera.transform.position = new Vector3(0, 0, -10);
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _boxCollider2D.enabled = true;
        _platform.SetActive(true);
        _spawnedPlatforms.SetActive(false);
        gameObject.SetActive(true);
        ScreenManager.inst.ShowNextScreen(ScreenType.HomeScreen);
        PlatformSpawner.inst.LastSpawn = PlatformSpawner.inst.playerTransform.position.y - PlatformSpawner.inst.spawnDistance;

        foreach (Transform child in _spawnedPlatforms.transform)
        {
            Destroy(child.gameObject);
        }
    }



}

public enum GameTags
{
    Platform,
    Trampoline,
    RestartPlatform,
    Enemy,

}