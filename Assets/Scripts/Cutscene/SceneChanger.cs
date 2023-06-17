using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void MoveToScene(int s_id)
    {
        SceneManager.LoadScene(s_id);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
