//Código realizado el 19-21 de Junio del 2024, tras pérdida del código realizado el 8 y 9 de marzo del 2024.
//Aprendí finalmente el uso de clases el 24 de Junio, tras horrible trabajo de Comunidad jeje 
//Se auto escribió using System

using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;


class GUI
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.Clear();
        Console.Title = "CONJUGADORA VERBAL";
        Console.WriteLine("BIENVENIDE A LA APLICACIÓN CONJUGADORA DE VERBOS");
        Console.WriteLine("Por favor, escriba un número de las siguientes opciones:");
        Console.WriteLine();
        Console.WriteLine("1.- No practicar el Presente Informal");
        Console.WriteLine("2.- No practicar lo anterior ni el Presente Formal");
        Console.WriteLine("3.- No practicar lo anterior ni la Negación Presente Formal");
        Console.WriteLine("Aprete cualquier tecla si desea practicar todo");
        

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string userOption = Console.ReadLine(); //esto no es un error
        Skip numberador = new Skip();
        int skip = numberador.Trans(userOption);
        Verbos verb = new Verbos();

        while (true)
        {
            KeyValuePair<string, string> acción = verb.rndAcción();
            string spingo = acción.Key;
            string nihongo = acción.Value;

            Conjugación conju = new Conjugación(verb); //ES NECESARIO DARLE PARÁMETROS A LAS CLASES
            KeyValuePair<string, string> conjugación = conju.rndConj(skip);
            string conjugado = conjugación.Key;
            string fin = conjugación.Value;

       
            Console.Clear();
            Console.WriteLine("¿Cómo se dice " + spingo + " en " + conjugado);
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(nihongo + fin);
            Console.ReadLine();
        }
    }
}
class Verbos
{
    public List<Dictionary<string, string>> TiposVerbo;
    public int SelectedTipo;

    public Verbos()
    {
        TiposVerbo = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>
            {
                {"decir (言)", "i"},
                {"cantar (歌)", "uta"},
                {"pensar (思)", "omo"},
                {"comprar (買)", "ka"},
                {"discernir (違)", "chiga"},
                {"utilizar (使)", "tsuka"},
                {"aprender (習)","nara"},
                {"reir (笑)", "wara"}
            },
            new Dictionary<string, string>
            {
                {"abrirse (開)", "a"},
                {"escuchar (聞)", "ki"},
                {"caminar (歩)", "aru"},
                {"ir (行)", "i"},
                {"poner (置)", "o"},
                {"escribir (書)", "ka"},
                {"florecer (咲)", "sa"},
                {"llegar (着)", "tsu"},
                {"llorar (泣)", "na"},
                {"gritar (鳴)", "na"},
                {"vestir (履)", "ha"},
                {"trabajar (働)", "hatara"},
                {"estirar (引)", "hi"},
                {"soplar (吹)", "fu"},
                {"pulir (磨)", "miga"}
            },
            new Dictionary<string, string>
            { 
                {"nadar (泳)", "oyo"},
                {"desvestir (脱)", "me"},
                {"apurar (急)", "iso" }
            },
            new Dictionary<string, string>
            { 
                {"jugar (遊)", "aso"},
                {"volar (飛)", "to"},
                {"hacer fila (並)", "nara"},
                {"llamar (呼)", "yo"}
            },
            new Dictionary<string, string>
            { 
                {"estar de pie (立)", "ta"},
                {"esperar (待)", "ma"},
                {"llevar (持)", "mo"}
            },
            new Dictionary<string, string>
            { 
                {"empujar (押)", "o"},
                {"recordar (思い出)", "omoida"},
                {"devolver (返)", "kae"},
                {"prestar (貸)", "ka"},
                {"sacar (出)", "da"},
                {"matar (殺)", "koro"},
                {"hablar (話)", "hana"},
                {"entregar (渡)", "wata"}

            },
            new Dictionary<string, string>
            { 
                {"residir (住)", "su"},
                {"pedir (頼)", "tano"},
                {"beber (飲)", "no"},
                {"descansar (休)", "yasu"},
                {"leer (読)", "yo"}
            },
            new Dictionary<string, string>
            { 
                {"caer del cielo (降)", "fu"},
                {"comenzarse (始ま)", "hashima"},
                {"adherir (貼)", "ha"},
                {"complicarse (困)", "koma"},
                {"tardar (かか)", "kaka"},
                {"nublar (曇)", "kumo"},
                {"voltearse (曲が)", "maga"},
                {"transformarse (な)", "na"},
                {"escalar (登)", "nobo"},
                {"acabarse (終わ)", "owa"},
                {"cerrarse (閉ま)", "shima"},
                {"sentarse (座)", "suwa"},
                {"agarrar (取)", "to"},
                {"fotografiar (撮)", "to"},
                {"fabricar (作)", "tsuku"},
                {"vender (売)", "u"},
                {"entender (分か)", "waka"},
                {"dar (や)", "ya"},
                {"volver a casa (帰)", "kae"},
                {"entrar (入)", "hai"},
                {"correr (走)", "hashi"},
                {"cortar (切)", "ki"},
                {"saber (知)", "shi"}
            }
        };
    }
    public KeyValuePair <string, string> rndAcción()
    {
        //AQUÍ TERMINA LA LISTA DE VERBOS
        //INICIA SELECCIÓN DE VERBOS
        Random rnd = new Random();

        SelectedTipo = rnd.Next(0, TiposVerbo.Count); 
        Dictionary<string, string> Tipo = TiposVerbo[SelectedTipo];
        
        int SelectedAcción = rnd.Next(0, Tipo.Count);
        KeyValuePair<string, string> Acción = Tipo.ElementAt(SelectedAcción);
        return Acción;
    }
}
class Conjugación
{
    private Dictionary<string, string> Conj;
    public int SelectedConj;
    public Conjugación(Verbos verb)
    {
        Consnt consnt = new Consnt();
        string c = consnt.Trans(verb.SelectedTipo);

        I ii = new I();
        string i = ii.Trans(verb.SelectedTipo);

        U uu = new U();
        string u = uu.Trans(verb.SelectedTipo);

        A aa = new A();
        string a = aa.Trans(verb.SelectedTipo);

        T tt = new T();
        string t = tt.Trans(verb.SelectedTipo);

        Conj = new Dictionary<string, string>
        {
            {"Presente Informal",u},                                //01
            {"Presente Formal", i+"masu"},                          //02
            {"Negación Presente Formal", i+"masen"},                //03
            {"Negación Presente Informal", a+"nai"},                //04
            {"Pasado Formal", i+"mashita"},                         //05
            {"Pasado Informal", t+"a"},                             //06
            {"Negación Pasado Formal", i+"masendeshita"},           //07
            {"Negación Pasado Informal", a+"nakatta"},              //08
            {"Gerundio Presente Formal", t+"eimasu"},               //09
            {"Gerundio Presente Informal", t+"eiru"},               //10
            {"Negación Gerundio Presente Formal", t+"eimasen"},     //11
            {"Gerundio Pasado Formal", t+"eimashita"},              //12
            {"Gerundio Pasado Informal", t+"eita"},                 //13
            {"Negación Gerundio Pasado Formal", t+"eimasendeshita"},//14
            {"Imperativo Formal", t+"ekudasai"},                    //15
            {"Imperativo Informal", c+"e"},                         //16
            {"Imperativo Negación Formal", a+"naidekudasai"},       //17
            {"Imperativo Negación Informal", u+"na"},              //18
            {"Invitación Formal", i+"mashyou"},                     //19
            {"Invitación Informal", c+"ō"},                         //20
            {"Suposición Formal",c+"udeshyō"},                      //21
            {"Suposición Informal", c+"udarō"},                     //22
            {"Negación Suposición Formal", a+"naideshyō"},          //23
            {"Negación Suposición Informal", a+"naidarō"}           //24
        };
    }
    public KeyValuePair <string, string> rndConj(int skip)
    {
        Random rnd = new Random();
        SelectedConj = rnd.Next(skip, Conj.Count);
        KeyValuePair<string, string> Conju = Conj.ElementAt(SelectedConj);
        return Conju; 
    }
}
//FUNCIONES DE LETRAS FINALES
   class Consnt()
    {
            public string Trans(int var)
        {
            if (var == 0)
            {return "";}
            else if (var == 1)
            {return "k";}
            else if (var == 2)
            {return "g";}
            else if (var == 3)
            {return "b";}
            else if (var == 4)
            {return "t";}
            else if (var == 5)
            {return "s";}
            else if (var == 6)
            {return "m";}
            else if (var == 7)
            {return "r";}
            else
            {return "X";}
        }
    }
   class I()
   {
        public string Trans(int var)
        {
            Consnt consnt = new Consnt();
            string c = consnt.Trans(var);
            if (var >= 0 && var <= 3 || var == 6 || var == 7)
            {return c +"i";}
            else if (var == 4)
            {return "chi";}
            else if (var == 5)
            {return "shi";}
            else
            {return "X";}
        }
   }     
   class U()
   {
        public string Trans(int var)
        {
            Consnt consnt = new Consnt();
            string c = consnt.Trans(var);
            if (var >= 0 && var <= 3 || var == 5 || var == 6 || var == 7)
            {return c + "u";}
            else if (var == 4)
            {return "tsu";}
            else
            {return "X";}
        }
   }    
   class A()
   {
        public string Trans(int var)
        {
            Consnt consnt = new Consnt();
            string c = consnt.Trans(var);
            if (var >= 1 && var <= 7)
            {return c + "a";}
            else if (var == 0)
            {return "wa";}
            else
            {return "X";}
        }
   }
    class T()
    {
        public string Trans(int var)
        {
            if (var == 0 || var == 4 || var == 7)
            {return "tt";}
            else if (var == 1)
            {return "it";}
            else if (var == 2)
            {return "id";}
            else if (var == 3 || var == 6)
            {return "nd";}
            else if (var == 5)
            {return "shit";}
            else
            {return "X";}
        }
    }
class Skip()
{
    public int Trans(string userOption)
    {
        int num;
        if (int.TryParse(userOption, out num))
        {
            if (num >= 0 && num <= 23)
            { return num; }
            else
            { return 0; }
        }
        else
        {
            return 0;
        }
    }
}
