using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCompanyController : MonoBehaviour {
       
void Update()
    {
        Debug.Log(generateName());
    }
public static string generateName(){
        string[] prefixName = {"Banana","Gofio","Balloon","Flower","Water","Shore","Plastic","Metal","Doggo","Survivor" };
        string[] sufixName = {"Company","Corporation","OS","SL","Enterprise","GMBH","Factory","Dojo"};
        
        return prefixName[Random.Range(0,prefixName.Length)]+" "+sufixName[Random.Range(0,sufixName.Length)];
    }
}
