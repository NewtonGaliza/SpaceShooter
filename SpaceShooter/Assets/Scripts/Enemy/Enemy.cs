using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    private float speedX;

    private void Start()
    {
        this.speedX = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        // speedX is negative because the enemy needs to go <- this direction
        this.rigidbody.velocity = new Vector2(-speedX, 0);
    }

    public void EnemyDestroy(bool deafated)
    {
        if(deafated)
        {
            ScoreController.Score++;
        }
        Destroy(this.gameObject);
    }


}
