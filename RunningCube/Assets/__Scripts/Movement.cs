using UnityEngine;

// Movimento do jogador.
public class Movement : MonoBehaviour {
    
    public float speedFoward=800f;
    public float speedSide=600f;

    public float speedFactor = 3f;
    public float speedIncreaseDistance = 200f;
    public float maxSpeed = 60f;

    float speedIncrease = 0f;
    public bool isMoveEnable = true;

    private Rigidbody rb;
    private GameController gameController;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
        // Define a variavel 'movement' no script do gameController.
        gameController.movement = this;
    }
	
	void FixedUpdate ()
    {
       
        rb.AddForce((speedFoward * Time.deltaTime) + speedIncrease, 0, 0);
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(0, 0,
                        ((-speedSide + (speedIncrease / 10)) * Time.deltaTime),
                        ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(0, 0,
                        ((speedSide + (speedIncrease / 10)) * Time.deltaTime),
                        ForceMode.VelocityChange);
        }
    }

    private void Update()
    {
        // Reinicio de queda. Otimizável.
        if (rb.position.y < -3f)
        {
            gameController.GameOver();
        }
        // Aumenta a velocidade por tempo apos X posição.
        if (transform.position.x >= speedIncreaseDistance && speedIncrease <= maxSpeed)
        {
            speedIncrease += speedFactor / 100;
        }
    }
}
