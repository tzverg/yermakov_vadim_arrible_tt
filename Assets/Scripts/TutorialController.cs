using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tutorialInfoGO;
    [SerializeField] private float secondForHide;
    [SerializeField] private string[] tutorialInfos;

    private Color defaultInfoColor;
    private Color currentInfoColor;
    private Text textInfo;
    private bool isShowed;

    private float currentTime;
    [SerializeField] private int currentInfoID;

    void Awake()
    {
        textInfo = tutorialInfoGO?.GetComponent<Text>();
        tutorialInfos = new string [] 
        {
            "Use WASD for motion",
            "Use SPACE for jumping" ,
            "Use E for interaction",
            "Hold Right Click for mouse orbiting"
        };
        currentInfoID = 0;
        defaultInfoColor = textInfo.color;
        ShowTutorialInfo();
    }

    public void ShowInterractionInfo()
    {
        textInfo.text = "Use E for interaction";

        currentTime = secondForHide;
        currentInfoColor = defaultInfoColor;

        tutorialInfoGO?.SetActive(true);
        isShowed = true;
    }

    private void ShowTutorialInfo()
    {
        textInfo.text = tutorialInfos[currentInfoID];
        ChangeCurrentInfoID();

        currentTime = secondForHide;
        currentInfoColor = defaultInfoColor;

        tutorialInfoGO?.SetActive(true);
        isShowed = true;
    }

    private void ChangeCurrentInfoID()
    {
        currentInfoID++;
        if (currentInfoID == tutorialInfos.Length)
        {
            currentInfoID = 0;
        }
    }

    void Update()
    {
        if (isShowed)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
            {
                currentTime = 0F;
                tutorialInfoGO?.SetActive(false);
                isShowed = false;
            }
            else
            {
                currentInfoColor = new Color(currentInfoColor.r, currentInfoColor.g, currentInfoColor.b, currentTime / secondForHide);
                textInfo.color = currentInfoColor;
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!isShowed)
            {
                ShowTutorialInfo();
            }
        }
    }
}
