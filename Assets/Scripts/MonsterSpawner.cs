using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()

    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            //karakterlerin rastgele indexi ve belireceði yön sol ve sað anlamýnda
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);


            //Instantate function: will create a copy of a game object as we reference here.
            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            //monsterReference enemy türlerimden seçilen herhangi birisini temsil ediyor.
            //spaendMonster beliren yani ortaya çýkarýlan monster anlamýnda ve random ile seçilen mosnter beliriyor.

            //left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monsters>().speed = Random.Range(4, 10);

            }
            //right side
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(4, 10);
                //shifted the monster's gaze to the direction it came from - flip process
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

    }

}
