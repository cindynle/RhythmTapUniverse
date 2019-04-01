using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;
    public bool failed=false;

    public bool hasStarted;

  //Testing physics vector forces
  //public GameObject beat;
  //private Rigidbody rigidbodys; 

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;

     //Testing physics vector forces
     // rigidbodys = beat.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown) { 
            hasStarted = true;
            }

        }
        else if (hasStarted)

        {
          //Original note sequence transform code, the problem is that transform position ignores collider and
          //makes beats drop below playable field

          // transform.position -= new Vector3(0f, 0.009f, beatTempo * Time.deltaTime);

        //Testing physics vector forces which do not ignore the collider. Probably the best solution to this, just haven't
        //gotten the right numbers in

        //   Vector3 tempVect = new Vector3(10, 10, 10);
        //  tempVect = tempVect.normalized * beatTempo * Time.deltaTime;
        //  beat.MovePosition(transform.position + tempVect);
        //rigidbodys.AddForce(0, 0, beatTempo * Time.deltaTime);
        } 
    
        if (failed)
        {
            gameObject.SetActive(false);
        }

    }
}
