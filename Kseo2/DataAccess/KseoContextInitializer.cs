using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.DataAccess
{
    public class KseoContextInitializer : DropCreateDatabaseIfModelChanges<KseoContext> //DropCreateDatabaseAlways<KseoContext>
    {
        protected override void Seed(KseoContext context)
        {

         #region Inicjowanie słowników

            #region Countries (Kraje)
            context.Countries.Add(new Country() { ShortName = "AF", Name = "AFGANISTAN", DisplayOrder = 3 });
            context.Countries.Add(new Country() { ShortName = "AL", Name = "ALBANIA", DisplayOrder = 4 });
            context.Countries.Add(new Country() { ShortName = "DA", Name = "ALGIERIA", DisplayOrder = 5 });
            context.Countries.Add(new Country() { ShortName = "AN", Name = "ANDORA", DisplayOrder = 6 });
            context.Countries.Add(new Country() { ShortName = "AG", Name = "ANGOLA", DisplayOrder = 7 });
            context.Countries.Add(new Country() { ShortName = "AC", Name = "ANGUILLA", DisplayOrder = 8 });
            context.Countries.Add(new Country() { ShortName = "AA", Name = "ANTARKTYDA", DisplayOrder = 9 });
            context.Countries.Add(new Country() { ShortName = "AT", Name = "ANTIGUA I BARBUDA", DisplayOrder = 10 });
            context.Countries.Add(new Country() { ShortName = "AY", Name = "ANTYLE HOLENDERSKIE", DisplayOrder = 11 });
            context.Countries.Add(new Country() { ShortName = "AI", Name = "ARABIA SAUDYJSKA", DisplayOrder = 12 });
            context.Countries.Add(new Country() { ShortName = "AB", Name = "ARGENTYNA", DisplayOrder = 13 });
            context.Countries.Add(new Country() { ShortName = "AR", Name = "ARMENIA", DisplayOrder = 14 });
            context.Countries.Add(new Country() { ShortName = "AD", Name = "ARUBA", DisplayOrder = 15 });
            context.Countries.Add(new Country() { ShortName = "AS", Name = "AUSTRALIA", DisplayOrder = 16 });
            context.Countries.Add(new Country() { ShortName = "AU", Name = "AUSTRIA", DisplayOrder = 17 });
            context.Countries.Add(new Country() { ShortName = "AZ", Name = "AZERBEJDŻAN", DisplayOrder = 18 });
            context.Countries.Add(new Country() { ShortName = "BH", Name = "BAHAMY", DisplayOrder = 19 });
            context.Countries.Add(new Country() { ShortName = "BR", Name = "BAHRJAN", DisplayOrder = 20 });
            context.Countries.Add(new Country() { ShortName = "BC", Name = "BANGLADESZ", DisplayOrder = 21 });
            context.Countries.Add(new Country() { ShortName = "BB", Name = "BARBADOS", DisplayOrder = 22 });
            context.Countries.Add(new Country() { ShortName = "BE", Name = "BELGIA", DisplayOrder = 23 });
            context.Countries.Add(new Country() { ShortName = "BL", Name = "BELIZE", DisplayOrder = 24 });
            context.Countries.Add(new Country() { ShortName = "BM", Name = "BERMUDY", DisplayOrder = 25 });
            context.Countries.Add(new Country() { ShortName = "BP", Name = "BEZPAŃSTWOWIEC", DisplayOrder = 26 });
            context.Countries.Add(new Country() { ShortName = "BT", Name = "BHUTAN", DisplayOrder = 27 });
            context.Countries.Add(new Country() { ShortName = "BI", Name = "BIAŁORUŚ", DisplayOrder = 28 });
            context.Countries.Add(new Country() { ShortName = "BU", Name = "BIRMA (MYANMAR)", DisplayOrder = 29 });
            context.Countries.Add(new Country() { ShortName = "BO", Name = "BOLIWIA", DisplayOrder = 30 });
            context.Countries.Add(new Country() { ShortName = "YF", Name = "BOŚNIA,HERCEGOWINA", DisplayOrder = 31 });
            context.Countries.Add(new Country() { ShortName = "BW", Name = "BOTSWANA", DisplayOrder = 32 });
            context.Countries.Add(new Country() { ShortName = "XX", Name = "BRAK DANYCH", DisplayOrder = 33 });
            context.Countries.Add(new Country() { ShortName = "BA", Name = "BRAZYLIA", DisplayOrder = 34 });
            context.Countries.Add(new Country() { ShortName = "BN", Name = "BRUNEI", DisplayOrder = 35 });
            context.Countries.Add(new Country() { ShortName = "BJ", Name = "BRYTYJSKIE TERYTORIUM OCEANU INDYJSKIEGO", DisplayOrder = 36 });
            context.Countries.Add(new Country() { ShortName = "BG", Name = "BUŁGARIA", DisplayOrder = 37 });
            context.Countries.Add(new Country() { ShortName = "BK", Name = "BURKINA FASO (GÓRNA WOLTA)", DisplayOrder = 38 });
            context.Countries.Add(new Country() { ShortName = "BD", Name = "BURUNDI", DisplayOrder = 39 });
            context.Countries.Add(new Country() { ShortName = "CL", Name = "CHILE", DisplayOrder = 40 });
            context.Countries.Add(new Country() { ShortName = "CN", Name = "CHINY", DisplayOrder = 41 });
            context.Countries.Add(new Country() { ShortName = "YG", Name = "CHORWACJA", DisplayOrder = 42 });
            context.Countries.Add(new Country() { ShortName = "CP", Name = "CYPR", DisplayOrder = 43 });
            context.Countries.Add(new Country() { ShortName = "CD", Name = "CZAD", DisplayOrder = 44 });
            context.Countries.Add(new Country() { ShortName = "CS", Name = "CZECHOSŁOWACJA", DisplayOrder = 45 });
            context.Countries.Add(new Country() { ShortName = "CZ", Name = "CZECHY", DisplayOrder = 46 });
            context.Countries.Add(new Country() { ShortName = "DN", Name = "DANIA", DisplayOrder = 47 });
            context.Countries.Add(new Country() { ShortName = "ZA", Name = "DEMOKRATYCZNA REPUBLIKA KONGA (ZAIR)", DisplayOrder = 48 });
            context.Countries.Add(new Country() { ShortName = "DM", Name = "DOMINIKA", DisplayOrder = 49 });
            context.Countries.Add(new Country() { ShortName = "DO", Name = "DOMINIKANA", DisplayOrder = 50 });
            context.Countries.Add(new Country() { ShortName = "DI", Name = "DŻIBUTI", DisplayOrder = 51 });
            context.Countries.Add(new Country() { ShortName = "EG", Name = "EGIPT", DisplayOrder = 52 });
            context.Countries.Add(new Country() { ShortName = "EC", Name = "EKWADOR", DisplayOrder = 53 });
            context.Countries.Add(new Country() { ShortName = "ER", Name = "ERYTREA", DisplayOrder = 54 });
            context.Countries.Add(new Country() { ShortName = "ET", Name = "ESTONIA", DisplayOrder = 55 });
            context.Countries.Add(new Country() { ShortName = "EH", Name = "ETIOPIA", DisplayOrder = 56 });
            context.Countries.Add(new Country() { ShortName = "FL", Name = "FALKLANDY/MALWINY", DisplayOrder = 57 });
            context.Countries.Add(new Country() { ShortName = "FJ", Name = "FIDŻI", DisplayOrder = 58 });
            context.Countries.Add(new Country() { ShortName = "PH", Name = "FILIPINY", DisplayOrder = 59 });
            context.Countries.Add(new Country() { ShortName = "FI", Name = "FINLANDIA", DisplayOrder = 60 });
            context.Countries.Add(new Country() { ShortName = "FR", Name = "FRANCJA", DisplayOrder = 61 });
            context.Countries.Add(new Country() { ShortName = "GA", Name = "GABON", DisplayOrder = 62 });
            context.Countries.Add(new Country() { ShortName = "GM", Name = "GAMBIA", DisplayOrder = 63 });
            context.Countries.Add(new Country() { ShortName = "GH", Name = "GHANA", DisplayOrder = 64 });
            context.Countries.Add(new Country() { ShortName = "GI", Name = "GIBRALTAR", DisplayOrder = 65 });
            context.Countries.Add(new Country() { ShortName = "GR", Name = "GRECJA", DisplayOrder = 66 });
            context.Countries.Add(new Country() { ShortName = "GD", Name = "GRENADA", DisplayOrder = 67 });
            context.Countries.Add(new Country() { ShortName = "GL", Name = "GRENLANDIA", DisplayOrder = 68 });
            context.Countries.Add(new Country() { ShortName = "GU", Name = "GRUZJA", DisplayOrder = 69 });
            context.Countries.Add(new Country() { ShortName = "GN", Name = "GUAM", DisplayOrder = 70 });
            context.Countries.Add(new Country() { ShortName = "GW", Name = "GUJANA", DisplayOrder = 71 });
            context.Countries.Add(new Country() { ShortName = "GJ", Name = "GWADELUPA", DisplayOrder = 72 });
            context.Countries.Add(new Country() { ShortName = "GT", Name = "GWATEMALA", DisplayOrder = 73 });
            context.Countries.Add(new Country() { ShortName = "GS", Name = "GWINEA", DisplayOrder = 74 });
            context.Countries.Add(new Country() { ShortName = "GE", Name = "GWINEA BISSAU", DisplayOrder = 75 });
            context.Countries.Add(new Country() { ShortName = "GK", Name = "GWINEA RÓWNIKOWA", DisplayOrder = 76 });
            context.Countries.Add(new Country() { ShortName = "HT", Name = "HAITI", DisplayOrder = 77 });
            context.Countries.Add(new Country() { ShortName = "ES", Name = "HISZPANIA", DisplayOrder = 78 });
            context.Countries.Add(new Country() { ShortName = "NL", Name = "HOLANDIA", DisplayOrder = 79 });
            context.Countries.Add(new Country() { ShortName = "HN", Name = "HONDURAS", DisplayOrder = 80 });
            context.Countries.Add(new Country() { ShortName = "HK", Name = "HONGKONG", DisplayOrder = 81 });
            context.Countries.Add(new Country() { ShortName = "IN", Name = "INDIE", DisplayOrder = 82 });
            context.Countries.Add(new Country() { ShortName = "ID", Name = "INDONEZJA", DisplayOrder = 83 });
            context.Countries.Add(new Country() { ShortName = "IR", Name = "IRAK", DisplayOrder = 84 });
            context.Countries.Add(new Country() { ShortName = "IQ", Name = "IRAN", DisplayOrder = 85 });
            context.Countries.Add(new Country() { ShortName = "IL", Name = "IRLANDIA", DisplayOrder = 86 });
            context.Countries.Add(new Country() { ShortName = "IS", Name = "ISLANDIA", DisplayOrder = 87 });
            context.Countries.Add(new Country() { ShortName = "IZ", Name = "IZRAEL", DisplayOrder = 88 });
            context.Countries.Add(new Country() { ShortName = "JA", Name = "JAMAJKA", DisplayOrder = 89 });
            context.Countries.Add(new Country() { ShortName = "JP", Name = "JAPONIA", DisplayOrder = 90 });
            context.Countries.Add(new Country() { ShortName = "YE", Name = "JEMEN", DisplayOrder = 91 });
            context.Countries.Add(new Country() { ShortName = "JO", Name = "JORDANIA", DisplayOrder = 92 });
            context.Countries.Add(new Country() { ShortName = "YU", Name = "JUGOSŁAWIA", DisplayOrder = 93 });
            context.Countries.Add(new Country() { ShortName = "CY", Name = "KAJMANY", DisplayOrder = 94 });
            context.Countries.Add(new Country() { ShortName = "KH", Name = "KAMBODŻA (KAMPUCZA)", DisplayOrder = 95 });
            context.Countries.Add(new Country() { ShortName = "CM", Name = "KAMERUN", DisplayOrder = 96 });
            context.Countries.Add(new Country() { ShortName = "CA", Name = "KANADA", DisplayOrder = 97 });
            context.Countries.Add(new Country() { ShortName = "QA", Name = "KATAR", DisplayOrder = 98 });
            context.Countries.Add(new Country() { ShortName = "KA", Name = "KAZACHSTAN", DisplayOrder = 99 });
            context.Countries.Add(new Country() { ShortName = "KE", Name = "KENIA", DisplayOrder = 100 });
            context.Countries.Add(new Country() { ShortName = "KI", Name = "KIRGISTAN (KIRGIZJA)", DisplayOrder = 101 });
            context.Countries.Add(new Country() { ShortName = "KR", Name = "KIRIBATI", DisplayOrder = 102 });
            context.Countries.Add(new Country() { ShortName = "CI", Name = "KOLUMBIA", DisplayOrder = 103 });
            context.Countries.Add(new Country() { ShortName = "KM", Name = "KOMORY", DisplayOrder = 104 });
            context.Countries.Add(new Country() { ShortName = "CO", Name = "KONGO", DisplayOrder = 105 });
            context.Countries.Add(new Country() { ShortName = "KO", Name = "KOREA POŁUDNIOWA", DisplayOrder = 106 });
            context.Countries.Add(new Country() { ShortName = "RK", Name = "KOREAŃSKA REPUBLIKA LUDOWO-DEMOKRATYCZNA (KOREA PÓŁNOCNA)", DisplayOrder = 107 });
            context.Countries.Add(new Country() { ShortName = "CR", Name = "KOSTARYKA", DisplayOrder = 108 });
            context.Countries.Add(new Country() { ShortName = "CB", Name = "KUBA", DisplayOrder = 109 });
            context.Countries.Add(new Country() { ShortName = "KW", Name = "KUWEJT", DisplayOrder = 110 });
            context.Countries.Add(new Country() { ShortName = "LA", Name = "LAOS", DisplayOrder = 111 });
            context.Countries.Add(new Country() { ShortName = "LS", Name = "LESOTHO", DisplayOrder = 112 });
            context.Countries.Add(new Country() { ShortName = "LB", Name = "LIBAN", DisplayOrder = 113 });
            context.Countries.Add(new Country() { ShortName = "LR", Name = "LIBERIA", DisplayOrder = 114 });
            context.Countries.Add(new Country() { ShortName = "LY", Name = "LIBIA", DisplayOrder = 115 });
            context.Countries.Add(new Country() { ShortName = "LI", Name = "LICHTENSTEIN", DisplayOrder = 116 });
            context.Countries.Add(new Country() { ShortName = "LT", Name = "LITWA", DisplayOrder = 117 });
            context.Countries.Add(new Country() { ShortName = "LU", Name = "LUKSEMBURG", DisplayOrder = 118 });
            context.Countries.Add(new Country() { ShortName = "LO", Name = "ŁOTWA", DisplayOrder = 119 });
            context.Countries.Add(new Country() { ShortName = "YH", Name = "MACEDONIA", DisplayOrder = 120 });
            context.Countries.Add(new Country() { ShortName = "MG", Name = "MADAGASKAR", DisplayOrder = 121 });
            context.Countries.Add(new Country() { ShortName = "MA", Name = "MAKAU", DisplayOrder = 122 });
            context.Countries.Add(new Country() { ShortName = "MW", Name = "MALAWI", DisplayOrder = 123 });
            context.Countries.Add(new Country() { ShortName = "MD", Name = "MALEDIWY", DisplayOrder = 124 });
            context.Countries.Add(new Country() { ShortName = "MS", Name = "MALEZJA", DisplayOrder = 125 });
            context.Countries.Add(new Country() { ShortName = "ML", Name = "MALI", DisplayOrder = 126 });
            context.Countries.Add(new Country() { ShortName = "MT", Name = "MALTA", DisplayOrder = 127 });
            context.Countries.Add(new Country() { ShortName = "MR", Name = "MAROKO", DisplayOrder = 128 });
            context.Countries.Add(new Country() { ShortName = "MP", Name = "MARTYNIKA", DisplayOrder = 129 });
            context.Countries.Add(new Country() { ShortName = "MU", Name = "MAURETANIA", DisplayOrder = 130 });
            context.Countries.Add(new Country() { ShortName = "MY", Name = "MAURITIUS", DisplayOrder = 131 });
            context.Countries.Add(new Country() { ShortName = "MJ", Name = "MAYOTTE", DisplayOrder = 132 });
            context.Countries.Add(new Country() { ShortName = "ME", Name = "MEKSYK", DisplayOrder = 133 });
            context.Countries.Add(new Country() { ShortName = "MI", Name = "MIKRONEZJA", DisplayOrder = 134 });
            context.Countries.Add(new Country() { ShortName = "MO", Name = "MOŁDAWIA", DisplayOrder = 135 });
            context.Countries.Add(new Country() { ShortName = "MC", Name = "MONAKO", DisplayOrder = 136 });
            context.Countries.Add(new Country() { ShortName = "MN", Name = "MONGOLIA", DisplayOrder = 137 });
            context.Countries.Add(new Country() { ShortName = "MQ", Name = "MONTSERRAT", DisplayOrder = 138 });
            context.Countries.Add(new Country() { ShortName = "MZ", Name = "MOZAMBIK", DisplayOrder = 139 });
            context.Countries.Add(new Country() { ShortName = "NA", Name = "NAMIBIA", DisplayOrder = 140 });
            context.Countries.Add(new Country() { ShortName = "NR", Name = "NAURU", DisplayOrder = 141 });
            context.Countries.Add(new Country() { ShortName = "NP", Name = "NEPAL", DisplayOrder = 142 });
            context.Countries.Add(new Country() { ShortName = "DE", Name = "NIEMCY", DisplayOrder = 143 });
            context.Countries.Add(new Country() { ShortName = "NE", Name = "NIGER", DisplayOrder = 144 });
            context.Countries.Add(new Country() { ShortName = "NG", Name = "NIGERIA", DisplayOrder = 145 });
            context.Countries.Add(new Country() { ShortName = "NC", Name = "NIKARAGUA", DisplayOrder = 146 });
            context.Countries.Add(new Country() { ShortName = "NU", Name = "NIUE", DisplayOrder = 147 });
            context.Countries.Add(new Country() { ShortName = "NF", Name = "NORFOLK", DisplayOrder = 148 });
            context.Countries.Add(new Country() { ShortName = "NO", Name = "NORWEGIA", DisplayOrder = 149 });
            context.Countries.Add(new Country() { ShortName = "NK", Name = "NOWA KALEDONIA", DisplayOrder = 150 });
            context.Countries.Add(new Country() { ShortName = "NZ", Name = "NOWA ZELANDIA", DisplayOrder = 151 });
            context.Countries.Add(new Country() { ShortName = "NH", Name = "NOWE HEBRYDY", DisplayOrder = 152 });
            context.Countries.Add(new Country() { ShortName = "OM", Name = "OMAN", DisplayOrder = 153 });
            context.Countries.Add(new Country() { ShortName = "PA", Name = "PAKISTAN", DisplayOrder = 154 });
            context.Countries.Add(new Country() { ShortName = "PU", Name = "PALAU", DisplayOrder = 155 });
            context.Countries.Add(new Country() { ShortName = "PS", Name = "PALESTYNA", DisplayOrder = 156 });
            context.Countries.Add(new Country() { ShortName = "PN", Name = "PANAMA", DisplayOrder = 157 });
            context.Countries.Add(new Country() { ShortName = "PG", Name = "PAPUA NOWA GWINEA", DisplayOrder = 158 });
            context.Countries.Add(new Country() { ShortName = "PY", Name = "PARAGWAJ", DisplayOrder = 159 });
            context.Countries.Add(new Country() { ShortName = "PE", Name = "PERU", DisplayOrder = 160 });
            context.Countries.Add(new Country() { ShortName = "PT", Name = "PITCAIRN", DisplayOrder = 161 });
            context.Countries.Add(new Country() { ShortName = "PF", Name = "POLINEZJA", DisplayOrder = 162 });
            context.Countries.Add(new Country() { ShortName = "PL", Name = "POLSKA", DisplayOrder = 1 });
            context.Countries.Add(new Country() { ShortName = "PK", Name = "POLSKIE BEZ NR PESEL", DisplayOrder = 2, IsActive = false });
            context.Countries.Add(new Country() { ShortName = "PI", Name = "PORTORYKO", DisplayOrder = 163 });
            context.Countries.Add(new Country() { ShortName = "PR", Name = "PORTUGALIA", DisplayOrder = 164 });
            context.Countries.Add(new Country() { ShortName = "RS", Name = "REPUBLIKA ŚRODKOWOAFRYKAŃSKA", DisplayOrder = 165 });
            context.Countries.Add(new Country() { ShortName = "RZ", Name = "REPUBLIKA ZIELONEGO PRZYLĄDKA", DisplayOrder = 166 });
            context.Countries.Add(new Country() { ShortName = "RE", Name = "REUNION", DisplayOrder = 167 });
            context.Countries.Add(new Country() { ShortName = "RH", Name = "RODEZJA", DisplayOrder = 168 });
            context.Countries.Add(new Country() { ShortName = "RO", Name = "ROSJA", DisplayOrder = 169 });
            context.Countries.Add(new Country() { ShortName = "RP", Name = "RPA (REPUBLIKA POŁUDNIOWEJ AFRYKI)", DisplayOrder = 170 });
            context.Countries.Add(new Country() { ShortName = "RA", Name = "RUANDA", DisplayOrder = 171 });
            context.Countries.Add(new Country() { ShortName = "RU", Name = "RUMUNIA", DisplayOrder = 172 });
            context.Countries.Add(new Country() { ShortName = "SH", Name = "SAHARA ZACHODNIA", DisplayOrder = 173 });
            context.Countries.Add(new Country() { ShortName = "SY", Name = "SALWADOR", DisplayOrder = 174 });
            context.Countries.Add(new Country() { ShortName = "SS", Name = "SAMOA AMERYKAŃSKIE", DisplayOrder = 175 });
            context.Countries.Add(new Country() { ShortName = "SN", Name = "SAMOA ZACHODNIE", DisplayOrder = 176 });
            context.Countries.Add(new Country() { ShortName = "SM", Name = "SAN MARINO", DisplayOrder = 177 });
            context.Countries.Add(new Country() { ShortName = "SE", Name = "SENEGAL", DisplayOrder = 178 });
            context.Countries.Add(new Country() { ShortName = "YJ", Name = "SERBIA,CZARNOGÓRA", DisplayOrder = 179 });
            context.Countries.Add(new Country() { ShortName = "SC", Name = "SESZELE", DisplayOrder = 180 });
            context.Countries.Add(new Country() { ShortName = "SB", Name = "SIERRA LEONE", DisplayOrder = 181 });
            context.Countries.Add(new Country() { ShortName = "SK", Name = "SIKKIM", DisplayOrder = 182 });
            context.Countries.Add(new Country() { ShortName = "SG", Name = "SINGAPUR", DisplayOrder = 183 });
            context.Countries.Add(new Country() { ShortName = "SL", Name = "SŁOWACJA", DisplayOrder = 184 });
            context.Countries.Add(new Country() { ShortName = "YI", Name = "SŁOWENIA", DisplayOrder = 185 });
            context.Countries.Add(new Country() { ShortName = "SO", Name = "SOMALIA", DisplayOrder = 186 });
            context.Countries.Add(new Country() { ShortName = "LK", Name = "SRI LANKA (CEJLON)", DisplayOrder = 187 });
            context.Countries.Add(new Country() { ShortName = "SZ", Name = "SUAZI", DisplayOrder = 188 });
            context.Countries.Add(new Country() { ShortName = "SD", Name = "SUDAN", DisplayOrder = 189 });
            context.Countries.Add(new Country() { ShortName = "SR", Name = "SURINAM", DisplayOrder = 190 });
            context.Countries.Add(new Country() { ShortName = "SP", Name = "SYRIA", DisplayOrder = 191 });
            context.Countries.Add(new Country() { ShortName = "CH", Name = "SZWAJCARIA", DisplayOrder = 192 });
            context.Countries.Add(new Country() { ShortName = "SW", Name = "SZWECJA", DisplayOrder = 193 });
            context.Countries.Add(new Country() { ShortName = "TA", Name = "TADŻYKISTAN", DisplayOrder = 194 });
            context.Countries.Add(new Country() { ShortName = "TH", Name = "TAJLANDIA (SYJAM)", DisplayOrder = 195 });
            context.Countries.Add(new Country() { ShortName = "TN", Name = "TAJWAN", DisplayOrder = 196 });
            context.Countries.Add(new Country() { ShortName = "TZ", Name = "TANZANIA", DisplayOrder = 197 });
            context.Countries.Add(new Country() { ShortName = "TM", Name = "TIMOR", DisplayOrder = 198 });
            context.Countries.Add(new Country() { ShortName = "TG", Name = "TOGO", DisplayOrder = 199 });
            context.Countries.Add(new Country() { ShortName = "TL", Name = "TOKELAU", DisplayOrder = 200 });
            context.Countries.Add(new Country() { ShortName = "TO", Name = "TONGA", DisplayOrder = 201 });
            context.Countries.Add(new Country() { ShortName = "TT", Name = "TRYNIDAD I TOBAGO", DisplayOrder = 202 });
            context.Countries.Add(new Country() { ShortName = "TE", Name = "TUNEZJA", DisplayOrder = 203 });
            context.Countries.Add(new Country() { ShortName = "TU", Name = "TURCJA", DisplayOrder = 204 });
            context.Countries.Add(new Country() { ShortName = "TR", Name = "TURKIESTAN", DisplayOrder = 205 });
            context.Countries.Add(new Country() { ShortName = "TK", Name = "TURKMENISTAN (TURKMENIA)", DisplayOrder = 206 });
            context.Countries.Add(new Country() { ShortName = "TC", Name = "TURKS I CAICOS", DisplayOrder = 207 });
            context.Countries.Add(new Country() { ShortName = "TV", Name = "TUVALU", DisplayOrder = 208 });
            context.Countries.Add(new Country() { ShortName = "UG", Name = "UGANDA", DisplayOrder = 209 });
            context.Countries.Add(new Country() { ShortName = "UK", Name = "UKRAINA", DisplayOrder = 210 });
            context.Countries.Add(new Country() { ShortName = "UR", Name = "URUGWAJ", DisplayOrder = 211 });
            context.Countries.Add(new Country() { ShortName = "US", Name = "USA (STANY ZJEDNOCZONE AMERYKI)", DisplayOrder = 212 });
            context.Countries.Add(new Country() { ShortName = "UZ", Name = "UZBEKISTAN", DisplayOrder = 213 });
            context.Countries.Add(new Country() { ShortName = "VU", Name = "VANUATU", DisplayOrder = 214 });
            context.Countries.Add(new Country() { ShortName = "VK", Name = "WAKE", DisplayOrder = 215 });
            context.Countries.Add(new Country() { ShortName = "VF", Name = "WALLIS I FUTUNA", DisplayOrder = 216 });
            context.Countries.Add(new Country() { ShortName = "VA", Name = "WATYKAN", DisplayOrder = 217 });
            context.Countries.Add(new Country() { ShortName = "VE", Name = "WENEZUELA", DisplayOrder = 218 });
            context.Countries.Add(new Country() { ShortName = "HU", Name = "WĘGRY", DisplayOrder = 219 });
            context.Countries.Add(new Country() { ShortName = "GB", Name = "WIELKA BRYTANIA", DisplayOrder = 220 });
            context.Countries.Add(new Country() { ShortName = "VD", Name = "WIETNAM", DisplayOrder = 221 });
            context.Countries.Add(new Country() { ShortName = "IT", Name = "WŁOCHY", DisplayOrder = 222 });
            context.Countries.Add(new Country() { ShortName = "WN", Name = "WSPÓLNOTA NIEPODLEGŁYCH PAŃSTW", DisplayOrder = 223 });
            context.Countries.Add(new Country() { ShortName = "WK", Name = "WYBRZEŻE KOŚCI SŁONIOWEJ", DisplayOrder = 224 });
            context.Countries.Add(new Country() { ShortName = "VO", Name = "WYSPY BOŻEGO NARODZENIA", DisplayOrder = 225 });
            context.Countries.Add(new Country() { ShortName = "VC", Name = "WYSPY COOKA", DisplayOrder = 226 });
            context.Countries.Add(new Country() { ShortName = "VZ", Name = "WYSPY DZIEWICZE (USA)", DisplayOrder = 227 });
            context.Countries.Add(new Country() { ShortName = "VB", Name = "WYSPY DZIEWICZE (WLK. BRYT.)", DisplayOrder = 228 });
            context.Countries.Add(new Country() { ShortName = "VS", Name = "WYSPY KOKOSOWE", DisplayOrder = 229 });
            context.Countries.Add(new Country() { ShortName = "VM", Name = "WYSPY MARSHALLA", DisplayOrder = 230 });
            context.Countries.Add(new Country() { ShortName = "VL", Name = "WYSPY SALOMONA", DisplayOrder = 231 });
            context.Countries.Add(new Country() { ShortName = "VG", Name = "WYSPY ŚWIĘTEGO TOMASZA I KSIĘŻYCA", DisplayOrder = 232 });
            context.Countries.Add(new Country() { ShortName = "CV", Name = "WYSPY ZIELONEGO PRZYLĄDKA", DisplayOrder = 233 });
            context.Countries.Add(new Country() { ShortName = "ZM", Name = "ZAMBIA", DisplayOrder = 234 });
            context.Countries.Add(new Country() { ShortName = "ZI", Name = "ZIMBABWE (RODEZJA)", DisplayOrder = 235 });
            context.Countries.Add(new Country() { ShortName = "ZE", Name = "ZJEDNOCZONE EMIRATY ARABSKIE", DisplayOrder = 236 });
            context.Countries.Add(new Country() { ShortName = "SU", Name = "ZSRR", DisplayOrder = 237 }); 
            #endregion

            #region QuestionForms (Forma zapytania)
            context.QuestionForms.Add(new QuestionForm() { ShortName = "", Name = "E-15", DisplayOrder = 1 });
            context.QuestionForms.Add(new QuestionForm() { ShortName = "", Name = "PISMO", DisplayOrder = 2 });
            context.QuestionForms.Add(new QuestionForm() { ShortName = "", Name = "POLECENIE SZEFA", DisplayOrder = 3 }); 
            #endregion

            #region QueryReasons (Powód sprawdzenia)
            context.QuestionReasons.Add(new QuestionReason() { Name = "A", Description = "ROZPRACOWANIE", DisplayOrder = 1 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "AA", Description = "PRZED ZAINTERESOWANIEM OPERACYJNYM", DisplayOrder = 2 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "QA", Description = "POSTĘPOWANIE SPRAWDZAJĄCE", DisplayOrder = 3 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "QK", Description = "KONCESJA", DisplayOrder = 4 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "J", Description = "DOPUSZCZENIE DO INFORMACJI NIEJAWNYCH", DisplayOrder = 5 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "QC", Description = "RODZINA (KONKUBENT) OPINIOWANEGO W POST. SPRAW.", DisplayOrder = 6 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "Q", Description = "OPINIOWANIE", DisplayOrder = 7 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "U", Description = "SPRAWDZENIE KANDYDATA DO ŻW", DisplayOrder = 8 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "AB", Description = "PRZED REJESTRACJĄ", DisplayOrder = 9 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "AC", Description = "PRZED ROZMOWĄ", DisplayOrder = 10 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "AD", Description = "PRZED ZASADZKĄ", DisplayOrder = 11 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "KU", Description = "KANDYDAT DO SŁUŻBY (PRACY)", DisplayOrder = 12 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "KW", Description = "RODZINA KANDYDATA DO SŁUŻBY (PRACY)", DisplayOrder = 13 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "KZ", Description = "RODZINA FUNKCJONARIUSZA (PRACOWNIKA)", DisplayOrder = 14 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "PA", Description = "PRZED (PO) ZATRZYMANIEM (-IU)", DisplayOrder = 15 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "PB", Description = "PRZED PRZESZUKANIEM", DisplayOrder = 16 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "PC", Description = "PRZED PRZESŁUCHANIEM", DisplayOrder = 17 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "PD", Description = "PRZED PRZEDSTAWIENIEM ZARZUTU", DisplayOrder = 18 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "PE", Description = "PRZED (PO) ZASTOSOWANIEM (IU) ŚRODKA ZAPOBIEGAWCZEGO", DisplayOrder = 19 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "PF", Description = "PRZED POSZUKIWANIEM", DisplayOrder = 20 });
            context.QuestionReasons.Add(new QuestionReason() { Name = "QD", Description = "KONTAKT OPINIOWANEGO W POST. SPRAW.", DisplayOrder = 21 }); 
            #endregion

            #region Ranks (Stopnie wojskowe tytuły)
            var of = new Rank() { Name = "OF", Description = "OFICER", DisplayOrder = 1 };
            context.Ranks.Add(of);
            context.Ranks.Add(new Rank() { Name = "PŁK", Description = "", DisplayOrder = 5, Masteritem = of  });
            context.Ranks.Add(new Rank() { Name = "PPŁK", Description = "", DisplayOrder = 6, Masteritem = of });
            context.Ranks.Add(new Rank() { Name = "MJR", Description = "", DisplayOrder = 7, Masteritem = of });
            context.Ranks.Add(new Rank() { Name = "KPT.", Description = "", DisplayOrder = 8, Masteritem = of });
            context.Ranks.Add(new Rank() { Name = "POR.", Description = "", DisplayOrder = 9, Masteritem = of });
            var pdf = new Rank() { Name = "PDF", Description = "PODOFICER", DisplayOrder = 2 };
            context.Ranks.Add(pdf);
            context.Ranks.Add(new Rank() { Name = "ST.CHOR.SZTAB.", Description = "", DisplayOrder = 10, Masteritem = pdf });
            context.Ranks.Add(new Rank() { Name = "CHOR.SZTAB.", Description = "", DisplayOrder = 11, Masteritem = pdf });
            context.Ranks.Add(new Rank() { Name = "MŁ.CHOR.SZTAB.", Description = "", DisplayOrder = 12, Masteritem = pdf });
            context.Ranks.Add(new Rank() { Name = "ST.CHOR.", Description = "", DisplayOrder = 13, Masteritem = pdf });
            context.Ranks.Add(new Rank() { Name = "CHOR.", Description = "", DisplayOrder = 14, Masteritem = pdf });
            var szer = new Rank() { Name = "SZER. ZAW.", Description = "SZEREGOWY ZAWODOWY", DisplayOrder = 3 }; 
            context.Ranks.Add(szer);
            context.Ranks.Add(new Rank() { Name = "SZER.", Description = "", DisplayOrder = 15, Masteritem = szer });
            context.Ranks.Add(new Rank() { Name = "ST.SZER.", Description = "", DisplayOrder = 16, Masteritem = szer });
            var oc = new Rank() { Name = "CYW.", Description = "OSOBA CYWILNA", DisplayOrder = 4, Masteritem = szer }; 
            context.Ranks.Add(oc);
            context.Ranks.Add(new Rank() { Name = "PW", Description = "PRACOWNIK WOJSKA", DisplayOrder = 17, Masteritem=oc });
            context.Ranks.Add(new Rank() { Name = "OC", Description = "OSOBA NIE ZWIĄZANA Z WOJSKIEM", DisplayOrder = 18, Masteritem = oc });
            #endregion


            #region Organizations, OrganizationalUnits (Instytucje, Jedostki organizacyjne)
            
            var zw = new Organization() { ShortName="ŻW", Name = "ŻANDARMERIA WOJSKOWA", Description = "", DisplayOrder = 10 };
            context.Organizations.Add(zw);
            var kg = new OrganizationalUnit(){ Name = "KG ŻW", Description = "KOMENDA GŁÓWNA ŻANDARMERII WOJSKOWEJ", DisplayOrder = 101, Organization = zw };
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "ODDZIAŁ KRYMINALNY KGŻW", Description = "ODDZIAŁ KRYMINALNY KGŻW", DisplayOrder = 102, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "MOŻW WARSZAWA", Description = "MAZOWIECKI ODDZIAŁ ŻANDARMERII WOJSKOWEJ", DisplayOrder = 101, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OOIN KGŻW", Description = "ODDZIAŁ OCHRONY INFORMACJI NIEJAWNYCH KGŻW", DisplayOrder = 103, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW BYDGOSZCZ", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ BYDGOSZCZ", DisplayOrder = 103, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW ELBLĄG", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ ELBLĄG", DisplayOrder = 104, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW KRAKÓW", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ KRAKÓW", DisplayOrder = 105, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW SZCZECIN", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ SZCZECIN", DisplayOrder = 106, MasterUnit = kg, Organization = zw });
            context.OrganizationalUnits.Add(new OrganizationalUnit() { Name = "OŻW ŻAGAŃ", Description = "ODDZIAŁ ŻANDARMERII WOJSKOWEJ ŻAGAŃ", DisplayOrder = 107, MasterUnit = kg, Organization = zw });

            context.Organizations.Add(new Organization() { ShortName = "", Name = "SKW", Description = "SŁUŻBA KONTRWYWIADU WOJSKOWEGO", DisplayOrder = 20 });
            context.Organizations.Add(new Organization() { ShortName = "", Name = "SWW", Description = "SŁUŻBA WYWIADU WOJSKOWEGO", DisplayOrder = 30 });
            context.Organizations.Add(new Organization() { ShortName = "", Name = "POLICJA", Description = "POLICJA", DisplayOrder = 40 });
            context.Organizations.Add(new Organization() { ShortName = "", Name = "STRAŻ GRANICZNA", Description = "STRAŻ GRANICZNA", DisplayOrder = 50 });
            context.Organizations.Add(new Organization() { ShortName = "", Name = "BOR", Description = "BIURO OCHRONY RZĄDU", DisplayOrder = 60 });
            context.Organizations.Add(new Organization() { ShortName = "", Name = "DEPARTAMENT KADR", Description = "DEPARTAMENT KADR MON", DisplayOrder = 70 });
            context.Organizations.Add(new Organization() { ShortName = "", Name = "AGENCA BW i W", Description = "AGENCJA BEZPIECZEŃSWTA WEWNĘTRZNEGO i AGENCJA WYWIADU", DisplayOrder = 80 });
            
                       
            #endregion

            #endregion

            context.Users.Add(new User() {Login = Environment.UserName,Name = "Użytkownik Testowy"});



            for (int i = 0; i < 100; i++)
            {
                string pesel = "00000000000"+i.ToString();
                context.Persons.Add(new Person() { Pesel = pesel.Substring(pesel.Length-11,11), FirstName = "IMIĘ"+i.ToString(), LastName = "NAZWISKO"+i.ToString(),Sex = "M" });
            }

            context.SaveChanges();
        }
    }
}
