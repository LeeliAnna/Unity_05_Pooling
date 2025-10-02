using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool<T>
where T : IPoolClient
{
    // doit avoir une ancre dans le jeux
    private Transform anchor;
    // objet a gerer par la pool 
    private GameObject prefab;
    // on donne une queue (obligatoirement Queue)
    private Queue<T> queue = new();

    private int batch;

    // Constructeur
    public Pool(Transform anchor, GameObject prefab, int batch)
    {
        this.anchor = anchor;
        this.prefab = prefab;
        this.batch = batch;

        CreateBatch();

    }

    private void CreateBatch()
    {
        // crée un nombre défini d'objet de la pool
        for (int _ = 0; _ < batch; _++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            if (go.TryGetComponent(out T client))
            {
                Add(client);
            }
            else
            {
                throw new ArgumentException("The prefab dosen't have a IPoolClient component.");
            }
        }
    }

    // Ajoute dans la queue un objet et active ca méthode Fall
    public void Add(T client)
    {
        queue.Enqueue(client);
        client.Fall();
    }

    // renvoie un objet de la queue, le retire, l'active dans le jeu et le retourne
    public T Get()
    {
        if (queue.Count == 0) CreateBatch();
        T client = queue.Dequeue();
        client.Arise(anchor.position, anchor.rotation);
        return client;
    }

}
