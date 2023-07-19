using UnityEngine;

public class SpheresBenchmark : MonoBehaviour
{
    public int numberOfSpheres = 100;

    private void Start()
    {
        for(int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer rend = sphereObj.GetComponent<Renderer>();

            rend.material = new Material(Shader.Find("Specular"));
            rend.material.color = Color.red;
            sphereObj.transform.position = Random.insideUnitSphere * 20;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach(Transform trm in spheres)
                trm.Translate(0, 0, 1f);
        }
    }
}
