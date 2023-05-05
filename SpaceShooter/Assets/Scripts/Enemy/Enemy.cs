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

    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] [Range(0, 100)] private float dropItemChance;
    [SerializeField] private LifeItem lifeItem;

    private float speedX;

    private void Start()
    {
        Vector2 currentPosition = this.transform.position;
        float halfHeight = Height / 2f;

        float upReferencePoint = currentPosition.y - halfHeight;
        float downReferencePoint = currentPosition.y + halfHeight;

        Camera camera = Camera.main;
        Vector2 upLimit = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 downLimit = camera.ViewportToWorldPoint(Vector2.one);

        if(upReferencePoint < upLimit.x)
        {
            float positionX = upLimit.x - halfHeight;
            this.transform.position = new Vector2(positionX, currentPosition.y);
        }
        else if(downReferencePoint > downLimit.x)
        {
            float positionX = downLimit.x + halfHeight;
            this.transform.position = new Vector2(positionX, currentPosition.y);
        }


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
            DropLifeItem();
        }

        ParticleSystem explosionParticle = Instantiate(this.explosionParticlePrefab, this.transform.position, Quaternion.identity);

        Destroy(explosionParticle, 1f); // destroy particle after 1 second
        Destroy(this.gameObject);
    }

    private void DropLifeItem()
    {
        float randomChance = Random.Range(0f, 100f);
        if(randomChance <= this.dropItemChance)
        {
            Instantiate(lifeItem, this.transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage()
    {
        this.enemyLife--;

        if(this.enemyLife <= 0)
        {
            EnemyDestroy(true);
        }
    }

    private float Height //altura
    {
        get {
                Bounds bounds = this.spriteRenderer.bounds;
                Vector3 size = bounds.size;
                return size.x;
            }
    }

}
