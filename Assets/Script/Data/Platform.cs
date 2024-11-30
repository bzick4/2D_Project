using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private float _Force;
    [SerializeField] private SliderJoint2D _SliderJointPlatform;
    [SerializeField] private GameObject _PointEffector, _PressE;
    [SerializeField] private Rigidbody2D _RbPlatform;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            _PressE.SetActive(true);
            PressButton();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        { 
            _PressE.SetActive(false); 
        }
    }

    private void PressButton()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PlatformUp();
            Invoke("PointEff", 3f);
        }
    }
    
    private void PlatformUp()
    {
        _RbPlatform.isKinematic= false;
        _SliderJointPlatform.useMotor = true;
        JointMotor2D platform = _SliderJointPlatform.motor;
        platform.motorSpeed = _Force;
    }

    private void PointEff()
    {
        _PointEffector.SetActive(true);
    }
    
    
    
    
    
    
}
