using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    private Animator _animation;
    public bool isRun {private get; set; }
    public bool isJump { private get; set; }
    public bool isFall { private get; set; }

    public float speed { private get; set; }

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void UpdateAnimation()
    {
    }

    public void FixedUpdate()
    {
        _animation.SetBool("isRun", isRun);
        _animation.SetBool("isJump", isJump);
        _animation.SetBool("isFall", isFall);
        _animation.SetFloat("Speed", 0);
    }
}
