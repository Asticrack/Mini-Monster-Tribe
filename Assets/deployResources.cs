using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawn randomly resources (tree, fruity bush or water) inside terrain boundings.
 * For instance, it just spawns every 2 seconds.
 * 
 **/
public class deployResources : MonoBehaviour
{
    public GameObject[] resources;
    private float width = 12f;
    private float height = 12f;
    private float respawnTime = 2.0f;
    private GameObject[] totalGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        totalGameObjects = GameObject.FindGameObjectsWithTag("Resource");
        Debug.Log(totalGameObjects.Length + " objects in total at first.");
        StartCoroutine(fruityBushWave());
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void spawnFruityBush(int index)
    {
        GameObject resourceToInstantiate = resources[index];
        GameObject a = Instantiate(resourceToInstantiate) as GameObject;
        a.transform.position = new Vector3(Random.Range(-12f, width), 0f, Random.Range(-12f, height));
    }

    IEnumerator fruityBushWave()
    {
        while(totalGameObjects.Length < 30)
        {
            yield return new WaitForSeconds(respawnTime);
            int index = Random.Range(0, resources.Length);
            spawnFruityBush(index);
            totalGameObjects = GameObject.FindGameObjectsWithTag("Resource");
            Debug.Log(totalGameObjects.Length + " objects in total.");
        }
    }
}
