using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    public float Speed = 1f;

    public Vector3 AmountToMove = Vector3.zero;

    private Vector3 OriginalPosition;

    private bool PressureHit = false;

    private Vector3 MoveToPosition;


    // Start is called before the first frame update
    private void Start()
    {

    }

    void Awake()
    {

        OriginalPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if( PressureHit )
        {
            transform.position = Vector3.Lerp( transform.position, MoveToPosition, Time.deltaTime * Speed );

        } else {
            
            transform.position = Vector3.Lerp( transform.position, OriginalPosition, Time.deltaTime * Speed );

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if( collision.gameObject.tag == "Player" )
        {
            
            MoveToPosition = new Vector3( OriginalPosition.x + AmountToMove.x, OriginalPosition.y + AmountToMove.y, OriginalPosition.z + AmountToMove.z );

            PressureHit = true;

        }
 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if( collision.gameObject.tag == "Player" )
        {
            PressureHit = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if( collision.gameObject.tag == "Player" )
        {

            PressureHit = false;

        }

    }
}
