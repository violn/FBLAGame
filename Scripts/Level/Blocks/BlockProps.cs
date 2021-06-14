using UnityEngine;

public class BlockProps : MonoBehaviour
{
    public enum Type
    {
        regular,
        final
    }

    public Type blockType;
    public static Vector3 defaultPosition;

    public void Awake()
    {
        defaultPosition = gameObject.transform.position;
    }
}
