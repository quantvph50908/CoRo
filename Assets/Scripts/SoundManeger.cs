using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource backgroundMusic; // Nhạc nền
    public Toggle toggleSound; // Toggle bật/tắt âm thanh
    public Slider sliderVolume; // Slider chỉnh âm lượng

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Kiểm tra xem toggleSound và sliderVolume có được gán hay không
        if (toggleSound == null || sliderVolume == null)
        {
            Debug.LogError("Toggle hoặc Slider chưa được gán trong Inspector!");
            return;
        }

        // Lấy trạng thái âm thanh từ PlayerPrefs
        bool isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        float volume = PlayerPrefs.GetFloat("Volume", 1.0f);

        // Cập nhật Toggle và Slider theo dữ liệu đã lưu
        toggleSound.isOn = isSoundOn;
        sliderVolume.value = volume;

        // Áp dụng các cài đặt
        UpdateSound();
        UpdateVolume();

        toggleSound.onValueChanged.AddListener(delegate { UpdateSound(); });
        sliderVolume.onValueChanged.AddListener(delegate { UpdateVolume(); });


    }

    // Hàm bật/tắt âm thanh
    public void UpdateSound()
    {
        bool isOn = toggleSound.isOn;
        backgroundMusic.mute = !isOn; // Tắt nhạc nếu toggle bị tắt

        // Lưu trạng thái
        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Hàm chỉnh âm lượng
    public void UpdateVolume()
    {
        float volume = sliderVolume.value;
        backgroundMusic.volume = volume;

        // Lưu âm lượng
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
