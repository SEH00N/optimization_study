using UnityEngine;

public class TankAIBenchmark : MonoBehaviour
{
    private GameObject[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;

    private void Start()
    {
        tanks = new GameObject[numberOfTanks];
        for (int i = 0; i < numberOfTanks; i++)
        {
            tanks[i] = Instantiate(tankPrefab);
            tanks[i].transform.position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));
        }
    }

    private int interval = 3;

    private void Update()
    {
        if(Time.frameCount % interval == 0)
        {
            
        }

        // foreach (GameObject t in tanks)
        // {
        //     GameObject player = GameObject.FindGameObjectWithTag("Player");
        //     if (player != null)
        //     {
        //         t.transform.LookAt(player.transform.position);
        //         t.transform.Translate(0, 0, 0.05f);
        //     }
        // }
    }
}
