using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    public GameObject GFX;
    public GameObject TorpedoExit;
    public GameObject TorpedoPrefab;

    bool moving;
    float horizontal;
    float vertical;

    public float runSpeed = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(ReloadTorpedo());
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
    private IEnumerator ReloadTorpedo()
    {
        yield return new WaitForSeconds(2f);
        FireTorpedo();
    }
    private void FireTorpedo()
    {
        Instantiate(TorpedoPrefab, TorpedoExit.transform);
        StartCoroutine(ReloadTorpedo());
    }

}
