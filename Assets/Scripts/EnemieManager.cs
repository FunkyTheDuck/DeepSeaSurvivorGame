using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    List<EnemieBase> enemies;
    public GameManager myGm;
    private float elapsedTime = 0f;
    public float spawnInterval = 5f;

    public GameObject GreenSmallFishPrefab;
    public GameObject OrangeSmallFishPrefab;
    public GameObject GreenMediumFishPrefab;
    public GameObject PurpleMediumFishPrefab;
    public GameObject YellowBigFishPrefab;
    public GameObject RedBigFishPrefab;
    public GameObject SharkPrefab;
    public GameObject ManaStarPrefab;

    private void Start()
    {
        myGm = gameObject.GetComponent<GameManager>();
        enemies = new List<EnemieBase>
        {
            new EnemieBase
            {
                Id = 0,
                Name = "GreenSmallFish",
                Level = 1,
                Description = "Its green and doesn't do much",
                Damage = 1,
                Health = 25,
                Speed = 1,
                RecoverTime = 3
            },
            new EnemieBase
            {
                Id = 1,
                Name = "OrangeSmallFish",
                Level = 1,
                Description = "Its Orange and doesn't do much",
                Damage = 1,
                Health = 25,
                Speed = 1,
                RecoverTime = 3
            },
            new EnemieBase
            {
                Id = 2,
                Name = "GreenMediumFish",
                Level = 1,
                Description = "Its green and could harm you",
                Damage = 15,
                Health = 150,
                Speed = 2,
                RecoverTime = 2
            },
            new EnemieBase
            {
                Id = 3,
                Name = "PurpleMediumFish",
                Level = 1,
                Description = "Its Purple and could harm you",
                Damage = 15,
                Health = 150,
                Speed = 2,
                RecoverTime = 2
            },
            new EnemieBase
            {
                Id = 4,
                Name = "YellowBigFish",
                Level = 1,
                Description = "Its yellow and its pretty big for a fish",
                Damage = 40,
                Health = 200,
                Speed = 4,
                RecoverTime = 1.5f
            },
            new EnemieBase
            {
                Id = 5,
                Name = "RedBigFish",
                Level = 1,
                Description = "Its red and its pretty big for a fish",
                Damage = 40,
                Health = 200,
                Speed = 4,
                RecoverTime = 1.5f
            },
            new EnemieBase
            {
                Id = 6,
                Name = "Shark",
                Level = 1,
                Description = "Its a shark, OH NO!",
                Damage = 100,
                Health = 350,
                Speed = 5,
                RecoverTime = 1
            }
        };

        StartCoroutine(SpawnEnemies());
    }

    public void SpawnManaStar(Vector3 deadEnemyPos, string enemyName)
    {
        GameObject manaStar = Instantiate(ManaStarPrefab);
        manaStar.GetComponent<ManaStar>().InitializedManaStar(enemyName);
        manaStar.transform.position = deadEnemyPos;
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            elapsedTime += 1;

            // Get a list of possible enemies to spawn
            EnemieBase[] possibleEnemies = GetEnemiesToSpawn();

            // Select a random enemy from the possible enemies
            EnemieBase enemyToSpawn = possibleEnemies[Random.Range(0, possibleEnemies.Length)];

            // Calculate a random spawn point around the player
            Vector3 spawnPoint = GetRandomSpawnPointAroundPlayer();
            GameObject enemyPrefab;
            switch (enemyToSpawn.Name)
            {
                case "GreenSmallFish":
                    enemyPrefab = GreenSmallFishPrefab;
                    break;
                case "OrangeSmallFish":
                    enemyPrefab = OrangeSmallFishPrefab;
                    break;
                case "GreenMediumFish":
                    enemyPrefab = GreenMediumFishPrefab;
                    break;
                case "PurpleMediumFish":
                    enemyPrefab = PurpleMediumFishPrefab;
                    break;
                case "YellowBigFish":
                    enemyPrefab = YellowBigFishPrefab;
                    break;
                case "RedBigFish":
                    enemyPrefab = RedBigFishPrefab;
                    break;
                case "Shark":
                    enemyPrefab = SharkPrefab;
                    break;
                default:
                    enemyPrefab = GreenSmallFishPrefab;
                    break;
            }
            // Instantiate the enemy
            Debug.Log("Spawn enemy");
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    EnemieBase[] GetEnemiesToSpawn()
    {
        // Create a list of enemies to spawn based on elapsed time
        if (elapsedTime < 60f)
        {
            return new EnemieBase[] { enemies[0], enemies[1] }; // Only weak enemies
        }
        else if (elapsedTime < 120f)
        {
            return new EnemieBase[] { enemies[0], enemies[1], enemies[2], enemies[3] }; // Weak and medium enemies
        }
        else if( elapsedTime < 180f)
        {
            return new EnemieBase[] { enemies[0], enemies[1], enemies[2], enemies[3], enemies[4], enemies[5] }; // Weak, medium, and strong enemies
        }
        else
        {
            return new EnemieBase[] { enemies[0], enemies[1], enemies[2], enemies[3], enemies[4], enemies[5], enemies[6] }; // Weak, medium, and strong enemies
        }
    }

    Vector3 GetRandomSpawnPointAroundPlayer()
    {
        // Generate a random angle in radians
        float angle = Random.Range(0f, Mathf.PI * 2);

        // Calculate the x and z positions
        Vector3 playerPos = myGm.GetPlayerPos();
        float x = playerPos.x + 20 * Mathf.Cos(angle);
        float y = playerPos.y + 20 * Mathf.Sin(angle);

        // Return the spawn point with the same y position as the player
        return new Vector3(x, y, playerPos.z);
    }

    public EnemieBase GetEnemieBaseFromName(string name)
    {
        return enemies.FirstOrDefault(e => e.Name == name);
    }
}