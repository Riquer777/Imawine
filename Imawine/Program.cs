using System.Diagnostics;
using System.Text.Json;


namespace Imawine;

class Program
{
    public static int MenuPosi;
    public static int MenuPosiMax = 7;
    public static int MenuMenu;
    //Add game data
    public static string AddGametitle      = "";
    public static string AddGamewinepath   = "";
    public static string AddGamewineprefix = "";
    public static string AddGameexepath    = "";
    public static string AddGamearg        = "";
    //user data
    public static string Home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); 
    public static string Progampath = AppContext.BaseDirectory;

    static void Main()
    {
        Directory.CreateDirectory(Path.Combine(Home,"WINGAMES"));
        Directory.CreateDirectory(Path.Combine(Home,"WINGAMES","Prefixes"));
        Directory.CreateDirectory(Path.Combine(Home,"WINGAMES","WINE"));
        if (!File.Exists(Path.Combine(Home, "WINGAMES","WINE","WINE.AppImage")))
        {
            File.Copy(Path.Combine(Progampath,"WINE","WINE.AppImage"),Path.Combine(Home,"WINGAMES","WINE","WINE.AppImage"));
        }
        MenuVisual(); 
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            MenuMovi();
            MenuVisual(); 
        }
        // ReSharper disable once FunctionNeverReturns
    }

    static void MenuMovi()
    {
        int a = InputRead();
            if (a == 3)
            {
                MenuAction();
            }

            if (a == 1)
            {
                if (MenuPosi > 0)
                {
                    MenuPosi -= 1;
                }
            }

            if (a == 2)
            {
                if (MenuPosi < MenuPosiMax)
                {
                    MenuPosi += 1;
                }
            }
        
    }

    public static void MenuAction()
    {
        switch (MenuMenu)
        {
            case 0:
                switch (MenuPosi)
                {
                    case 0:
                        MenuMenu = 2;
                        MenuPosiMax = ConfigData.Games.Count;
                        MenuPosi = 0;
                        MenuVisual();
                        Thread.Sleep(500);
                        break;
                    case 2:
                        MenuMenu = 3;
                        MenuPosiMax = ConfigData.Games.Count;
                        MenuPosi = 0;
                        MenuVisual();
                        Thread.Sleep(500);
                        break;
                    case 1:
                        MenuPosi    = 0;
                        MenuPosiMax = 7;
                        MenuMenu = 1;
                        MenuVisual();
                        Thread.Sleep(500);
                        break;
                    case 3:
                        var prefixesUnicos3 = ConfigData.Games
                            .Select(g => g.Prefix)
                            .Distinct()
                            .ToList();

                        for (int i = 0; i < prefixesUnicos3.Count; i++)
                        {
                            Console.WriteLine($"{i}. {Path.GetFileName(prefixesUnicos3[i])}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Select a prefix from the prefix folder in the WINGAMES folder by its number (ENTER AN INCORRECT NUMBER OR LETTER TO EXIT THE MENU)");

                        string input3 = Console.ReadLine() ?? "";

                        if (!int.TryParse(input3, out int index3) ||
                            index3 < 0 ||
                            index3 >= prefixesUnicos3.Count)
                        {
                            break;
                        }
                        string prefixSelecionado3 = prefixesUnicos3[index3];
                        WineKit.Run(Path.Combine(Home,"WINGAMES","WINE","WINE.AppImage"),Path.Combine(Home,"WINGAMES","Prefixes",prefixSelecionado3),"wineboot");
                        WineKit.Run(Path.Combine(Home,"WINGAMES","WINE","WINE.AppImage"),Path.Combine(Home,"WINGAMES","Prefixes",prefixSelecionado3),"winetricks","--self-update");
                        break;
                    case 4:
                        var prefixesUnicos = ConfigData.Games
                            .Select(g => g.Prefix)
                            .Distinct()
                            .ToList();

                        for (int i = 0; i < prefixesUnicos.Count; i++)
                        {
                            Console.WriteLine($"{i}. {Path.GetFileName(prefixesUnicos[i])}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Select a prefix from the prefix folder in the WINGAMES folder by its number (ENTER AN INCORRECT NUMBER OR LETTER TO EXIT THE MENU)");

                        string input = Console.ReadLine() ?? "";

                        if (!int.TryParse(input, out int index) ||
                            index < 0 ||
                            index >= prefixesUnicos.Count)
                        {
                            break;
                        }
                        string prefixSelecionado = prefixesUnicos[index];
                        WineKit.Run(Path.Combine(Home,"WINGAMES","WINE","WINE.AppImage"),Path.Combine(Home,"WINGAMES","Prefixes",prefixSelecionado),"winetricks");
                        break;
                    case 5:
                        var prefixesUnicos2 = ConfigData.Games
                            .Select(g => g.Prefix)
                            .Distinct()
                            .ToList();

                        for (int i = 0; i < prefixesUnicos2.Count; i++)
                        {
                            Console.WriteLine($"{i}. {Path.GetFileName(prefixesUnicos2[i])}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Select a prefix from the prefix folder in the WINGAMES folder by its number (ENTER AN INCORRECT NUMBER OR LETTER TO EXIT THE MENU)");

                        string input2 = Console.ReadLine() ?? "";

                        if (!int.TryParse(input2, out int index2) ||
                            index2 < 0 ||
                            index2 >= prefixesUnicos2.Count)
                        {
                            break;
                        }
                        string prefixSelecionado2 = prefixesUnicos2[index2];
                        WineKit.Run(Path.Combine(Home,"WINGAMES","WINE","WINE.AppImage"),Path.Combine(Home,"WINGAMES","Prefixes",prefixSelecionado2),"winecfg");
                        break;
                    //exit
                    case 7:
                        Environment.Exit(0);
                        break;
                }

                break;
            //game add
            case 1:
                switch (MenuPosi)
                {
                    case 0:
                        AddGame();
                        MenuPosi = 1;
                        MenuPosiMax = 6;
                        MenuMenu = 0;
                        MenuVisual();
                        Thread.Sleep(500);
                        break;
                    case 1:
                        Console.WriteLine("enter:");
                        AddGametitle = Console.ReadLine() ?? "";
                        break;
                    case 2:
                        Console.WriteLine("enter:");
                        AddGameexepath = Console.ReadLine() ?? "";
                        break;
                    case 3:
                        Console.WriteLine("enter:");
                        AddGamewineprefix = Console.ReadLine() ?? "";
                        break;
                    case 4:
                        Console.WriteLine("enter:");
                        AddGamewinepath = Console.ReadLine() ?? "";
                        break;
                    case 5:
                        Console.WriteLine("enter:");
                        AddGamearg = Console.ReadLine() ?? "";
                        break;
                    case 6:
                        MenuPosi = 1;
                        MenuPosiMax = 7;
                        MenuMenu = 0;
                        MenuVisual();
                        Thread.Sleep(500);
                        break; 
                }
                break;
            //game open
            case 2:
                if (MenuPosi <= MenuPosiMax - 1)
                {
                    Game gameselect = ConfigData.Games[MenuPosi];
                    Console.WriteLine("Use MangoHUD and GAMEMODE? [example: YN = MangoHUD on, GAMEMODE off]");
                    switch ((Console.ReadLine() ?? "").ToUpper())
                    {
                        case "YY":
                            Basic_chek_prefix(gameselect.Prefix,gameselect.Wine);
                            Launcher.RunWine(gameselect.Wine,gameselect.Exe,gameselect.Prefix,gameselect.Args,true,true);
                            break;
                        case "YN":
                            Basic_chek_prefix(gameselect.Prefix,gameselect.Wine);
                            Launcher.RunWine(gameselect.Wine,gameselect.Exe,gameselect.Prefix,gameselect.Args,true);
                            break;
                        case "NY":
                            Basic_chek_prefix(gameselect.Prefix,gameselect.Wine);
                            Launcher.RunWine(gameselect.Wine,gameselect.Exe,gameselect.Prefix,gameselect.Args,false,true);
                            break;
                        case "NN":
                            Basic_chek_prefix(gameselect.Prefix,gameselect.Wine);
                            Launcher.RunWine(gameselect.Wine,gameselect.Exe,gameselect.Prefix,gameselect.Args);
                            break;
                        default:
                            Basic_chek_prefix(gameselect.Prefix,gameselect.Wine);
                            Console.WriteLine("Enter the correct answer.");
                            break;
                    }
                }
                else
                {
                    MenuPosi = 1;
                    MenuPosiMax = 6;
                    MenuMenu = 0;
                    MenuVisual();
                    Thread.Sleep(500);
                }
                break;
            //game delete
            case 3:
                if (MenuPosi <= MenuPosiMax - 1)
                {
                    GameDelete(MenuPosi);
                    MenuPosi = 1;
                    MenuPosiMax = 6;
                    MenuMenu = 0;
                    MenuVisual();
                    Thread.Sleep(500);
                }
                else
                {
                    MenuPosi = 1;
                    MenuPosiMax = 6;
                    MenuMenu = 0;
                    MenuVisual();
                    Thread.Sleep(500);
                }
                break;
                
        }       
    }

    public static Config ConfigData = Load(Path.Combine(Home,"WINGAMES","Imawine_games.json"));
    
    public static void GameDelete(int index)
    {
        if (index < 0 || index >= ConfigData.Games.Count)
        {
            Console.WriteLine("Invalid game index.");
            Console.ReadLine();
            return;
        }
        

        ConfigData.Games.RemoveAt(index);

        Save(
            ConfigData,
            Path.Combine(Home, "WINGAMES", "Imawine_games.json")
        );
        Save(ConfigData, Path.Combine(Home,"WINGAMES","Imawine_games.json"));
    }
    public static void AddGame()
    {
        if (string.IsNullOrWhiteSpace(AddGameexepath) ||
            string.IsNullOrWhiteSpace(AddGametitle))
        {
            Console.WriteLine("Enter data in the required fields.");
            Console.ReadLine();
            return;
        }

        if (string.IsNullOrWhiteSpace(AddGamewinepath))
        {
            AddGamewinepath =
                Path.Combine(Home, "WINGAMES", "WINE", "WINE.AppImage");
        }

        if (string.IsNullOrWhiteSpace(AddGamewineprefix))
        {
            AddGamewineprefix =
                Path.Combine(Home, "WINGAMES", "Prefixes", "default");
        }
        else
        {
            AddGamewineprefix =
                Path.Combine(Home, "WINGAMES", "Prefixes", AddGamewineprefix);
        }

        ConfigData.Games.Add(new Game
        {
            Title = AddGametitle,
            Wine = AddGamewinepath,
            Prefix = AddGamewineprefix,
            Exe = AddGameexepath,
            Args = AddGamearg
        });
        Save(ConfigData, Path.Combine(Home,"WINGAMES","Imawine_games.json"));
    }
    public static void MenuVisual()
    {
        if (MenuPosi > MenuPosiMax)
        {
            MenuPosi = MenuPosiMax;
        }
        
        string buffertext;
        switch (MenuMenu)
        {
            case 0:
                buffertext = "";
                buffertext += $"{Launcher.Cor.Verde}|[Imawine]{Launcher.Cor.Reset}";
                buffertext += "\n|[" + (MenuPosi== 0 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Games";
                buffertext += "\n|[" + (MenuPosi== 1 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Add Game";
                buffertext += "\n|[" + (MenuPosi== 2 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Delete Game";
                buffertext += "\n|[" + (MenuPosi== 3 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Update/Repair Game Prefixe";
                buffertext += "\n|[" + (MenuPosi== 4 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Winetricks";
                buffertext += "\n|[" + (MenuPosi== 5 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Winecfg";
                buffertext += "\n|[" + (MenuPosi== 6 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Help(shortly)";
                buffertext += "\n|[" + (MenuPosi== 7 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Exit";
                Console.Clear();
                Console.WriteLine(buffertext);
                break;
            case 1:
                buffertext = "";
                buffertext += $"{Launcher.Cor.Verde}|[Imawine]ADD GAME MENU{Launcher.Cor.Reset}";
                buffertext += "\n|[" + (MenuPosi== 0 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"ADD GAME [Enter to ADD]";
                buffertext += "\n|[" + (MenuPosi== 1 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"GAME TITLE:";
                buffertext += "\n" + AddGametitle;
                buffertext += "\n|[" + (MenuPosi== 2 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Exe Path:";
                buffertext += "\n" + AddGameexepath;
                buffertext += "\n|[" + (MenuPosi== 3 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Prefix inside Prefixe folder in WINGAMES    (type enter for default prefixe):";
                buffertext += "\n" + AddGamewineprefix;
                buffertext += "\n|[" + (MenuPosi== 4 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Wine path inside the WINE folder (type enter for wine.AppImage[the default]):";
                buffertext += "\n" + AddGamewinepath;
                buffertext += "\n|[" + (MenuPosi== 5 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Args (Enter for nothing [default]):";
                buffertext += "\n" + AddGamearg;
                buffertext += "\n|[" + (MenuPosi== 6 ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+"Back/Cancel";
                Console.Clear();
                Console.WriteLine(buffertext);
                break;
            case 2:
                buffertext = "";
                buffertext += $"{Launcher.Cor.Verde}|[Imawine]Game list:{Launcher.Cor.Reset}";
                for (int i = 0; i < ConfigData.Games.Count; i++)
                {
                    buffertext += "\n|[" + (MenuPosi== i ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+ConfigData.Games[i].Title;
                }
                buffertext += "\n|[" + (MenuPosi== MenuPosiMax  ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+ "Back";
                Console.Clear();
                Console.WriteLine(buffertext);
                break;
            case 3:
                buffertext = "";
                buffertext += $"{Launcher.Cor.Verde}|[Imawine]Game list DELETE:{Launcher.Cor.Reset}";
                for (int i = 0; i < ConfigData.Games.Count; i++)
                {
                    buffertext += "\n|[" + (MenuPosi== i ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+ConfigData.Games[i].Title;
                }
                buffertext += "\n|[" + (MenuPosi== MenuPosiMax  ? $"{Launcher.Cor.Verde}*{Launcher.Cor.Reset}" : $"{Launcher.Cor.Amarelo}#{Launcher.Cor.Reset}") + "]"+ "Back";
                Console.Clear();
                Console.WriteLine(buffertext);
                break;
                
        }
        

        
    }

    static void Basic_chek_prefix(string prefixin,string wine)
    {
        if (!Directory.Exists(Path.Combine(Home,"WINGAMES","Prefixes",prefixin)))
        {
            Directory.CreateDirectory(Path.Combine(Home, "WINGAMES", "Prefixes", prefixin));
        }
        if (!Directory.EnumerateFileSystemEntries(Path.Combine(Home, "WINGAMES", "Prefixes", prefixin)).Any())
        {
            Newprefixe(prefixin,wine);
        }
    }

    static void Newprefixe(string prefixin,string wine)
    {
        WineKit.Run(wine,prefixin,"wineboot");
        WineKit.Run(wine,prefixin,"winetricks","dxvk");
        WineKit.Run(wine,prefixin,"winetricks","vkd3d");
    }
    public class Config
    {
        public List<Game> Games { get; set; } = new();
    }
    static void Save(Config config, string path)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(path, json);
    }
    static Config Load(string path)
    {
        if (!File.Exists(path))
            return new Config();

        string json = File.ReadAllText(path);

        if (string.IsNullOrWhiteSpace(json))
            return new Config();

        return JsonSerializer.Deserialize<Config>(json) ?? new Config();
    }
    public class Game
    {
        public string Title { get; set; } = "";

        public string Exe { get; set; } = "";

        public string Prefix { get; set; } = "";

        public string Wine { get; set; } = "";

        public string Args { get; set; } = "";
    }

    static int InputRead()
    {
        int resultado = 0;
        while (resultado == 0)
        {
            var inputRead = Console.ReadKey(true);
            switch (inputRead.Key)
            {
                case ConsoleKey.DownArrow or ConsoleKey.S:
                    resultado = 2;
                    break;
                case ConsoleKey.UpArrow or ConsoleKey.W:
                    resultado = 1;
                    break;
                case ConsoleKey.Enter:
                    resultado = 3;
                    break;
            }
            
        }
        return resultado;
    }
}
public static class Launcher
{
    public static void RunWine(
    string winePath,
    string exePath,
    string winePrefix,
    string args = "",
    bool useMangoHud = false,
    bool useGameMode = false)
{
    if (!File.Exists(winePath))
    {
        Console.WriteLine($"{Cor.Vermelho}[LOG]{Cor.Reset} Wine not found: {winePath}");
        return;
    }

    if (!File.Exists(exePath))
    {
        Console.WriteLine($"{Cor.Vermelho}[LOG]{Cor.Reset} EXE not found: {exePath}");
        return;
    }

    string gameDir = Path.GetDirectoryName(exePath)!;

    Console.WriteLine($"{Cor.Verde}[LOG]{Cor.Reset} Start game...");
    Console.WriteLine($"WINE: {winePath}");
    Console.WriteLine($"PREFIX: {winePrefix}");
    Console.WriteLine($"EXE: {exePath}");
    Console.WriteLine($"ARGS: {args}");
    Console.WriteLine($"WORKDIR: {gameDir}");

    var process = new Process();

    process.StartInfo.FileName = winePath;

    process.StartInfo.Arguments =
        $"\"{exePath}\" {args}".Trim();

    process.StartInfo.WorkingDirectory = gameDir;

    process.StartInfo.Environment["WINEPREFIX"] = winePrefix;

    if (useMangoHud)
    {
        process.StartInfo.Environment["MANGOHUD"] = "1";
    }

    if (useGameMode)
    {
        Console.WriteLine($"{Cor.VermelhoBright}GAMEMODE has been temporarily disabled due to critical errors.{Cor.Reset}");
        //process.StartInfo.FileName = "gamemoderun";
        //process.StartInfo.ArgumentList.Add(winePath);
        //process.StartInfo.ArgumentList.Add(exePath);
    }

    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.CreateNoWindow = true;

    process.OutputDataReceived += (_, e) =>
    {
        if (!string.IsNullOrWhiteSpace(e.Data))
        {
            Console.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (!string.IsNullOrWhiteSpace(e.Data))
        {
            Console.WriteLine($"{Cor.Vermelho}[LOG]{Cor.Reset} {e.Data}");
        }
    };
    Console.WriteLine($"{Cor.Verde}[LOG]{Cor.Reset}Press {Cor.Amarelo}ENTER{Cor.Reset}to{Cor.Vermelho}finish the process after it has been initialized{Cor.Amarelo}(starting after 3 seconds){Cor.Reset}");
    Thread.Sleep(3000);
    process.Start();

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();

    CancellationTokenSource cts = new();

    Thread inputThread = new Thread(() =>
    {
        Thread.Sleep(500);
        Console.ReadLine();

        if (!cts.IsCancellationRequested)
        {
            try
            {
                if (!process.HasExited)
                {
                    Console.WriteLine(
                        $"{Cor.Amarelo}[LOG]{Cor.Reset} Kill process..."
                    );

                    process.Kill(entireProcessTree: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"{Cor.Vermelho}[LOG]{Cor.Reset} {ex.Message}"
                );
            }

            cts.Cancel();
        }
    });

    inputThread.IsBackground = true;
    inputThread.Start();

    process.WaitForExit();

    cts.Cancel();

    Console.WriteLine(
        $"{Cor.Verde}[LOG]{Cor.Reset} Finished (Exit code {process.ExitCode})"
    );
}
    public static class Cor
    {
        public const string Preto = "\u001b[30m";
        public const string Vermelho = "\u001b[31m";
        public const string Verde = "\u001b[32m";
        public const string Amarelo = "\u001b[33m";
        public const string Azul = "\u001b[34m";
        public const string Magenta = "\u001b[35m";
        public const string Ciano = "\u001b[36m";
        public const string Branco = "\u001b[37m";

        public const string PretoBright = "\u001b[90m";
        public const string VermelhoBright = "\u001b[91m";
        public const string VerdeBright = "\u001b[92m";
        public const string AmareloBright = "\u001b[93m";
        public const string AzulBright = "\u001b[94m";
        public const string MagentaBright = "\u001b[95m";
        public const string CianoBright = "\u001b[96m";
        public const string BrancoBright = "\u001b[97m";

        public const string Reset = "\u001b[0m";
    }
}

public static class WineKit
{
    public static void Run(
        string wineAppImage,
        string winePrefix,
        string command,
        params string[] args)
    {
        if (!File.Exists(wineAppImage))
        {
            Console.WriteLine($"[ERR] Wine AppImage not found: {wineAppImage}");
            return;
        }

        Console.WriteLine("[LOG] Running Wine AppImage tool");
        Console.WriteLine($"WINE: {wineAppImage}");
        Console.WriteLine($"PREFIX: {winePrefix}");
        Console.WriteLine($"COMMAND: {command}");

        var process = new Process();

        // 👉 SEMPRE o AppImage primeiro
        process.StartInfo.FileName = wineAppImage;

        // prefix
        process.StartInfo.Environment["WINEPREFIX"] = winePrefix;

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        // 👉 comando interno do AppImage
        process.StartInfo.ArgumentList.Add(command);

        // args extras (dxvk etc)
        foreach (var a in args)
            process.StartInfo.ArgumentList.Add(a);

        process.OutputDataReceived += (_, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
                Console.WriteLine(e.Data);
        };

        process.ErrorDataReceived += (_, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
                Console.WriteLine("[ERR] " + e.Data);
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        Console.WriteLine($"[LOG] Finished ({process.ExitCode})");
    }
}