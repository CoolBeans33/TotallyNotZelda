using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovableBlock : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private float pushWait;
    [SerializeField] private float stopWait;
    Vector3 pushFromPosition;
    bool isPushed = false;
    [SerializeField] public int value;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPushed)
        {
            //wait a small amount of time.  After that time, push.
            pushFromPosition = other.transform.position;
            StartCoroutine(pushCo());
            isPushed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPushed = false;
            StopAllCoroutines();
        }
    }

    private Vector3 LRUD(Vector3 positionOne, Vector3 positionTwo)
    {
        float diffY = positionOne.y - positionTwo.y;
        float diffX = positionOne.x - positionTwo.x;
        if (Mathf.Abs(diffY) > Mathf.Abs(diffX))
        {
            if (diffY > 0)
            {
                return new Vector3(0, 1, 0);
            }
            else
            {
                return new Vector3(0, -1, 0);
            }
        }
        else
        {
            if (diffX > 0)
            {
                return new Vector3(1, 0, 0);
            }
            else
            {
                return new Vector3(-1, 0, 0);
            }
        }
    }

    private IEnumerator pushCo()
    {
        yield return new WaitForSeconds(pushWait);
        Push(LRUD(transform.position, pushFromPosition));
    }

    void Push(Vector3 pushDirection)
    {
        myRigidbody.DOMove(transform.position + pushDirection, 0.3f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Is it the player?
        if (other.CompareTag("Switches") 
            && (other.GetComponent<Switch>().reqVal == value 
            || other.GetComponent<Switch>().optionalVal == value
            || other.GetComponent<Switch>().optionalVal2 == value
            || other.GetComponent<Switch>().optionalVal3 == value))
        {
            new WaitForSeconds(stopWait);
            this.transform.position = other.transform.position;
            this.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    
}
