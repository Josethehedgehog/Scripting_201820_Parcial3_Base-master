using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    GameController t;

    // Use this for initialization
    private void Start()
    {
        if (timerText == null)
        {
            enabled = false;
        }

        t = GetComponent<GameController>();

    }

    // Update is called once per frame
    private void Update()
    {
        timerText.text = Mathf.Round(t.CurrentGameTime).ToString();
        //TODO: Set text from GameController
    }
}