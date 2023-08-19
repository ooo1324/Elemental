using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Water_FishSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> targetPrefabs;

    public float spawnRate = 1.0f;

    private float minValueX = -13.0f;

     Water_MovingFish moving_Fish;

    private int sorting_Value;
    private int score; 
   // public TextMeshProUGUI scoreText;

    [Range(0,100)]
    public int percent;
    // int level = 2; // 예를 들어서 2레벨이리고ㅓ 치고 

    public int ckaclIndex;

    void Start()
    {
  
        StartCoroutine(SpawnTarget());

        sorting_Value = 1;

     //   UpdateScore(0);
        moving_Fish = GetComponent<Water_MovingFish>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            int index = 0;

            if (percent < Random.Range(0,100)) // 좋은거
            {
                index = Random.Range(0, 3);
            }
            else
                index = Random.Range(3, 8);

            ckaclIndex = index;

          //  Debug.Log

            yield return new WaitForSeconds(spawnRate);

           // Debug.Log(spawnRate);


            //여기에 더는 생성하지않는다는 bool 변수 넣을지도 
            GameObject obj = Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            obj.GetComponent<SpriteRenderer>().sortingOrder = sorting_Value;
            sorting_Value++; // 나중에 한번 조절하는 코드 넣기 

     
        }
    }

    Vector2 RandomSpawnPosition()
    {
        float spawnPosX = minValueX;
        float spawnPosY = RandomSquareIndex();

        Vector2 spawnPosition = new Vector2(spawnPosX, spawnPosY);

        return spawnPosition;

    }
    float RandomSquareIndex()
    {
        return Random.Range(-3.5f, 4.0f);
    }

    //public void UpdateScore(int scoreToAdd)
    //{
    //    score += scoreToAdd;
    //    scoreText.text = "score: " + score;
    //}


}
