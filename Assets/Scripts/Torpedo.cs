using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    public bool facingRight;
    [SerializeField]
    public SkillBase skill;
    void Start()
    {

        StartCoroutine(DestoryAfterTime(skill.TimeToDestory));
    }

    void Update()
    {
        if(facingRight)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * skill.Speed * Time.deltaTime;
        }
        else
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left * skill.Speed * Time.deltaTime;
        }
    }
    private IEnumerator DestoryAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Debug.Log("Explosion from torpedo");
    }
}