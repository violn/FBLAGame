using UnityEngine;

//Changes the opacity of the player when the up or down key is pressed
//This is used more for testing purposes for a mechanic later in development
public class ChangeOpacity : MonoBehaviour
{

    private Renderer rend;

    private Color AssetColor = new Color();

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        AssetColor.a = .5f;
    }

    // Update is called once per frame
    private void Update()
    {
    
    //Changes to half opacity when moving up
    //And the character isn't arleady in half opacity
        if (MoveUp())
        {
            rend.material.color = AssetColor;
            if (AssetColor.a == 1f)
            {
                AssetColor.a = .5f;
            }
        }
        
        //Changes to full opactity when the down key is pressed
        //And the player isn't already at full opacity
        else if (MoveDown())
        {
            rend.material.color = AssetColor;
            if (AssetColor.a != 1f)
            {
                AssetColor.a = 1f;
            }
        }
    }
    
//Gets the up input
    private static bool MoveUp()
    {
        return Input.GetAxis("Vertical") > 0;
    }
    
//Gets the down input
    private static bool MoveDown()
    {
        return Input.GetAxis("Vertical") < 0;
    }
}
