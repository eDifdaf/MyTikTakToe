namespace TTT_private;

public class WinCon {
    public static bool CheckForWin(Field[,] map) {
        if (CheckForWinHor(map)) {
            return true;
        }

        if (CheckForWinVert(map)) {
            return true;
        }
        
        if (CheckForWinDia(map)) {
            return true;
        }

        return false;
    }

    private static bool CheckForWinHor(Field[,] map) {
        for (int i = 0; i < map.GetLength(0); i++) {
            if (map[i, 0].EState != FieldState.Init && map[i, 1].EState != FieldState.Init &&
                map[i, 2].EState != FieldState.Init) {
                if (map[i, 0].EState == map[i, 1].EState && map[i, 1].EState == map[i, 2].EState) {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool CheckForWinVert(Field[,] map) {
        for (int i = 0; i < map.GetLength(0); i++) {
            if (map[i, 0].EState != FieldState.Init && map[i, 1].EState != FieldState.Init &&
                map[i, 2].EState != FieldState.Init) {
                if (map[0, i].EState == map[1, i].EState && map[1, i].EState == map[2, i].EState) {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool CheckForWinDia(Field[,] map) {
        if ((map[0, 0].EState != FieldState.Init && map[1, 1].EState != FieldState.Init &&
             map[2, 2].EState != FieldState.Init) || (map[2, 0].EState != FieldState.Init &&
                                                      map[1, 1].EState != FieldState.Init &&
                                                      map[0, 2].EState != FieldState.Init)) {
            if (map[0, 0].EState == map[1, 1].EState && map[1, 1].EState == map[2, 2].EState) {
                return true;
            }

            if (map[2, 0].EState == map[1, 1].EState && map[1, 1].EState == map[0, 2].EState) {
                return true;
            }
            
        }

        return false;
    }
}