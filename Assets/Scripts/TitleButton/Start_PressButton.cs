using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Start_PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Image img_Renderer;
    public Sprite sprite01;
    public Sprite sprite02;

    public GameObject gameObj;

    //public Fade_InOut fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        img_Renderer = GetComponent<Image>();

      //  fadeIn = GetComponent<Fade_InOut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        img_Renderer.sprite = sprite01; //눌린이미지 

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Exit");
        img_Renderer.sprite = sprite02; // 올라온이미지 

        gameObj.SetActive(true);
        gameObj.GetComponent<Fade_InOut>().StartCoroutine("FadeIn");
    }
}
