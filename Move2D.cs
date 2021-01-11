using UnityEngine;
using Vector3 = UnityEngine.Vector3;

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