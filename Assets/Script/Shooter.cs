
using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private float _FireSpeed;
    [SerializeField] private Transform _FirePoint;
    
    public void Shoot(float direction)
    { 
        GameObject currentBullet = Instantiate(_Bullet, _FirePoint.position, Quaternion.identity); 
        Rigidbody2D currentBulletVelocity =  currentBullet.GetComponent<Rigidbody2D>();
        
        if (direction >= 0) 
        { 
            currentBulletVelocity.velocity = new Vector2(_FireSpeed *1, currentBulletVelocity.velocity.y); 
        }
        else 
        { 
            currentBulletVelocity.velocity = new Vector2(_FireSpeed *-1, currentBulletVelocity.velocity.y); 
        }
    }
}
