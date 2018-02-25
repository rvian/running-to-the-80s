using UnityEngine;

// Spawna um container de obstaculos e o terreno ao colidir com o trigger colision

public class NextPrefabPhase : MonoBehaviour { 

    public GameObject[] ocA;
    public GameObject[] ocB;

    public GameObject terrain;

    public float plataformDistance;
    public float obstacleDistance;

    public Transform spawnPoint;

    Vector3 obstaclePosition;


	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == ("SecCube"))
        {
            ObstacleSpawner();
            Destroy(gameObject); // impede duplo spawn caso o primeiro cubo quebre no trigger
        }

    }

    void ObstacleSpawner()
    {
        Instantiate(terrain, spawnPoint.position, Quaternion.identity);
        if (Time.timeSinceLevelLoad < 15) //se o tempo for menos que x segundos, entao spanwa o prefab A - facil
        {
            obstaclePosition = new Vector3(spawnPoint.position.x - 278f,
                                           spawnPoint.position.y + 1f,
                                           spawnPoint.position.z);
            Instantiate(ocA[Random.Range(0, ocA.Length)], obstaclePosition, Quaternion.identity);
        }
        else // spawna prefab B
        {
            obstaclePosition = new Vector3(spawnPoint.position.x,
                                           spawnPoint.position.y + 1f,
                                           spawnPoint.position.z);
            Instantiate(ocB[Random.Range(0, ocB.Length)], obstaclePosition, Quaternion.identity);
        }
    }
}
