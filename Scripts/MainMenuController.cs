using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(){
        //Parse converts a string into an integer like typecasting in cpp
                                          //*right below is ued which button is pressed*//
       int SelectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
      
      GameManager.instance.CharIndex=SelectedCharacter;
       SceneManager.LoadScene("Gameplay");
    }

    
}
