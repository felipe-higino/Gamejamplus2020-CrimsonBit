using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCinematic : MonoBehaviour
{
    
    public string scene;
    public GameObject fade;
    public void CallScene(){
        SceneManager.LoadScene(scene);
    }
    void Update()
    {
       if(Input.anyKeyDown){
           fade.SetActive(true);
            Invoke("CallScene",1.2f);
           enabled = false;
       } 
    }
}
