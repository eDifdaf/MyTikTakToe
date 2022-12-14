using TTT_private;

#region epilepsywarning

Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("##############|------#####|-----\\###--|#|--####||#########|------###|-----\\#####/------\\###\\####/######################");
Console.WriteLine("##############||##########||####||####|#|######||#########||########||####||###||###########\\##/#######################");
Console.WriteLine("##############||-----#####||----/#####|#|######||#########||-----###||----/#####\\-----\\######||########################");
Console.WriteLine("##############||##########||##########|#|######||#########||########||################||#####||########################");
Console.WriteLine("##############|------#####||########--|#|--####||------###|------###||##########\\-----/######||########################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("###############||########||###/-----\\####||----\\###||\\####||###--|#|--###||\\####||####/----\\###########################");
Console.WriteLine("################\\########/###||#####||###||####||##||##\\##||#####|#|#####||##\\##||###||################################");
Console.WriteLine("################||##/\\##||###||-----||###||----/###||####\\||#####|#|#####||####\\||###||##--||##########################");
Console.WriteLine("#################\\/###\\/#####||#####||###||###\\\\###||#####||###--|#|--###||#####||####\\----/###########################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.WriteLine("#######################################################################################################################");
Console.Write("######################################################################################################################");

Thread.Sleep(500);
Console.Clear();

#endregion

#region GameStart

Field[,] map = new Field[3, 3];
MapHandler.CreateMap(map);

#endregion

#region InGame

string drawMap = "";
    bool gameEnded = true;
    bool gameWon = false;
ConsoleKey pressedKey;


while (gameEnded) {
    await Task.Run(() => {
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine(drawMap);
    });
    
    
    Task.Run(() => {
        pressedKey = Console.ReadKey().Key;
        MapHandler.KeyHandler(map, pressedKey);
    });


    await Task.Run(() => { gameWon = MapHandler.UpdateFrame(map, ref drawMap); });
    
    if (gameWon) {
        gameEnded = false;
    }
}
#endregion
if (MapHandler.Player == FieldState.Player1) {
    Console.WriteLine("Player 2 has won!");
}
else if (MapHandler.Player == FieldState.Player2) {
    Console.WriteLine("Player 1 has won!");
}
Console.ReadLine();