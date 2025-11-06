using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance; //싱클 톤?
    public static CharacterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("characterManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }
    }

    // public Player _player; 실수로 이러게 적었는데 사용가능한가? 차이가 있나
    private Player _player;
    public Player Player
    
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
