using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static EventDefine;

public class TutorialDynamic : MonoBehaviour
{
    [SerializeField] private GameObject drag;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject mouseCursor;
    [SerializeField] private GameObject tutorialDynamicPanel;
    [SerializeField] private float duration = 2f;
    [SerializeField] private float display = -3f;

    private void Start()
    {
        TutorialDynamicController.Instance.DisableObjects();
        mouseCursor.transform.position = new Vector3(drag.transform.position.x, drag.transform.position.y, display);
        StartCursorMovement();
    }

    private async void StartCursorMovement()
    {
        while (drag != null && drag.activeInHierarchy)
        {
            mouseCursor.GetComponent<SpriteRenderer>().sortingOrder = drag.GetComponent<SpriteRenderer>().sortingOrder + 1;

            await mouseCursor.transform.DOMove(target.transform.position, duration)
                .SetEase(Ease.InOutQuad) 
                .AsyncWaitForCompletion(); 

            if (drag == null || !drag.activeInHierarchy)
                break; 

            mouseCursor.transform.position = new Vector3(drag.transform.position.x, drag.transform.position.y, display);
        }

        TutorialDynamicController.Instance.EnableObjects();

        if (tutorialDynamicPanel != null && tutorialDynamicPanel.activeInHierarchy)
            tutorialDynamicPanel.SetActive(false);
    }

}
