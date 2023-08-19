using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    public float moveSpeed;

    public BoxCollider2D triggerCollider;

    public float rotateAngle;

    private bool isRotate;

    private float widthSize;
    private float heightSize;
    private SpriteRenderer renderer;
    private Vector3 lookXVec;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        widthSize = Random.Range(-triggerCollider.size.x / 2, triggerCollider.size.x / 2);
        heightSize = Random.Range(-triggerCollider.size.y / 2, triggerCollider.size.y / 2);


        if (transform.localPosition.x > 0)
        {
            lookXVec = Vector3.left;
            renderer.flipX = true;
        }
        else
        {
            lookXVec = Vector3.right;        
        }

        if (transform.localPosition.y > 0)
        {
            rotateAngle *= -1;
        }
    }

    private void Update()
    {
        transform.Translate(lookXVec * moveSpeed * Time.deltaTime);

        if (lookXVec == Vector3.right)
        {
            if (transform.localPosition.x >= 0 + widthSize)
            {
                if (!isRotate)
                {
                    transform.Rotate(0, 0, transform.localRotation.z + rotateAngle);
                    isRotate = true;
                }
            }
        }
        else if (lookXVec == Vector3.left)
        {
            if (transform.localPosition.x <= 0 + widthSize)
            {
                if (!isRotate)
                {
                    transform.Rotate(0, 0, transform.localRotation.z + -rotateAngle);
                    isRotate = true;
                }
            }
        }
    
    }


}
