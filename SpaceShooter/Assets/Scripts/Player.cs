using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private Laser laserPrefab;
    [SerializeField] private float waitingShoot;
    private float shootInterval;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int lifes;

    private EndGame endGameScreen;


    private void Start()
    {
        this.lifes = 5;
        this.shootInterval = 0;  
        ScoreController.Score = 0;      

        
        GameObject endGamegameObject = GameObject.FindGameObjectWithTag("EndGameScreen");
        this.endGameScreen = endGamegameObject.GetComponent<EndGame>();
        this.endGameScreen.Hide();
    }

    private void Update()
    {
        this.shootInterval += Time.deltaTime;
        if(this.shootInterval >= 1f)
        {
            this.shootInterval = this.waitingShoot;
            Shoot();
        }

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        //transform.position += moveDir * moveSpeed *Time.deltaTime; 
        transform.position += (Vector3)inputVector * moveSpeed * Time.deltaTime;

        CheckScreenLimit();
    }

    private void Shoot()
    {
        // quaternion.euler 0,0,-90 to rotate the laser
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.Euler(0,0,-90));
    }

    public int Life
    {
        get { return this.lifes; }

        set { 

            this.lifes = value; 
            
            if(this.lifes <= 0)
            {
               this.lifes = 0;

               this.gameObject.SetActive(false);

               endGameScreen.Show();
            }

            }      
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            Life--;
            Enemy enemy =collider.GetComponent<Enemy>();
            enemy.TakeDamage();
        }
    }

    private void CheckScreenLimit()
    {
        Vector2 currentPosition = this.transform.position;

        float halfWidth = Width / 2f;
        float halfHeight = Height / 2f;

        Camera camera = Camera.main;
        Vector2 leftDownLimit = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 rightUpLimit = camera.ViewportToWorldPoint(Vector2.one);

        float letfReferencePoint = currentPosition.x - halfWidth;
        float rightReferencePoint = currentPosition.x + halfWidth;        

        if(letfReferencePoint < leftDownLimit.x)
        {
            this.transform.position = new Vector2(leftDownLimit.x + halfWidth, currentPosition.y);     
        } 
        else if(rightReferencePoint > rightUpLimit.x)
        {
            this.transform.position = new Vector2(rightUpLimit.x - halfWidth, currentPosition.y);
        }

        currentPosition = this.transform.position;

        float upReferencePoint = currentPosition.y + halfHeight;
        float downReferencePoint = currentPosition.y - halfHeight;

        if(upReferencePoint > rightUpLimit.y)
        {
            this.transform.position = new Vector2(currentPosition.x, rightUpLimit.y - halfHeight);
        }
        else if(downReferencePoint < leftDownLimit.y)
        {
            this.transform.position = new Vector2(currentPosition.x, leftDownLimit.y + halfHeight);
        }


    }

    private float Width //largura
    {
        get {  
                Bounds bounds = this.spriteRenderer.bounds; 
                Vector3 size = bounds.size;
                return size.x;
            }
    }

    private float Height //altura
    {
        get {
                Bounds bounds = this.spriteRenderer.bounds;
                Vector3 size = bounds.size;
                return size.y;
            }
    }
}
