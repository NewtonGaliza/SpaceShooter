using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    [SerializeField] private int lifeAmount;

    public int LifeAmount
    {
        get { return this.lifeAmount; }
    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }
}
