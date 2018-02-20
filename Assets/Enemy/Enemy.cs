using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    /**
    *  VARIABLES
    * */

    private float currentHealthPoints = 100f;
    private float maxHealthPoints = 100f;






    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {

    }


    private void Update()
    {

    }








    /**
    *  FUNCTIONS
    * */
    public float HealthAsPercentage()
    {
        return currentHealthPoints / maxHealthPoints;
    }
}
