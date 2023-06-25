using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    //ak hi array bana li teno monsters ki
    private GameObject[] monsterRefernce;

    private GameObject spawedMonster;

    [SerializeField]
    private Transform leftPos,rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }
    //using this function because we can cll it ny time in this function it is giving 
    //Rand number btw 1 and 5
    IEnumerator SpawnMonster(){
       while (true)
       {
         yield return new WaitForSeconds(Random.Range(1,5));
        
        //finding a random value for randomIndex from 0 to
        randomIndex=Random.Range(0,monsterRefernce.Length);

        //finding random value 0,1 or 2
        randomSide= Random.Range(0,2);
        //Any enemy from the three depend on random num
        //if index is 0 it will return enemy 1
        //Instantiate() gives us a copy of enemy generated
        spawedMonster=Instantiate(monsterRefernce[randomIndex]);

        //left side
        if (randomSide==0)
        {
            //if monster is on left side then monster is gone come from left and
            // go to the right side


            spawedMonster.transform.position=leftPos.position;
            //getting random speed of monster btw 4 and 10


            spawedMonster.GetComponent<Monster>().speed=Random.Range(4,10);
        }
        else
        {
            //right side
            //if monster is on right side then monster is gone come from right and
            // go to the left side


            spawedMonster.transform.position=rightPos.position;


            //getting random speed of monster btw 4 and 10
            //(-)using it beacuse monster is moving in opposite direction from right to left


            spawedMonster.GetComponent<Monster>().speed=-Random.Range(4,10);


            //ham chata ha ka jab monster right sa left ay to us ka angle bhi chg ho
            //means face bhi left ki tarf ho is lia ham localscale - kar da ga


            spawedMonster.transform.localScale=new Vector3(-1f,1f,1f);
        }
       }//while loop 
    }
}
