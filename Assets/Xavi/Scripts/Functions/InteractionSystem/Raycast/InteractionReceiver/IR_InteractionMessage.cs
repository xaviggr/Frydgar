using UnityEngine;

public class IR_InteractionMessage : InteractionReceiver
{
    public string txt;
    public GameObject canvas_interaction_message;
    public GameObject text_to_change;

    private void Start()
    {
        canvas_interaction_message.SetActive(false);
    }

    public override void Receive(GameObject other)
    {
        canvas_interaction_message.SetActive(true);
        if (text_to_change.GetComponent<DisplayData>() != null)
        {
            text_to_change.GetComponent<DisplayData>().UpdateValue(txt);
        }
    }

    public override void Out(GameObject other)
    {
        canvas_interaction_message.SetActive(false);
    }
}
