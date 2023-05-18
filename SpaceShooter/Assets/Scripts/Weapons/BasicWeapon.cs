using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicWeapon : MonoBehaviour
{
    [SerializeField] private Laser laserPrefab;
    [SerializeField] private float waitingShoot;
    
    public Transform[] shootPosition;
    
    private float shootInterval;

    // Start is called before the first frame update
    public virtual void Start()
    {
        this.shootInterval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.shootInterval += Time.deltaTime;
        if(this.shootInterval >= 1f)
        {
            this.shootInterval = this.waitingShoot;
            Shoot();
        }
    }

    protected Laser CreateLaser(Vector2 position)
    {
        // quaternion.euler 0,0,-90 to rotate the laser
        return Instantiate(this.laserPrefab, position, Quaternion.Euler(0,0,-90));
    }

    protected abstract void Shoot();

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
   
}
