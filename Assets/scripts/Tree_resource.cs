using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_resource : MonoBehaviour
{
    System.Random rand = new System.Random();
    private int maxBuchesQuantity = 100;
    private int currentBuchesQuantity;
    // Start is called before the first frame update
    void Start()
    {
        generateCurrentBuchesQuantity();
    }

    private void generateCurrentBuchesQuantity()
    {
        currentBuchesQuantity = rand.Next(20, maxBuchesQuantity);
    }

    public int cutTheTree()
    {
        int quantityRecoltee = currentBuchesQuantity;
        currentBuchesQuantity = 0;
        return quantityRecoltee;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBuchesQuantity == 0)
        {
            Destroy(gameObject);
        }
    }
}
