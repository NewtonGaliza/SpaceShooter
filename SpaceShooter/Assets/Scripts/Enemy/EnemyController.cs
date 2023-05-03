using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float passTime;
    [SerializeField] private Enemy greenEnemtPrefab;
    [SerializeField] private Enemy blueEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.passTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.passTime += Time.deltaTime;

        if(this.passTime >= 1f)
        {
            this.passTime = 0;

            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float positionY = Random.Range(minPosition.y, maxPosition.y);

            Vector2 enemyPosition = new Vector2(maxPosition.x, positionY);

            Enemy prefabEnemy;
            
            float chance = Random.Range(0, 100);
            if(chance <= 25) // 25% chance of create a blue enemy
            {
                prefabEnemy = this.blueEnemyPrefab;
            }
            else
            {
                prefabEnemy = this.greenEnemtPrefab;
            }


            Instantiate(prefabEnemy, enemyPosition, Quaternion.identity);
        }
    }
}
