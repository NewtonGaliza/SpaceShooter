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

    private void Start()
    {
        this.shootInterval = 0;  
        ScoreController.Score = 0;      
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
    }

    private void Shoot()
    {
        // quaternion.euler 0,0,-90 to rotate the laser
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.Euler(0,0,-90));
    }
}
