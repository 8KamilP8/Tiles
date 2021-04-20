public interface IDisplay<T> {
    void UpdateDisplay();
    void ConnectWithValue(ref T value);
    void UpdateDisplay(T value);
}
