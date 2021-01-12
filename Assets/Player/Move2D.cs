using UnityEngine;
using Vector3 = UnityEngine.Vector3;
//Controls how the player moves
//Currently doesn't take in collission

public class Move2D : MonoBehaviour
{
    public Transform MoveHere;
    public float Speed;

    // Start is called before the first frame update
    private void Start()
    {
        MoveHere.parent = null;
    }

    // Update is called once per frame
    private void Update()
    {
        //Causes the player to move towards our move here
        transform.position = Vector3.MoveTowards(transform.position, MoveHere.position, Speed * Time.deltaTime);

        //The player can only move if they're directly on move here
        if (Vector3.Distance(transform.position, MoveHere.position) <= .0f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                MoveHere.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                MoveHere.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
    }
}
