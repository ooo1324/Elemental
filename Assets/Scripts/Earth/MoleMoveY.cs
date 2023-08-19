using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMoveY: MonoBehaviour
{
    public float moveSpeed;

    public BoxCollider2D triggerCollider;

    public float rotateAngle;

    private bool isRotate;

    private float heightSize;

    private SpriteRenderer renderer;
    private Vector3 lookYVec;
    private Vector3 rotateVec;

    // Start is called before the first frame update
    void Awake()
    {
        triggerCollider = GameObject.Find("GridTrigger").GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
   
    }

    private void Start()
    {
        heightSize = Random.Range(-triggerCollider.size.y / 2, triggerCollider.size.y / 2);

        lookYVec = transform.localPosition.y > 0 ? Vector3.down : Vector3.up;

        rotateVec = transform.localPosition.x > 0 ? Vector3.left : Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(lookYVec * moveSpeed * Time.deltaTime);

        if (lookYVec == Vector3.up)
        {
            if (transform.localPosition.y >= 0 + heightSize)
            {
                if (!isRotate)
                {
                    lookYVec = rotateVec;
                    if (rotateVec == Vector3.left)
                        renderer.flipX = true;
                    isRotate = true;
                }
            }
        }
        else if (lookYVec == Vector3.down)
        {
            if (transform.localPosition.y <= 0 + heightSize)
            {
                if (!isRotate)
                {
                    lookYVec = rotateVec;
                    if (rotateVec == Vector3.left)
                        renderer.flipX = true;
                    isRotate = true;
                }
            }
        }
    }
}
