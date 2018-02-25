/* Script para detectar a colisao do primeiro cubo do player. 
 * Chama o metodo que colocara o rigidbody e spawn do segundo cubo, destroi o primeiro cubo. 
*/
using UnityEngine;

public class ColisionDetect : MonoBehaviour {

    private Vector3 destructPos;
    public GameObject destructPlayer; //ragdoll
    public GameObject secondCube; 
    //public EndTrigger endTrigger; 
    /*
    private void Start()
    {
        endTrigger = GameObject.FindGameObjectWithTag("Finish").GetComponent<EndTrigger>();
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && GameObject.FindGameObjectWithTag("SecCube")==false)
        {
            destructPos = transform.position;
            Destruct();
            //endTrigger.ChangeMoveVar();
        }
    }
    public void Destruct()
    {
        Instantiate(destructPlayer, destructPos,transform.rotation);
        Instantiate(secondCube, destructPos, transform.rotation);
        Destroy(gameObject);
    }
   
}
