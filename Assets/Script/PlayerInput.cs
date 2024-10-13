using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
        bool isJumpButton = Input.GetButtonDown(GlobalStringVars.JUMP);
        
        
        _playerMovement.Move(horizontal);
    }
}
