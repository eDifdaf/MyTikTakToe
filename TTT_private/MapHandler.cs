namespace TTT_private; 

public class MapHandler {
    public static FieldState Player = FieldState.Player1;

    public static void CreateMap(Field[,] map) {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                map[i, j] = new Field(i, j);
            }
        }

        map[1, 1].IsFocus = true;
    }

    public static bool UpdateFrame(Field[,] map, ref string drawMap) {
            
        drawMap = DrawToScreen(map);
        bool win = WinCon.CheckForWin(map);
            
        if (win) {
            return true;
        }
            
        return false;
    }

    private static string DrawToScreen(Field[,] map) {
        string drawMap = "";
        //go through every line
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                
                #region focus_blinking_effect

                if (!map[i, j].WasFocused) {
                    if (!map[i, j].IsFocus) {
                        switch (map[i, j].EState) {
                            case FieldState.Init:
                                drawMap += "      |";
                                break;
                            case FieldState.Player1:
                                drawMap += "  X   |";
                                break;
                            case FieldState.Player2:
                                drawMap += "  O   |";
                                break;
                            default:
                                Console.WriteLine("Wie??????????????????");
                                break;
                        }

                        map[i, j].WasFocused = false;
                    }
                    else {
                        map[i, j].WasFocused = true;
                        drawMap += " #### |";
                    }
                }
                else {
                    switch (map[i, j].EState) {
                        case FieldState.Init:
                            drawMap += "      |";
                            break;
                        case FieldState.Player1:
                            drawMap += "  X   |";
                            break;
                        case FieldState.Player2:
                            drawMap += "  O   |";
                            break;
                        default:
                            Console.WriteLine("Wie??????????????????");
                            break;
                    }

                    map[i, j].WasFocused = false;
                }

                #endregion
            }
                
            drawMap += "\n -------------------- \n";
        }

        return drawMap;
    }
        
    public static void SetField(Field[,] map, int playerX, int playerY) {
        if (map[playerX, playerY].EState == FieldState.Init) {
                
            //sets Field to current player
            map[playerX, playerY].EState = Player;
                
            //sets new current player
            if (Player == FieldState.Player1) {
                Player = FieldState.Player2;
            }
            else {
                Player = FieldState.Player1;
            }
        }
    }
        
    private static Point Coordfinder(Field[,] map) {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                if (map[i, j].IsFocus) {
                    return new Point {XCoord = map[i, j].XCoord, YCoord = map[i, j].YCoord};
                }
            }
        }

        return new Point {XCoord = 0, YCoord = 0};
    }
        
    public static void KeyHandler(Field[,] map, ConsoleKey key) {
        Point tempPoint;
        tempPoint = Coordfinder(map);
        int x = tempPoint.XCoord;
        int y = tempPoint.YCoord;

        switch (key) {
            case ConsoleKey.LeftArrow:
                try {
                    map[x, y].IsFocus = false;
                    map[x, y].WasFocused = false;
                    map[x, y - 1].IsFocus = true;
                }
                catch (Exception) {
                    map[x, y].IsFocus = true;
                }

                break;
            case ConsoleKey.RightArrow:
                try {
                    map[x, y].IsFocus = false;
                    map[x, y].WasFocused = false;
                    map[x, y + 1].IsFocus = true;
                }
                catch (Exception) {
                    map[x, y].IsFocus = true;
                }

                break;
            case ConsoleKey.UpArrow:
                try {
                    map[x, y].IsFocus = false;
                    map[x, y].WasFocused = false;
                    map[x - 1, y].IsFocus = true;
                }
                catch (Exception) {
                    map[x, y].IsFocus = true;
                }

                break;
            case ConsoleKey.DownArrow:
                try {
                    map[x, y].IsFocus = false;
                    map[x, y].WasFocused = false;
                    map[x + 1, y].IsFocus = true;
                }
                catch (Exception) {
                    map[x, y].IsFocus = true;
                }

                break;
            case ConsoleKey.Enter:
                SetField(map, x, y);
                break;
        }
    }
        
    /*
    public static FieldState WhoWon() {
        return FieldState.Player1;
    }
    */
}