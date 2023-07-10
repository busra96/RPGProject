using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     MoveToCursor();
        // }

        UpdateAnimator();
    }

 

    public void MoveTo(Vector3 destination)
    {
        _navMeshAgent.destination = destination;
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = _navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        _animator.SetFloat("forwardSpeed", speed);
    }
}
