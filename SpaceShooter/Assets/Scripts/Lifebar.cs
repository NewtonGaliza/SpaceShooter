using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    [SerializeField] private GameObject[] redBars;

    public void ShowLifes(int lifes)
    {
        for(int i = 0; i < this.redBars.Length; i++)
        {
            if(i < lifes)
            {
                //ativar
                this.redBars[i].SetActive(true);
            }
            else
            {
                //desativar
                this.redBars[i].SetActive(false);
            }
        }
    }
}
