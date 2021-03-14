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
    public GameObject terrain;
    public int[] nbResources;
    private List<System.Tuple<GameObject, int>> resourcesToSpawn = new List<System.Tuple<GameObject, int>>();
    private float terrain_width_origin;
    private float terrain_height_origin;
    private float terrain_width_end;
    private float terrain_height_end;
    private float respawnTime = 0.05f;
    private List<System.Tuple<GameObject, int>> currentTotalObjectsOnScene = new List<System.Tuple<GameObject, int>>();
    private List<GameObject> badMonsterHouses = new List<GameObject>();
    private List<GameObject> coolMonsterHouses = new List<GameObject>();
    private List<GameObject> playerMonsterHouse = new List<GameObject>();
    private System.Random random = new System.Random();
    //private List<GameObject> playerMonsterHouses = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject terrainCenter = terrain.transform.Find("terrainCenter").gameObject;
        print(terrainCenter.transform.position);
        terrain_width_origin = terrainCenter.transform.position.x -12f;
        terrain_height_origin = terrainCenter.transform.position.z -12f;
        terrain_width_end = terrainCenter.transform.position.x + 12f;
        terrain_height_end = terrainCenter.transform.position.z + 12f;
        print(System.String.Format("gauche={0} droite={1} bas={2} haut={3}", terrain_width_origin, terrain_width_end, terrain_height_origin, terrain_height_end));
        initResourcesToSpawn();
        initTotalGameObjects();
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

    private System.Tuple<float,float> redefineNextHousePositionIfNecessary(float xPos, float zPos)
    {
        for (int i = 0; i < badMonsterHouses.Count; i++)
        {
            if (xPos < (badMonsterHouses[i].transform.position.x + 2f))
            {
                xPos = Random.Range(terrain_width_origin, terrain_width_end);
            }
            if (zPos < (badMonsterHouses[i].transform.position.z + 2f))
            {
                zPos = Random.Range(terrain_height_end, terrain_height_end);
            }
        }
        for (int i = 0; i < coolMonsterHouses.Count; i++)
        {
            if (xPos < (coolMonsterHouses[i].transform.position.x + 2f))
            {
                xPos = Random.Range(terrain_width_origin, terrain_width_end);
            }
            if (zPos < (coolMonsterHouses[i].transform.position.z + 2f))
            {
                zPos = Random.Range(terrain_height_origin, terrain_height_end);
            }
        }
        for (int i = 0; i < playerMonsterHouse.Count; i++)
        {
            if (xPos < (playerMonsterHouse[i].transform.position.x + 2f))
            {
                xPos = Random.Range(terrain_width_origin, terrain_width_end);
            }
            if (zPos < (playerMonsterHouse[i].transform.position.z + 2f))
            {
                zPos = Random.Range(terrain_height_origin, terrain_height_end);
            }
        }
        return new System.Tuple<float, float>(xPos, zPos);
    }

    private void spawnFruityBush(int index)
    {
        GameObject resourceToInstantiate = resourcesToSpawn[index].Item1;
        GameObject a = Instantiate(resourceToInstantiate) as GameObject;
        float xPos = Random.Range(terrain_width_origin, terrain_width_end);
        float zPos = Random.Range(terrain_height_origin, terrain_height_end);

        if (isHouseObject(a))
        {
            System.Tuple<float, float> positions = redefineNextHousePositionIfNecessary(xPos, zPos);
            xPos = positions.Item1;
            zPos = positions.Item2;
        }
        a.transform.position = new Vector3(xPos, a.transform.position.y, zPos);
        
        if (a.ToString().StartsWith("bad monster house"))
        {
            badMonsterHouses.Add(a);
        }
        else if (a.ToString().StartsWith("cool monster house"))
        {
            coolMonsterHouses.Add(a);
        }
        else if (a.ToString().StartsWith("player monster house"))
        {
            playerMonsterHouse.Add(a);
        }
    }

    private float generateMonsterPositionNearHouseOnX(GameObject house, GameObject monster)
    {
        float xPos = Random.Range(house.transform.position.x, house.transform.position.x + 1.5f);
        //if (xPos < terrain_width_origin || xPos > terrain_width_end)
        //{
        //    xPos = generateMonsterPositionNearHouseOnX(house, monster);
        //}
        return xPos;
    }

    private float generateMonsterPositionNearHouseOnZ(GameObject house, GameObject monster)
    {
        float zPos = Random.Range(house.transform.position.z, house.transform.position.z + 1.5f);
        //if (zPos < terrain_width_origin || zPos > terrain_width_end)
        //{ 
        //    zPos = generateMonsterPositionNearHouseOnZ(house, monster);
        //}
        return zPos;
    }

    private void spawnMonstersNearHouse(List<GameObject> houses, string name)
    {
        System.Tuple<GameObject, int> monsters = resourcesToSpawn.Find(t => isMonterObject(t.Item1, name));
        int monstersIndex = resourcesToSpawn.IndexOf(monsters);
        GameObject b;
        GameObject a;
        while (currentTotalObjectsOnScene[monstersIndex].Item2 < monsters.Item2)
        { 
            a = houses[random.Next(houses.Count)];
            b = Instantiate(monsters.Item1) as GameObject;
            b.transform.position = new Vector3(generateMonsterPositionNearHouseOnX(a, b), b.transform.position.y, generateMonsterPositionNearHouseOnZ(a, b));
            currentTotalObjectsOnScene[monstersIndex] = new System.Tuple<GameObject, int>(monsters.Item1, currentTotalObjectsOnScene[monstersIndex].Item2 + 1);
            //print(System.String.Format("{0} {1} présents au total pour le moment sur la scène.", currentTotalObjectsOnScene[monstersIndex].Item2, currentTotalObjectsOnScene[monstersIndex].Item1));
        }
    }

    private bool isMonterObject(GameObject o, string maybeName = "")
    {
        return o.ToString().Contains(maybeName + " monster") && !(o.ToString().Contains("house"));
    }

    private bool isHouseObject(GameObject o)
    {
        return o.ToString().Contains("house");
    }

    IEnumerator fruityBushWave()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            if (isMonterObject(resourcesToSpawn[i].Item1))
            {
                if (resourcesToSpawn[i].Item1.ToString().Contains("bad"))
                {
                    spawnMonstersNearHouse(badMonsterHouses, "bad");
                }
                else if (resourcesToSpawn[i].Item1.ToString().Contains("cool"))
                {
                    spawnMonstersNearHouse(coolMonsterHouses, "cool");
                } else if (resourcesToSpawn[i].Item1.ToString().Contains("player"))
                {
                    spawnMonstersNearHouse(playerMonsterHouse, "player");
                }
            }
            else
            {
                while (currentTotalObjectsOnScene[i].Item2 < resourcesToSpawn[i].Item2)
                {
                    yield return new WaitForSeconds(respawnTime);
                    spawnFruityBush(i);
                    currentTotalObjectsOnScene[i] = new System.Tuple<GameObject, int>(resourcesToSpawn[i].Item1, currentTotalObjectsOnScene[i].Item2 + 1);
                    //print(System.String.Format("{0} {1} présents au total pour le moment sur la scène.", currentTotalObjectsOnScene[i].Item2, currentTotalObjectsOnScene[i].Item1));
                }
            }
        }
    }
}
