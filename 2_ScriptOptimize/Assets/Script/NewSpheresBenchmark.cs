using UnityEngine;

public class NewSpheresBenchmark : MonoBehaviour
{
    public int numberOfSpheres = 100;

    private Transform[] spheres;

    private void Start()
    {
        spheres = new Transform[numberOfSpheres];

        Shader shader = Shader.Find("Specular");     
        Material mat = new Material(shader);
        mat.color = Color.red;

        for(int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            spheres[i] = sphereObj.transform;

            Renderer rend = sphereObj.GetComponent<Renderer>();

            rend.material = mat;
            sphereObj.transform.position = Random.insideUnitSphere * 20;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach(Transform trm in spheres)
                trm.Translate(0, 0, 1f);
        }
    }
}
