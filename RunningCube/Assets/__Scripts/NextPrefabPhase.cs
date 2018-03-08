using UnityEngine;

// Spawna o próximo container de obstaculos e terreno ao passar pelo trigger.
public class NextPrefabPhase : MonoBehaviour { 

    public GameObject[] ocA;
    public GameObject[] ocB;
    public GameObject terrain;
    public float easyTime = 20f;
    //public float medTime = 40f;
    public float plataformDistance;
    public float obstacleDistance;
    public Transform spawnPoint;

    Vector3 obstaclePosition;

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == ("SecCube"))
        {
            ObstacleSpawner();
            Destroy(gameObject);
        }
    }

    void ObstacleSpawner()
    {
        Instantiate(terrain, spawnPoint.position, Quaternion.identity);
        // Se o jogador passar pelo trigger antes do tempo, instancia um 
        // container de obstaculos fácil.
        if (Time.timeSinceLevelLoad < easyTime) 
        {
            obstaclePosition = new Vector3(spawnPoint.position.x - 278f,
                                           spawnPoint.position.y + 1f,
                                           spawnPoint.position.z);
            Instantiate(ocA[Random.Range(0, ocA.Length)],
                        obstaclePosition,
                        Quaternion.identity);
        }
        else
        {
            obstaclePosition = new Vector3(spawnPoint.position.x,
                                           spawnPoint.position.y + 1f,
                                           spawnPoint.position.z);
            Instantiate(ocB[Random.Range(0, ocB.Length)],
                        obstaclePosition,
                        Quaternion.identity);
        }
    }
}
