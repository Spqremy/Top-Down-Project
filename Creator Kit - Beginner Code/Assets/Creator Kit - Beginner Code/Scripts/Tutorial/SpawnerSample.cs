using UnityEngine;
using CreatorKitCode;

public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    void Start()
    {
        LootAngle myLootAngle = new LootAngle(15);
        LootAngle spawnAngle = new LootAngle(45);
        SpawnHealPotion(spawnAngle.NextAngle());
    }

    void SpawnHealPotion(int angle)
    {
        int radius = 5;

        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        Vector3 spawnPosition = transform.position + direction * radius;
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }

    public class LootAngle
    {
        int angle;
        int step;

        public LootAngle(int increment)
        {
            step = increment;
            angle = 0;

        }
        public int NextAngle()
        {
            int currentAngle = angle;
            angle = Helpers.WrapAngle(angle + step);

            return currentAngle;

        }
        
    }

}

