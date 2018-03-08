using UnityEngine;

// Faz a camera seguir o alvo.
public class CamFollow : MonoBehaviour
{
    // Alvo a ser seguido.
    Transform player;
    public Vector3 offset;

    private void Start()
    {
        // O alvo inicial é o primeiro avatar
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Não está 100%, mas está melhor que antes.
        if (player == null)
        {
            GetSecondTarget();
        }
        transform.position = player.position + offset;
    }

    void GetSecondTarget()
    {
        player = GameObject.FindGameObjectWithTag("SecCube").transform;
    }
}

    