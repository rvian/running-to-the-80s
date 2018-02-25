using UnityEngine;


public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {

        if (player != null)
            transform.position = player.position + offset;
        else if (GameObject.FindGameObjectWithTag("SecCube"))
            transform.position = GameObject.FindGameObjectWithTag("SecCube").transform.position + offset;
        
    }
}

    