using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    List<EnemieBase> enemies;
    private void Start()
    {
        enemies = new List<EnemieBase>
        {
            new EnemieBase
            {
                Id = 0,
                Name = "GreenSmallFish",
                Level = 1,
                Description = "Its green and doesn't do much",
                Damage = 1,
                Health = 50,
                Speed = 300,
            },
            new EnemieBase
            {
                Id = 1,
                Name = "OrangeSmallFish",
                Level = 1,
                Description = "Its Orange and doesn't do much",
                Damage = 1,
                Health = 50,
                Speed = 300,
            },
            new EnemieBase
            {
                Id = 2,
                Name = "GreenMediumFish",
                Level = 1,
                Description = "Its green and could harm you",
                Damage = 15,
                Health = 150,
                Speed = 500,
            },
            new EnemieBase
            {
                Id = 3,
                Name = "PurpleMediumFish",
                Level = 1,
                Description = "Its Purple and could harm you",
                Damage = 15,
                Health = 150,
                Speed = 500,
            },
            new EnemieBase
            {
                Id = 4,
                Name = "YellowBigFish",
                Level = 1,
                Description = "Its yellow and its pretty big for a fish",
                Damage = 40,
                Health = 200,
                Speed = 600,
            },
            new EnemieBase
            {
                Id = 5,
                Name = "RedBigFish",
                Level = 1,
                Description = "Its red and its pretty big for a fish",
                Damage = 40,
                Health = 200,
                Speed = 600,
            },
            new EnemieBase
            {
                Id = 6,
                Name = "RedBigFish",
                Level = 1,
                Description = "Its red and its pretty big for a fish",
                Damage = 100,
                Health = 350,
                Speed = 800,
            }
        };


    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(10);
        int difficulty = GetRandomNumberAsDifficulty();
        switch(difficulty)
        {
            case 1:
                //spawn a sharm of sharks
                break;
            case > 2 and <= 10:
                //spawn multiple sharks
                break;
            case > 11 and <= 99:
                //spawn a few sharks
                break;
        }
    }

    private int GetRandomNumberAsDifficulty()
    {
        return Random.Range(1, 100000);
    }
    private int GetRandomNumberAsAmount()
    {
        return Random.Range(1, 100);
    }


    public EnemieBase GetEnemieBaseFromName(string name)
    {
        return enemies.FirstOrDefault(e => e.Name == name);
    }
}