using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private float _force;
    [SerializeField] private SliderJoint2D _sliderJointPlatform;
    [SerializeField] private GameObject _pointEffector, _pressE;
    [SerializeField] private Rigidbody2D _rbPlatform;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            _pressE.SetActive(true);
            PressButton();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        { 
            _pressE.SetActive(false); 
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
        _rbPlatform.isKinematic= false;
        _sliderJointPlatform.useMotor = true;
        JointMotor2D platform = _sliderJointPlatform.motor;
        platform.motorSpeed = _force;
    }

    private void PointEff()
    {
        _pointEffector.SetActive(true);
    }
    
    
    
    
    
    
}
