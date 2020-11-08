using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployResources : MonoBehaviour
{
    public GameObject[] resources;
    private float width = 12f;
    private float height = 12f;
    private float respawnTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
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
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            int index = Random.Range(0, resources.Length);
            spawnFruityBush(index);
        }
    }
}
