﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PlayerHealthBar : MonoBehaviour
{
   /**
   *  VARIABLES
   * */
    private RawImage healthBarRawImage;
    private Player player;






   /**
   *  CLASS FUNCTIONS
   * */
   private void Start()
    {
        player = FindObjectOfType<Player>();
        healthBarRawImage = GetComponent<RawImage>();
    }


   private void Update()
    {
        float xValue = -(player.HealthAsPercentage() / 2f) - 0.5f;
        healthBarRawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
    }




   /**
   *  FUNCTIONS
   * */
}
