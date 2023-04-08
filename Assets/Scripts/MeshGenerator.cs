using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public int xSize = 20;
    public int zSize = 20;

    public float height;
    public float entropy;
    public Gradient gradient;
    public GameObject box;
    void Start()
    {
        CreateMesh();
    }
    void CreateMesh()
    {
        for (var z = 0; z < zSize; z++)
        {
            for (var x = 0; x < xSize; x++)
            {
                float noiseX = (x / (float)xSize) * entropy;
                float noiseZ = (z / (float)zSize) * entropy;
                float y = Mathf.PerlinNoise(noiseX, noiseZ) * height;
                Vector3 pos = new Vector3(x, Mathf.Round(y), z);
                GameObject obj = Instantiate(box, pos, Quaternion.identity);
                Material m = obj.GetComponent<MeshRenderer>().material;
                m.color = gradient.Evaluate(y / this.height);
            }
        }
    }
}
