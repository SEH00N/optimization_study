using System.Diagnostics;
using UnityEngine;

public class LandscapeUVCube : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public int width = 100;
    public int depth = 100;

    private GameObject cubeParentObj;

    void Start()
    {
        CreateCubes();
        CombineAll();
        // StaticBatchingUtility.Combine(gameObject);
    }

    private void CreateCubes()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                float height = Mathf.PerlinNoise(x / 50f, z / 50f) * 50 + Mathf.PerlinNoise((x + 25) / 30f, (z + 25) / 30f) * 50;

                Vector3 pos = new Vector3(x, height, z);
                if (height > 60)
                    cubeParentObj = Instantiate(block1, pos, Quaternion.identity);
                else if (height > 50)
                    cubeParentObj = Instantiate(block2, pos, Quaternion.identity);
                else if (height > 30)
                    cubeParentObj = Instantiate(block3, pos, Quaternion.identity);
                else
                    cubeParentObj = Instantiate(block4, pos, Quaternion.identity);

                cubeParentObj.transform.SetParent(transform);
            }
        } 
    }

    private void CombineAll()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combines = new CombineInstance[meshFilters.Length - 1];

        int i = 1;
        while(i < meshFilters.Length)
        {
            combines[i - 1].mesh = meshFilters[i].sharedMesh;
            combines[i - 1].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        GetComponent<MeshFilter>().mesh = new Mesh();
        GetComponent<MeshFilter>().mesh.CombineMeshes(combines);
        gameObject.SetActive(true);
    }
}
