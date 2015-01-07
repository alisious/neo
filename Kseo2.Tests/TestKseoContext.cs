using Kseo2.DataAccess;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Tests
{
    public class TestKseoContext :IKseoContext
    {

        public TestKseoContext()
        {
            
            #region Countries (Kraje)
            Countries = new TestDbSet<Country>
            {
                new Country() {ShortName = "AF", Name = "AFGANISTAN", DisplayOrder = 3},
                new Country() {ShortName = "AL", Name = "ALBANIA", DisplayOrder = 4},
                new Country() {ShortName = "DA", Name = "ALGIERIA", DisplayOrder = 5},
                new Country() {ShortName = "AN", Name = "ANDORA", DisplayOrder = 6},
                new Country() {ShortName = "AG", Name = "ANGOLA", DisplayOrder = 7},
                new Country() {ShortName = "AC", Name = "ANGUILLA", DisplayOrder = 8},
                new Country() {ShortName = "AA", Name = "ANTARKTYDA", DisplayOrder = 9},
                new Country() {ShortName = "AT", Name = "ANTIGUA I BARBUDA", DisplayOrder = 10},
                new Country() {ShortName = "AY", Name = "ANTYLE HOLENDERSKIE", DisplayOrder = 11},
                new Country() {ShortName = "AI", Name = "ARABIA SAUDYJSKA", DisplayOrder = 12},
                new Country() {ShortName = "AB", Name = "ARGENTYNA", DisplayOrder = 13},
                new Country() {ShortName = "AR", Name = "ARMENIA", DisplayOrder = 14},
                new Country() {ShortName = "AD", Name = "ARUBA", DisplayOrder = 15},
                new Country() {ShortName = "AS", Name = "AUSTRALIA", DisplayOrder = 16},
                new Country() {ShortName = "AU", Name = "AUSTRIA", DisplayOrder = 17},
                new Country() {ShortName = "AZ", Name = "AZERBEJDŻAN", DisplayOrder = 18},
                new Country() {ShortName = "BH", Name = "BAHAMY", DisplayOrder = 19},
                new Country() {ShortName = "BR", Name = "BAHRJAN", DisplayOrder = 20},
                new Country() {ShortName = "BC", Name = "BANGLADESZ", DisplayOrder = 21},
                new Country() {ShortName = "BB", Name = "BARBADOS", DisplayOrder = 22},
                new Country() {ShortName = "BE", Name = "BELGIA", DisplayOrder = 23},
                new Country() {ShortName = "BL", Name = "BELIZE", DisplayOrder = 24},
                new Country() {ShortName = "BM", Name = "BERMUDY", DisplayOrder = 25},
                new Country() {ShortName = "BP", Name = "BEZPAŃSTWOWIEC", DisplayOrder = 26},
                new Country() {ShortName = "BT", Name = "BHUTAN", DisplayOrder = 27},
                new Country() {ShortName = "BI", Name = "BIAŁORUŚ", DisplayOrder = 28},
                new Country() {ShortName = "BU", Name = "BIRMA (MYANMAR)", DisplayOrder = 29},
                new Country() {ShortName = "BO", Name = "BOLIWIA", DisplayOrder = 30},
                new Country() {ShortName = "YF", Name = "BOŚNIA,HERCEGOWINA", DisplayOrder = 31},
                new Country() {ShortName = "BW", Name = "BOTSWANA", DisplayOrder = 32},
                new Country() {ShortName = "XX", Name = "BRAK DANYCH", DisplayOrder = 33},
                new Country() {ShortName = "BA", Name = "BRAZYLIA", DisplayOrder = 34},
                new Country() {ShortName = "BN", Name = "BRUNEI", DisplayOrder = 35},
                new Country() {ShortName = "BJ", Name = "BRYTYJSKIE TERYTORIUM OCEANU INDYJSKIEGO", DisplayOrder = 36},
                new Country() {ShortName = "BG", Name = "BUŁGARIA", DisplayOrder = 37},
                new Country() {ShortName = "BK", Name = "BURKINA FASO (GÓRNA WOLTA)", DisplayOrder = 38},
                new Country() {ShortName = "BD", Name = "BURUNDI", DisplayOrder = 39},
                new Country() {ShortName = "CL", Name = "CHILE", DisplayOrder = 40},
                new Country() {ShortName = "CN", Name = "CHINY", DisplayOrder = 41},
                new Country() {ShortName = "YG", Name = "CHORWACJA", DisplayOrder = 42},
                new Country() {ShortName = "CP", Name = "CYPR", DisplayOrder = 43},
                new Country() {ShortName = "CD", Name = "CZAD", DisplayOrder = 44},
                new Country() {ShortName = "CS", Name = "CZECHOSŁOWACJA", DisplayOrder = 45},
                new Country() {ShortName = "CZ", Name = "CZECHY", DisplayOrder = 46},
                new Country() {ShortName = "DN", Name = "DANIA", DisplayOrder = 47},
                new Country() {ShortName = "ZA", Name = "DEMOKRATYCZNA REPUBLIKA KONGA (ZAIR)", DisplayOrder = 48},
                new Country() {ShortName = "DM", Name = "DOMINIKA", DisplayOrder = 49},
                new Country() {ShortName = "DO", Name = "DOMINIKANA", DisplayOrder = 50},
                new Country() {ShortName = "DI", Name = "DŻIBUTI", DisplayOrder = 51},
                new Country() {ShortName = "EG", Name = "EGIPT", DisplayOrder = 52},
                new Country() {ShortName = "EC", Name = "EKWADOR", DisplayOrder = 53},
                new Country() {ShortName = "ER", Name = "ERYTREA", DisplayOrder = 54},
                new Country() {ShortName = "ET", Name = "ESTONIA", DisplayOrder = 55},
                new Country() {ShortName = "EH", Name = "ETIOPIA", DisplayOrder = 56},
                new Country() {ShortName = "FL", Name = "FALKLANDY/MALWINY", DisplayOrder = 57},
                new Country() {ShortName = "FJ", Name = "FIDŻI", DisplayOrder = 58},
                new Country() {ShortName = "PH", Name = "FILIPINY", DisplayOrder = 59},
                new Country() {ShortName = "FI", Name = "FINLANDIA", DisplayOrder = 60},
                new Country() {ShortName = "FR", Name = "FRANCJA", DisplayOrder = 61},
                new Country() {ShortName = "GA", Name = "GABON", DisplayOrder = 62},
                new Country() {ShortName = "GM", Name = "GAMBIA", DisplayOrder = 63},
                new Country() {ShortName = "GH", Name = "GHANA", DisplayOrder = 64},
                new Country() {ShortName = "GI", Name = "GIBRALTAR", DisplayOrder = 65},
                new Country() {ShortName = "GR", Name = "GRECJA", DisplayOrder = 66},
                new Country() {ShortName = "GD", Name = "GRENADA", DisplayOrder = 67},
                new Country() {ShortName = "GL", Name = "GRENLANDIA", DisplayOrder = 68},
                new Country() {ShortName = "GU", Name = "GRUZJA", DisplayOrder = 69},
                new Country() {ShortName = "GN", Name = "GUAM", DisplayOrder = 70},
                new Country() {ShortName = "GW", Name = "GUJANA", DisplayOrder = 71},
                new Country() {ShortName = "GJ", Name = "GWADELUPA", DisplayOrder = 72},
                new Country() {ShortName = "GT", Name = "GWATEMALA", DisplayOrder = 73},
                new Country() {ShortName = "GS", Name = "GWINEA", DisplayOrder = 74},
                new Country() {ShortName = "GE", Name = "GWINEA BISSAU", DisplayOrder = 75},
                new Country() {ShortName = "GK", Name = "GWINEA RÓWNIKOWA", DisplayOrder = 76},
                new Country() {ShortName = "HT", Name = "HAITI", DisplayOrder = 77},
                new Country() {ShortName = "ES", Name = "HISZPANIA", DisplayOrder = 78},
                new Country() {ShortName = "NL", Name = "HOLANDIA", DisplayOrder = 79},
                new Country() {ShortName = "HN", Name = "HONDURAS", DisplayOrder = 80},
                new Country() {ShortName = "HK", Name = "HONGKONG", DisplayOrder = 81},
                new Country() {ShortName = "IN", Name = "INDIE", DisplayOrder = 82},
                new Country() {ShortName = "ID", Name = "INDONEZJA", DisplayOrder = 83},
                new Country() {ShortName = "IR", Name = "IRAK", DisplayOrder = 84},
                new Country() {ShortName = "IQ", Name = "IRAN", DisplayOrder = 85},
                new Country() {ShortName = "IL", Name = "IRLANDIA", DisplayOrder = 86},
                new Country() {ShortName = "IS", Name = "ISLANDIA", DisplayOrder = 87},
                new Country() {ShortName = "IZ", Name = "IZRAEL", DisplayOrder = 88},
                new Country() {ShortName = "JA", Name = "JAMAJKA", DisplayOrder = 89},
                new Country() {ShortName = "JP", Name = "JAPONIA", DisplayOrder = 90},
                new Country() {ShortName = "YE", Name = "JEMEN", DisplayOrder = 91},
                new Country() {ShortName = "JO", Name = "JORDANIA", DisplayOrder = 92},
                new Country() {ShortName = "YU", Name = "JUGOSŁAWIA", DisplayOrder = 93},
                new Country() {ShortName = "CY", Name = "KAJMANY", DisplayOrder = 94},
                new Country() {ShortName = "KH", Name = "KAMBODŻA (KAMPUCZA)", DisplayOrder = 95},
                new Country() {ShortName = "CM", Name = "KAMERUN", DisplayOrder = 96},
                new Country() {ShortName = "CA", Name = "KANADA", DisplayOrder = 97},
                new Country() {ShortName = "QA", Name = "KATAR", DisplayOrder = 98},
                new Country() {ShortName = "KA", Name = "KAZACHSTAN", DisplayOrder = 99},
                new Country() {ShortName = "KE", Name = "KENIA", DisplayOrder = 100},
                new Country() {ShortName = "KI", Name = "KIRGISTAN (KIRGIZJA)", DisplayOrder = 101},
                new Country() {ShortName = "KR", Name = "KIRIBATI", DisplayOrder = 102},
                new Country() {ShortName = "CI", Name = "KOLUMBIA", DisplayOrder = 103},
                new Country() {ShortName = "KM", Name = "KOMORY", DisplayOrder = 104},
                new Country() {ShortName = "CO", Name = "KONGO", DisplayOrder = 105},
                new Country() {ShortName = "KO", Name = "KOREA POŁUDNIOWA", DisplayOrder = 106},
                new Country()
                {
                    ShortName = "RK",
                    Name = "KOREAŃSKA REPUBLIKA LUDOWO-DEMOKRATYCZNA (KOREA PÓŁNOCNA)",
                    DisplayOrder = 107
                },
                new Country() {ShortName = "CR", Name = "KOSTARYKA", DisplayOrder = 108},
                new Country() {ShortName = "CB", Name = "KUBA", DisplayOrder = 109},
                new Country() {ShortName = "KW", Name = "KUWEJT", DisplayOrder = 110},
                new Country() {ShortName = "LA", Name = "LAOS", DisplayOrder = 111},
                new Country() {ShortName = "LS", Name = "LESOTHO", DisplayOrder = 112},
                new Country() {ShortName = "LB", Name = "LIBAN", DisplayOrder = 113},
                new Country() {ShortName = "LR", Name = "LIBERIA", DisplayOrder = 114},
                new Country() {ShortName = "LY", Name = "LIBIA", DisplayOrder = 115},
                new Country() {ShortName = "LI", Name = "LICHTENSTEIN", DisplayOrder = 116},
                new Country() {ShortName = "LT", Name = "LITWA", DisplayOrder = 117},
                new Country() {ShortName = "LU", Name = "LUKSEMBURG", DisplayOrder = 118},
                new Country() {ShortName = "LO", Name = "ŁOTWA", DisplayOrder = 119},
                new Country() {ShortName = "YH", Name = "MACEDONIA", DisplayOrder = 120},
                new Country() {ShortName = "MG", Name = "MADAGASKAR", DisplayOrder = 121},
                new Country() {ShortName = "MA", Name = "MAKAU", DisplayOrder = 122},
                new Country() {ShortName = "MW", Name = "MALAWI", DisplayOrder = 123},
                new Country() {ShortName = "MD", Name = "MALEDIWY", DisplayOrder = 124},
                new Country() {ShortName = "MS", Name = "MALEZJA", DisplayOrder = 125},
                new Country() {ShortName = "ML", Name = "MALI", DisplayOrder = 126},
                new Country() {ShortName = "MT", Name = "MALTA", DisplayOrder = 127},
                new Country() {ShortName = "MR", Name = "MAROKO", DisplayOrder = 128},
                new Country() {ShortName = "MP", Name = "MARTYNIKA", DisplayOrder = 129},
                new Country() {ShortName = "MU", Name = "MAURETANIA", DisplayOrder = 130},
                new Country() {ShortName = "MY", Name = "MAURITIUS", DisplayOrder = 131},
                new Country() {ShortName = "MJ", Name = "MAYOTTE", DisplayOrder = 132},
                new Country() {ShortName = "ME", Name = "MEKSYK", DisplayOrder = 133},
                new Country() {ShortName = "MI", Name = "MIKRONEZJA", DisplayOrder = 134},
                new Country() {ShortName = "MO", Name = "MOŁDAWIA", DisplayOrder = 135},
                new Country() {ShortName = "MC", Name = "MONAKO", DisplayOrder = 136},
                new Country() {ShortName = "MN", Name = "MONGOLIA", DisplayOrder = 137},
                new Country() {ShortName = "MQ", Name = "MONTSERRAT", DisplayOrder = 138},
                new Country() {ShortName = "MZ", Name = "MOZAMBIK", DisplayOrder = 139},
                new Country() {ShortName = "NA", Name = "NAMIBIA", DisplayOrder = 140},
                new Country() {ShortName = "NR", Name = "NAURU", DisplayOrder = 141},
                new Country() {ShortName = "NP", Name = "NEPAL", DisplayOrder = 142},
                new Country() {ShortName = "DE", Name = "NIEMCY", DisplayOrder = 143},
                new Country() {ShortName = "NE", Name = "NIGER", DisplayOrder = 144},
                new Country() {ShortName = "NG", Name = "NIGERIA", DisplayOrder = 145},
                new Country() {ShortName = "NC", Name = "NIKARAGUA", DisplayOrder = 146},
                new Country() {ShortName = "NU", Name = "NIUE", DisplayOrder = 147},
                new Country() {ShortName = "NF", Name = "NORFOLK", DisplayOrder = 148},
                new Country() {ShortName = "NO", Name = "NORWEGIA", DisplayOrder = 149},
                new Country() {ShortName = "NK", Name = "NOWA KALEDONIA", DisplayOrder = 150},
                new Country() {ShortName = "NZ", Name = "NOWA ZELANDIA", DisplayOrder = 151},
                new Country() {ShortName = "NH", Name = "NOWE HEBRYDY", DisplayOrder = 152},
                new Country() {ShortName = "OM", Name = "OMAN", DisplayOrder = 153},
                new Country() {ShortName = "PA", Name = "PAKISTAN", DisplayOrder = 154},
                new Country() {ShortName = "PU", Name = "PALAU", DisplayOrder = 155},
                new Country() {ShortName = "PS", Name = "PALESTYNA", DisplayOrder = 156},
                new Country() {ShortName = "PN", Name = "PANAMA", DisplayOrder = 157},
                new Country() {ShortName = "PG", Name = "PAPUA NOWA GWINEA", DisplayOrder = 158},
                new Country() {ShortName = "PY", Name = "PARAGWAJ", DisplayOrder = 159},
                new Country() {ShortName = "PE", Name = "PERU", DisplayOrder = 160},
                new Country() {ShortName = "PT", Name = "PITCAIRN", DisplayOrder = 161},
                new Country() {ShortName = "PF", Name = "POLINEZJA", DisplayOrder = 162},
                new Country() {ShortName = "PL", Name = "POLSKA", DisplayOrder = 1},
                new Country() {ShortName = "PK", Name = "POLSKIE BEZ NR PESEL", DisplayOrder = 2, IsActive = false},
                new Country() {ShortName = "PI", Name = "PORTORYKO", DisplayOrder = 163},
                new Country() {ShortName = "PR", Name = "PORTUGALIA", DisplayOrder = 164},
                new Country() {ShortName = "RS", Name = "REPUBLIKA ŚRODKOWOAFRYKAŃSKA", DisplayOrder = 165},
                new Country() {ShortName = "RZ", Name = "REPUBLIKA ZIELONEGO PRZYLĄDKA", DisplayOrder = 166},
                new Country() {ShortName = "RE", Name = "REUNION", DisplayOrder = 167},
                new Country() {ShortName = "RH", Name = "RODEZJA", DisplayOrder = 168},
                new Country() {ShortName = "RO", Name = "ROSJA", DisplayOrder = 169},
                new Country() {ShortName = "RP", Name = "RPA (REPUBLIKA POŁUDNIOWEJ AFRYKI)", DisplayOrder = 170},
                new Country() {ShortName = "RA", Name = "RUANDA", DisplayOrder = 171},
                new Country() {ShortName = "RU", Name = "RUMUNIA", DisplayOrder = 172},
                new Country() {ShortName = "SH", Name = "SAHARA ZACHODNIA", DisplayOrder = 173},
                new Country() {ShortName = "SY", Name = "SALWADOR", DisplayOrder = 174},
                new Country() {ShortName = "SS", Name = "SAMOA AMERYKAŃSKIE", DisplayOrder = 175},
                new Country() {ShortName = "SN", Name = "SAMOA ZACHODNIE", DisplayOrder = 176},
                new Country() {ShortName = "SM", Name = "SAN MARINO", DisplayOrder = 177},
                new Country() {ShortName = "SE", Name = "SENEGAL", DisplayOrder = 178},
                new Country() {ShortName = "YJ", Name = "SERBIA,CZARNOGÓRA", DisplayOrder = 179},
                new Country() {ShortName = "SC", Name = "SESZELE", DisplayOrder = 180},
                new Country() {ShortName = "SB", Name = "SIERRA LEONE", DisplayOrder = 181},
                new Country() {ShortName = "SK", Name = "SIKKIM", DisplayOrder = 182},
                new Country() {ShortName = "SG", Name = "SINGAPUR", DisplayOrder = 183},
                new Country() {ShortName = "SL", Name = "SŁOWACJA", DisplayOrder = 184},
                new Country() {ShortName = "YI", Name = "SŁOWENIA", DisplayOrder = 185},
                new Country() {ShortName = "SO", Name = "SOMALIA", DisplayOrder = 186},
                new Country() {ShortName = "LK", Name = "SRI LANKA (CEJLON)", DisplayOrder = 187},
                new Country() {ShortName = "SZ", Name = "SUAZI", DisplayOrder = 188},
                new Country() {ShortName = "SD", Name = "SUDAN", DisplayOrder = 189},
                new Country() {ShortName = "SR", Name = "SURINAM", DisplayOrder = 190},
                new Country() {ShortName = "SP", Name = "SYRIA", DisplayOrder = 191},
                new Country() {ShortName = "CH", Name = "SZWAJCARIA", DisplayOrder = 192},
                new Country() {ShortName = "SW", Name = "SZWECJA", DisplayOrder = 193},
                new Country() {ShortName = "TA", Name = "TADŻYKISTAN", DisplayOrder = 194},
                new Country() {ShortName = "TH", Name = "TAJLANDIA (SYJAM)", DisplayOrder = 195},
                new Country() {ShortName = "TN", Name = "TAJWAN", DisplayOrder = 196},
                new Country() {ShortName = "TZ", Name = "TANZANIA", DisplayOrder = 197},
                new Country() {ShortName = "TM", Name = "TIMOR", DisplayOrder = 198},
                new Country() {ShortName = "TG", Name = "TOGO", DisplayOrder = 199},
                new Country() {ShortName = "TL", Name = "TOKELAU", DisplayOrder = 200},
                new Country() {ShortName = "TO", Name = "TONGA", DisplayOrder = 201},
                new Country() {ShortName = "TT", Name = "TRYNIDAD I TOBAGO", DisplayOrder = 202},
                new Country() {ShortName = "TE", Name = "TUNEZJA", DisplayOrder = 203},
                new Country() {ShortName = "TU", Name = "TURCJA", DisplayOrder = 204},
                new Country() {ShortName = "TR", Name = "TURKIESTAN", DisplayOrder = 205},
                new Country() {ShortName = "TK", Name = "TURKMENISTAN (TURKMENIA)", DisplayOrder = 206},
                new Country() {ShortName = "TC", Name = "TURKS I CAICOS", DisplayOrder = 207},
                new Country() {ShortName = "TV", Name = "TUVALU", DisplayOrder = 208},
                new Country() {ShortName = "UG", Name = "UGANDA", DisplayOrder = 209},
                new Country() {ShortName = "UK", Name = "UKRAINA", DisplayOrder = 210},
                new Country() {ShortName = "UR", Name = "URUGWAJ", DisplayOrder = 211},
                new Country() {ShortName = "US", Name = "USA (STANY ZJEDNOCZONE AMERYKI)", DisplayOrder = 212},
                new Country() {ShortName = "UZ", Name = "UZBEKISTAN", DisplayOrder = 213},
                new Country() {ShortName = "VU", Name = "VANUATU", DisplayOrder = 214},
                new Country() {ShortName = "VK", Name = "WAKE", DisplayOrder = 215},
                new Country() {ShortName = "VF", Name = "WALLIS I FUTUNA", DisplayOrder = 216},
                new Country() {ShortName = "VA", Name = "WATYKAN", DisplayOrder = 217},
                new Country() {ShortName = "VE", Name = "WENEZUELA", DisplayOrder = 218},
                new Country() {ShortName = "HU", Name = "WĘGRY", DisplayOrder = 219},
                new Country() {ShortName = "GB", Name = "WIELKA BRYTANIA", DisplayOrder = 220},
                new Country() {ShortName = "VD", Name = "WIETNAM", DisplayOrder = 221},
                new Country() {ShortName = "IT", Name = "WŁOCHY", DisplayOrder = 222},
                new Country() {ShortName = "WN", Name = "WSPÓLNOTA NIEPODLEGŁYCH PAŃSTW", DisplayOrder = 223},
                new Country() {ShortName = "WK", Name = "WYBRZEŻE KOŚCI SŁONIOWEJ", DisplayOrder = 224},
                new Country() {ShortName = "VO", Name = "WYSPY BOŻEGO NARODZENIA", DisplayOrder = 225},
                new Country() {ShortName = "VC", Name = "WYSPY COOKA", DisplayOrder = 226},
                new Country() {ShortName = "VZ", Name = "WYSPY DZIEWICZE (USA)", DisplayOrder = 227},
                new Country() {ShortName = "VB", Name = "WYSPY DZIEWICZE (WLK. BRYT.)", DisplayOrder = 228},
                new Country() {ShortName = "VS", Name = "WYSPY KOKOSOWE", DisplayOrder = 229},
                new Country() {ShortName = "VM", Name = "WYSPY MARSHALLA", DisplayOrder = 230},
                new Country() {ShortName = "VL", Name = "WYSPY SALOMONA", DisplayOrder = 231},
                new Country() {ShortName = "VG", Name = "WYSPY ŚWIĘTEGO TOMASZA I KSIĘŻYCA", DisplayOrder = 232},
                new Country() {ShortName = "CV", Name = "WYSPY ZIELONEGO PRZYLĄDKA", DisplayOrder = 233},
                new Country() {ShortName = "ZM", Name = "ZAMBIA", DisplayOrder = 234},
                new Country() {ShortName = "ZI", Name = "ZIMBABWE (RODEZJA)", DisplayOrder = 235},
                new Country() {ShortName = "ZE", Name = "ZJEDNOCZONE EMIRATY ARABSKIE", DisplayOrder = 236},
                new Country() {ShortName = "SU", Name = "ZSRR", DisplayOrder = 237}
            };

            #endregion

            #region QuestionForms (Forma zapytania)
            QuestionForms = new TestDbSet<QuestionForm>
            {
                new QuestionForm() {ShortName = "", Name = "E-15", DisplayOrder = 1},
                new QuestionForm() {ShortName = "", Name = "PISMO", DisplayOrder = 2},
                new QuestionForm() {ShortName = "", Name = "POLECENIE SZEFA", DisplayOrder = 3}
            };

            #endregion

            #region QueryReasons (Powód sprawdzenia)
            QuestionReasons = new TestDbSet<QuestionReason>
            {
                new QuestionReason() {Name = "A", Description = "ROZPRACOWANIE", DisplayOrder = 1},
                new QuestionReason() {Name = "AA", Description = "PRZED ZAINTERESOWANIEM OPERACYJNYM", DisplayOrder = 2},
                new QuestionReason() {Name = "QA", Description = "POSTĘPOWANIE SPRAWDZAJĄCE", DisplayOrder = 3},
                new QuestionReason() {Name = "QK", Description = "KONCESJA", DisplayOrder = 4},
                new QuestionReason()
                {
                    Name = "J",
                    Description = "DOPUSZCZENIE DO INFORMACJI NIEJAWNYCH",
                    DisplayOrder = 5
                },
                new QuestionReason()
                {
                    Name = "QC",
                    Description = "RODZINA (KONKUBENT) OPINIOWANEGO W POST. SPRAW.",
                    DisplayOrder = 6
                },
                new QuestionReason() {Name = "Q", Description = "OPINIOWANIE", DisplayOrder = 7},
                new QuestionReason() {Name = "U", Description = "SPRAWDZENIE KANDYDATA DO ŻW", DisplayOrder = 8},
                new QuestionReason() {Name = "AB", Description = "PRZED REJESTRACJĄ", DisplayOrder = 9},
                new QuestionReason() {Name = "AC", Description = "PRZED ROZMOWĄ", DisplayOrder = 10},
                new QuestionReason() {Name = "AD", Description = "PRZED ZASADZKĄ", DisplayOrder = 11},
                new QuestionReason() {Name = "KU", Description = "KANDYDAT DO SŁUŻBY (PRACY)", DisplayOrder = 12},
                new QuestionReason()
                {
                    Name = "KW",
                    Description = "RODZINA KANDYDATA DO SŁUŻBY (PRACY)",
                    DisplayOrder = 13
                },
                new QuestionReason()
                {
                    Name = "KZ",
                    Description = "RODZINA FUNKCJONARIUSZA (PRACOWNIKA)",
                    DisplayOrder = 14
                },
                new QuestionReason() {Name = "PA", Description = "PRZED (PO) ZATRZYMANIEM (-IU)", DisplayOrder = 15},
                new QuestionReason() {Name = "PB", Description = "PRZED PRZESZUKANIEM", DisplayOrder = 16},
                new QuestionReason() {Name = "PC", Description = "PRZED PRZESŁUCHANIEM", DisplayOrder = 17},
                new QuestionReason() {Name = "PD", Description = "PRZED PRZEDSTAWIENIEM ZARZUTU", DisplayOrder = 18},
                new QuestionReason()
                {
                    Name = "PE",
                    Description = "PRZED (PO) ZASTOSOWANIEM (IU) ŚRODKA ZAPOBIEGAWCZEGO",
                    DisplayOrder = 19
                },
                new QuestionReason() {Name = "PF", Description = "PRZED POSZUKIWANIEM", DisplayOrder = 20},
                new QuestionReason()
                {
                    Name = "QD",
                    Description = "KONTAKT OPINIOWANEGO W POST. SPRAW.",
                    DisplayOrder = 21
                }
            };

            #endregion

            #region Ranks (Stopnie wojskowe tytuły)
            Ranks = new TestDbSet<Rank>();
            var of = new Rank() { Name = "OF", Description = "OFICER", DisplayOrder = 1 };
            Ranks.Add(of);
            Ranks.Add(new Rank() { Name = "PŁK", Description = "", DisplayOrder = 5, Masteritem = of });
            Ranks.Add(new Rank() { Name = "PPŁK", Description = "", DisplayOrder = 6, Masteritem = of });
            Ranks.Add(new Rank() { Name = "MJR", Description = "", DisplayOrder = 7, Masteritem = of });
            Ranks.Add(new Rank() { Name = "KPT.", Description = "", DisplayOrder = 8, Masteritem = of });
            Ranks.Add(new Rank() { Name = "POR.", Description = "", DisplayOrder = 9, Masteritem = of });
            var pdf = new Rank() { Name = "PDF", Description = "PODOFICER", DisplayOrder = 2 };
            Ranks.Add(pdf);
            Ranks.Add(new Rank() { Name = "ST.CHOR.SZTAB.", Description = "", DisplayOrder = 10, Masteritem = pdf });
            Ranks.Add(new Rank() { Name = "CHOR.SZTAB.", Description = "", DisplayOrder = 11, Masteritem = pdf });
            Ranks.Add(new Rank() { Name = "MŁ.CHOR.SZTAB.", Description = "", DisplayOrder = 12, Masteritem = pdf });
            Ranks.Add(new Rank() { Name = "ST.CHOR.", Description = "", DisplayOrder = 13, Masteritem = pdf });
            Ranks.Add(new Rank() { Name = "CHOR.", Description = "", DisplayOrder = 14, Masteritem = pdf });
            var szer = new Rank() { Name = "SZER. ZAW.", Description = "SZEREGOWY ZAWODOWY", DisplayOrder = 3 };
            Ranks.Add(szer);
            Ranks.Add(new Rank() { Name = "SZER.", Description = "", DisplayOrder = 15, Masteritem = szer });
            Ranks.Add(new Rank() { Name = "ST.SZER.", Description = "", DisplayOrder = 16, Masteritem = szer });
            var oc = new Rank() { Name = "CYW.", Description = "OSOBA CYWILNA", DisplayOrder = 4, Masteritem = szer };
            Ranks.Add(oc);
            Ranks.Add(new Rank() { Name = "PW", Description = "PRACOWNIK WOJSKA", DisplayOrder = 17, Masteritem = oc });
            Ranks.Add(new Rank() { Name = "OC", Description = "OSOBA NIE ZWIĄZANA Z WOJSKIEM", DisplayOrder = 18, Masteritem = oc });
            #endregion

            #region Organizations, OrganizationalUnits (Instytucje, Jedostki organizacyjne)
            Organizations = new TestDbSet<Organization>();
            OrganizationalUnits = new TestDbSet<OrganizationalUnit>();
            var zw = new Organization() { ShortName = "ŻW", Name = "ŻANDARMERIA WOJSKOWA", Description = "", DisplayOrder = 10 };
            Organizations.Add(zw);
            var kg = new OrganizationalUnit() { Name = "KG ŻW", Description = "KOMENDA GŁÓWNA ŻANDARMERII WOJSKOWEJ", DisplayOrder = 101, Organization = zw };
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "ODDZIAŁ KRYMINALNY KGŻW", Description = "ODDZIAŁ KRYMINALNY KGŻW", DisplayOrder = 102, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "MOŻW WARSZAWA", Description = "MAZOWIECKI ODDZIAŁ ŻANDARMERII WOJSKOWEJ", DisplayOrder = 101, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OOIN KGŻW", Description = "ODDZIAŁ OCHRONY INFORMACJI NIEJAWNYCH KGŻW", DisplayOrder = 103, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW BYDGOSZCZ", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ BYDGOSZCZ", DisplayOrder = 103, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW ELBLĄG", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ ELBLĄG", DisplayOrder = 104, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW KRAKÓW", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ KRAKÓW", DisplayOrder = 105, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW SZCZECIN", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ SZCZECIN", DisplayOrder = 106, MasterUnit = kg, Organization = zw });
            OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW ŻAGAŃ", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ ŻAGAŃ", DisplayOrder = 107, MasterUnit = kg, Organization = zw });

            Organizations.Add(new Organization() { ShortName = "", Name = "SKW", Description = "SŁUŻBA KONTRWYWIADU WOJSKOWEGO", DisplayOrder = 20 });
            Organizations.Add(new Organization() { ShortName = "", Name = "SWW", Description = "SŁUŻBA WYWIADU WOJSKOWEGO", DisplayOrder = 30 });
            Organizations.Add(new Organization() { ShortName = "", Name = "POLICJA", Description = "POLICJA", DisplayOrder = 40 });
            Organizations.Add(new Organization() { ShortName = "", Name = "STRAŻ GRANICZNA", Description = "STRAŻ GRANICZNA", DisplayOrder = 50 });
            Organizations.Add(new Organization() { ShortName = "", Name = "BOR", Description = "BIURO OCHRONY RZĄDU", DisplayOrder = 60 });
            Organizations.Add(new Organization() { ShortName = "", Name = "DEPARTAMENT KADR", Description = "DEPARTAMENT KADR MON", DisplayOrder = 70 });
            Organizations.Add(new Organization() { ShortName = "", Name = "AGENCA BW i W", Description = "AGENCJA BEZPIECZEŃSWTA WEWNĘTRZNEGO i AGENCJA WYWIADU", DisplayOrder = 80 });


            #endregion

            Users = new TestDbSet<User> {new User() {Login = Environment.UserName, Name = "Użytkownik Testowy"}};

            Persons = new TestDbSet<Person>();
            for (var i = 0; i < 100; i++)
            {
                var pesel = "00000000000" + i;
                Persons.Add(new Person { Pesel = pesel.Substring(pesel.Length - 11, 11), FirstName = "IMIĘ" + i, LastName = "NAZWISKO" + i, Sex = "M" });
            }

            Questions = new TestDbSet<Question>();
            Verifications = new TestDbSet<Verification>();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionForm> QuestionForms { get; set; }
        public DbSet<QuestionReason> QuestionReasons { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<User> Users { get; set; }
        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            SaveChangesCount++;
            return 1;
        } 
    }
}
