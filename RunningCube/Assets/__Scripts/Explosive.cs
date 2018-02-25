using UnityEngine;
/*
 * adiciona forca nos cubos pequenos do cubo vermelho, para n parecerem estaticos quando spawnados 
 * */


public class Explosive : MonoBehaviour {

    private Rigidbody rb;
    public float fowardForce = 350f;



	void Start () { 
        rb = GetComponent<Rigidbody>();
        rb.AddForce(fowardForce,0,0,ForceMode.Impulse);
     }
	
}
