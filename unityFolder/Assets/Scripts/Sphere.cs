using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 50f;

    public GameObject player;

    public Renderer materialRD;

    public Color v3color;


    private void Start()
    {
        player = this.gameObject;
        materialRD = this.GetComponent<Renderer>();

        var startLoading = GetComponent<SystemLoadAndSave>();
        startLoading.LoadFromJSON();

        player.transform.position = startLoading.playerPos3system;
        speed = startLoading.speedLS;
        v3color = startLoading.matShpereLS;
        materialRD.material.color = v3color;
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
                speed = saveLoading.speedLS;
                v3color = saveLoading.matShpereLS;
                materialRD.material.color = v3color;
            }
            else
            {
                Debug.Log("Dont have save data");
            }
        }

        if (Input.GetKeyUp("z"))
        {
            speed = speed - 250f;
        }

        if (Input.GetKeyUp("c"))
        {
            speed = speed + 250f;
        }

        if (Input.GetKeyUp("e"))
        {
            v3color = Random.ColorHSV();
            materialRD.material.color = v3color;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);
        
    }
}
