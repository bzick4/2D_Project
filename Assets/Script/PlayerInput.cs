using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
//[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    [SerializeField] private Shooter _shooter;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        //_shooter = GetComponent<Shooter>();
    }


    private void Update()
    {
        float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
        bool isJumpButton = Input.GetButtonDown(GlobalStringVars.JUMP);
        
        // if(Input.GetButtonDown(GlobalStringVars.FIRE_1))
        // { _shooter.Shoot(horizontal);}
        
        _playerMovement.Move(horizontal);
    }
}
