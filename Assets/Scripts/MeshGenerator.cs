using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public int xSize = 20;
    public int zSize = 20;

    public float height;
    public float entropy;
    public Gradient principalGradient;
    public GameObject voxelObject;
    void Start()
    {
        CreateMesh();
    }
    public void CreateMesh()
    {
        for (var z = 0; z < zSize; z++)
        {
            for (var x = 0; x < xSize; x++)
            {
                float noiseX = (x / (float)xSize) * entropy;
                float noiseZ = (z / (float)zSize) * entropy;
                float y = Mathf.PerlinNoise(noiseX, noiseZ) * height;
                Vector3 pos = new Vector3(x, Mathf.Round(y), z);
                GameObject obj = Instantiate(voxelObject, pos, Quaternion.identity);
                obj.transform.SetParent(this.transform);
                Material m = obj.GetComponent<MeshRenderer>().material;
                m.color = principalGradient.Evaluate(y / this.height);
            }
        }
    }
}
