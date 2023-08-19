using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public int Broke;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y > -6)
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        else
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (Broke == 0)
            Debug.Log("정상");
        else
            Debug.Log("비정상");

        GetComponent<BoxCollider2D>().enabled = false;
    }
}
