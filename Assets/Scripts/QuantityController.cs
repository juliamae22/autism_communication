using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityController : MonoBehaviour {

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject buttonCar;
    public GameObject buttonPen;
    public GameObject buttonBall;
    public GameObject buttonDone;

    public void presser1()
    {
        button2.SetActive(false);
        button3.SetActive(false);
    }

    public void presser2()
    {
        button1.SetActive(false);
        button3.SetActive(false);
    }

    public void presser3()
    {
        button1.SetActive(false);
        button2.SetActive(false);
    }
    public void presserCar()
    {
        buttonPen.SetActive(false);
        buttonBall.SetActive(false);
    }

    public void presserBall()
    {
        buttonCar.SetActive(false);
        buttonPen.SetActive(false);
    }

    public void presserPen()
    {
        buttonCar.SetActive(false);
        buttonBall.SetActive(false);
    }

    public void presserDone()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        buttonPen.SetActive(false);
        buttonBall.SetActive(false);
        buttonCar.SetActive(false);
        buttonDone.SetActive(false);
    }
}
