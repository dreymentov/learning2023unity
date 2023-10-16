using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed = 50f;
    public float speedsCam = 50f;
    public float speedRotate = 50f;

    public bool isDialog = false;

    public GameObject player;

    public Transform go_MovingForCamera;

    public Rigidbody rb;

    public Animator animP;

    private float X;
    private float eulerY;

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

        if (Input.GetAxis("Horizontal1") != 0 | Input.GetAxis("Vertical") != 0)
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

        if(Input.GetKeyUp("f"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            X = Input.GetAxis("Mouse X") * speedsCam * Time.deltaTime;
            eulerY = (go_MovingForCamera.transform.rotation.eulerAngles.y + X) % 360;
            go_MovingForCamera.transform.rotation = Quaternion.Euler(0, eulerY, 0); ;
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Input.GetAxis("Horizontal1") * speed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);
        rb.rotation = Quaternion.Euler(0, rb.transform.rotation.eulerAngles.y + (Input.GetAxis("Horizontal") * speedRotate * Time.fixedDeltaTime), 0);
    }
}
