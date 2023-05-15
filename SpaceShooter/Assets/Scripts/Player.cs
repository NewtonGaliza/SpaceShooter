using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int MaxLifeCont = 5;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private WeaponController weaponController;

    [SerializeField] private Shield shield;

    private int lifes;

    private EndGame endGameScreen;



    private void Start()
    {
        this.lifes = MaxLifeCont;
        ScoreController.Score = 0;      

        GameObject endGamegameObject = GameObject.FindGameObjectWithTag("EndGameScreen");
        this.endGameScreen = endGamegameObject.GetComponent<EndGame>();
        this.endGameScreen.Hide();

        EquipSingleShot();

        this.shield.Deactivate();
    }

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        //transform.position += moveDir * moveSpeed *Time.deltaTime; 
        transform.position += (Vector3)inputVector * moveSpeed * Time.deltaTime;

        CheckScreenLimit();
    }

    public int Life
    {
        get { return this.lifes; }

        set { 

            this.lifes = value; 

            if(this.lifes > MaxLifeCont)
            {
                this.lifes = MaxLifeCont;
            }
            else if(this.lifes <= 0)
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
            Enemy enemy =collider.GetComponent<Enemy>();
            EnemyCollide(enemy);
        }
        else if(collider.CompareTag("LifeItem"))
        {
            LifeItem lifeItem = collider.GetComponent<LifeItem>();
            CollectLifeItem(lifeItem);
        }
        else if(collider.CompareTag("PowerUp"))
        {
            CollectablePowerUp powerUp = collider.GetComponent<CollectablePowerUp>();
            CollectPowerUp(powerUp);
        }
    }

    public void EnemyCollide(Enemy enemy)
    {
        if(this.shield.ShieldActivated)
        {
            this.shield.TakeDamage();
        }
        else
        {
            Life--;
        }
        enemy.TakeDamage();
    }

    private void CollectLifeItem(LifeItem lifeItem)
    {
        Life += lifeItem.LifeAmount;
        lifeItem.Collect();
    }

    public void CollectPowerUp(CollectablePowerUp powerUp)
    {
        PowerUpEffect powerUpEffect = powerUp.PowerUpEffect;
        powerUpEffect.Apply(this);
        powerUp.Collect();
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

    public void EquipSingleShot()
    {
        this.weaponController.EquipSingleShot();
    }

    public void EquipAlternateShot()
    {
        this.weaponController.EquipAlternateShot();
    }

    public void EquipDoubleShot()
    {
        this.weaponController.EquipDoubleShot();
    }

    public void EquipShield()
    {
        this.shield.Activate();
    }
}
