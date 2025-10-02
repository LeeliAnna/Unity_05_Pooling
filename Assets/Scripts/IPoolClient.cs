using UnityEngine;

public interface IPoolClient
{
    // se releve
    void Arise(Vector3 position, Quaternion rotation);
    void Fall();
}
