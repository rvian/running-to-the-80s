using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    private GameController gameController;
    private Movement playerMove;
    //public Movement player2Move;

    private void Update()
    {
        
        playerMove = FindObjectOfType<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "SecCube")
        {
            playerMove.enabled = false;
            gameController = FindObjectOfType<GameController>();
            gameController.GameWin();
        }/*
        else
        {
            player2Move.enabled = false;
            gameController.GameWin();
        }*/
    }
}
    
     
          