using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject SingleGateUI;
    [SerializeField] private StageObject stage;
    [SerializeField] private int qubitID;

    private int gateCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gateCount++;
        AddSingleGateUIElement(collision.gameObject);
        Gate g = new Gate(collision.gameObject.tag, qubitID);
        stage.gate_list.Add(new Gate(collision.gameObject.tag, qubitID));
        Debug.Log(g.ToString());
        Destroy(collision.gameObject);
    }

    void AddSingleGateUIElement(GameObject gate_obj)
    {
        Sprite gate_sprite = gate_obj.GetComponent<SpriteRenderer>().sprite;
        Vector2 pos = new Vector2(-280 + gateCount*50,-50);
        GameObject uiElement = Instantiate(SingleGateUI, pos, Quaternion.identity);
        uiElement.transform.SetParent(GameObject.Find("Canvas").transform, false);
        Image gateImage = uiElement.AddComponent<Image>();
        gateImage.sprite = gate_sprite;
        // Image newImage = new Image();
        // newImage.sprite = gate_sprite;
        // Image newImage = Instantiate(   , pos, Quaternion.identity);
    }
}
