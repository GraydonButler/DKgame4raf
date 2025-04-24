using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _cldr;
    private CapsuleCollider2D _banana;
    private CapsuleCollider2D _player;
    private Animator _animator;
    public PlayerControl playercntrl;

    public playersoudscript PlayerSoundSystem;

    private float _groundcheckdistance = 0.1f;
    private bool _isGrounded = false;
    private int _doubleJump = 0;
    private int _jumpamount = 3;
    public int bananacount = 0;
    public bool m_TagStringbanana = false;
    private bool _canPlayLandSoud = false;



    private SpriteRenderer _sp;
    public float speed = 1.0f;
    public float jumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cldr = GetComponent<Collider2D>();
        _sp = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _doubleJump = _jumpamount;
        
       // _player = GetComponent<CapsuleCollider2D>();
       // _banana = GetComponent<CapsuleCollider2D>();
        
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

       
       if (collision.gameObject.tag=="banana")
        {
            Debug.Log("it works");
            Destroy(collision.gameObject);
            bananacount = bananacount = 1;
           
        }

      
    }
    private void CheckGrounded()
    {
        Bounds bounds = _cldr.bounds;
        Vector2 leftRayorigin = new Vector2(bounds.min.x, bounds.min.y);
        Vector2 rightRayorigin = new Vector2(bounds.max.x, bounds.min.y);

        RaycastHit2D hitleft = Physics2D.Raycast(leftRayorigin, Vector2.down, _groundcheckdistance, LayerMask.GetMask("Ground"));
        RaycastHit2D hitright = Physics2D.Raycast(rightRayorigin, Vector2.down, _groundcheckdistance, LayerMask.GetMask("Ground"));

        _isGrounded = hitleft.collider != null || hitright.collider != null;


        _animator.SetBool("_isJumping", !_isGrounded);


      if (_isGrounded && _canPlayLandSoud)
        {
            PlayerSoundSystem.PlayerRandomLandSound();
            _canPlayLandSoud = false;
        }

        if (!_isGrounded)
        {
            _canPlayLandSoud = true;
        }



    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

         /*

        
          if (moveHorizontal <=0)
        {
            _sp.flipX = true;
        }
        else
        {
            _sp.flipX = false;
        }*/

        _rb.velocity = new Vector2(moveHorizontal * speed, _rb.velocity.y);



        if (moveHorizontal != 0)
        {
            Flipsprite(moveHorizontal);
            _animator.SetBool("_isWalking", true);

        }
        else
        {
            _animator.SetBool("_isWalking", false);
        }
        

        
        if ((Input.GetButtonDown("Jump")) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            PlayerSoundSystem.PlayerJumpSound();

            
            //_doubleJump = _jumpamount-1;


        }
        else 
        {
            if ((Input.GetButtonDown("Jump")) && bananacount >=1) 
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                 bananacount = bananacount-1;
                //_doubleJump = _doubleJump - 1;
                PlayerSoundSystem.PlayerJumpSound();
            }
        }
        
    }

    void Flipsprite(float horizontalInput)
    {
        Vector3 scale = transform.localScale;
        scale.x = (horizontalInput > 0) ? 1 : -1;
        transform.localScale = scale;

    }
    
}