using UnityEngine;
using UnityEngine.UIElements;

public class CorruptionCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static int count = 0;
    public UIDocument ui;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count < 100)
            ui.rootVisualElement.Q<Label>("CorruptionCount").text = (100 - count).ToString();
        else
            ui.rootVisualElement.Q<Label>("CorruptionCount").text = "GAME OVER";
    }

    public static void AddToCount()
    {
        count++;
    }

    public static void AddToCount(int c)
    {
        count += c;
    }
}
