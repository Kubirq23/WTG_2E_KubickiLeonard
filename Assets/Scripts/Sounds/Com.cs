
using UnityEngine;
using UnityEngine.UIElements;

public class Com : MonoBehaviour //co to jest?
{
    public static bool mc = true; //co to jest?// jesli wylonczono dziwienk to ten skrypt zapamientuje to i mowi nastempnej scenie
    public static int[] SpritesColor = {0,0,0,0,0,Random.Range(0,14),Random.Range(0,14)};
    public static void SpriteChange(int pos,int state){
        SpritesColor[pos] = state;
    } 
    public static Color32 color(int kto){
        var color = SpritesColor[kto];
        switch(color){
            case 0:
                return new Color32(255,255,255,255);
            case 1:
                return new Color32(255,196,0,255);//ffc400
            case 2:
                return new Color32(162,255,0,255);//a2ff00
            case 3:
                return new Color32(72,255,0,255);//48ff00
            case 4:
                return new Color32(0,255,149,255);//00ff95
            case 5:
                return new Color32(0,255,225,255);//00ffe1
            case 6:
                return new Color32(0,157,255,255);//009dff
            case 7:
                return new Color32(0,13,255,255);//000dff
            case 8:
                return new Color32(255,0,234,255);
            case 9:
                return new Color32(162,0,255,255);
            case 10:
                return new Color32(255,0,234,255);
            case 11:
                return new Color32(255,0,111,255);
            case 12:
                return new Color32(255,0,13,255);
            case 13:
                return new Color32(255,85,0,255);
            case 14:
                return new Color32(255,128,0,255);
                    
        }
        return new Color32(255,255,255,255);
        
    }

}
