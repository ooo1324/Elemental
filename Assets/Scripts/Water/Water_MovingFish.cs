using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Water_MovingFish : MonoBehaviour
{
    // Start is called before the first frame update

     Image image ;

  

    bool isLeftSpawn ;
    bool isRightSpawn;

    public int pointValue;
    //물고기 크기 조정하

    float minXpos = -15.5f;
    float maxXpos = 4.5f;

 

    SpriteRenderer spRenderer;

    float alpha_Fish;
    public float alpha_Time;

    public bool isMouseDown;

    //이펙트
    public GameObject explosionFx;

    //스폰
     Water_FishSpawn fish_Spawn;

    public float speed;
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();

        fish_Spawn = GameObject.Find("Water_FishSpawn").GetComponent<Water_FishSpawn>();

        int a = Random.Range(0, 2);

        if (a == 0) // 만약 x가 더 작으면?
        {
            //spRenderer.layer
           

            gameObject.tag = "LeftFish";
            spRenderer.flipX = true;
            this.transform.position = new Vector2(minXpos, this.transform.position.y);
            isLeftSpawn = true;
        }
        else
        {
            gameObject.tag = "RightFish";
            this.transform.position = new Vector2(maxXpos, this.transform.position.y);
            isLeftSpawn = false;
        }

        if (this.spRenderer.sortingLayerName != "Fish") { return; }

        // StartCoroutine(SetLayer());
        //
        if (speed == 5)
            return;
        else
            speed = Random.Range(2, 4);

        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
  
        if (isLeftSpawn)
        {
          //  Debug.Log("오른쪽으로 가기");
            this.transform.Translate(speed * Time.deltaTime * Management.Instance.level, 0, 0);
        }
        else 
        {
            // Debug.Log("왼쪽으로 가기");
            this.transform.Translate(-speed * Time.deltaTime * Management.Instance.level, 0, 0);
        }

     
    }



    private void OnMouseDown() // 마우스 클릭
    {
        Destroy(gameObject);
        Explode();
        isMouseDown = true;
   

       // fish_Spawn.UpdateScore(pointValue);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    


        if ((this.gameObject.tag == "LeftFish" && collision.tag == "RightSenser") ||
            (gameObject.tag == "RightFish" && collision.tag == "LeftSenser"))
        {
         //   Debug.Log("센서감지");
            Destroy(gameObject);
             // 이펙트
        }

    }

    void Explode() // 이펙트
    {      
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
    }

}
