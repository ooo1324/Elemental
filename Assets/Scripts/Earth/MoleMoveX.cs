using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMoveX : MonoBehaviour
{
    public float moveSpeed;

    public BoxCollider2D triggerCollider;

    private bool isRotate;

    private float widthSize;
    private float heightSize;
    private SpriteRenderer renderer;
    private Vector3 lookXVec;
    private Vector3 rotateVec;

    private void Awake()
    {
        triggerCollider = GameObject.Find("GridTrigger").GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        widthSize = Random.Range(-triggerCollider.size.x / 2, triggerCollider.size.x / 2);
        heightSize = Random.Range(-triggerCollider.size.y / 2, triggerCollider.size.y / 2);

        lookXVec = transform.localPosition.x > 0 ? Vector3.left : Vector3.right;

        if (transform.localPosition.x > 0)
        {
            lookXVec = Vector3.left;
            renderer.flipX = true;
        }          
        else
        {
            lookXVec = Vector3.right;
        }

        rotateVec = transform.localPosition.y > 0 ? Vector3.down : Vector3.up;
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
                    lookXVec = rotateVec;
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
                    lookXVec = rotateVec;
                    isRotate = true;
                }
            }
        }

    }
}
