using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Target;

    void LateUpdate()
    {
        transform.position = Target.position;
    }
}
