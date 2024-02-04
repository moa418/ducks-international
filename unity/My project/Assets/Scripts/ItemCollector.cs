using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject SingleGateUI;
    [SerializeField] private Sprite xgateSprite;
    [SerializeField] private Sprite zgateSprite;

    public List<string> duckGates = new List<string> {};

    public int gateCount;
    void Start()
    {
        gateCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("X-Gate"))
        {
            Destroy(collision.gameObject);
            gateCount++;
            AddSingleGateUIElement(xgateSprite);
            duckGates.Add("X");
        }
        else if (collision.gameObject.CompareTag("Z-Gate"))
        {
            Destroy(collision.gameObject);
            gateCount++;
            AddSingleGateUIElement(zgateSprite);
            duckGates.Add("Z");
        }

        foreach (string value in duckGates)
        {
            Debug.Log(value);
        }

    }

    void AddSingleGateUIElement(Sprite gateSprite)
    {
        Vector2 pos = new Vector2(-280 + gateCount*50,-50);
        GameObject uiElement = Instantiate(SingleGateUI, pos, Quaternion.identity);
        uiElement.transform.SetParent(GameObject.Find("Canvas").transform, false);
        Image gateImage = uiElement.GetComponent<Image>();
        gateImage.sprite = gateSprite;
        
    }

    public void EmptyCircuit()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;

        // Loop through all child objects of the canvas and destroy them
        foreach (Transform child in canvasTransform)
        if (child.name != "CircuitBackground")
        {
            if (child.name != "Button")
            {
            Destroy(child.gameObject);

            }
            // Destroy the child object
        }
    }
}
