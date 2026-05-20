using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCar : MonoBehaviour
{
    public string CarDriveScene = "CarDriveScene";

    public void LoadCarScene()
    {
        SceneManager.LoadScene(CarDriveScene);
    }
}