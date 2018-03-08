using UnityEngine;

// Adiciona impulso inicial no segundo avatar.
public class Explosive : MonoBehaviour {

    private Rigidbody rb;
    public float fowardForce = 350f;

	void Start ()
    { 
        rb = GetComponent<Rigidbody>();
        rb.AddForce(fowardForce,0,0,ForceMode.Impulse);
    }
	
}
