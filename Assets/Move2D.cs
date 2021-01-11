using UnityEngine;
using Vector3 = UnityEngine.Vector3;

//A controller that allows the character to move
//NOTE: in this game the charater movement has to be restricted somewhat
//As the player will be moving through a grid but the frid won't be seen
//This is the end for the psuedo-code as this script is unfinished
public class Move2D : MonoBehaviour
{
    private static float distance = 7f;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movement = new Vector3(0f, 0f, 0f);
        if(MoveLeft())
        {
            movement.x = distance;
            transform.position += movement * Time.deltaTime;
        }

        else if(MoveRight())
        {
            movement.x = distance * -1;
            transform.position += movement * Time.deltaTime;
        }
    }

    private static bool MoveLeft()
    {
        return Input.GetAxis("Horizontal") > 0;
    }

    private static bool MoveRight()
    {
        return Input.GetAxis("Horizontal") < 0;
    }
}
