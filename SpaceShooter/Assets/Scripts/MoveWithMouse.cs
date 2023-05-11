using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
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
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = this.camera.ScreenToWorldPoint(mousePosition);

        /*
        this code made the ship move to mouse póint, not with mouse point

        Vector2 newPosition = Vector2.Lerp(this.transform.position, worldPosition, (this.movementSpeed * Time.deltaTime));
        this.rigidbody2D.position = newPosition;
        */

        this.rigidbody2D.position = worldPosition;
    }
}
