using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaStar : MonoBehaviour
{
    float amountOfMana;
    public void InitializedManaStar(string enemyName)
    {
        if(enemyName.ToLower().Contains("small"))
        {
            amountOfMana = 1;
        }
        else if(enemyName.ToLower().Contains("medium"))
        {
            amountOfMana = Random.Range(1,3);
        }
        else if(enemyName.ToLower().Contains("big"))
        {
            amountOfMana = Random.Range(2,5);
        }
        else
        {
            amountOfMana = Random.Range(4,7);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered");
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().GetManaFromStar(amountOfMana);
            Destroy(gameObject);
        }
    }
}