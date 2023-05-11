using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectablePowerUp : MonoBehaviour
{
    public abstract PowerUpEffect PowerUpEffect { get; }

    public void Collect()
    {
        Destroy(this.gameObject);
    }
}
