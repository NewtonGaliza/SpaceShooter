using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect
{
    private float effectDuration; // in seconds

    public PowerUpEffect(float effectDuration)
    {
        this.effectDuration = effectDuration;
    }

    public abstract void Apply(Player player);

    public abstract void Remove(Player player);

    public void Refresh()
    {
        if(Active)
        {
            this.effectDuration -= Time.deltaTime;
        }
    }

    public bool Active
    {
        /*

        this two codes are equals

        get
        {
            if(this.effectDuration > 0)
            {
                return true;
            }
            return false;

        }
        */

        get { return (this.effectDuration > 0); }
    }


}
