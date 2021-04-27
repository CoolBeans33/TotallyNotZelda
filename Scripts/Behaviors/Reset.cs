using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform ParentModel;
    private List<Vector3> originalPosList;

    // Start is called before the first frame update
    void Start()
    {
        // list generation
        originalPosList = new List<Vector3>();
        // Store the initial position of the child object in the list
        foreach (Transform child in ParentModel)
        {
            originalPosList.Add(child.transform.localPosition);
        }
    }
    public void AllPosiReset()
    {
        // reset the position of the child objects
        int i = 0;
        foreach (Transform child in ParentModel)
        {
            child.transform.localPosition = originalPosList[i];
            if(child.gameObject.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static && child.gameObject.CompareTag("Block"))
            {
                child.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }

            if (child.gameObject.CompareTag("Door"))
            {
                child.gameObject.GetComponent<Door>().count--;
            }
            if (child.gameObject.CompareTag("Switches"))
            {
                child.gameObject.GetComponent<Switch>().active = false;
            }
            i++;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Is it the player?
        if (other.CompareTag("Player"))
        {
            AllPosiReset();
        }
    }
}
