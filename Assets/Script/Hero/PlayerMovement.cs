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

    [Header("Panels")] 
    [SerializeField] private GameObject _PanelLose;
    
    private Animator _animator;
    private Health _health;
    
    private Rigidbody2D _samuraiRb;
    private bool isMove;
    private bool isJumped;
    private bool isGrounded = false;
    private Vector3 input;

    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _health = GetComponent<Health>();
        _samuraiRb = GetComponent<Rigidbody2D>();
        _currentSpeed = _Speed;
    }

    private void Update()
    {
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
    
    private void Block()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("isBlock",true);
            Debug.Log("block");
        }
        else
        {
            _animator.SetBool("isBlock",false);
        }
    }
    
    private void OnEnable()
    { 
        if (_health != null) 
        { 
            Health.OnDamage += Dead;
        } 
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            Health.OnDamage -= Dead;
        }
    }
    
    private void Dead()
    {
        if (_health._currentHealth <=0 )
        {
            _animator.SetTrigger("Dead");
            Invoke("LosePanele", 2f);
        }
        else
        {
            _PanelLose.SetActive(false);
        }
    }
    
    private void LosePanele()
    {
        _PanelLose.SetActive(true);
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
            _animator.SetBool("isJump", false);
            _animator.SetBool("isFall", false);
        }
    }
    
    private void HorizontalMovement(float direction)
    { 
        _samuraiRb.velocity = new Vector2(_currentSpeed*direction, _samuraiRb.velocity.y);
    }
    
    private void Jump()
    {
        if (isJumped && isGrounded)
        { 
            _samuraiRb.AddForce(Vector2.up * _JumpForce, ForceMode2D.Impulse);
            _animator.SetBool("isJump", true);
            _animator.SetBool("isRun", false);
            
            isJumped = false;
            Debug.Log("jump");
        }
        else if (!isGrounded && _samuraiRb.velocity.y<0)
        {
            _animator.SetBool("isFall", true);
            _animator.SetBool("isJump", false);
            
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
            _animator.SetFloat("Walk",_samuraiRb.velocity.magnitude);
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
            _animator.SetBool("isRun", true);
        }
        else if(Input.GetKeyUp(KeyCode.RightShift))
        {
            _currentSpeed = _Speed;
            _animator.SetBool("isRun", false);
        }
    }
    
    private void Sitdown()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            _animator.SetBool("isSitdown", true);
            Debug.Log("sitdown");
        }
        else
        {
            _animator.SetBool("isSitdown", false);
        }
    }
    
}
