using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruityBush_resource : MonoBehaviour
{
    private int maxFruitsQuantity = 20;
    private int currentFruitsQuantity;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        generateCurrentFruitsQuantity();
    }

    private void generateCurrentFruitsQuantity()
    {
        currentFruitsQuantity = rand.Next(5, maxFruitsQuantity);
    }

    public int recolteTousLesFruits()
    {
        int quantityRecoltee = currentFruitsQuantity;
        currentFruitsQuantity = 0;
        return quantityRecoltee;
    }

    public int recolteUneQuantiteDeFruits(int quantity)
    {
        int quantityRecoltee;
        if (quantity > currentFruitsQuantity)
        {
            quantityRecoltee = recolteTousLesFruits();
            return quantityRecoltee;
        } else
        {
            quantityRecoltee = quantity;
            currentFruitsQuantity -= quantity;
            return quantityRecoltee;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
