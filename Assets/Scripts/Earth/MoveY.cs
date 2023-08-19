using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveY : MonoBehaviour
{
    public float moveSpeed;

    public BoxCollider2D triggerCollider;

    public float rotateAngle;

    private bool isRotate;

    private float widthSize;
    private float heightSize;

    private SpriteRenderer renderer;
    private Vector3 lookYVec;

    // Start is called before the first frame update
    void Awake()
    {
        triggerCollider = GameObject.Find("GridTrigger").GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
   
    }

    private void Start()
    {
        widthSize = Random.Range(-triggerCollider.size.x / 2, triggerCollider.size.x / 2);
        heightSize = Random.Range(-triggerCollider.size.y / 2, triggerCollider.size.y / 2);


        if (transform.localPosition.y > 0)
        {
            lookYVec = Vector3.right;
        }
        else
        {
            lookYVec = Vector3.left;
            renderer.flipX = true;
        }

        if (transform.localPosition.x > 0)
        {
            rotateAngle *= -1;

            renderer.flipY = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(lookYVec * moveSpeed * Time.deltaTime);

        if (lookYVec == Vector3.left)
        {
            if (transform.localPosition.y >= 0 + heightSize)
            {
                if (!isRotate)
                {
                    transform.Rotate(0, 0, transform.localRotation.z + -rotateAngle);
                    isRotate = true;
                }
            }
        }
        else if (lookYVec == Vector3.right)
        {
            if (transform.localPosition.y <= 0 + heightSize)
            {
                if (!isRotate)
                {
                    transform.Rotate(0, 0, transform.localRotation.z + rotateAngle);
                    isRotate = true;
                }
            }
        }
    }
}
