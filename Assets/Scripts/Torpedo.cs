using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    GameObject parent;
    [SerializeField]
    public SkillBase skill;
    void Start()
    {
        DestoryAfterTime(4);
    }

    void Update()
    {
        
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