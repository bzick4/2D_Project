
using System;
using UnityEngine;

public class SecretLocation : MonoBehaviour
{
    [SerializeField] private GameObject _Secret, _ButtonPressE;
    private bool isActivate=true;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            if (isActivate)
            {
                _ButtonPressE.SetActive(true);
            }

            PressE();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _ButtonPressE.SetActive(false);
            isActivate = true;
        }
    }
    
    private void PressE()
    {
       if( Input.GetKeyDown(KeyCode.E))
       {
           _Secret.SetActive(false);
            Destroy(gameObject, 1.4f);
            isActivate = false;
       }
    }


}
