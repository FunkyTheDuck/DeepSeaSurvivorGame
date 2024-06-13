using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    public GameObject GFX;
    public GameManager MyGM;

    int playerLevel = 1;
    float playerHealth = 100f;
    float targetedMana = 20;
    float currentMana = 0;

    bool moving;
    float horizontal;
    float vertical;

    public float runSpeed = 1f;

    void Start()
    {
        MyGM = GameObject.Find("GameManager").GetComponent<GameManager>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.A))
        {
            GFX.transform.rotation = new Quaternion(GFX.transform.rotation.x, 180, GFX.transform.rotation.z, 0);
            moving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GFX.transform.rotation = new Quaternion(GFX.transform.rotation.x, 0, GFX.transform.rotation.z, 0);
            moving = true;
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            moving = false;
        }
        if(moving)
        {
            RotateRoter();
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    private void RotateRoter()
    {
        GFX.transform.GetChild(0).GetChild(0).transform.Rotate(new Vector3(0,0,3) * 50 * Time.deltaTime, Space.Self);
    }

    public void GetManaFromStar(float amount)
    {
        currentMana += amount;
        if(currentMana >= targetedMana)
        {
            currentMana -= targetedMana;
            playerLevel += 1;
            if(playerLevel < 5)
            {
                targetedMana += Random.Range(5, 11);
            } else if(playerLevel < 10)
            {
                targetedMana += Random.Range(7, 15);
            }
            else if(playerLevel < 15)
            {
                targetedMana += Random.Range(10, 16);
            }
            else
            {
                targetedMana += Random.Range(15, 21);
            }
            MyGM.PlayerLeveledUp();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player losing health");
            playerHealth -= collision.gameObject.GetComponent<Enemie>().Stats.Damage;
        }
    }
}