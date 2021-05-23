using System;
using Raylib_cs;

namespace pongping
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapar ett parametrarna för fönstret som spelet kommer att ritas i och namnet av fönstret
            Raylib.InitWindow(1000, 800, "Dungeon Delver");

            //Startar en audio device för programmet
            Raylib.InitAudioDevice();

            //Skapar en "sound" variabel för ladda ljudfilen "dungeonmusic.wav"
            Sound dungeon = Raylib.LoadSound("resources/dungeonmusic.wav");

            //En string för att definera de olika "stages" som spelet går igenom såsom startmenyn, level 1 och settings menyn
            string scene = "StartMenu";

            //Sätter målet för programmets fps att vara 60 under tiden som det är på
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {

                //Gör att man inte kan trycka på någon knapp såsom "escape" för att stänga programmet
                Raylib.SetExitKey(0);

                //Gör det möjligt att använda rit-funktionerna i raylib
                Raylib.BeginDrawing();

                if (scene == "StartMenu")
                {

                    //Rektanglar för musen så att man kan registrera den i programmets fönster och för rektanglen
                    //som är knappen för att starta spelet
                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                    Rectangle newgame = new Rectangle(315, 330, 380, 80);

                    //Gör backgrunden i fönstret svart
                    Raylib.ClearBackground(Color.BLACK);
                    //ritar ut rektangeln som var definerad "newgame"
                    Raylib.DrawRectangleRec(newgame, Color.WHITE);

                    //Bools för att veta när musen är över rektangeln "newgame" och 
                    //när den vänstra musknappen har blivit nertryckt och släppt
                    bool newgameoverlap = Raylib.CheckCollisionRecs(newgame, mouserec);
                    bool mousedown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);

                    //en if sats som kollar om boolen "newgameoverlap" är true och i sådanna fall ändrar färgen på
                    //rektangeln för att indikera att man kan klicka på knappen
                    if (newgameoverlap)
                    {
                        Raylib.DrawRectangleRec(newgame, Color.GRAY);
                    }
                    //Kollar om man har musen över "newgame" rektangeln och om man trycker på knappen
                    //om boolen är sann så startar spelet genom att ändra scenen
                    if (newgameoverlap && mousedown)
                    {
                        scene = "Firstlevel";
                        Raylib.PlaySound(dungeon);
                    }

                    //Ritar texten på huvudmenyn
                    Raylib.DrawText("Dungeon Delver", 200, 200, 80, Color.WHITE);
                    Raylib.DrawText("New Game", 380, 350, 50, Color.BLACK);
                }

                else if (scene == "Firstlevel")
                {

                    Raylib.ClearBackground(Color.BLACK);

                }

                Raylib.EndDrawing();
            }

            //Loadar bort ljudfilen 
            Raylib.UnloadSound(dungeon);

            //Stänger ner audio devicen som programmet använder
            Raylib.CloseAudioDevice();
        }
    }
}
