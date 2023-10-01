using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 50f;

    public GameObject player;

    public Animator animP;

    public bool isDialog = false;


    private void Start()
    {
        player = this.gameObject;

        var startLoading = GetComponent<SystemLoadAndSave>();
        startLoading.LoadFromJSON();

        player.transform.position = startLoading.playerPos3system;
        speed = startLoading.speedLS;
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
            saveLoading.Save();
        }  
        
        if (Input.GetKeyUp("l"))
        {
            if(saveLoading.playerPos3system != null)
            {
                PlayerPrefs.GetString("json");
                saveLoading.LoadFromJSON();
                saveLoading.Load();
                saveLoading.itemsInUI.GetComponent<InventoryWindow>().DestroyLogos();
                saveLoading.itemsInUI.GetComponent<InventoryWindow>().Redraw();

                player.transform.position = saveLoading.playerPos3system;
                speed = saveLoading.speedLS;
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

        if (Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
        {
            animP.SetBool("isRunning", true);
        }
        else 
        {
            animP.SetBool("isRunning", false);
        }

        if (isDialog)
        {
            animP.SetBool("isTalking", true);
        }
        else
        {
            animP.SetBool("isTalking", false);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);
    }
}
