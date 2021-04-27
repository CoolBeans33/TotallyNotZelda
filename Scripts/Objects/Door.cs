using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DoorType
{
    key,
    item,
    button
}

public class Door : MonoBehaviour
{
    public bool open = false;
    public DoorType thisDoorType;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public int count = 0;
    [SerializeField] private int reqCount;

    public void Open()
    {
        if(count == reqCount)
        {
            doorSprite.enabled = false;
            open = true;
            physicsCollider.enabled = false;
        }
    }

    public void Close()
    {
        //Turn off the door's sprite renderer
        doorSprite.enabled = true;
        //set open to true
        open = false;
        //turn off the door's box collider
        physicsCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == reqCount)
        {
            Open();
        }
    }
}
