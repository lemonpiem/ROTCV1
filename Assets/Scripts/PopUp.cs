using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 

public class PopUp : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextMeshProUGUI popupTitle;
    [SerializeField] TextMeshProUGUI popupText;

    public void Init (Transform canvas, string popupMessage, string bottontxt, Action action)
    {
        popupText.text = popupMessage;
        buttonText.text = bottontxt;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }


}
