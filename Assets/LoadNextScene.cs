using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public SceneAsset scene;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene.name);
    }
}
