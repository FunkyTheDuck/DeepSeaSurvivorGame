using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    GameManager myGM;
    Transform torpedoPos;
    public GameObject TorpedoPrefab;
    SkillBase torpedoStats;
    private void Start()
    {
        myGM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void StartTorpedo()
    {
        torpedoStats = myGM.GetSkillBaseFromName("Torpedo");
        torpedoPos = transform.GetChild(1).transform.GetChild(1).transform;
        CreateTorpedo();
    } 
    private IEnumerator ReloadTorpedo(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CreateTorpedo();
    }
    private void CreateTorpedo()
    {
        GameObject torpedo = Instantiate(TorpedoPrefab);
        torpedo.transform.position = torpedoPos.position;
        torpedo.GetComponent<Torpedo>().skill = torpedoStats;
        if (transform.GetChild(1).transform.rotation.y > 0)
        {
            torpedo.GetComponent<Torpedo>().facingRight = false;
        }
        else
        {
            torpedo.GetComponent<Torpedo>().facingRight = true;
        }
        StartCoroutine(ReloadTorpedo(3));
    }
}