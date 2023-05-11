using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTouch : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float movementSpeed;
    
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            Vector2 worldPosition = this.camera.ScreenToWorldPoint(touchPosition);

            this.rigidbody2D.position = worldPosition;
        }        
    }
}
