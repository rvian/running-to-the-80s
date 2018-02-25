using UnityEngine;

public class ObjectDestroy : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.tag !="Ground")
            Destroy(other.gameObject);
    }
}
