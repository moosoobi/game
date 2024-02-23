using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cart : MonoBehaviour
{

    public string[] productNames;
    public int[] productPrices;
    public int index=0;
    public int TotalPrice=0;
    public TextMeshProUGUI CartName;
    public TextMeshProUGUI CartPrice;
    public TextMeshProUGUI OrderAmount;
    public TextMeshProUGUI OrderTotalPrice;


    void Start()
    {
    }

    public void AddItem(int number)
    {
        if(number==1){
            productNames[index]="jack coke";
            productPrices[index]=80000;
        }else if(number==2){
            productNames[index]="Xrated tonic";
            productPrices[index]=90000;
        }else if(number==3){
            productNames[index]="mojito";
            productPrices[index]=70000;
        }
        else if(number==4){
            productNames[index]="blue hawaii";
            productPrices[index]=70000;
        }
        else if(number==5){
            productNames[index]="kahlua milk";
            productPrices[index]=85000;
        }
        else if(number==6){
            productNames[index]="Espresso martini";
            productPrices[index]=120000;
        }
        else if(number==7){
            productNames[index]="white russian";
            productPrices[index]=85000;
        }
        else if(number==8){
            productNames[index]="Tequlia sunrise";
            productPrices[index]=75000;
        }
        else if(number==9){
            productNames[index]="black russian";
            productPrices[index]=80000;
        }
        else if(number==10){
            productNames[index]="Illegal";
            productPrices[index]=100000;
        }
        else if(number==11){
            productNames[index]="peach crush";
            productPrices[index]=65000;
        }
        else if(number==12){
            productNames[index]="rusty nail";
            productPrices[index]=80000;
        }
        index=index+1;
        DisplayShoppingCart();
    }

    public void DisplayShoppingCart()
    {
        CartName.text = string.Join("\n", productNames);
        string productPrice = productPrices[index-1].ToString();
        CartPrice.text += productPrice;
        CartPrice.text += "\n";
        OrderAmount.text=index.ToString();
        TotalPrice+=productPrices[index-1];
        OrderTotalPrice.text=TotalPrice.ToString();
        
            
    }
}
