using UnityEngine;

// Limpa os objetos que passarem pelo jogador.
public class ObjectDestroy : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        // Não destroi o chão.
        if (other.tag != "Ground")
        {
            Destroy(other.gameObject);
        }
    }
}
