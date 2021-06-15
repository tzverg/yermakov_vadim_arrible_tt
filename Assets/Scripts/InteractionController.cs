using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] protected GameObject interactionObject;
    [SerializeField] protected TutorialController tutorialC;

    private bool waitForInterraction;

    private void Awake()
    {
        waitForInterraction = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        tutorialC?.ShowInterractionInfo();
        waitForInterraction = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        waitForInterraction = false;
    }

    protected virtual void Interact() { }

    private void Update()
    {
        if (waitForInterraction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }
}