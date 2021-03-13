using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawn randomly resources (tree, fruity bush or water) inside terrain boundings.
 * For instance, it just spawns every 0.25 seconds.
 * 
 **/
public class deployResources : MonoBehaviour
{
    public GameObject[] resources;
    public int[] nbResources;
    private List<System.Tuple<GameObject, int>> resourcesToSpawn = new List<System.Tuple<GameObject, int>>();
    private float width = 12f;
    private float height = 12f;
    private float respawnTime = 0.1f;
    private List<System.Tuple<GameObject, int>> currentTotalObjectsOnScene = new List<System.Tuple<GameObject, int>>();

    // Start is called before the first frame update
    void Start()
    {
        initResourcesToSpawn();
        initTotalGameObjects();

        for (int i = 0; i < currentTotalObjectsOnScene.Count; i++)
        {
            print(System.String.Format("{0} {1} présents au total pour le moment sur la scène.", currentTotalObjectsOnScene[i].Item2, currentTotalObjectsOnScene[i].Item1));
        }
        //currentTotalObjectsOnScene = GameObject.FindGameObjectsWithTag("Resource");
        //Debug.Log(currentTotalObjectsOnScene.Length + " objects in total at first.");
        StartCoroutine(fruityBushWave());
    }

    private void initResourcesToSpawn()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            resourcesToSpawn.Add(new System.Tuple<GameObject, int>(resources[i], nbResources[i]));
        }
    }

    private void initTotalGameObjects()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            currentTotalObjectsOnScene.Add(new System.Tuple<GameObject, int>(resourcesToSpawn[i].Item1, 0));
        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void spawnFruityBush(int index)
    {
        GameObject resourceToInstantiate = resourcesToSpawn[index].Item1;
        GameObject a = Instantiate(resourceToInstantiate) as GameObject;
        a.transform.position = new Vector3(Random.Range(-12f, width), a.transform.position.y, Random.Range(-12f, height));
        if (a.ToString().StartsWith("bad monster house"))
        {
            spawnMonstersNearHouse(a, "bad");
        }
        else if (a.ToString().StartsWith("cool monster house"))
        {
            spawnMonstersNearHouse(a, "cool");
        }
        else if (a.ToString().StartsWith("player monster house"))
        {
            spawnMonstersNearHouse(a, "player");
        }
    }

    private void spawnMonstersNearHouse(GameObject monsterHouse, string name)
    {
        System.Tuple<GameObject, int> monsters = resourcesToSpawn.Find(t => isMonterObject(t.Item1, name));
        int monstersIndex = resourcesToSpawn.IndexOf(monsters);
        while (currentTotalObjectsOnScene[monstersIndex].Item2 < monsters.Item2)
        {
            GameObject b = Instantiate(monsters.Item1) as GameObject;
            b.transform.position = new Vector3(Random.Range(monsterHouse.transform.position.x + 1f, width - monsterHouse.transform.position.x - 3f), b.transform.position.y, Random.Range(monsterHouse.transform.position.z + 1f, height - monsterHouse.transform.position.z - 3f));
            currentTotalObjectsOnScene[monstersIndex] = new System.Tuple<GameObject, int>(monsters.Item1, currentTotalObjectsOnScene[monstersIndex].Item2 + 1);
            print(System.String.Format("{0} {1} présents au total pour le moment sur la scène.", currentTotalObjectsOnScene[monstersIndex].Item2, currentTotalObjectsOnScene[monstersIndex].Item1));
        }
    }

    private bool isMonterObject(GameObject o, string maybeName = "")
    {
        return o.ToString().Contains(maybeName + " monster") && !(o.ToString().Contains("house"));
    }

    IEnumerator fruityBushWave()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            if (isMonterObject(resourcesToSpawn[i].Item1))
            {
                continue;
            }
            while (currentTotalObjectsOnScene[i].Item2 < resourcesToSpawn[i].Item2)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnFruityBush(i);
                currentTotalObjectsOnScene[i] = new System.Tuple<GameObject, int>(resourcesToSpawn[i].Item1, currentTotalObjectsOnScene[i].Item2 + 1);
                print(System.String.Format("{0} {1} présents au total pour le moment sur la scène.", currentTotalObjectsOnScene[i].Item2, currentTotalObjectsOnScene[i].Item1));
                //print(System.String.Format("Position de l'objet en Y : {0}", currentTotalObjectsOnScene[i].Item1.transform.position.y));
            }
        }
        /*while(currentTotalObjectsOnScene.Length < 10)
        {
            yield return new WaitForSeconds(respawnTime);
            int index = Random.Range(0, resources.Length);
            spawnFruityBush(index);
            currentTotalObjectsOnScene = GameObject.FindGameObjectsWithTag("Resource");
            Debug.Log(currentTotalObjectsOnScene.Length + " objects in total.");
        }*/
    }
}
