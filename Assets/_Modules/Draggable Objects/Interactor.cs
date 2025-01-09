using System.Threading.Tasks;
using UnityEngine;

public class Interactor : MonoBehaviour {
    [SerializeField] private StretchAndShrink stretchAndShrink;

    private void Reset()
    {
        LoadStretchAndShrink();
    }

    private void Awake()
    {
        LoadStretchAndShrink();
    }

    private void LoadStretchAndShrink()
    {
        stretchAndShrink = GetComponent<StretchAndShrink>();
    }

    private async void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out IInteractableObject interactableObject)) {
            if (stretchAndShrink.isInteracted) return;

            stretchAndShrink.isInteracted = true;
            await stretchAndShrink.StartStretchAndShrink();
            interactableObject.Interact(gameObject);
        }
    }

   
}
