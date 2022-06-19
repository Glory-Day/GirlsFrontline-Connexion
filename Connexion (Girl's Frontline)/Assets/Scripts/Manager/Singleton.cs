using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // 객체가 소멸되었는지 아닌지 확인하기 위한 boolean 변수
        private static bool _quited;

        private static object Locked => new Object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                // 객체가 소멸해서 없는 경우 null을 반환함
                if (_quited)
                {
                    Debug.LogWarning("[Singleton] Instance '" +
                                     typeof(T) + "' already destroyed. Returning null.");
                    return null;
                }

                // 스레드 안전 (Thread Safe)
                lock (Locked)
                {
                    if (_instance != null)
                    {
                        return _instance;
                    }

                    // 인스턴스가 존재하면 가져와서 _instance에 저장함
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance != null)
                    {
                        return _instance;
                    }

                    // 인스턴스가 아직 생성되지 않았으면 생성함
                    var gameObject = new GameObject();
                    _instance = gameObject.AddComponent<T>();
                    gameObject.name = typeof(T) + " (Singleton)";

                    // 인스턴스가 소멸되지 않게 함
                    DontDestroyOnLoad(gameObject);

                    return _instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            _quited = true;
        }
        
        private void OnDestroy() 
        {
            _quited = true;
        }
    }
}
