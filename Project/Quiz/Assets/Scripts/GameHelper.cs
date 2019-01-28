using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour {
    public GameObject Panel;
    public GameObject StartButton;
    public GameObject GameName;
    public GameObject Button;


	// Use this for initialization
	void Start () {
		
	}	

    public void PanelSlideOut()
    {
        if (!Panel.GetComponent<Animator>().enabled) Panel.GetComponent<Animator>().enabled = true;
        else Panel.GetComponent<Animator>().SetTrigger("out");

        if (StartButton.gameObject.activeSelf == true)
        {
            StartCoroutine(StartButtonDelete());
        }

        StartCoroutine(AnswerIn());
    }

    IEnumerator StartButtonDelete()
    {
        yield return new WaitForSeconds(1.5f);
        StartButton.gameObject.SetActive(false);
        GameName.gameObject.SetActive(false);
    }

    IEnumerator AnswerIn()
    {
        yield return new WaitForSeconds(3f);
        if (!Button.gameObject.activeSelf) Button.gameObject.SetActive(true);
        Button.GetComponent<Animator>().SetTrigger("in");
    }


}
