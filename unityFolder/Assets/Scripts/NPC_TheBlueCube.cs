using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_TheBlueCube : MonoBehaviour
{
    public TMP_Text nameNPCText;
    public TMP_Text dialogueText;

    public RectTransform dialogePanel;

    public string[] dialoges;

    public int typingSpeed = 1;

    public int idString;

    private bool isDialog = false;

    private bool TakePoint = false;

    public List<PotionData> playerItems;

    public Sprite[] playerSlots;

    public PotionData potionReward;

    public RectTransform inventoryWindow;

    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;

    void Start()
    {
        dialogePanel.gameObject.SetActive(false);
        nameNPCText.text = "";
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyUp("space"))
            {
                Type(idString);

                idString++;

                if (idString > 5)
                {
                    TakePoint = true;
                    DisablePanel();
                }
            }
        }
    }

    IEnumerator Type(int index)
    {
        dialogueText.text = "";
        foreach (char letter in dialoges[index])
        {
            dialogueText.text = dialogueText.text + letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            idString = 0;
            isDialog = true;
            dialogePanel.gameObject.SetActive(true);
            nameNPCText.text = this.gameObject.name;
            dialogueText.text = "";
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            DisablePanel();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playerItems = other.GetComponent<Inventory>().items;

            playerSlots = other.GetComponent<Inventory>().slots;

            if (TakePoint)
            {
                TakePoint = false;
                other.GetComponent<Inventory>().items.Add(potionReward);
                other.GetComponent<Inventory>().AddItemToInventory(potionReward);

                var icon = new GameObject(name: "Icon");

                icon.transform.parent = itemsPanel;
                icon.AddComponent<Image>().sprite = potionReward.Icon;
            }
        }
        
    }

    private void DisablePanel()
    {
        isDialog = false;
        dialogePanel.gameObject.SetActive(false);
        idString = 0;
        nameNPCText.text = "";
        dialogueText.text = "";
    }
}
