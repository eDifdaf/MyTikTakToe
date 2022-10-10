namespace TTT_private;
public enum FieldState {
    Player1,
    Player2,
    Init
}
public class Field:Point {
    public bool IsFocus;
    public bool WasFocused;
    
    public FieldState EState { get; set; }
    
    public Field(int XCoord, int YCoord) {
        EState = FieldState.Init;
        this.XCoord = XCoord;
        this.YCoord = YCoord;
        IsFocus = false;
        WasFocused = false;
    }
}