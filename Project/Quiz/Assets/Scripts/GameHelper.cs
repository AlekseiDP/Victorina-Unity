using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour {
    public GameObject Panel;                                       //Объект общей панели
    public GameObject StartButton;                                 //Кнопка старта
    public GameObject GameName;                                    //Текст названия игры

    public GameObject AnswerButton1;                               //Кнопка ответа      
    public Text AnswerText1;                                       //Текст ответа
    public GameObject AnswerButton2;                               //Кнопка ответа      
    public Text AnswerText2;                                       //Текст ответа
    public GameObject AnswerButton3;                               //Кнопка ответа      
    public Text AnswerText3;                                       //Текст ответа

    public Text QuestionText;                                      //Текст вопроса

    public Question[] Questions;                                   //Массив объектов класса Question
    public List<object> qList;                                     //Список, который хранит вопросы




	// Use this for initialization
	void Start () {
		
	}	

    //метод вызываемый кнопкой старта
    public void ClickOn()
    {
        if (!Panel.GetComponent<Animator>().enabled) Panel.GetComponent<Animator>().enabled = true;
        else Panel.GetComponent<Animator>().SetTrigger("out");

        if (StartButton.gameObject.activeSelf == true)
        {
            StartCoroutine(StartButtonDelete());
        }

        StartCoroutine(QuestionGenerator());        
    }

    //метод удаления кнопки старта и названия игры
    IEnumerator StartButtonDelete()
    {
        yield return new WaitForSeconds(1.5f);
        StartButton.gameObject.SetActive(false);
        GameName.gameObject.SetActive(false);
        yield break;
    }
    
    IEnumerator AnswerIn(Question q)
    {
        yield return new WaitForSeconds(1.5f);
        if (!AnswerButton1.gameObject.activeSelf) AnswerButton1.gameObject.SetActive(true);
        AnswerText1.text = q.answers[0];
        AnswerButton1.GetComponent<Animator>().SetTrigger("in");

        yield return new WaitForSeconds(0.5f);
        if (!AnswerButton2.gameObject.activeSelf) AnswerButton2.gameObject.SetActive(true);
        AnswerText2.text = q.answers[1];
        AnswerButton2.GetComponent<Animator>().SetTrigger("in");

        yield return new WaitForSeconds(0.5f);
        AnswerText3.text = q.answers[2];
        if (!AnswerButton3.gameObject.activeSelf) AnswerButton3.gameObject.SetActive(true);
        AnswerButton3.GetComponent<Animator>().SetTrigger("in");

        yield break;
    }

    IEnumerator AnswerOut()
    {
        yield return new WaitForSeconds(1f);                
        AnswerButton1.GetComponent<Animator>().SetTrigger("out");

        yield return new WaitForSeconds(0.5f);        
        AnswerButton2.GetComponent<Animator>().SetTrigger("out");

        yield return new WaitForSeconds(0.5f);        
        AnswerButton3.GetComponent<Animator>().SetTrigger("out");

        yield return new WaitForSeconds(0.5f);
        if (AnswerButton1.gameObject.activeSelf) AnswerButton1.gameObject.SetActive(false);
        if (AnswerButton2.gameObject.activeSelf) AnswerButton2.gameObject.SetActive(false);
        if (AnswerButton3.gameObject.activeSelf) AnswerButton3.gameObject.SetActive(false);

        ClickOn();

        yield break;
    }

    public void AnswerButtonClickOn()
    {
        StartCoroutine(AnswerOut());
    }

    IEnumerator QuestionGenerator()
    {
        yield return new WaitForSeconds(1.5f);
        qList = new List<object>(Questions);
        Question crntQ = qList[Random.Range(0, qList.Count)] as Question;
        QuestionText.text = crntQ.question;

        StartCoroutine(AnswerIn(crntQ));

        yield break;
    }




}

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers = new string[3];
}

