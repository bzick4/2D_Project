using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [Header("Movement vars")] 
    [SerializeField] private float _JumpForce;
    [SerializeField] private float _Speed;
    [SerializeField] private float _RunSpeed=1.7f;
    private float _currentSpeed;
    
    [Header("Settings")]
    [SerializeField] private Transform _GroundColliderTransform;
    [SerializeField] private LayerMask _GroundMask;
    [SerializeField] private float _JumpOffset;
    
    [SerializeField] private Animator _HeroAnimation;
    [SerializeField] private Health _Health;
    [SerializeField] private DamageDealler _DamageDealler;
    [SerializeField] private GameObject _PanelLose;

    
    private Rigidbody2D _samuraiRb;
    private bool isMove;
    private bool isJumped;
    private bool isGrounded = false;
    private Vector3 input;

    private void Awake()
    {
        _samuraiRb = GetComponent<Rigidbody2D>();
        _currentSpeed = _Speed;
    }

    private void Update()
    {
        //Attack();
        Block();
        Dead();
        KeyJump();
        Move(direction:0f);
        Run();
        Sitdown();
    }

    private void FixedUpdate()
    {
        CheckGround();
        Jump();
    }
    
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _HeroAnimation.SetBool("isAttack",true);
            //Debug.Log("Attack");
        }
        else
        {
            _HeroAnimation.SetBool("isAttack",false);
        }
        
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _HeroAnimation.SetBool("isBlock",true);
            Debug.Log("block");
        }
        else
        {
            _HeroAnimation.SetBool("isBlock",false);
        }
    }

    private void Dead()
    {
        if (_Health._currentHealth <=0 )
        {
            _HeroAnimation.SetBool("isDead",true);
            _PanelLose.SetActive(true);
        }
    }
    
    private void Flip()
    {
        isMove = !isMove;
        transform.Rotate(0f, 180f, 0f);
    }
    
    private void CheckGround()
    {
        Vector3 overLapCirclePosition = _GroundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overLapCirclePosition, _JumpOffset, _GroundMask);

        if (isGrounded)
        {
            _HeroAnimation.SetBool("isJump", false);
            _HeroAnimation.SetBool("isFall", false);
        }
    }
    
    private void HorizontalMovement(float direction)
    { 
        _samuraiRb.velocity = new Vector2(_currentSpeed*direction, _samuraiRb.velocity.y);
    }

    private void Hurt(float damage)
    {
        if (_Health._currentHealth==-damage)
        {
            _HeroAnimation.SetBool("isHurt",true);
        }
    }
    
    private void Jump()
    {
        if (isJumped && isGrounded)
        { 
            _samuraiRb.AddForce(Vector2.up * _JumpForce, ForceMode2D.Impulse);
            _HeroAnimation.SetBool("isJump", true);
            _HeroAnimation.SetBool("isRun", false);
            
            isJumped = false;
            Debug.Log("jump");
        }
        else if (!isGrounded && _samuraiRb.velocity.y<0)
        {
            _HeroAnimation.SetBool("isFall", true);
            _HeroAnimation.SetBool("isJump", false);
            
            Debug.Log("fall");
        }
    }
    
    private void KeyJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isJumped = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && !isGrounded)
        {
            isJumped = false;;
        }
    }
    
    public void Move(float direction)
    {
        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
            _HeroAnimation.SetFloat("Walk",_samuraiRb.velocity.magnitude);
        }
        
        if(!isMove && direction < 0 || isMove && direction >0)
        {
            Flip();
        }
    }
    
    private void Run()
    {
        if(Input.GetKeyDown(KeyCode.RightShift) && isGrounded && isMove || Input.GetKeyDown(KeyCode.RightShift) && isGrounded && !isMove)
        {
            _currentSpeed = _RunSpeed;
            _HeroAnimation.SetBool("isRun", true);
        }
        else if(Input.GetKeyUp(KeyCode.RightShift))
        {
            _currentSpeed = _Speed;
            _HeroAnimation.SetBool("isRun", false);
        }
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
    
}
