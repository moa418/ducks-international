using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject SingleGateUI;
    [SerializeField] private StageObject stage;

    private int gateCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gate g;
        int qID = gameObject.GetComponent<PlayerMovement>().qubitID;
        string coll_tag = collision.gameObject.tag;
        Debug.Log(coll_tag);
        if((coll_tag == "CX-Gate") || (coll_tag == "CZ-Gate")) {
            Debug.Log("Add gate");
            gateCount++;
            AddDoubleGateUIElement(collision.gameObject);
            g = new Gate(collision.gameObject.tag, qID - 1, qID);
            stage.gate_list.Add(g);
            Debug.Log(g.ToString());
        } else if((coll_tag == "Water") || (coll_tag == "Lava") || (coll_tag == "Measure")) {
            Debug.Log("Execute measure");
            gateCount++;
            AddSingleGateUIElement(collision.gameObject);
            g = new Gate(collision.gameObject.tag, qID);
            stage.gate_list.Add(g);
            Debug.Log(g.ToString());
            stage.Measure();
        } else {
            Debug.Log("Add gate");
            gateCount++;
            AddSingleGateUIElement(collision.gameObject);
            g = new Gate(collision.gameObject.tag, qID);
            stage.gate_list.Add(g);
            Debug.Log(g.ToString());
        }
        Destroy(collision.gameObject);
    }

    void AddSingleGateUIElement(GameObject gate_obj)
    {
        Sprite gate_sprite = gate_obj.GetComponent<SpriteRenderer>().sprite;
        Vector2 pos = new Vector2(-280 + gateCount*50,-50);
        GameObject uiElement = Instantiate(SingleGateUI, pos, Quaternion.identity);
        uiElement.transform.SetParent(GameObject.Find("Canvas").transform, false);
        Image gateImage = uiElement.GetComponent<Image>();
        gateImage.sprite = gate_sprite;
    }

    void AddDoubleGateUIElement(GameObject gate_obj) {
        // stub
    }
}
