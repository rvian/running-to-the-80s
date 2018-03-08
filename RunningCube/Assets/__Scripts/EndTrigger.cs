using UnityEngine;

// Trigger para finalizar a fase. Chama a UI para o proximo nivel e 
// desabilita o movimento do jogador.
public class EndTrigger : MonoBehaviour
{
    private GameController gameController;
    private Movement playerMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "SecCube")
        {
            playerMove = other.GetComponent<Movement>();
            playerMove.enabled = false;
            gameController = FindObjectOfType<GameController>();
            gameController.GameWin();
        }
    }
}