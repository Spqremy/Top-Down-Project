﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;
public class Crafting : MonoBehaviour
{
    public Recipe recipe;
    public CharacterData characterData;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Craft();
        }
    }

    private void Craft()
    {
        List<int> exclude = new List<int>();
        int foundIngredience = 0;

        foreach (var y in recipe.RequieredItem)
        {
            for (int i = 0; i < characterData.Inventory.Entries.Length; i++)
            {
                if (exclude.Contains(i))
                {
                    continue;
                }

                if (characterData.Inventory.Entries[i] != null)
                {
                    if (y == characterData.Inventory.Entries[i].Item)
                    {
                        exclude.Add(i);
                        foundIngredience++;
                    }
                }

            }
        }

        if (recipe.RequieredItem.Length == foundIngredience)
        {
            foreach (var x in exclude)
            {
                characterData.Inventory.Entries[x].Item = null;
                characterData.Inventory.Entries[x].Count = 0;
                characterData.Inventory.Entries[x] = null;
            }

            characterData.Inventory.Entries[12] = new InventorySystem.InventoryEntry();
            characterData.Inventory.Entries[12].Item = recipe.resultedItem[0];
            characterData.Inventory.Entries[12].Count = 1;

        }
        else
        {
            Debug.Log("Can't focus");
        }
    }
}
