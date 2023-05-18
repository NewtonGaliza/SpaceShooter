using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectablePowerUp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float intervalBetweenBlinks;
    [SerializeField] private float maxBlinks;
    [SerializeField] private float timeReduceBetweenBlinks;

    [SerializeField] private float effectDuration;

    [SerializeField] private float intervalTimeBeforeSelfDestruct;
    private float timeCountBeforeSelfDestruct;
    private bool selfDestructed;

    public abstract PowerUpEffect PowerUpEffect { get; }

    private void Start()
    {
        this.selfDestructed = false;
        this.timeCountBeforeSelfDestruct = 0;
    }

    private void Update()
    {
        if(!this.selfDestructed)
        {
            this.timeCountBeforeSelfDestruct += Time.deltaTime;
            if(this.timeCountBeforeSelfDestruct >= intervalTimeBeforeSelfDestruct)
            {
                InitiateSeflDestruct();
            }
        }
    }

    public float DurationInSeconds
    {
        get { return this.effectDuration; }
    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }

    private void InitiateSeflDestruct()
    {
        this.selfDestructed = true;

        StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        int blinkCount = 0;
        do
        {
            /*
            if(this.spriteRenderer.enabled)
            {
                this.spriteRenderer.enabled = false;
            }
            else
            {
                this.spriteRenderer.enabled = true;
            }

            #### this code above is the same as the code below ####

            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
            */

            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;

            yield return new WaitForSeconds(this.intervalBetweenBlinks);
            blinkCount++;
            this.timeReduceBetweenBlinks -= blinkCount * Time.deltaTime;
        }
        while(blinkCount < this.maxBlinks);

        Destroy(this.gameObject);
    }
}
