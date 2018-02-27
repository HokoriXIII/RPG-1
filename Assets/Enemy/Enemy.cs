using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;



public class Enemy : MonoBehaviour {

    /**
    *  VARIABLES
    * */

    private float currentHealthPoints = 100f;
    private float maxHealthPoints = 100f;
    private float attackRadius = 40f;
    private AICharacterControl aiCharacterControl = null;
    private GameObject player = null;




    /**
    *  CLASS FUNCTIONS
    * */
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aiCharacterControl = GetComponent<AICharacterControl>();
    }


    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);


        if (distanceToPlayer <= attackRadius)
            aiCharacterControl.SetTarget(player.transform);
        else
            aiCharacterControl.SetTarget(transform);

    }








    /**
    *  FUNCTIONS
    * */
    public float HealthAsPercentage()
    {
        return currentHealthPoints / maxHealthPoints;
    }
}
