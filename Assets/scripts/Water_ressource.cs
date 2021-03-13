using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_ressource : MonoBehaviour
{
    System.Random rand = new System.Random();
    private float maxWaterQuantity = 5f; // En litres par exemple...
    private float currentWaterQuantity;
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
        currentWaterQuantity = System.Convert.ToSingle(rand.NextDouble()) * 5f;
        if (currentWaterQuantity < 1f)
        {
            generateCurrentWaterQuantity();
        }
    }

    public float emptyRessource()
    {
        float waterQuantityTaken = currentWaterQuantity;
        currentWaterQuantity = 0f;
        return waterQuantityTaken;
    }

    public float takeRessourceWithQuantity(float quantity)
    {
        float waterQuantityTaken;
        if (quantity > currentWaterQuantity)
        {
            waterQuantityTaken = currentWaterQuantity;
            currentWaterQuantity = 0f;
            return waterQuantityTaken;
        } else
        {
            waterQuantityTaken = quantity;
            currentWaterQuantity -= quantity;
            return waterQuantityTaken;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
