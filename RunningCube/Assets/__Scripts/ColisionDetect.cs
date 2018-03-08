using UnityEngine;

// Detecta a colisão com obstáculos do primeiro avatar.
// Instância o ragdoll.
public class ColisionDetect : MonoBehaviour {

    public GameObject destructPlayer;
    public GameObject secondCube;

    private Vector3 destructPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" &&
            GameObject.FindGameObjectWithTag("SecCube")==false)
        {
            destructPos = transform.position;
            Destruct();
        }
    }
    public void Destruct()
    {
        Instantiate(destructPlayer, destructPos,Quaternion.identity);
        Instantiate(secondCube, destructPos, transform.rotation);
        Destroy(gameObject);
    }
}
