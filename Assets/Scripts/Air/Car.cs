using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public SpriteRenderer carRenderer;

    public bool isExhaust;

    public GameObject normalSmog;

    public GameObject badSmog;

    private float currSpeed;

    void Update()
    {
        transform.Translate(Vector3.right * currSpeed * Time.deltaTime * 
            Management.Instance.level);
    }

    private void OnEnable()
    {
        currSpeed = moveSpeed;
        StartCoroutine(SmogAction());
        StartCoroutine(CheckFrontCar());
    }

    IEnumerator SmogAction()
    {
        yield return new WaitForSeconds(0.2f);
        badSmog.SetActive(isExhaust);
        normalSmog.SetActive(!isExhaust);
    }

    IEnumerator CheckFrontCar()
    {
        while (true) 
        {
            //RayCast로 체크 앞에 차가 있으면 
            Debug.DrawRay(gameObject.transform.position + Vector3.right * 1, Vector2.right * 0.5f, new Color(0, 1, 0));

            //원점, 방향, 거리
            RaycastHit2D rayHit = Physics2D.Raycast(gameObject.transform.position + Vector3.right * 1,
                Vector2.right, 0.7f, LayerMask.GetMask("Car"));

            //빔을 쏴서 맞았으면 초기화 되어 not NULL
            if (rayHit.collider != null)
            {
                currSpeed = 0;
            }
            else
            {
                currSpeed = moveSpeed;
            }

            yield return new WaitForSeconds(0.005f);
        }

    }

    private void OnMouseDown()
    {
        if (!Management.Instance.Stop)
        {    
            if (isExhaust)
            {
                //매연 자동차인 경우
                GameManager.instance.PlusScore(GamePanelManager.EElementalType.air);
                gameObject.SetActive(false);
            }
            else
            {
                //매연 자동차가 아닌 경우
                GameManager.instance.MinusSocre(GamePanelManager.EElementalType.air);
            }
        }
    }
}
