using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject SingleGateUI;
    [SerializeField] private Sprite xgateSprite;
    [SerializeField] private StageObject stage;

    private int gateCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("X-Gate"))
        {
            Destroy(collision.gameObject);
            gateCount++;
            AddSingleGateUIElement(xgateSprite);
            stage.gate_list.Add("X-Gate");
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
}
