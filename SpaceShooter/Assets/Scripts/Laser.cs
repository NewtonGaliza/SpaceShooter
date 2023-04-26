using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speedX;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody.velocity = new Vector2(this.speedX, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            // destroy enemy
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.EnemyDestroy();

            // destroy laser
            Destroy(this.gameObject);
        }
        
    }
}
