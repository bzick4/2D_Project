using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer_2lvl : MonoBehaviour
{
    [SerializeField] private float _Speed;

    private bool isMoving = true;

    private void Update()
    {
        if (transform.position.y > 2.2f)
        {
            isMoving = false;
        }
        else if (transform.position.y <-1.3f)
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
