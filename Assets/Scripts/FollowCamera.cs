using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Target;

    void Update()
    {
        transform.position = Target.position;
    }
}
