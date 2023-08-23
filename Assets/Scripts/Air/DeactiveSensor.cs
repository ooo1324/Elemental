using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            collision.gameObject.SetActive(false);  
        }
    }
}
