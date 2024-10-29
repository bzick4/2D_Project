using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private float X, Y;
    private Transform _player;

    private void Start()
    {
        _player = GetComponent<Transform>();
    }

    private void Update()
    {
        X = _player.transform.position.x;
        Y = _player.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("X", X);
        PlayerPrefs.SetFloat("Y",Y);
        PlayerPrefs.Save();
        Debug.Log("Uspeshno");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("X"))
        {
            X = PlayerPrefs.GetFloat("X");
        }
        if (PlayerPrefs.HasKey("Y"))
        {
            Y = PlayerPrefs.GetFloat("Y");
        }

        _player.transform.position = new Vector2(X, Y);
    }
    
}

