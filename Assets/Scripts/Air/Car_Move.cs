using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    public int Speed;
    public int Broke;

    void Update()
    {
        if (transform.position.y > -6.6f)
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        else
        {
            transform.position = new Vector2(transform.position.x, 6.6f);
            this.gameObject.SetActive(false);
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if (Broke == 0)
            Debug.Log("����");
        else
            Debug.Log("����");

        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
