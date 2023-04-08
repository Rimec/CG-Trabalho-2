using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
   [Header("Buttons")]
   [SerializeField] private Button generateButton;
   [SerializeField] private Button xSizeButtonPlus, xSizeButtonLess;
   [SerializeField] private Button zSizeButtonPlus, zSizeButtonLess;
   [SerializeField] private Button heightButtonPlus, heightButtonLess;
   [SerializeField] private Button entropyButtonPlus, entropyButtonLess;

   private void Awake()
   {
      AssingButtons();
   }

   void AssingButtons()
   {
      
      
   }

   void GenerateMesh()
   {
      //Destroy
      //Create
   }
}
