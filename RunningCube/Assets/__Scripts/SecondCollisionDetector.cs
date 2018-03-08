using UnityEngine;

// Detecção de colisão do segundo avatar.
public class SecondCollisionDetector : MonoBehaviour {

    public Blink blink;
    public Movement movement;

    // Ao colidir verifica se é um obstaculo, desabilita o movimento e 
    // chama o metodo de gameover.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && blink.isInvencible == false)
        {
            movement.isMoveEnable = false;
            FindObjectOfType<GameController>().GameOver();
        }
    }
}
