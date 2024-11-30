using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField] private Transform[] _Layers;
    [SerializeField] private float[] _Coeff;

    private int LayersCount;
    private void Start()
    {
        LayersCount = _Layers.Length;
    }


    private void Update()
    {
        for (int i = 0; i < LayersCount; i++)
        {
            _Layers[i].position = transform.position * _Coeff[i];
        }
    }
}
