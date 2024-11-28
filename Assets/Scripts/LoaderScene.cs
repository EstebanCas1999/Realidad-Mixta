using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Extensions.SceneTransitions;
using Microsoft.MixedReality.Toolkit.SceneSystem;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoaderScene : MonoBehaviour
{
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
}