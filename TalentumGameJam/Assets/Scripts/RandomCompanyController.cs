using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomCompanyController : MonoBehaviour {
    private void OnEnable()
    {
        generateName();
    }

    public void generateName(){
        string[] prefixName = {"Banana","Gofio","Balloon","Flower","Water","Shore","Plastic","Metal","Doggo","Survivor" };
        string[] sufixName = {"Company","Corporation","OS","SL","Enterprise","GMBH","Factory","Dojo"};
        string companyName = prefixName[Random.Range(0, prefixName.Length)] + " " + sufixName[Random.Range(0, sufixName.Length)];
        gameObject.GetComponent<Text>().text = "CONGRATULATIONS, WE ARE VERY SATISFIED WITH YOUR WORK, BUT WE STILL NEED YOUR HELP WITH " + companyName+"\n GOOD LUCK, \n POWER GUANCHES INC.";
    }
}
