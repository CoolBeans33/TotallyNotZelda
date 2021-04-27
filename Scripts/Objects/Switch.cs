using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch: MonoBehaviour
{
    public bool active;
    //public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;
    [SerializeField] public int reqVal;
    [SerializeField] public int optionalVal;
    [SerializeField] public int optionalVal2;
    [SerializeField] public int optionalVal3;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ActivateSwitch()
    {
        active = true;
        thisDoor.count++;
        //storedValue.RuntimeValue = active;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Is it the block?
        if (other.CompareTag("Block") && 
           (other.GetComponent<MovableBlock>().value == reqVal 
           || other.GetComponent<MovableBlock>().value == optionalVal 
           || other.GetComponent<MovableBlock>().value == optionalVal2
           || other.GetComponent<MovableBlock>().value == optionalVal3))
        {
            ActivateSwitch();
        }
    }

}
