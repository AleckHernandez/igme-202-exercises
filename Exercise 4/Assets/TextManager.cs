using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> textObjs;


    public void SwitchTexts()
    {
        textObjs[0].SetActive(textObjs[1].activeSelf);
        textObjs[1].SetActive(!textObjs[0].activeSelf);
        textObjs[2].SetActive(textObjs[3].activeSelf);
        textObjs[3].SetActive(!textObjs[2].activeSelf);
    }
}
