using GameFramework;
using System.Collections;
using UltEvents;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementWithClick : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Transform moveIndicator;

    private Transform _previousSelected;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.layer == Layers.Selectable)
                {
                    _previousSelected = hit.transform;
                    _previousSelected.GetComponent<OptionalBoolEventHolder>().Invoke(true);
                }
                else if (_previousSelected)
                {
                    _previousSelected.GetComponent<OptionalBoolEventHolder>().Invoke(false);

                    moveIndicator.gameObject.SetActive(true);
                    moveIndicator.position = hit.point + Vector3.up * 0.025f;
                    moveIndicator.rotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);

                    StopCoroutine(DisableMarker());
                    StartCoroutine(DisableMarker());
                }
                else
                {
                    moveIndicator.position = hit.point + Vector3.up * 0.025f;
                    moveIndicator.rotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);
                    moveIndicator.gameObject.SetActive(true);

                    StopCoroutine(DisableMarker());
                    StartCoroutine(DisableMarker());
                }

                agent.SetDestination(hit.point);
            }
          
        }
    }

    private IEnumerator DisableMarker()
    {
        yield return new WaitForSeconds(1.5f);

        moveIndicator.gameObject.SetActive(false);
    }
}
