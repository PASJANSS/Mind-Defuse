using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cesar : MonoBehaviour
{
    public Renderer lamp;
    public TextMeshProUGUI questionLabel;
    public TextMeshProUGUI[] buttonLabels;
    List<string> words = new List<string>
    {
        "pryzmat", "pytanie", "shindig", "wydawca", "herbaty", "chwalba", "zownia", "samowar", "marsza", "podmuch", "derkacz", "kajdany", "bacowa",
        "osiowa", "poraka", "kocita", "milutki", "drzemka", "retinol", "wytrysk", "odek", "sterner", "piechur", "niewola", "warcaby", "miniony",
        "typowa", "okrada", "stanach", "kerala", "wlasnie", "arabiki", "robusty", "Drzewka", "okresie", "lutego", "czerwca",
        "abakach", "abakami", "abakanu", "abakany", "abakiem", "abakowi", "abakusa", "abakusy", "abandon", "abatach", "abatami", "abatowi", "abatysa", "abatys", "abatys", "abatyso", "abatysy", "abazjom", "abaura", "abauru", "abaury", "abbowie", "abbozza", "abbozzo", "abbozzu", "abcugom", "abcugw", "abdomen", "abdulem", "abdulom", "abdykuj", "abelitu", "abelity", "abietyn", "abisale", "abisali", "abisalu", "abitell", "ablacja", "ablacj", "ablacje", "ablacj", "ablacji", "ablacjo", "ablacyj", "ablatyw", "ablegat", "ablegra", "ablegry", "ablucja", "ablucj", "ablucje", "ablucj", "ablucji", "ablucjo", "ablucyj", "abnegat", "abobrom", "abobrze", "abonent", "abonuj", "abonuje", "abonuj", "aborcie", "aborcja", "aborcj", "aborcje", "aborcj", "aborcji", "aborcjo", "aborcyj", "aborda", "abortem", "aborter", "abortom", "abortw", "abortus", "abraduj", "abrazja", "abrazj", "abrazje", "abrazj", "abrazji", "abrazjo", "abrazyj", "abroguj", "abrysem", "abrysie", "abrysom", "abrysw", "abscesu", "abscesy", "absmaki", "absmaku", "absolut", "abstach", "abstami", "absurdu", "absurdy", "absydom", "absyntu", "absynty", "abszmak", "abszytu", "abszyty", "abulicy", "abulika", "abuliki", "abuliku", "abuliom", "abwehra", "abwehr", "abwehr", "abwehro", "abwehry", "abwerom", "abwerze", "abysale", "abysali", "abysalu", "abycie", "acanach", "acanami", "acanich", "acaniej", "acanimi", "acaniom", "acankom", "acanowi", "accenta", "accenty", "accorda", "accordy", "acediom", "acenole", "acenoli", "acenolu", "acerola", "acerol", "acerole", "acerol", "aceroli", "acerolo", "acetale", "acetali", "acetalu", "acetonu", "acetony", "acetyle", "acetyli", "acetylu", "achacie", "achajc", "achajmy", "achaje", "achaam", "achaa", "achaby", "achaem", "achae", "achania", "achanie", "achaniu", "acholia", "acholi", "acholie", "acholi", "acholii", "acholij", "acholio", "achtela", "achtele", "achteli", "achtelu", "achtlem", "achtlom", "achylia", "achyli", "achylie", "achyli", "achylii", "achylij", "achylio", "acidach", "acidami", "acmiola", "acmiol", "acmiole", "acmiol", "acmioli", "acmiolo", "acpanem", "acpani", "acpanie", "acpanom", "acpanw", "acydoza", "acydoz", "acydoz", "acydozo", "acydozy", "acylach", "acylami", "acylowa", "acylow", "acylowe", "acylowi", "acylowy", "acyluj", "acyluje", "acyluj", "aczaria", "aczari", "aczarie", "aczari", "aczarii", "aczario", "aarjom", "aarjw", "adadia", "adadio", "adadiu", "adagiem", "adagiom", "adagiw", "adagium", "adalatu", "adalaty", "adalina", "adalin", "adalin", "adalino", "adaliny", "adamici", "adamita", "adamit", "adamit", "adamito", "adamity", "adamowa", "adamow", "adamowe", "adamowi", "adamowy", "adamsyt", "adapter", "adaptor", "adaptuj", "adasiem", "adasiom", "adatach", "adatami", "adatowi", "adcultu", "adculty", "addenda", "addendy", "addycja", "addycj", "addycje", "addycj", "addycji", "addycjo", "addycyj", "adenina", "adenin", "adenin", "adenino", "adeniny", "adeniom", "adeniw", "adenium", "adenkom", "adenoid", "adescy", "adeska", "adesk", "adeski", "adesku", "adepcie", "adeptce", "adeptek", "adeptem", "adeptka", "adeptk", "adeptk", "adeptki", "adeptko", "adeptom", "adeptw", "adermin", "adhezja", "adhezj", "adhezje", "adhezj", "adhezji", "adhezjo", "adhezyj", "adiabat", "adiafor", "adianta", "adidasa", "adidasy", "adinole", "adinoli", "adinolu", "adirato", "adiunkt", "adminem", "adminie", "adminom", "adminw", "admira", "admiruj", "admisja", "admisj", "admisje", "admisj", "admisji", "admisjo", "admisyj", "adnotuj", "adonika", "adoniki", "adoniku", "adonisa", "adonisi", "adonisy", "adopcja", "adopcj", "adopcje", "adopcj", "adopcji", "adopcjo", "adopcyj", "adoptuj", "adorant", "adornuj", "adoruj", "adoruje", "adoruj", "adresat", "adresem", "adresie", "adresik", "adresom", "adresw", "adresuj", "adriach", "adriami", "adrymin", "adstrat", "adularu", "adulary", "adwaita", "adwait", "adwait", "adwaito", "adwaity", "adwajta", "adwajt", "adwajt", "adwajto", "adwajty", "adwarze", "adwentu", "adwenty", "adwokat", "adynata", "adytonu", "adytony", "adykom", "aeckich", "aeckiej", "aeckimi", "aedicul", "aelowca", "aelowce", "aelowcu", "aelowcy", "aeracja", "aeracj", "aeracje", "aeracj", "aeracji", "aeracjo", "aeracyj", "aeralem", "aeralom", "aeralw", "aerator", "aerobem", "aerobic", "aerobie", "aerobik", "aerobom", "aerobw", "aerobus", "aerodyn", "aerofon", "aerofor", "aerolit", "aerolog", "aerosa", "aerosol", "aerozol", "afatycy", "afatyka", "afatyki", "afatyku", "afazjom", "afekcie", "afektem", "afektom", "afektw", "afektuj", "afeliom", "afeliw", "afelium", "afemiom", "aferach", "aferale", "aferaa", "aferay", "aferami", "afereza", "aferez", "aferez", "aferezo", "aferezy", "aferkom", "aferowa", "aferow", "aferowe", "aferowi", "aferowy", "afganem", "afganie", "afganom", "afganw", "afgaca", "afgace", "afgacu", "afgacy", "afghani", "aficydu", "aficydy", "afiksem", "afiksie", "afiksom", "afiksw", "afiliuj", "afinuj", "afinuje", "afinuj", "afirmuj", "afiszem", "afiszom", "afiszw", "afiszuj", "afodosu", "afodosy", "afoniom", "aforyzm", "afrakta", "afrodyt", "afrontu", "afronty", "afrycie", "afrykat", "afrykom", "afrytem", "afrytom", "afrytw", "aftowej", "aftowym", "agadach", "agadami", "agadzie", "agalitu", "agality", "agamach", "agamami", "agameta", "agamet", "agamet", "agameto", "agamety", "agamiom", "agamont", "aganach", "aganami", "aganina", "agankom", "agascy", "agaska", "agask", "agaski", "agasku", "agapach", "agapami", "agapant", "agarach", "agarami", "agarowa", "agarow", "agarowe", "agarowi", "agarowy", "agatach", "agatami", "agatisu", "agatisy", "agatowa", "agatow", "agatowe", "agatowi", "agatowy", "agawach", "agawami", "agemach", "agemami", "agencie", "agencik", "agencja", "agencj", "agencje", "agencj", "agencji", "agencjo", "agencyj", "agendce", "agendek", "agendka", "agendk", "agendk", "agendki", "agendko", "agendom", "agensem", "agensie", "agensom", "agensw", "agentce", "agentek", "agentem", "agentka", "agentk", "agentk", "agentki", "agentko", "agentom", "agentw", "agentur", "agerata", "aggiach", "aggiami", "agitato", "agitkom", "agituj", "agituje", "agituj", "aglecie", "agletem", "agletom", "agletw", "aglikon", "agnaccy", "agnacie", "agnacja", "agnacj", "agnacje", "agnacj", "agnacji", "agnacjo", "agnacka", "agnack", "agnacki", "agnacku", "agnacyj", "agnatce", "agnatek", "agnatem", "agnatka", "agnatk", "agnatk", "agnatki", "agnatko", "agnatom", "agnatw", "agnozja", "agnozj", "agnozje", "agnozj", "agnozji", "agnozjo", "agnozyj", "agnusek", "agnusem", "agnusie", "agnuska", "agnuski", "agnusku", "agnusom", "agnusw", "agogice", "agogika", "agogik", "agogik", "agogiki", "agogiko", "agonach", "agonami", "agoniom", "agonowi", "agorach", "agorami", "agoroty", "agrafce", "agrafek", "agrafia", "agrafi", "agrafie", "agrafi", "agrafii", "agrafij", "agrafio", "agrafka", "agrafk", "agrafk", "agrafki", "agrafko", "agrafom", "agrafon", "agrafw", "agrarna", "agrarn", "agrarne", "agrarni", "agrarny", "agrawuj", "agregat", "agreguj", "agresja", "agresj", "agresje", "agresj", "agresji", "agresjo", "agresor", "agrestu", "agresty", "agresyj", "agrogaz", "agronom", "ahimsie", "ahimsom", "ahinsie", "ahinsom", "ahmadii", "ahmadij", "aidsach", "aidsami", "aidsowa", "aidsow", "aidsowe", "aidsowi", "aidsowy", "ailantu", "ailanty", "ailloli", "airbagi", "airbagu", "airbusa", "airbusu", "airbusy", "ajaksem", "ajaksie", "ajaksom", "ajaksw", "ajencie", "ajencja", "ajencj", "ajencje", "ajencj", "ajencji", "ajencjo", "ajencyj", "ajentce", "ajentek", "ajentem", "ajentka", "ajentk", "ajentk", "ajentki", "ajentko", "ajentom", "ajentw", "ajentur", "ajerach", "ajerami", "ajerowa", "ajerow", "ajerowe", "ajerowi", "ajerowy", "ajkowa", "ajkowa", "ajkowa", "ajkujc", "ajkujmy", "ajkuje", "ajlanta", "ajlantu", "ajlanty", "ajmakom", "ajmakw", "ajnoscy", "ajnoska", "ajnosk", "ajnoski", "ajnosku", "ajowana", "ajowany", "ajranem", "ajranie", "ajranom", "ajranw", "ajurwed", "ajwarem", "ajwarom", "ajwarw", "ajwarze", "akacjom", "akadzcy", "akadzka", "akadzk", "akadzki", "akadzku", "akancie", "akaniem", "akaniom", "akantem", "akantod", "akantom", "akantw", "akapitu", "akapity", "akarach", "akarami", "akaroid", "akatyst", "akcentu", "akcenty", "akceptu", "akcepty", "akcesem", "akcesie", "akcesja", "akcesj", "akcesje", "akcesj", "akcesji", "akcesjo", "akcesom", "akcesw", "akcesyj", "akcikom", "akcikw", "akcjach", "akcjami", "akcyjna", "akcyjn", "akcyjne", "akcyjni", "akcyjny", "akcyzie", "akcyzom", "akineza", "akinez", "akinez", "akinezo", "akinezy", "aklamuj", "aklinie", "aklinom", "akmeizm", "akolada", "akolad", "akolad", "akolado", "akolady", "akolici", "akolita", "akolit", "akolit", "akolito", "akolity", "akolutu", "akoluty", "akoncie", "akondem", "akondom", "akondw", "akonitu", "akonity", "akontem", "akontom", "akordem", "akordom", "akordw", "akordyk", "akowcem", "akowcom", "akowcw", "akowcze", "akowiec", "akowscy", "akowska", "akowsk", "akowski", "akowsku", "akrania", "akrani", "akranie", "akrani", "akranii", "akranij", "akranio", "akrasia", "akrasi", "akrasie", "akrasi", "akrasii", "akrasij", "akrasio", "akrecja", "akrecj", "akrecje", "akrecj", "akrecji", "akrecjo", "akrecyj", "akrolit", "akronem", "akronie", "akronim", "akronom", "akronw", "akropol", "akrosom", "akrybia", "akrybi", "akrybie", "akrybi", "akrybii", "akrybij", "akrybio", "akrydyn", "akryjce", "akryjek", "akryjka", "akryjk", "akryjk", "akryjki", "akryjko", "akrylan", "akrylem", "akrylom", "akrylw", "aksamit", "aksenia", "akseni", "aksenie", "akseni", "aksenii", "aksenij", "aksenio", "aksisem", "aksisie", "aksisom", "aksisw"
    };
    bool isDone;
    string word;
    string scriptedWord = "";
    int key = 5;
    private void Start()
    {
        Generate();
    }

    void Generate()
    {
        scriptedWord = "";
        word = words[Random.Range(0, words.Count)];
        words.Remove(word);
        for (int i = 0; i < buttonLabels.Length; i++)
        {
            int a = Random.Range(0, words.Count);
            buttonLabels[i].text = words[a];
            buttonLabels[i].transform.parent.GetComponent<CesarButton>().word = words[a];
            words.RemoveAt(a);
        }
        for (int i = 0; i < word.Length; i++)
        {
            int letter = word[i] + key;
            if (letter > 122)
                letter -= 26;
            scriptedWord += (char)letter;
        }
        questionLabel.text = scriptedWord;
        int x = Random.Range(0, buttonLabels.Length);
        buttonLabels[x].text = word;
        buttonLabels[x].transform.parent.GetComponent<CesarButton>().word = word;
    }

    public void ButtonClicked(string text)
    {
        if (isDone) return;

        if(text == word)
        {
            BombIDGen.Instance.WinLamp(lamp);
            BombIDGen.Instance.gamesDone++;
            isDone = true;
        }
        else
        {
            BombIDGen.Instance.LightLamp(lamp, 0);
            BombIDGen.Instance.lives--;
            Generate();
        }
    }
}
