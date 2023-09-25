using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 50f;

    public GameObject player;


    private void Start()
    {
        player = this.gameObject;
        var startLoading = GetComponent<SystemLoadAndSave>();
        startLoading.LoadFromJSON();

        player.transform.position = startLoading.playerPos3system;
    }
    private void Update()
    {
        var saveLoading = GetComponent<SystemLoadAndSave>();

        if (Input.GetKeyUp("r"))
        {
            player.transform.position = new Vector3(0, 0, 5);
        }
        if (Input.GetKeyUp("k"))
        {
            saveLoading.ToSaveJSON();
        }   
        if (Input.GetKeyUp("l"))
        {
            if(saveLoading.playerPos3system != null)
            {
                saveLoading.LoadFromJSON();
                player.transform.position = saveLoading.playerPos3system;
            }
            else
            {
                Debug.Log("Dont have save data");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);
    }
}
