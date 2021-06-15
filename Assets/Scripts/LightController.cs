public class LightController : InteractionController
{
    protected override void Interact()
    {
        interactionObject.SetActive(!interactionObject.activeSelf);
    }
}