using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [Header("Movement vars")] 
    [SerializeField] private float _JumpForce;
    [SerializeField] private float _Speed;
    [SerializeField] private float _RunSpeed;
    private float _speedWalk=0.7f;
    
    [Header("Settings")]
    [SerializeField] private Transform _GroundColliderTransform;
    [SerializeField] private LayerMask _GroundMask;
    [SerializeField] private AnimationCurve _CurveWalk;
    [SerializeField] private AnimationCurve _CurveRun;
    [SerializeField] private float _JumpOffset;
    
    [SerializeField] private Animator _HeroAnimation;

    
    private Rigidbody2D _samuraiRb;
    private bool isMove;
    private bool isJumped;
    private bool isGrounded = false;
    private Vector3 input;

    private void Awake()
    {
        _samuraiRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Attack();
        Block();
        //Fall();
        KeyJump();
        Move(direction:0f);
        //JumpAnim();
        
        Sitdown();
        //Run();
    }

    private void FixedUpdate()
    {
        CheckGround();
        Jump();
    }

    private void CheckGround()
    {
        Vector3 overLapCirclePosition = _GroundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overLapCirclePosition, _JumpOffset, _GroundMask);  
    }
    
    public void Move(float direction)
    {
        // if (isJumpButton)
        // {
        //     Jump();
        //     _HeroAnimation.SetBool("isJump", true);
        // }
        // else
        // {
        //     _HeroAnimation.SetBool("isJump", false);
        //     //_HeroAnimation.SetBool("isIdle", true);
        // }
        
        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
            _HeroAnimation.SetFloat("Run",_samuraiRb.velocity.magnitude);
        }
        
        if(!isMove && direction < 0 || isMove && direction >0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isMove = !isMove;
        transform.Rotate(0f, 180f, 0f);
    }

    private void KeyJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumped = true;
        }
        else
        {
            Invoke("JJ",5f);
        }
    }

    private void JJ()
    {
        isJumped = false;
    }
    private void Jump()
    {
        if (isJumped)
        {
            _samuraiRb.AddForce(Vector2.up * _JumpForce, ForceMode2D.Impulse);
            _HeroAnimation.SetBool("isJump", true);
            Debug.Log("jump");
        }
        else
        {
            _HeroAnimation.SetBool("isJump", false);
        }
    }
    
    private void HorizontalMovement(float direction)
    { 
        _samuraiRb.velocity = new Vector2(_CurveWalk.Evaluate(direction), _samuraiRb.velocity.y);
    }

    private void Sitdown()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            _HeroAnimation.SetBool("isSitdown", true);
            Debug.Log("sitdown");
        }
        else
        {
            _HeroAnimation.SetBool("isSitdown", false);
        }
    }
    
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _HeroAnimation.SetBool("isAttack",true);
            Debug.Log("Attack");
        }
        else
        {
            _HeroAnimation.SetBool("isAttack",false);
        }
        
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _HeroAnimation.SetBool("isBlock",true);
            Debug.Log("block");
        }
        else
        {
            _HeroAnimation.SetBool("isBlock",false);
        }
    }
    
    private void Fall() 
    { 
        if (_samuraiRb.velocity.y < 0)
        { 
            _HeroAnimation.SetBool("isJump" ,false);
            _HeroAnimation.SetBool("isFall",true);
            Debug.Log("fall");
        } 
    }
    
    // private void Run()
    // {
    //     if (isMove && Input.GetKey(KeyCode.RightShift) || !isMove && Input.GetKey(KeyCode.RightShift))
    //     {
    //         _Speed = _RunSpeed;
    //         //_samuraiRb.velocity = new Vector2(_CurveRun.Evaluate(input.x*_RunSpeed),_samuraiRb.velocity.y);
    //         //_HeroAnimation.SetFloat("Run", _samuraiRb.velocity.magnitude);
    //         Debug.Log("run");
    //     }
    //     else if(isMove && Input.GetKeyUp(KeyCode.RightShift) || !isMove && Input.GetKeyUp(KeyCode.RightShift))
    //     {
    //         _Speed = _speedWalk;
    //         _HeroAnimation.SetBool("isRun", false);
    //         _HeroAnimation.SetBool("isWalk", true);
    //     } 
    // }
}
