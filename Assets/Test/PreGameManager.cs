
using UnityEngine;
using UnityEngine.UI;

public class PreGameManager : MonoBehaviour{
    [SerializeField]
    private Image Player1,player2,alien,alien10,alien20;
    [SerializeField]
    private Sprite[] Player,Alien,Alien10,Alien20;

    private int Choise = 0,Choise2 = 0,AilenChoise = 0,Alien10C =0,Alien20C = 0;

    public void NextSprite(int ktory){
        if(ktory == 0){
            AilenChoise++;
            if(AilenChoise  >= Alien.Length) AilenChoise =0;
            alien.sprite = Alien[AilenChoise];
            Com.SpriteChange(0,AilenChoise);
        }
        else if(ktory == 1){
            Choise++;
            if(Choise >= Player.Length) Choise = 0;
            Player1.sprite = Player[Choise];
            Com.SpriteChange(1,Choise);
        }
        else if(ktory == 2){
            Choise2++;
            if(Choise2 >= Player.Length) Choise2 = 0;
            player2.sprite = Player[Choise2];
            Com.SpriteChange(2,Choise2);

        }
        else if(ktory == 3){
            Alien20C++;
            if(Alien20C >= Alien20.Length) Alien20C =0;
            alien20.sprite = Alien20[Alien20C];
            Com.SpriteChange(3,Alien20C);

        }
        else if(ktory == 4){
            Alien10C++;
            if(Alien10C  >= Alien10.Length) Alien10C =0;
            alien10.sprite = Alien10[Alien10C];
            Com.SpriteChange(4,Alien10C);
        }

    }
    public void PrevSprite(int ktory){
        if(ktory == 0){
            AilenChoise--;
            if(AilenChoise  <= -1) AilenChoise =Alien.Length -1;
            alien.sprite = Alien[AilenChoise];
            Com.SpriteChange(0,AilenChoise);

        }
        else if(ktory == 1){
            Choise--;
            if(Choise <= -1) Choise = Player.Length -1;
            Player1.sprite = Player[Choise];
            Com.SpriteChange(1,Choise);

        }
        else if(ktory == 2){
            Choise2--;
            if(Choise2 <= -1) Choise2 =  Player.Length -1;
            player2.sprite = Player[Choise2];
            Com.SpriteChange(2,Choise2);

        }
        else if(ktory == 3){
            Alien20C--;
            if(Alien20C <= -1) Alien20C =  Alien20.Length -1;
            alien20.sprite = Alien20[Alien20C];
            Com.SpriteChange(3,Alien20C);

        }
        else if(ktory == 4){
            Alien10C--;
            if(Alien10C <= -1) Alien10C =  Alien10.Length -1;
            alien10.sprite = Alien10[Alien10C];
            Com.SpriteChange(4,Alien10C);

        }
    }

}
