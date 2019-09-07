using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;
[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public Item[] RequieredItem;
    public Item[] resultedItem;
}
