using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
   [Header("Scripts")] [SerializeField] private MeshGenerator meshGenerator;
   [SerializeField] private CreateVoxelModel createVoxelModel;

   [Header("Buttons")] [SerializeField] private Button generateButton;
   [SerializeField] private Button xSizeButtonPlus, xSizeButtonLess;
   [SerializeField] private Button zSizeButtonPlus, zSizeButtonLess;
   [SerializeField] private Button heightButtonPlus, heightButtonLess;
   [SerializeField] private Button entropyButtonPlus, entropyButtonLess;
   [SerializeField] private Button objectButtonPlus, objectButtonLess;

   [Header("Object")] 
   [SerializeField] private GameObject[] objects;

   [Header("Text")] 
   [SerializeField] private TextMeshProUGUI xSizeText, zSizeText;
   [SerializeField] private TextMeshProUGUI heightText, entropyText;
   

   #region Values

   private int xSize, zSize;
   private float height, entropy;
   private int objectIndex;

   #endregion

   private void Awake()
   {
      AssingButtons();
      ChangeValues();
   }

   void ChangeValues()
   {
      xSize = meshGenerator.xSize;
      ChangeText(xSizeText,xSize);
      
      zSize = meshGenerator.zSize;
      ChangeText(zSizeText, zSize);
      
      height = meshGenerator.height;
      ChangeText(heightText, (int)height);
      
      entropy = meshGenerator.entropy;
      ChangeText(entropyText, (int)entropy);

      objectIndex = 0;
      ChangeObjectIndex(objectIndex);
   }
   void AssingButtons()
   {
      generateButton.onClick.AddListener(GenerateMesh);
      
      xSizeButtonPlus.onClick.AddListener(delegate { ChangeXValue(+1);});
      xSizeButtonLess.onClick.AddListener(delegate { ChangeXValue(-1);});
      
      zSizeButtonPlus.onClick.AddListener(delegate { ChangeZValue(+1);});
      zSizeButtonLess.onClick.AddListener(delegate { ChangeZValue(-1);});
      
      heightButtonPlus.onClick.AddListener(delegate { ChangeHeightValue(+1);});
      heightButtonLess.onClick.AddListener(delegate { ChangeHeightValue(-1);});
      
      entropyButtonPlus.onClick.AddListener(delegate { ChangeEntropyValue(+1);});
      entropyButtonLess.onClick.AddListener(delegate { ChangeEntropyValue(-1);});
      
      objectButtonPlus.onClick.AddListener(delegate { ChangeObjectIndex(+1);});
      objectButtonLess.onClick.AddListener(delegate { ChangeObjectIndex(-1);});
   }

   void GenerateMesh()
   {
      meshGenerator.DestroyMesh();
      meshGenerator.ReciveValues(xSize, zSize, height, entropy, objects[objectIndex]);
   }

   void ChangeXValue(int i)
   {
      xSize += i;
      ChangeText(xSizeText,xSize);
   }

   void ChangeZValue(int i)
   {
      zSize += i;
      ChangeText(zSizeText, zSize);
   }

   void ChangeHeightValue(int i)
   {
      height += i;
      ChangeText(heightText, (int)height);
   }

   void ChangeEntropyValue(int i)
   {
      entropy += i;
      ChangeText(entropyText, (int)entropy);
   }
   void ChangeText(TextMeshProUGUI text, int value)
   {
     text.text = value.ToString();
   }
   void ChangeObjectIndex(int i)
   {
      objectIndex += i;

      foreach (var o in objects)
         o.SetActive(false);
    
      objects[objectIndex].SetActive(true);
   }
}
