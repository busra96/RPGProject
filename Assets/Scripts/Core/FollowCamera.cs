using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform Target;

        void LateUpdate()
        {
            transform.position = Target.position;
        }
    }
}
