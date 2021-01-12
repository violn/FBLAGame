using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Player.Props;

//Controls how the player moves
public class Move2D : MonoBehaviour
{
    public Transform MoveHere;
    public float Speed;
    public LayerMask Colliders;

    // Start is called before the first frame update
    private void Start()
    {
        MoveHere.parent = null;
    }

    // Update is called once per frame
    private void Update()
    {
        //Causes the player to move towards our MoveHere
        transform.position = Vector3.MoveTowards(transform.position, MoveHere.position, Speed * Time.deltaTime);

        //The player can only move if they're directly on move here
        if (Vector3.Distance(transform.position, MoveHere.position) <= .0f)
        {
            //Checks for the left or right input
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //Checks for collision boxes to prevent phasing through walls
                if(!Physics2D.OverlapCircle(MoveHere.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .5f, Colliders))
                {
                    //Move the player to the MoveHere
                    MoveHere.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            //Moves up if in front of a box that doesn't have a box on top of it
            //Checks for the up input
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && PlayerProps.InFront)
            {
                //Move player to MoveHere
                MoveHere.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
    }
}
