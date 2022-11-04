using UnityEngine;

public class GraviyManager : MonoBehaviour
{
    public Vector3 gravityDirection;

    void Awake()
    {
        Physics2D.gravity = gravityDirection;
    }

}
