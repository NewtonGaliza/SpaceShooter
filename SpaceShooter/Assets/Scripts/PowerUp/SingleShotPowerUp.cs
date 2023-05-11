using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotPowerUp : CollectablePowerUp
{
    public override PowerUpEffect PowerUpEffect
    {
        get { return new SingleShotEffect(); }
    }
}
