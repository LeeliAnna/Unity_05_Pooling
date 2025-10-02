using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target;
    private Pool<CreatureBehavior> pool;

    //crée la pool et démarre la coroutine de création d'objet
    void Start()
    {
        pool = new(transform, prefab, 2);
        StartCoroutine(Spawn());

    }

    // coroutine de création 
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            // spawn a l'endroit du point de spawn dans le bon sens
            CreatureBehavior creature = pool.Get();
            creature.sp = this;
            creature.GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
    }

    public void Teleport(CreatureBehavior creature)
    {
        pool.Add(creature);
    }
    

}
