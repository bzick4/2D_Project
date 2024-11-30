using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_HeroHealthBar : MonoBehaviour
{
    [SerializeField] private Transform _Hero;
    [SerializeField] private Vector3 _Offset = new Vector3(0, 1, 0); 

    void Update()
    {
        if (_Hero!= null)
        {
            transform.position = _Hero.position + _Offset;
        }
    }
}
