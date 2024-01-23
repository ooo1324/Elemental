using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

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
    private Vector3 rotationDirection;

    private bool isUnderBridge;

    private string layerName;


    void Update()
    {
        transform.Translate(Vector3.right * currSpeed * Time.deltaTime * 
            Management.Instance.level);
    }

    private void OnEnable()
    {
        rotationDirection = AngleToDirection(gameObject.transform.localEulerAngles.z);
        currSpeed = moveSpeed;
        layerName = LayerMask.LayerToName(gameObject.layer);
        carRenderer.sortingOrder = layerName == "Car_Bridge"? 9 : 5;
        normalSmog.GetComponent<SpriteRenderer>().sortingOrder = carRenderer.sortingOrder - 1;
        badSmog.GetComponent<SpriteRenderer>().sortingOrder = carRenderer.sortingOrder - 1;
        StartCoroutine(SmogAction());
        StartCoroutine(CheckFrontCar());
    }

    private Vector3 AngleToDirection(float angle)
    {
        float rad = angle * Mathf.PI / 180;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
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
            Debug.DrawRay(gameObject.transform.position + rotationDirection * 1, rotationDirection * 0.5f, new Color(0, 1, 0));

            //원점, 방향, 거리
            RaycastHit2D rayHit = Physics2D.Raycast(gameObject.transform.position + rotationDirection * 1,
                rotationDirection, 0.7f, LayerMask.GetMask(layerName));

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
            if (isUnderBridge) return;
            if (isExhaust)
            {
                //매연 자동차인 경우
                GameManager.instance.PlusScore(GamePanelManager.EElementalType.air, gameObject.transform.position);
                gameObject.SetActive(false);
                AirSoundManager.instance.PlayCorrectSound();
            }
            else
            {
                //매연 자동차가 아닌 경우
                GameManager.instance.MinusSocre(GamePanelManager.EElementalType.air, gameObject.transform.position);
                gameObject.SetActive(false);
                AirSoundManager.instance.PlayIncorrectSound();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarBridge"))
        {
            isUnderBridge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarBridge"))
        {
            isUnderBridge = false;
        }
    }
}
