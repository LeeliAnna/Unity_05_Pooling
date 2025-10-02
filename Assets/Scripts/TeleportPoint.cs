using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // cherche un composant qui implémente l'interfece. TryGetComponent retourne un bool
        // out permet de n'instancier la variable qui si la méthode est vrais
        if (other.TryGetComponent(out CreatureBehavior creature))
        {
            creature.Teleport();
        }
    }
}
