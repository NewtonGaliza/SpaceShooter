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
        Camera camera = Camera.main;
        Vector3 positionOnCamera = camera.WorldToViewportPoint(this.transform.position);

        if(positionOnCamera.x > 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            // destroy enemy
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage();

            // destroy laser
            Destroy(this.gameObject);
        }
        
    }
}
