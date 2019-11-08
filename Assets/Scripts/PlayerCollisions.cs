using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
    }
}
