using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Reset : MonoBehaviour
{
   public string sceneNameother;
   public string sceneNameother2;


   public void reset()
   {
      SceneManager.LoadScene(sceneName: "Game_TPP Asset");
   }
    
   public void Scene()
   {
      SceneManager.LoadScene(sceneName:"Menugame");
   }
   
   public void SceneN()
   {
      SceneManager.LoadScene(sceneNameother);
   }

    public void SceneS()
   {
      SceneManager.LoadScene(sceneNameother2);
   }

   public void ExitBtn()
    {
        Application.Quit();
    }
}
