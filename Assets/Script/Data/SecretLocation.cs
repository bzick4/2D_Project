
using System;
using UnityEngine;

public class SecretLocation : MonoBehaviour
{
    [SerializeField] private GameObject _Secret, _PressE;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _PressE.SetActive(true);
        }
        
        PressE();
    }
    
    private void PressE()
    {
       if( Input.GetKey(KeyCode.E))
       {
            _Secret.SetActive(false);
            _PressE.SetActive(false);
            Destroy(gameObject, 4f);
       }
    }


}
