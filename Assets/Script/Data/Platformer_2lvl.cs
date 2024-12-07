using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer_2lvl : MonoBehaviour
{
    [SerializeField] private float _Speed;
    [Header("Range")] 
    [SerializeField] private float _MaxY;
    [SerializeField] private float _MinY;
    private bool isMoving = true;

    private void Update()
    {
        if (transform.position.y > _MaxY)
        {
            isMoving = false;
        }
        else if (transform.position.y <-_MinY)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+ _Speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+ -_Speed * Time.deltaTime); 
        }
    }
}
