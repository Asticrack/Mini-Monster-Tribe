using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_resource : MonoBehaviour
{
    System.Random rand = new System.Random();
    private int maxWaterQuantity = 5; // En litres par exemple...
    private int currentWaterQuantity;
    // Start is called before the first frame update
    void Start()
    {
        generateCurrentWaterQuantity();
    }

    /// <summary>
    /// Génère la quantité d'eau en litres d'un bassin d'eau, entre 0 et 5 litres, 0 étant impossible.
    /// </summary>
    private void generateCurrentWaterQuantity()
    {
        currentWaterQuantity = rand.Next(1, maxWaterQuantity);
    }

    public int emptyRessource()
    {
        int waterQuantityTaken = currentWaterQuantity;
        currentWaterQuantity = 0;
        return waterQuantityTaken;
    }

    public int takeRessourceWithQuantity(int quantity)
    {
        int waterQuantityTaken;
        if (quantity > currentWaterQuantity)
        {
            waterQuantityTaken = emptyRessource();
            return waterQuantityTaken;
        } else
        {
            waterQuantityTaken = quantity;
            currentWaterQuantity -= quantity;
            return waterQuantityTaken;
        }
    }

    public int getCurrentWaterQuantity()
    {
        print(displayInformation());
        return currentWaterQuantity;
    }

    public string displayInformation()
    {
        string s = System.String.Format("Récoltable : {0}/{0} litres d'eau.", currentWaterQuantity, maxWaterQuantity);
        return s;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaterQuantity == 0)
        {
            Destroy(gameObject);
        }
    }
}
