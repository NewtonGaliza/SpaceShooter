using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private ParticleSystem explosionParticlePrefab;
    [SerializeField] private int enemyLife;
    private float speedX;

    private void Start()
    {
        this.speedX = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        // speedX is negative because the enemy needs to go <- this direction
        this.rigidbody.velocity = new Vector2(-speedX, 0);

        Camera camera = Camera.main;
        Vector3 positionOnCamera = camera.WorldToViewportPoint(this.transform.position);
    
        if(positionOnCamera.x < 0)
        {
            //enemy left the screen
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.Life--;
            EnemyDestroy(false);
        }
    }

    private void EnemyDestroy(bool deafated)
    {
        if(deafated)
        {
            ScoreController.Score++;
        }

        ParticleSystem explosionParticle = Instantiate(this.explosionParticlePrefab, this.transform.position, Quaternion.identity);

        Destroy(explosionParticle, 1f); // destroy particle after 1 second
        Destroy(this.gameObject);
    }

    public void TakeDamage()
    {
        this.enemyLife--;

        if(this.enemyLife <= 0)
        {
            EnemyDestroy(true);
        }
    }

}
