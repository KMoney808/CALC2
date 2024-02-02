using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class MathProblem2 : MonoBehaviour
{
    //allow drag-drop of TEXTMESHPRO objects in canvas
    public TextMeshProUGUI firstNumber;
    public TextMeshProUGUI secondNumber;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;

    //enter the range of numbers for the math problems
    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int firstNumberInProblem;
    int secondNumberInProblem;
    int answerOne;
    int answerTwo;
    int displayRandomAnswer;
    int randomAnswerPlacement;
    public int currentAnswer;
    public TextMeshProUGUI rightOrWrong_Text;

    //call the function here so it will display in game
    private void Start()
    {
        DisplayMathProblem(); //this will show the math problem in UI
    }
    public void DisplayMathProblem()
    {
        //generate a random number as the first and second numbers
        randomFirstNumber = Random.Range(0, easyMathList.Count + 1);
        randomSecondNumber = Random.Range(0, easyMathList.Count + 1);

        //assessing your first and second number
        firstNumberInProblem = randomFirstNumber;
        secondNumberInProblem = randomSecondNumber;

        //this is where you can enter addition, subtraction, multiplication, division
        answerOne = firstNumberInProblem + secondNumberInProblem; //change the signs / * +                                                        
        // answerOne will always be the right answer


        //this display the wrong answer
        //answerTwo will always be the wrong answer
        displayRandomAnswer = Random.Range(0, 2);
        if (displayRandomAnswer == 0)
        {
            answerTwo = answerOne + Random.Range(1, 5);
        }
        else
        {
            answerTwo = answerOne - Random.Range(1, 5);
        }

        firstNumber.text = "" + firstNumberInProblem;
        secondNumber.text = "" + secondNumberInProblem;

        //buttons with correct and wrong answers
        randomAnswerPlacement = Random.Range(0, 2);
        if(randomAnswerPlacement == 0) //this flips the answer buttons
        {
            answer1.text = "" + answerOne;
            answer2.text = "" + answerTwo;
            currentAnswer = 0;  //display left answer
        }
        else
        {
            answer1.text = "" + answerTwo;
            answer2.text = "" + answerOne;
            currentAnswer = 1;  //display right answer
        }

        
    }

    //have the buttons respond on click
    public void ButtonAnswer1()
    {
        if (currentAnswer == 0)
        {
            rightOrWrong_Text.enabled = true;
            rightOrWrong_Text.color = Color.green;
            rightOrWrong_Text.text = ("Correct");
            Invoke("TurnOffText", 1);
        }
        else //if other button was selected then red 
        {
            rightOrWrong_Text.enabled = true;
            rightOrWrong_Text.color = Color.red;
            rightOrWrong_Text.text = ("Try Again!");
            Invoke("TurnOffText", 1);
        }
    }

    public void ButtonAnswer2()
    {
        if (currentAnswer == 1)
        {
            rightOrWrong_Text.enabled = true;
            rightOrWrong_Text.color = Color.green;
            rightOrWrong_Text.text = ("Correct!");
            Invoke("TurnOffText", 1);
        }
        else
        {
            rightOrWrong_Text.enabled = true;
            rightOrWrong_Text.color = Color.red;
            rightOrWrong_Text.text = ("Try Again!");
            Invoke("TurnOffText", 1);
        }
    }

    public void TurnOffText()
    {
        if(rightOrWrong_Text != null)
            rightOrWrong_Text.enabled=false; //turnoff the message
        DisplayMathProblem(); //generate new math problem again
    }



}




