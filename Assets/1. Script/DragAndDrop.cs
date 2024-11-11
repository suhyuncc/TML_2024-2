using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Element
{
    Null = 0,
    Air = 1,
    Earth = 2,
    Water = 3,
    Fire = 4,
}

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 landPosition;
    [SerializeField]
    private Vector3 InitPosition;


    public bool Onspell;

    private GameObject spell;
    public Element element;

    private void OnEnable()
    {
        InitPosition = transform.position;
        landPosition = InitPosition;
    }
        

    private void Awake()
    {
        Onspell = false;
    }

    private Vector3 GetmousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
        mousePosition = Input.mousePosition - GetmousePos();
    }

    private void OnMouseDrag()
    {
        Debug.Log("Drag");
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

    }

    private void OnMouseUp()
    {
        Debug.Log("Ip");
        transform.position = InitPosition;
    }

    private void OnTriggerExit(Collider other)
    {
        landPosition = InitPosition;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spell"))
        {
            Onspell = true;
            spell = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Onspell = false;
    }

    public void ReturnPos()
    {
        transform.rotation = Quaternion.identity;
        transform.position = InitPosition;
    }
}
