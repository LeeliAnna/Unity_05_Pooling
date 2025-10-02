using UnityEngine;

public class CreatureBehavior : MonoBehaviour, IPoolClient
{
    [HideInInspector] public SpawnPoint sp;

    // jouer quand la créature arrive dans la pool, active le game object et donne une position et une rotation
    public void Arise(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        // transform.position = position;
        // transform.rotation = rotation;
        transform.SetPositionAndRotation(position, rotation);
    }

    // jouer quand la créature sors de la pool, désactive l'objet
    public void Fall()
    {
        gameObject.SetActive(false);
    }

    // Renvoie l'objet au point de départ (spawn point)
    public void Teleport()
    {
        sp.Teleport(this);
    }

}
