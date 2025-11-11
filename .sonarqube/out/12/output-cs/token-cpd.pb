‚M
`C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Utilities\RutValidator.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
	Utilities! *
{ 
public 

static 
class 
RutValidator $
{ 
public 
static 
string 
ObtenerNumeroRut -
(- .
string. 4
rut5 8
)8 9
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
rut* -
)- .
). /
{ 
return 
string 
. 
Empty #
;# $
} 
string 
	rutLimpio 
= 
rut "
." #
Replace# *
(* +
$str+ .
,. /
string0 6
.6 7
Empty7 <
,< =
StringComparison> N
.N O
OrdinalO V
)V W
." #
Replace# *
(* +
$str+ .
,. /
string0 6
.6 7
Empty7 <
,< =
StringComparison> N
.N O
OrdinalO V
)V W
." #
Replace# *
(* +
$str+ .
,. /
string0 6
.6 7
Empty7 <
,< =
StringComparison> N
.N O
OrdinalO V
)V W
." #
Trim# '
(' (
)( )
.  " #
ToUpper  # *
(  * +
CultureInfo  + 6
.  6 7
InvariantCulture  7 G
)  G H
;  H I
if"" 
("" 
string"" 
."" 
IsNullOrEmpty"" $
(""$ %
	rutLimpio""% .
)"". /
)""/ 0
{## 
return$$ 
string$$ 
.$$ 
Empty$$ #
;$$# $
}%% 
if'' 
('' 
	rutLimpio'' 
.'' 
Length''  
>''! "
$num''# $
)''$ %
{(( 
char)) 
ultimoCaracter)) #
=))$ %
	rutLimpio))& /
[))/ 0
	rutLimpio))0 9
.))9 :
Length)): @
-))A B
$num))C D
]))D E
;))E F
if++ 
(++ 
!++ 
char++ 
.++ 
IsDigit++ !
(++! "
ultimoCaracter++" 0
)++0 1
||++2 4
	rutLimpio++5 >
.++> ?
Length++? E
>++F G
$num++H I
)++I J
{,, 
	rutLimpio-- 
=-- 
	rutLimpio--  )
.--) *
	Substring--* 3
(--3 4
$num--4 5
,--5 6
	rutLimpio--7 @
.--@ A
Length--A G
---H I
$num--J K
)--K L
;--L M
}.. 
}// 
return11 
new11 
string11 
(11 
	rutLimpio11 '
.11' (
Where11( -
(11- .
char11. 2
.112 3
IsDigit113 :
)11: ;
.11; <
ToArray11< C
(11C D
)11D E
)11E F
;11F G
}22 	
public99 
static99 
bool99 
Validar99 "
(99" #
string99# )
rut99* -
)99- .
{:: 	
if;; 
(;; 
string;; 
.;; 
IsNullOrWhiteSpace;; )
(;;) *
rut;;* -
);;- .
);;. /
{<< 
return== 
false== 
;== 
}>> 
rutAA 
=AA 
rutAA 
.AA 
ReplaceAA 
(AA 
$strAA !
,AA! "
stringAA# )
.AA) *
EmptyAA* /
,AA/ 0
StringComparisonAA1 A
.AAA B
OrdinalAAB I
)AAI J
.BB 
ReplaceBB 
(BB 
$strBB !
,BB! "
stringBB# )
.BB) *
EmptyBB* /
,BB/ 0
StringComparisonBB1 A
.BBA B
OrdinalBBB I
)BBI J
.CC 
TrimCC 
(CC 
)CC 
.DD 
ToUpperDD 
(DD 
CultureInfoDD )
.DD) *
InvariantCultureDD* :
)DD: ;
;DD; <
ifFF 
(FF 
rutFF 
.FF 
LengthFF 
<FF 
$numFF 
)FF 
{GG 
returnHH 
falseHH 
;HH 
}II 
ifLL 
(LL 
rutLL 
.LL 
AllLL 
(LL 
charLL 
.LL 
IsDigitLL $
)LL$ %
)LL% &
{MM 
ifOO 
(OO 
rutOO 
.OO 
LengthOO 
>=OO !
$numOO" #
&&OO$ &
rutOO' *
.OO* +
LengthOO+ 1
<=OO2 4
$numOO5 6
)OO6 7
{PP 
returnQQ 
trueQQ 
;QQ  
}RR 
ifUU 
(UU 
rutUU 
.UU 
LengthUU 
==UU !
$numUU" #
)UU# $
{VV 
stringWW 
	rutNumeroWW $
=WW% &
rutWW' *
.WW* +
	SubstringWW+ 4
(WW4 5
$numWW5 6
,WW6 7
$numWW8 9
)WW9 :
;WW: ;
charXX 
dvXX 
=XX 
rutXX !
[XX! "
$numXX" #
]XX# $
;XX$ %
ifZZ 
(ZZ 
!ZZ 
intZZ 
.ZZ 
TryParseZZ %
(ZZ% &
	rutNumeroZZ& /
,ZZ/ 0
outZZ1 4
intZZ5 8
numeroZZ9 ?
)ZZ? @
)ZZ@ A
{[[ 
return\\ 
false\\ $
;\\$ %
}]] 
return__ %
CalcularDigitoVerificador__ 4
(__4 5
numero__5 ;
)__; <
==__= ?
dv__@ B
;__B C
}`` 
returnbb 
falsebb 
;bb 
}cc 
ifff 
(ff 
rutff 
.ff 
Lengthff 
>=ff 
$numff 
)ff  
{gg 
stringhh 
	rutNumerohh  
=hh! "
ruthh# &
.hh& '
	Substringhh' 0
(hh0 1
$numhh1 2
,hh2 3
ruthh4 7
.hh7 8
Lengthhh8 >
-hh? @
$numhhA B
)hhB C
;hhC D
charii 
digitoVerificadorii &
=ii' (
rutii) ,
[ii, -
rutii- 0
.ii0 1
Lengthii1 7
-ii8 9
$numii: ;
]ii; <
;ii< =
ifkk 
(kk 
!kk 
intkk 
.kk 
TryParsekk !
(kk! "
	rutNumerokk" +
,kk+ ,
outkk- 0
intkk1 4
numerokk5 ;
)kk; <
)kk< =
{ll 
returnmm 
falsemm  
;mm  !
}nn 
charpp 

dvEsperadopp 
=pp  !%
CalcularDigitoVerificadorpp" ;
(pp; <
numeropp< B
)ppB C
;ppC D
returnqq 
digitoVerificadorqq (
==qq) +

dvEsperadoqq, 6
;qq6 7
}rr 
returntt 
falsett 
;tt 
}uu 	
privatezz 
staticzz 
charzz %
CalcularDigitoVerificadorzz 5
(zz5 6
intzz6 9
rutzz: =
)zz= >
{{{ 	
if|| 
(|| 
rut|| 
<=|| 
$num|| 
|||| 
rut|| 
>||  !
$num||" *
)||* +
{}} 
throw~~ 
new~~ '
ArgumentOutOfRangeException~~ 5
(~~5 6
nameof~~6 <
(~~< =
rut~~= @
)~~@ A
,~~A B
$str~~C l
)~~l m
;~~m n
} 
int
ÅÅ 
suma
ÅÅ 
=
ÅÅ 
$num
ÅÅ 
;
ÅÅ 
int
ÇÇ 
multiplicador
ÇÇ 
=
ÇÇ 
$num
ÇÇ  !
;
ÇÇ! "
int
ÉÉ 
valor
ÉÉ 
=
ÉÉ 
rut
ÉÉ 
;
ÉÉ 
while
ÖÖ 
(
ÖÖ 
valor
ÖÖ 
>
ÖÖ 
$num
ÖÖ 
)
ÖÖ 
{
ÜÜ 
suma
áá 
+=
áá 
(
áá 
valor
áá 
%
áá  
$num
áá! #
)
áá# $
*
áá% &
multiplicador
áá' 4
;
áá4 5
valor
àà 
/=
àà 
$num
àà 
;
àà 
multiplicador
ââ 
=
ââ 
multiplicador
ââ  -
==
ââ. 0
$num
ââ1 2
?
ââ3 4
$num
ââ5 6
:
ââ7 8
multiplicador
ââ9 F
+
ââG H
$num
ââI J
;
ââJ K
}
ää 
int
åå 
resto
åå 
=
åå 
suma
åå 
%
åå 
$num
åå !
;
åå! "
int
çç 
dv
çç 
=
çç 
$num
çç 
-
çç 
resto
çç 
;
çç  
return
èè 
dv
èè 
switch
èè 
{
êê 
$num
ëë 
=>
ëë 
$char
ëë 
,
ëë 
$num
íí 
=>
íí 
$char
íí 
,
íí 
_
ìì 
=>
ìì 
dv
ìì 
.
ìì 
ToString
ìì  
(
ìì  !
CultureInfo
ìì! ,
.
ìì, -
InvariantCulture
ìì- =
)
ìì= >
[
ìì> ?
$num
ìì? @
]
ìì@ A
,
ììA B
}
îî 
;
îî 
}
ïï 	
}
ññ 
}óó ñB
_C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\TokenService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
{ 
public 

class 
TokenService 
( 
IOptions &
<& '
JwtSettings' 2
>2 3
options4 ;
); <
:= >
ITokenService? L
{ 
private 
readonly 
JwtSettings $
_jwtSettings% 1
=2 3
options4 ;
?; <
.< =
Value= B
??C E
throwF K
newL O!
ArgumentNullExceptionP e
(e f
nameoff l
(l m
optionsm t
)t u
)u v
;v w
public 
string 
GenerateToken #
(# $
	TokenData$ -
data. 2
)2 3
{ 	!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
data. 2
)2 3
;3 4
try   
{!! 
var"" 
	secretKey"" 
="" 
this""  $
.""$ %
_jwtSettings""% 1
.""1 2
Key""2 5
;""5 6
var## 
issuer## 
=## 
this## !
.##! "
_jwtSettings##" .
.##. /
Issuer##/ 5
;##5 6
if%% 
(%% 
string%% 
.%% 
IsNullOrEmpty%% (
(%%( )
	secretKey%%) 2
)%%2 3
||%%4 6
string%%7 =
.%%= >
IsNullOrEmpty%%> K
(%%K L
issuer%%L R
)%%R S
)%%S T
{&& 
throw'' 
new'' %
InvalidOperationException'' 7
(''7 8
$str''8 x
)''x y
;''y z
}(( 
if++ 
(++ 
	secretKey++ 
.++ 
Length++ $
<++% &
$num++' )
)++) *
{,, 
throw-- 
new-- %
InvalidOperationException-- 7
(--7 8
$str--8 i
)--i j
;--j k
}.. 
var00 
key00 
=00 
new00  
SymmetricSecurityKey00 2
(002 3
Encoding003 ;
.00; <
UTF800< @
.00@ A
GetBytes00A I
(00I J
	secretKey00J S
)00S T
)00T U
;00U V
var11 
creds11 
=11 
new11 
SigningCredentials11  2
(112 3
key113 6
,116 7
SecurityAlgorithms118 J
.11J K

HmacSha25611K U
)11U V
;11V W
var33 
claims33 
=33 
new33  
List33! %
<33% &
Claim33& +
>33+ ,
{44 
new55 
(55 

ClaimTypes55 "
.55" #
Role55# '
,55' (
data55) -
.55- .
Rol55. 1
.551 2
ToString552 :
(55: ;
CultureInfo55; F
.55F G
InvariantCulture55G W
)55W X
)55X Y
,55Y Z
new66 
(66 #
JwtRegisteredClaimNames66 /
.66/ 0
Jti660 3
,663 4
data665 9
.669 :
	SessionId66: C
)66C D
,66D E
new77 
(77 

ClaimTypes77 "
.77" #
NameIdentifier77# 1
,771 2
data773 7
.777 8
	EsTitular778 A
.77A B
ToString77B J
(77J K
CultureInfo77K V
.77V W
InvariantCulture77W g
)77g h
)77h i
,77i j
new88 
(88 

ClaimTypes88 "
.88" #
Dns88# &
,88& '
data88( ,
.88, -
Origen88- 3
.883 4
ToString884 <
(88< =
CultureInfo88= H
.88H I
InvariantCulture88I Y
)88Y Z
)88Z [
,88[ \
new99 
(99 
$str99 %
,99% &
!99' (
string99( .
.99. /
IsNullOrWhiteSpace99/ A
(99A B
data99B F
.99F G
Solicitante99G R
)99R S
?99T U
data99V Z
.99Z [
Solicitante99[ f
:99g h
string99i o
.99o p
Empty99p u
)99u v
,99v w
new:: 
(:: 
$str:: !
,::! "
!::# $
string::$ *
.::* +
IsNullOrWhiteSpace::+ =
(::= >
data::> B
.::B C
Nombres::C J
)::J K
?::L M
data::N R
.::R S
Nombres::S Z
:::[ \
string::] c
.::c d
Empty::d i
)::i j
,::j k
new;; 
(;; 
$str;; #
,;;# $
!;;% &
string;;& ,
.;;, -
IsNullOrWhiteSpace;;- ?
(;;? @
data;;@ D
.;;D E
	Apellidos;;E N
);;N O
?;;P Q
data;;R V
.;;V W
	Apellidos;;W `
:;;a b
string;;c i
.;;i j
Empty;;j o
);;o p
,;;p q
new<< 
(<< 
$str<< 
,<<  
!<<! "
string<<" (
.<<( )
IsNullOrWhiteSpace<<) ;
(<<; <
data<<< @
.<<@ A
Email<<A F
)<<F G
?<<H I
data<<J N
.<<N O
Email<<O T
:<<U V
string<<W ]
.<<] ^
Empty<<^ c
)<<c d
,<<d e
new== 
(== 
$str== %
,==% &
!==' (
string==( .
.==. /
IsNullOrWhiteSpace==/ A
(==A B
data==B F
.==F G
TokenOrigen==G R
)==R S
?==T U
data==V Z
.==Z [
TokenOrigen==[ f
:==g h
string==i o
.==o p
Empty==p u
)==u v
,==v w
}>> 
;>> 
var@@ 
tokenDescriptor@@ #
=@@$ %
new@@& )#
SecurityTokenDescriptor@@* A
{AA 
SubjectBB 
=BB 
newBB !
ClaimsIdentityBB" 0
(BB0 1
claimsBB1 7
)BB7 8
,BB8 9
ExpiresCC 
=CC 
DateTimeCC &
.CC& '
UtcNowCC' -
.CC- .
AddDaysCC. 5
(CC5 6
$numCC6 7
)CC7 8
,CC8 9
IssuerDD 
=DD 
issuerDD #
,DD# $
AudienceEE 
=EE 
issuerEE %
,EE% &
SigningCredentialsFF &
=FF' (
credsFF) .
,FF. /
}GG 
;GG 
varII 
tokenHandlerII  
=II! "
newII# &#
JwtSecurityTokenHandlerII' >
(II> ?
)II? @
;II@ A
varJJ 
tokenJJ 
=JJ 
tokenHandlerJJ (
.JJ( )
CreateTokenJJ) 4
(JJ4 5
tokenDescriptorJJ5 D
)JJD E
;JJE F
returnLL 
tokenHandlerLL #
.LL# $

WriteTokenLL$ .
(LL. /
tokenLL/ 4
)LL4 5
;LL5 6
}MM 
catchNN 
(NN 
SystemNN 
.NN 
SecurityNN "
.NN" #
CryptographyNN# /
.NN/ 0"
CryptographicExceptionNN0 F
exNNG I
)NNI J
{OO 
throwPP 
newPP %
InvalidOperationExceptionPP 3
(PP3 4
$strPP4 j
,PPj k
exPPl n
)PPn o
;PPo p
}QQ 
catchRR 
(RR $
EncoderFallbackExceptionRR +
exRR, .
)RR. /
{SS 
throwTT 
newTT %
InvalidOperationExceptionTT 3
(TT3 4
$strTT4 \
,TT\ ]
exTT^ `
)TT` a
;TTa b
}UU 
catchVV 
(VV 
ArgumentExceptionVV $
exVV% '
)VV' (
{WW 
throwXX 
newXX %
InvalidOperationExceptionXX 3
(XX3 4
$strXX4 g
,XXg h
exXXi k
)XXk l
;XXl m
}YY 
}ZZ 	
}[[ 
}\\ Èé
dC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\SiniestrosService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
{ 
public 

class 
SiniestrosService "
:# $
ISiniestrosService% 7
{ 
private 
readonly +
EPSiniestroPorAseguradoSettings 8,
 _ePSiniestroPorAseguradoSettings9 Y
;Y Z
private 
readonly *
EPGetdatosdelsiniestroSettings 7#
_ePGetdatosdelsiniestro8 O
;O P
private 
readonly 
IHttpService %
_httpService& 2
;2 3
private 
readonly 

IAppLogger #
<# $
SiniestrosService$ 5
>5 6
_logger7 >
;> ?
public!! 
SiniestrosService!!  
(!!  !
IOptions"" 
<"" +
EPSiniestroPorAseguradoSettings"" 4
>""4 5+
ePSiniestroPorAseguradoSettings""6 U
,""U V
IOptions## 
<## *
EPGetdatosdelsiniestroSettings## 3
>##3 4"
ePGetdatosdelsiniestro##5 K
,##K L
IHttpService$$ 
httpService$$ $
,$$$ %

IAppLogger%% 
<%% 
SiniestrosService%% (
>%%( )
logger%%* 0
)%%0 1
{&& 	
this'' 
.'' ,
 _ePSiniestroPorAseguradoSettings'' 1
=''2 3+
ePSiniestroPorAseguradoSettings''4 S
?''S T
.''T U
Value''U Z
??''[ ]
throw''^ c
new''d g!
ArgumentNullException''h }
(''} ~
nameof	''~ Ñ
(
''Ñ Ö-
ePSiniestroPorAseguradoSettings
''Ö §
)
''§ •
)
''• ¶
;
''¶ ß
this(( 
.(( #
_ePGetdatosdelsiniestro(( (
=(() *"
ePGetdatosdelsiniestro((+ A
?((A B
.((B C
Value((C H
??((I K
throw((L Q
new((R U!
ArgumentNullException((V k
(((k l
nameof((l r
(((r s#
ePGetdatosdelsiniestro	((s â
)
((â ä
)
((ä ã
;
((ã å
this)) 
.)) 
_httpService)) 
=)) 
httpService))  +
??)), .
throw))/ 4
new))5 8!
ArgumentNullException))9 N
())N O
nameof))O U
())U V
httpService))V a
)))a b
)))b c
;))c d
this** 
.** 
_logger** 
=** 
logger** !
??**" $
throw**% *
new**+ .!
ArgumentNullException**/ D
(**D E
nameof**E K
(**K L
logger**L R
)**R S
)**S T
;**T U
}++ 	
public33 
async33 
Task33 
<33 
SiniestrosResponse33 ,
>33, -%
GetSiniestrosPorAsegurado33. G
(33G H
SiniestrosRequest33H Y
request33Z a
)33a b
{44 	!
ArgumentNullException55 !
.55! "
ThrowIfNull55" -
(55- .
request55. 5
)555 6
;556 7!
ArgumentNullException66 !
.66! "
ThrowIfNull66" -
(66- .
request66. 5
.665 6
RutAsegurado666 B
)66B C
;66C D
var88 
(88 
	processId88 
,88 
	stopwatch88 %
)88% &
=88' (
this88) -
.88- .
_logger88. 5
.885 6
StartProcess886 B
(88B C
new88C F
{99 
	Operation:: 
=:: 
$str:: 7
,::7 8
request;; 
.;; 
RutAsegurado;; $
,;;$ %
}<< 
)<< 
;<< 
try>> 
{?? 
this@@ 
.@@ 
_logger@@ 
.@@ 
Info@@ !
(@@! "
$"@@" $
$str@@$ J
{@@J K
request@@K R
.@@R S
RutAsegurado@@S _
}@@_ `
"@@` a
)@@a b
;@@b c
varBB 
urlBB 
=BB 
thisBB 
.BB 
BuildAndValidateUriBB 2
(BB2 3
thisBB3 7
.BB7 8,
 _ePSiniestroPorAseguradoSettingsBB8 X
.BBX Y
BasePathBBY a
,BBa b
$strBBc }
)BB} ~
;BB~ 
varCC 
bodyCC 
=CC 
newCC 
{CC  
RUTASEGURADOCC! -
=CC. /
requestCC0 7
.CC7 8
RutAseguradoCC8 D
}CCE F
;CCF G
varEE 
headersEE 
=EE 
thisEE "
.EE" #&
BuildAuthenticationHeadersEE# =
(EE= >
thisFF 
.FF ,
 _ePSiniestroPorAseguradoSettingsFF 9
.FF9 :
AuthFF: >
,FF> ?
thisGG 
.GG ,
 _ePSiniestroPorAseguradoSettingsGG 9
.GG9 :
TokenCABNameGG: F
,GGF G
thisHH 
.HH ,
 _ePSiniestroPorAseguradoSettingsHH 9
.HH9 :
TokenCABValueHH: G
,HHG H
thisII 
.II ,
 _ePSiniestroPorAseguradoSettingsII 9
.II9 :

CookieNameII: D
,IID E
thisJJ 
.JJ ,
 _ePSiniestroPorAseguradoSettingsJJ 9
.JJ9 :
CookieValueJJ: E
)JJE F
;JJF G
varLL 
resultLL 
=LL 
awaitLL "
thisLL# '
.LL' (
_httpServiceLL( 4
.LL4 5 
PostWithHeadersAsyncLL5 I
<LLI J
objectLLJ P
,LLP Q
SiniestrosResponseLLR d
>LLd e
(LLe f
urlMM 
,MM 
bodyNN 
,NN 
bearerTokenOO 
:OO  
nullOO! %
,OO% &
customHeadersPP !
:PP! "
headersPP# *
)PP* +
.PP+ ,
ConfigureAwaitPP, :
(PP: ;
falsePP; @
)PP@ A
;PPA B
ifRR 
(RR 
resultRR 
==RR 
nullRR "
)RR" #
{SS 
constTT 
stringTT  
errorMessageTT! -
=TT. /
$strTT0 ^
;TT^ _
thisUU 
.UU 
_loggerUU  
.UU  !
LogErrorUU! )
(UU) *
errorMessageUU* 6
)UU6 7
;UU7 8
throwVV 
newVV %
InvalidOperationExceptionVV 7
(VV7 8
errorMessageVV8 D
)VVD E
;VVE F
}WW 
thisYY 
.YY 
_loggerYY 
.YY 

EndProcessYY '
(YY' (
	processIdYY( 1
,YY1 2
	stopwatchYY3 <
,YY< =
newYY> A
{YYB C
SuccessYYD K
=YYL M
trueYYN R
,YYR S
DataReturnedYYT `
=YYa b
trueYYc g
}YYh i
)YYi j
;YYj k
thisZZ 
.ZZ 
_loggerZZ 
.ZZ 
InfoZZ !
(ZZ! "
$"ZZ" $
$strZZ$ V
{ZZV W
requestZZW ^
.ZZ^ _
RutAseguradoZZ_ k
}ZZk l
"ZZl m
)ZZm n
;ZZn o
return\\ 
result\\ 
;\\ 
}]] 
catch^^ 
(^^ 
	Exception^^ 
ex^^ 
)^^  
{__ 
this`` 
.`` 
_logger`` 
.`` 
LogError`` %
(``% &
ex``& (
,``( )
$"``* ,
$str``, X
{``X Y
request``Y `
.``` a
RutAsegurado``a m
}``m n
"``n o
)``o p
;``p q
thisaa 
.aa 
_loggeraa 
.aa 

EndProcessaa '
(aa' (
	processIdaa( 1
,aa1 2
	stopwatchaa3 <
,aa< =
newaa> A
{aaB C
SuccessaaD K
=aaL M
falseaaN S
,aaS T
ErroraaU Z
=aa[ \
exaa] _
.aa_ `
Messageaa` g
}aah i
)aai j
;aaj k
throwbb 
;bb 
}cc 
}dd 	
publicmm 
asyncmm 
Taskmm 
<mm %
SiniestrosDetalleResponsemm 3
>mm3 4 
GetDatosDelSiniestromm5 I
(mmI J 
SiniestrosDetRequestmmJ ^
requestmm_ f
)mmf g
{nn 	!
ArgumentNullExceptionoo !
.oo! "
ThrowIfNulloo" -
(oo- .
requestoo. 5
)oo5 6
;oo6 7
ifqq 
(qq 
requestqq 
.qq 
INsinieqq 
<=qq  "
$numqq# $
)qq$ %
{rr 
throwss 
newss 
ArgumentExceptionss +
(ss+ ,
$strss, [
,ss[ \
nameofss] c
(ssc d
requestssd k
)ssk l
)ssl m
;ssm n
}tt 
ifvv 
(vv 
requestvv 
.vv 
INdoctovv 
<=vv  "
$numvv# $
)vv$ %
{ww 
throwxx 
newxx 
ArgumentExceptionxx +
(xx+ ,
$strxx, l
)xxl m
;xxm n
}yy 
var{{ 
({{ 
	processId{{ 
,{{ 
	stopwatch{{ %
){{% &
={{' (
this{{) -
.{{- .
_logger{{. 5
.{{5 6
StartProcess{{6 B
({{B C
new{{C F
{|| 
	Operation}} 
=}} 
$str}} 2
,}}2 3
NumeroSiniestro~~ 
=~~  !
request~~" )
.~~) *
INsinie~~* 1
,~~1 2
NumeroDocumento 
=  !
request" )
.) *
INdocto* 1
,1 2
}
ÄÄ 
)
ÄÄ 
;
ÄÄ 
try
ÇÇ 
{
ÉÉ 
this
ÑÑ 
.
ÑÑ 
_logger
ÑÑ 
.
ÑÑ 
Info
ÑÑ !
(
ÑÑ! "
$"
ÑÑ" $
$str
ÑÑ$ F
{
ÑÑF G
request
ÑÑG N
.
ÑÑN O
INsinie
ÑÑO V
}
ÑÑV W
"
ÑÑW X
)
ÑÑX Y
;
ÑÑY Z
var
ÜÜ 
url
ÜÜ 
=
ÜÜ 
this
ÜÜ 
.
ÜÜ !
BuildAndValidateUri
ÜÜ 2
(
ÜÜ2 3
this
ÜÜ3 7
.
ÜÜ7 8%
_ePGetdatosdelsiniestro
ÜÜ8 O
.
ÜÜO P
BasePath
ÜÜP X
,
ÜÜX Y
$str
ÜÜZ q
)
ÜÜq r
;
ÜÜr s
var
àà 
headers
àà 
=
àà 
new
àà !

Dictionary
àà" ,
<
àà, -
string
àà- 3
,
àà3 4
string
àà5 ;
>
àà; <
{
ââ 
[
ää 
$str
ää $
]
ää$ %
=
ää& '
$"
ää( *
$str
ää* 0
{
ää0 1
this
ää1 5
.
ää5 6%
_ePGetdatosdelsiniestro
ää6 M
.
ääM N
Auth
ääN R
}
ääR S
"
ääS T
,
ääT U
[
ãã 
$str
ãã !
]
ãã! "
=
ãã# $
request
ãã% ,
.
ãã, -
INsinie
ãã- 4
.
ãã4 5
ToString
ãã5 =
(
ãã= >
CultureInfo
ãã> I
.
ããI J
InvariantCulture
ããJ Z
)
ããZ [
,
ãã[ \
}
åå 
;
åå 
var
éé 
result
éé 
=
éé 
await
éé "
this
éé# '
.
éé' (
_httpService
éé( 4
.
éé4 5!
GetWithHeadersAsync
éé5 H
<
ééH I'
SiniestrosDetalleResponse
ééI b
>
ééb c
(
ééc d
url
èè 
,
èè 
bearerToken
êê 
:
êê  
null
êê! %
,
êê% &
customHeaders
ëë !
:
ëë! "
headers
ëë# *
)
ëë* +
.
ëë+ ,
ConfigureAwait
ëë, :
(
ëë: ;
false
ëë; @
)
ëë@ A
;
ëëA B
if
ìì 
(
ìì 
result
ìì 
==
ìì 
null
ìì "
)
ìì" #
{
îî 
const
ïï 
string
ïï  
errorMessage
ïï! -
=
ïï. /
$str
ïï0 i
;
ïïi j
this
ññ 
.
ññ 
_logger
ññ  
.
ññ  !
LogError
ññ! )
(
ññ) *
errorMessage
ññ* 6
)
ññ6 7
;
ññ7 8
throw
óó 
new
óó '
InvalidOperationException
óó 7
(
óó7 8
errorMessage
óó8 D
)
óóD E
;
óóE F
}
òò 
this
öö 
.
öö 
_logger
öö 
.
öö 

EndProcess
öö '
(
öö' (
	processId
öö( 1
,
öö1 2
	stopwatch
öö3 <
,
öö< =
new
öö> A
{
ööB C
Success
ööD K
=
ööL M
true
ööN R
,
ööR S
DataReturned
ööT `
=
ööa b
true
ööc g
}
ööh i
)
ööi j
;
ööj k
this
õõ 
.
õõ 
_logger
õõ 
.
õõ 
Info
õõ !
(
õõ! "
$"
õõ" $
$str
õõ$ :
{
õõ: ;
request
õõ; B
.
õõB C
INsinie
õõC J
}
õõJ K
$str
õõK a
"
õõa b
)
õõb c
;
õõc d
return
ùù 
result
ùù 
;
ùù 
}
ûû 
catch
üü 
(
üü 
	Exception
üü 
ex
üü 
)
üü  
{
†† 
this
°° 
.
°° 
_logger
°° 
.
°° 
LogError
°° %
(
°°% &
ex
°°& (
,
°°( )
$"
°°* ,
$str
°°, T
{
°°T U
request
°°U \
.
°°\ ]
INsinie
°°] d
}
°°d e
"
°°e f
)
°°f g
;
°°g h
this
¢¢ 
.
¢¢ 
_logger
¢¢ 
.
¢¢ 

EndProcess
¢¢ '
(
¢¢' (
	processId
¢¢( 1
,
¢¢1 2
	stopwatch
¢¢3 <
,
¢¢< =
new
¢¢> A
{
¢¢B C
Success
¢¢D K
=
¢¢L M
false
¢¢N S
,
¢¢S T
Error
¢¢U Z
=
¢¢[ \
ex
¢¢] _
.
¢¢_ `
Message
¢¢` g
}
¢¢h i
)
¢¢i j
;
¢¢j k
throw
££ 
;
££ 
}
§§ 
}
•• 	
private
ßß 
Uri
ßß !
BuildAndValidateUri
ßß '
(
ßß' (
string
ßß( .
basePath
ßß/ 7
,
ßß7 8
string
ßß9 ?
serviceName
ßß@ K
)
ßßK L
{
®® 	
this
©© 
.
©© 
_logger
©© 
.
©© 
Debug
©© 
(
©© 
$"
©© !
$str
©©! >
{
©©> ?
serviceName
©©? J
}
©©J K
"
©©K L
)
©©L M
;
©©M N
if
´´ 
(
´´ 
string
´´ 
.
´´  
IsNullOrWhiteSpace
´´ )
(
´´) *
basePath
´´* 2
)
´´2 3
)
´´3 4
{
¨¨ 
throw
≠≠ 
new
≠≠ '
InvalidOperationException
≠≠ 3
(
≠≠3 4
$"
≠≠4 6
$str
≠≠6 l
{
≠≠l m
serviceName
≠≠m x
}
≠≠x y
"
≠≠y z
)
≠≠z {
;
≠≠{ |
}
ÆÆ 
if
∞∞ 
(
∞∞ 
!
∞∞ 
Uri
∞∞ 
.
∞∞ 
	TryCreate
∞∞ 
(
∞∞ 
basePath
∞∞ '
,
∞∞' (
UriKind
∞∞) 0
.
∞∞0 1
Absolute
∞∞1 9
,
∞∞9 :
out
∞∞; >
Uri
∞∞? B
?
∞∞B C
validUri
∞∞D L
)
∞∞L M
)
∞∞M N
{
±± 
throw
≤≤ 
new
≤≤ '
InvalidOperationException
≤≤ 3
(
≤≤3 4
$"
≤≤4 6
$str
≤≤6 ^
{
≤≤^ _
serviceName
≤≤_ j
}
≤≤j k
$str
≤≤k m
{
≤≤m n
basePath
≤≤n v
}
≤≤v w
"
≤≤w x
)
≤≤x y
;
≤≤y z
}
≥≥ 
this
µµ 
.
µµ 
_logger
µµ 
.
µµ 
Debug
µµ 
(
µµ 
$"
µµ !
$str
µµ! =
{
µµ= >
validUri
µµ> F
}
µµF G
"
µµG H
)
µµH I
;
µµI J
return
∂∂ 
validUri
∂∂ 
;
∂∂ 
}
∑∑ 	
private
ππ 

Dictionary
ππ 
<
ππ 
string
ππ !
,
ππ! "
string
ππ# )
>
ππ) *(
BuildAuthenticationHeaders
ππ+ E
(
ππE F
string
∫∫ 
auth
∫∫ 
,
∫∫ 
string
ªª 
	tokenName
ªª 
,
ªª 
string
ºº 

tokenValue
ºº 
,
ºº 
string
ΩΩ 

cookieName
ΩΩ 
,
ΩΩ 
string
ææ 
cookieValue
ææ 
)
ææ 
{
øø 	
this
¿¿ 
.
¿¿ 
_logger
¿¿ 
.
¿¿ 
Debug
¿¿ 
(
¿¿ 
$"
¿¿ !
$str
¿¿! W
{
¿¿W X
	tokenName
¿¿X a
}
¿¿a b
$str
¿¿b d
{
¿¿d e

cookieName
¿¿e o
}
¿¿o p
"
¿¿p q
)
¿¿q r
;
¿¿r s
return
¬¬ 
new
¬¬ 

Dictionary
¬¬ !
<
¬¬! "
string
¬¬" (
,
¬¬( )
string
¬¬* 0
>
¬¬0 1
{
√√ 
[
ƒƒ 
$str
ƒƒ  
]
ƒƒ  !
=
ƒƒ" #
$"
ƒƒ$ &
$str
ƒƒ& ,
{
ƒƒ, -
auth
ƒƒ- 1
}
ƒƒ1 2
"
ƒƒ2 3
,
ƒƒ3 4
[
≈≈ 
	tokenName
≈≈ 
]
≈≈ 
=
≈≈ 

tokenValue
≈≈ (
,
≈≈( )
[
∆∆ 

cookieName
∆∆ 
]
∆∆ 
=
∆∆ 
cookieValue
∆∆ *
,
∆∆* +
}
«« 
;
«« 
}
»» 	
}
…… 
}   Ùq
jC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\ResiliencePolicyService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
{ 
public 

class #
ResiliencePolicyService (
:) *$
IResiliencePolicyService+ C
{ 
private 
readonly 

IAppLogger #
<# $#
ResiliencePolicyService$ ;
>; <
_logger= D
;D E
private 
static 
ResiliencePipeline )"
CreateBulkheadPipeline* @
(@ A
)A B
{ 	
return 
new %
ResiliencePipelineBuilder 0
(0 1
)1 2
. !
AddConcurrencyLimiter &
(& '
permitLimit' 2
:2 3
$num4 5
,5 6

queueLimit7 A
:A B
$numC E
)E F
. 
Build 
( 
) 
; 
}   	
public&& #
ResiliencePolicyService&& &
(&&& '

IAppLogger&&' 1
<&&1 2#
ResiliencePolicyService&&2 I
>&&I J
logger&&K Q
)&&Q R
{'' 	
this(( 
.(( 
_logger(( 
=(( 
logger(( !
??((" $
throw((% *
new((+ .!
ArgumentNullException((/ D
(((D E
nameof((E K
(((K L
logger((L R
)((R S
)((S T
;((T U
this** 
.** 
RetryPipeline** 
=**  
this**! %
.**% &
CreateRetryPipeline**& 9
(**9 :
)**: ;
;**; <
this++ 
.++ "
CircuitBreakerPipeline++ '
=++( )
this++* .
.++. /(
CreateCircuitBreakerPipeline++/ K
(++K L
)++L M
;++M N
this,, 
.,, 
TimeoutPipeline,,  
=,,! "
this,,# '
.,,' (!
CreateTimeoutPipeline,,( =
(,,= >
),,> ?
;,,? @
this-- 
.-- 
BulkheadPipeline-- !
=--" #"
CreateBulkheadPipeline--$ :
(--: ;
)--; <
;--< =
}.. 	
public11 
ResiliencePipeline11 !
RetryPipeline11" /
{110 1
get112 5
;115 6
}117 8
public44 
ResiliencePipeline44 !"
CircuitBreakerPipeline44" 8
{449 :
get44; >
;44> ?
}44@ A
public77 
ResiliencePipeline77 !
TimeoutPipeline77" 1
{772 3
get774 7
;777 8
}779 :
public:: 
ResiliencePipeline:: !
BulkheadPipeline::" 2
{::3 4
get::5 8
;::8 9
}::: ;
private@@ 
ResiliencePipeline@@ "
CreateRetryPipeline@@# 6
(@@6 7
)@@7 8
{AA 	
returnBB 
newBB %
ResiliencePipelineBuilderBB 0
(BB0 1
)BB1 2
.CC 
AddRetryCC 
(CC 
newCC  
RetryStrategyOptionsCC 2
{DD 
MaxRetryAttemptsEE $
=EE% &
$numEE' (
,EE( )
DelayFF 
=FF 
TimeSpanFF $
.FF$ %
FromMillisecondsFF% 5
(FF5 6
$numFF6 9
)FF9 :
,FF: ;
BackoffTypeGG 
=GG  !
DelayBackoffTypeGG" 2
.GG2 3
ExponentialGG3 >
,GG> ?
	UseJitterHH 
=HH 
trueHH  $
,HH$ %
OnRetryII 
=II 
argsII "
=>II# %
{JJ 
thisKK 
.KK 
_loggerKK $
.KK$ %
InfoKK% )
(KK) *
$"KK* ,
$strKK, <
{KK< =
argsKK= A
.KKA B
AttemptNumberKKB O
}KKO P
$strKKP \
{KK\ ]
argsKK] a
.KKa b

RetryDelayKKb l
.KKl m
TotalSecondsKKm y
}KKy z
$strKKz ~
{KK~ 
args	KK É
.
KKÉ Ñ
Outcome
KKÑ ã
.
KKã å
	Exception
KKå ï
?
KKï ñ
.
KKñ ó
Message
KKó û
}
KKû ü
"
KKü †
)
KK† °
;
KK° ¢
returnLL 
	ValueTaskLL (
.LL( )
CompletedTaskLL) 6
;LL6 7
}MM 
,MM 
ShouldHandleNN  
=NN! "
newNN# &
PredicateBuilderNN' 7
(NN7 8
)NN8 9
.OO 
HandleOO 
<OO   
HttpRequestExceptionOO  4
>OO4 5
(OO5 6
)OO6 7
.PP 
HandlePP 
<PP  !
TaskCanceledExceptionPP  5
>PP5 6
(PP6 7
)PP7 8
.QQ 
HandleQQ 
<QQ  $
TimeoutRejectedExceptionQQ  8
>QQ8 9
(QQ9 :
)QQ: ;
,QQ; <
}RR 
)RR 
.SS 
BuildSS 
(SS 
)SS 
;SS 
}TT 	
private[[ 
ResiliencePipeline[[ "(
CreateCircuitBreakerPipeline[[# ?
([[? @
)[[@ A
{\\ 	
var]] 
circuitBreaker]] 
=]]  
new]]! $%
ResiliencePipelineBuilder]]% >
(]]> ?
)]]? @
.^^ 
AddCircuitBreaker^^ "
(^^" #
new^^# &)
CircuitBreakerStrategyOptions^^' D
{__ 
FailureRatio``  
=``! "
$num``# &
,``& '
MinimumThroughputaa %
=aa& '
$numaa( )
,aa) *
SamplingDurationbb $
=bb% &
TimeSpanbb' /
.bb/ 0
FromSecondsbb0 ;
(bb; <
$numbb< >
)bb> ?
,bb? @
BreakDurationcc !
=cc" #
TimeSpancc$ ,
.cc, -
FromSecondscc- 8
(cc8 9
$numcc9 ;
)cc; <
,cc< =
OnOpeneddd 
=dd 
argsdd #
=>dd$ &
{ee 
thisff 
.ff 
_loggerff $
.ff$ %
LogErrorff% -
(ff- .
$"ff. 0
$strff0 l
{ffl m
argsffm q
.ffq r
BreakDurationffr 
.	ff Ä
TotalSeconds
ffÄ å
}
ffå ç
$str
ffç é
"
ffé è
)
ffè ê
;
ffê ë
returngg 
	ValueTaskgg (
.gg( )
CompletedTaskgg) 6
;gg6 7
}hh 
,hh 
OnClosedii 
=ii 
argsii #
=>ii$ &
{jj 
thiskk 
.kk 
_loggerkk $
.kk$ %
Infokk% )
(kk) *
$"kk* ,
$strkk, f
{kkf g
argskkg k
}kkk l
"kkl m
)kkm n
;kkn o
returnll 
	ValueTaskll (
.ll( )
CompletedTaskll) 6
;ll6 7
}mm 
,mm 
OnHalfOpenednn  
=nn! "
argsnn# '
=>nn( *
{oo 
thispp 
.pp 
_loggerpp $
.pp$ %
Infopp% )
(pp) *
$"pp* ,
$strpp, m
{ppm n
argsppn r
}ppr s
"pps t
)ppt u
;ppu v
returnqq 
	ValueTaskqq (
.qq( )
CompletedTaskqq) 6
;qq6 7
}rr 
,rr 
ShouldHandless  
=ss! "
newss# &
PredicateBuilderss' 7
(ss7 8
)ss8 9
.tt 
Handlett 
<tt   
HttpRequestExceptiontt  4
>tt4 5
(tt5 6
)tt6 7
.uu 
Handleuu 
<uu  !
TaskCanceledExceptionuu  5
>uu5 6
(uu6 7
)uu7 8
.vv 
Handlevv 
<vv  $
TimeoutRejectedExceptionvv  8
>vv8 9
(vv9 :
)vv: ;
,vv; <
}ww 
)ww 
.xx 
Buildxx 
(xx 
)xx 
;xx 
return{{ 
new{{ %
ResiliencePipelineBuilder{{ 0
({{0 1
){{1 2
.|| 
AddRetry|| 
(|| 
new||  
RetryStrategyOptions|| 2
{}} 
MaxRetryAttempts~~ $
=~~% &
$num~~' (
,~~( )
Delay 
= 
TimeSpan $
.$ %
FromSeconds% 0
(0 1
$num1 2
)2 3
,3 4
BackoffType
ÄÄ 
=
ÄÄ  !
DelayBackoffType
ÄÄ" 2
.
ÄÄ2 3
Constant
ÄÄ3 ;
,
ÄÄ; <
	UseJitter
ÅÅ 
=
ÅÅ 
true
ÅÅ  $
,
ÅÅ$ %
OnRetry
ÇÇ 
=
ÇÇ 
args
ÇÇ "
=>
ÇÇ# %
{
ÉÉ 
this
ÑÑ 
.
ÑÑ 
_logger
ÑÑ $
.
ÑÑ$ %
Info
ÑÑ% )
(
ÑÑ) *
$"
ÑÑ* ,
$str
ÑÑ, ?
{
ÑÑ? @
args
ÑÑ@ D
.
ÑÑD E
AttemptNumber
ÑÑE R
}
ÑÑR S
$str
ÑÑS V
{
ÑÑV W
args
ÑÑW [
.
ÑÑ[ \
Outcome
ÑÑ\ c
.
ÑÑc d
	Exception
ÑÑd m
?
ÑÑm n
.
ÑÑn o
Message
ÑÑo v
}
ÑÑv w
"
ÑÑw x
)
ÑÑx y
;
ÑÑy z
return
ÖÖ 
	ValueTask
ÖÖ (
.
ÖÖ( )
CompletedTask
ÖÖ) 6
;
ÖÖ6 7
}
ÜÜ 
,
ÜÜ 
ShouldHandle
áá  
=
áá! "
new
áá# &
PredicateBuilder
áá' 7
(
áá7 8
)
áá8 9
.
àà 
Handle
àà 
<
àà  "
HttpRequestException
àà  4
>
àà4 5
(
àà5 6
)
àà6 7
.
ââ 
Handle
ââ 
<
ââ  #
TaskCanceledException
ââ  5
>
ââ5 6
(
ââ6 7
)
ââ7 8
.
ää 
Handle
ää 
<
ää  &
TimeoutRejectedException
ää  8
>
ää8 9
(
ää9 :
)
ää: ;
,
ää; <
}
ãã 
)
ãã 
.
åå 
AddPipeline
åå 
(
åå 
circuitBreaker
åå +
)
åå+ ,
.
çç 
Build
çç 
(
çç 
)
çç 
;
çç 
}
éé 	
private
îî  
ResiliencePipeline
îî "#
CreateTimeoutPipeline
îî# 8
(
îî8 9
)
îî9 :
{
ïï 	
return
ññ 
new
ññ '
ResiliencePipelineBuilder
ññ 0
(
ññ0 1
)
ññ1 2
.
óó 
AddRetry
óó 
(
óó 
new
óó "
RetryStrategyOptions
óó 2
{
òò 
MaxRetryAttempts
ôô $
=
ôô% &
$num
ôô' (
,
ôô( )
DelayGenerator
öö "
=
öö# $
args
öö% )
=>
öö* ,
{
õõ 
var
ùù 
	baseDelay
ùù %
=
ùù& '
TimeSpan
ùù( 0
.
ùù0 1
FromSeconds
ùù1 <
(
ùù< =
Math
ùù= A
.
ùùA B
Pow
ùùB E
(
ùùE F
$num
ùùF G
,
ùùG H
args
ùùI M
.
ùùM N
AttemptNumber
ùùN [
)
ùù[ \
)
ùù\ ]
;
ùù] ^
var
ûû 
jitter
ûû "
=
ûû# $
TimeSpan
ûû% -
.
ûû- .
FromMilliseconds
ûû. >
(
ûû> ?#
RandomNumberGenerator
ûû? T
.
ûûT U
GetInt32
ûûU ]
(
ûû] ^
$num
ûû^ _
,
ûû_ `
$num
ûûa e
)
ûûe f
)
ûûf g
;
ûûg h
return
üü 
	ValueTask
üü (
.
üü( )

FromResult
üü) 3
<
üü3 4
TimeSpan
üü4 <
?
üü< =
>
üü= >
(
üü> ?
	baseDelay
üü? H
+
üüI J
jitter
üüK Q
)
üüQ R
;
üüR S
}
†† 
,
†† 
OnRetry
°° 
=
°° 
args
°° "
=>
°°# %
{
¢¢ 
this
££ 
.
££ 
_logger
££ $
.
££$ %
Info
££% )
(
££) *
$"
££* ,
$str
££, D
{
££D E
args
££E I
.
££I J
AttemptNumber
££J W
}
££W X
$str
££X n
{
££n o
args
££o s
.
££s t
Outcome
££t {
.
££{ |
	Exception££| Ö
?££Ö Ü
.££Ü á
Message££á é
}££é è
"££è ê
)££ê ë
;££ë í
return
§§ 
	ValueTask
§§ (
.
§§( )
CompletedTask
§§) 6
;
§§6 7
}
•• 
,
•• 
ShouldHandle
¶¶  
=
¶¶! "
new
¶¶# &
PredicateBuilder
¶¶' 7
(
¶¶7 8
)
¶¶8 9
.
ßß 
Handle
ßß 
<
ßß  "
HttpRequestException
ßß  4
>
ßß4 5
(
ßß5 6
)
ßß6 7
.
®® 
Handle
®® 
<
®®  #
TaskCanceledException
®®  5
>
®®5 6
(
®®6 7
)
®®7 8
.
©© 
Handle
©© 
<
©©  &
TimeoutRejectedException
©©  8
>
©©8 9
(
©©9 :
)
©©: ;
,
©©; <
}
™™ 
)
™™ 
.
´´ 

AddTimeout
´´ 
(
´´ 
new
´´ $
TimeoutStrategyOptions
´´  6
{
¨¨ 
Timeout
≠≠ 
=
≠≠ 
TimeSpan
≠≠ &
.
≠≠& '
FromSeconds
≠≠' 2
(
≠≠2 3
$num
≠≠3 5
)
≠≠5 6
,
≠≠6 7
	OnTimeout
ÆÆ 
=
ÆÆ 
args
ÆÆ  $
=>
ÆÆ% '
{
ØØ 
this
∞∞ 
.
∞∞ 
_logger
∞∞ $
.
∞∞$ %
LogError
∞∞% -
(
∞∞- .
$"
∞∞. 0
$str
∞∞0 R
{
∞∞R S
args
∞∞S W
.
∞∞W X
Context
∞∞X _
.
∞∞_ `
OperationKey
∞∞` l
}
∞∞l m
"
∞∞m n
)
∞∞n o
;
∞∞o p
return
±± 
	ValueTask
±± (
.
±±( )
CompletedTask
±±) 6
;
±±6 7
}
≤≤ 
,
≤≤ 
}
≥≥ 
)
≥≥ 
.
¥¥ 
Build
¥¥ 
(
¥¥ 
)
¥¥ 
;
¥¥ 
}
µµ 	
}
∂∂ 
}∑∑ „

eC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Models\ApiResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *
Models* 0
{ 
public 

class 
ApiResponse 
< 
T 
> 
{ 
public 
T 
? 
Data 
{ 
get 
; 
set !
;! "
}# $
public,, 
HttpStatusCode,, 

StatusCode,, (
{,,) *
get,,+ .
;,,. /
set,,0 3
;,,3 4
},,5 6
public;; 
string;; 
RawResponse;; !
{;;" #
get;;$ '
;;;' (
set;;) ,
;;;, -
};;. /
=;;0 1
string;;2 8
.;;8 9
Empty;;9 >
;;;> ?
publicMM 
boolMM 
	IsSuccessMM 
=>MM  
(MM! "
intMM" %
)MM% &
thisMM& *
.MM* +

StatusCodeMM+ 5
>=MM6 8
$numMM9 <
&&MM= ?
(MM@ A
intMMA D
)MMD E
thisMME I
.MMI J

StatusCodeMMJ T
<MMU V
$numMMW Z
;MMZ [
}NN 
}OO ∑
dC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Models\ApiRequest.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *
Models* 0
{ 
public

 

class

 

ApiRequest

 
{ 
public 
Uri 
Url 
{ 
get 
; 
set !
;! "
}# $
=% &
null' +
!+ ,
;, -
public"" 

HttpMethod"" 
Method""  
{""! "
get""# &
;""& '
set""( +
;""+ ,
}""- .
=""/ 0

HttpMethod""1 ;
.""; <
Get""< ?
;""? @
public.. 
object.. 
?.. 
Body.. 
{.. 
get.. !
;..! "
set..# &
;..& '
}..( )
public<< 

Dictionary<< 
<<< 
string<<  
,<<  !
string<<" (
><<( )
Headers<<* 1
{<<2 3
get<<4 7
;<<7 8
}<<9 :
=<<; <
new<<= @
(<<@ A
)<<A B
;<<B C
publicHH 
stringHH 
?HH 
BearerTokenHH "
{HH# $
getHH% (
;HH( )
setHH* -
;HH- .
}HH/ 0
}II 
}JJ ë
kC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Interfaces\ITokenService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *

Interfaces* 4
{ 
public 

	interface 
ITokenService "
{ 
string 
GenerateToken 
( 
	TokenData &
data' +
)+ ,
;, -
} 
} À
pC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Interfaces\ISiniestrosService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *

Interfaces* 4
{ 
public 

	interface 
ISiniestrosService '
{ 
Task 
< 
SiniestrosResponse 
>  %
GetSiniestrosPorAsegurado! :
(: ;
SiniestrosRequest; L
requestM T
)T U
;U V
Task 
< %
SiniestrosDetalleResponse &
>& ' 
GetDatosDelSiniestro( <
(< = 
SiniestrosDetRequest= Q
requestR Y
)Y Z
;Z [
} 
} î
vC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Interfaces\IResiliencePolicyService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *

Interfaces* 4
{ 
public 

	interface $
IResiliencePolicyService -
{ 
ResiliencePipeline 
RetryPipeline (
{) *
get+ .
;. /
}0 1
ResiliencePipeline "
CircuitBreakerPipeline 1
{2 3
get4 7
;7 8
}9 :
ResiliencePipeline 
TimeoutPipeline *
{+ ,
get- 0
;0 1
}2 3
ResiliencePipeline 
BulkheadPipeline +
{, -
get. 1
;1 2
}3 4
}   
}!! Õ-
jC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Interfaces\IHttpService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *

Interfaces* 4
{ 
public 

	interface 
IHttpService !
{ 
Task 
< 
	TResponse 
? 
> 
GetAsync !
<! "
	TResponse" +
>+ ,
(, -
Uri- 0
url1 4
,4 5
string6 <
?< =
bearerToken> I
=J K
nullL P
)P Q
where 
	TResponse 
: 
class #
;# $
Task!! 
<!! 
	TResponse!! 
?!! 
>!! 
	PostAsync!! "
<!!" #
TRequest!!# +
,!!+ ,
	TResponse!!- 6
>!!6 7
(!!7 8
Uri!!8 ;
url!!< ?
,!!? @
TRequest!!A I
body!!J N
,!!N O
string!!P V
?!!V W
bearerToken!!X c
=!!d e
null!!f j
)!!j k
where"" 
TRequest"" 
:"" 
class"" "
where## 
	TResponse## 
:## 
class## #
;### $
Task.. 
<.. 
	TResponse.. 
?.. 
>.. 
PutAsync.. !
<..! "
TRequest.." *
,..* +
	TResponse.., 5
>..5 6
(..6 7
Uri..7 :
url..; >
,..> ?
TRequest..@ H
body..I M
,..M N
string..O U
?..U V
bearerToken..W b
=..c d
null..e i
)..i j
where// 
TRequest// 
:// 
class// "
where00 
	TResponse00 
:00 
class00 #
;00# $
Task99 
<99 
	TResponse99 
?99 
>99 
DeleteAsync99 $
<99$ %
	TResponse99% .
>99. /
(99/ 0
Uri990 3
url994 7
,997 8
string999 ?
?99? @
bearerToken99A L
=99M N
null99O S
)99S T
where:: 
	TResponse:: 
::: 
class:: #
;::# $
TaskBB 
<BB 
HttpApiResponseBB 
<BB 
	TResponseBB &
>BB& '
>BB' (
SendCustomAsyncBB) 8
<BB8 9
	TResponseBB9 B
>BBB C
(BBC D
HttpRequestBBD O
requestBBP W
)BBW X
whereCC 
	TResponseCC 
:CC 
classCC #
;CC# $
TaskMM 
<MM 
	TResponseMM 
?MM 
>MM 
GetWithHeadersAsyncMM ,
<MM, -
	TResponseMM- 6
>MM6 7
(MM7 8
UriNN 
urlNN 
,NN 
stringOO 
?OO 
bearerTokenOO 
=OO  !
nullOO" &
,OO& '

DictionaryPP 
<PP 
stringPP 
,PP 
stringPP %
>PP% &
?PP& '
customHeadersPP( 5
=PP6 7
nullPP8 <
)PP< =
whereQQ 
	TResponseQQ 
:QQ 
classQQ #
;QQ# $
Task]] 
<]] 
	TResponse]] 
?]] 
>]]  
PostWithHeadersAsync]] -
<]]- .
TRequest]]. 6
,]]6 7
	TResponse]]8 A
>]]A B
(]]B C
Uri^^ 
url^^ 
,^^ 
TRequest__ 
body__ 
,__ 
string`` 
?`` 
bearerToken`` 
=``  !
null``" &
,``& '

Dictionaryaa 
<aa 
stringaa 
,aa 
stringaa %
>aa% &
?aa& '
customHeadersaa( 5
=aa6 7
nullaa8 <
)aa< =
wherebb 
TRequestbb 
:bb 
classbb "
wherecc 
	TResponsecc 
:cc 
classcc #
;cc# $
Taskmm 
<mm 
HttpApiResponsemm 
<mm 
	TResponsemm &
>mm& '
>mm' (&
GetWithCircuitBreakerAsyncmm) C
<mmC D
	TResponsemmD M
>mmM N
(mmN O
Urinn 
urlnn 
,nn 
stringoo 
?oo 
bearerTokenoo 
=oo  !
nulloo" &
,oo& '

Dictionarypp 
<pp 
stringpp 
,pp 
stringpp %
>pp% &
?pp& '
customHeaderspp( 5
=pp6 7
nullpp8 <
)pp< =
whereqq 
	TResponseqq 
:qq 
classqq #
;qq# $
Task}} 
<}} 
HttpApiResponse}} 
<}} 
	TResponse}} &
>}}& '
>}}' ('
PostWithCircuitBreakerAsync}}) D
<}}D E
TRequest}}E M
,}}M N
	TResponse}}O X
>}}X Y
(}}Y Z
Uri~~ 
url~~ 
,~~ 
TRequest 
body 
, 
string
ÄÄ 
?
ÄÄ 
bearerToken
ÄÄ 
=
ÄÄ  !
null
ÄÄ" &
,
ÄÄ& '

Dictionary
ÅÅ 
<
ÅÅ 
string
ÅÅ 
,
ÅÅ 
string
ÅÅ %
>
ÅÅ% &
?
ÅÅ& '
customHeaders
ÅÅ( 5
=
ÅÅ6 7
null
ÅÅ8 <
)
ÅÅ< =
where
ÇÇ 
TRequest
ÇÇ 
:
ÇÇ 
class
ÇÇ "
where
ÉÉ 
	TResponse
ÉÉ 
:
ÉÉ 
class
ÉÉ #
;
ÉÉ# $
}
ÑÑ 
}ÖÖ Ó

pC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Interfaces\IHttpClientService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *

Interfaces* 4
{ 
public 

	interface 
IHttpClientService '
{ 
Task 
< 
ApiResponse 
< 
T 
> 
> 
	SendAsync &
<& '
T' (
>( )
() *

ApiRequest* 4
request5 <
)< =
;= >
Task(( 
<(( 
ApiResponse(( 
<(( 
T(( 
>(( 
>(( !
SendWithoutRetryAsync(( 2
<((2 3
T((3 4
>((4 5
(((5 6

ApiRequest((6 @
request((A H
)((H I
;((I J
Task11 
<11 
string11 
>11 
	PostAsync11 
(11 
Uri11 "
url11# &
,11& '
string11( .
jsonBody11/ 7
,117 8

Dictionary119 C
<11C D
string11D J
,11J K
string11L R
>11R S
?11S T
headers11U \
=11] ^
null11_ c
)11c d
;11d e
}22 
}33 Ï
jC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\Interfaces\ICadsService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
.) *

Interfaces* 4
{ 
public 

	interface 
ICadsService !
{ 
Task 
< 
UserAccessResponse 
?  
>  !
ValideUserAccess" 2
(2 3!
ValidateAccessRequest3 H
requestI P
)P Q
;Q R
} 
} ≤°
^C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\HttpService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
{ 
public 

class 
HttpService 
: 
IHttpService +
{ 
private 
const 
string "
_getWithCircuitBreaker 3
=4 5
$str6 P
;P Q
private 
const 
string #
_postWithCircuitBreaker 4
=5 6
$str7 R
;R S
private 
readonly 
IHttpClientService +
_httpClientService, >
;> ?
private 
readonly 

IAppLogger #
<# $
HttpService$ /
>/ 0
_logger1 8
;8 9
private 
readonly $
IResiliencePolicyService 1$
_resiliencePolicyService2 J
;J K
public"" 
HttpService"" 
("" 
IHttpClientService## 
httpClientService## 0
,##0 1

IAppLogger$$ 
<$$ 
HttpService$$ "
>$$" #
logger$$$ *
,$$* +$
IResiliencePolicyService%% $#
resiliencePolicyService%%% <
)%%< =
{&& 	
this'' 
.'' 
_httpClientService'' #
=''$ %
httpClientService''& 7
??''8 :
throw''; @
new''A D!
ArgumentNullException''E Z
(''Z [
nameof''[ a
(''a b
httpClientService''b s
)''s t
)''t u
;''u v
this(( 
.(( 
_logger(( 
=(( 
logger(( !
??((" $
throw((% *
new((+ .!
ArgumentNullException((/ D
(((D E
nameof((E K
(((K L
logger((L R
)((R S
)((S T
;((T U
this)) 
.)) $
_resiliencePolicyService)) )
=))* +#
resiliencePolicyService)), C
??))D F
throw))G L
new))M P!
ArgumentNullException))Q f
())f g
nameof))g m
())m n$
resiliencePolicyService	))n Ö
)
))Ö Ü
)
))Ü á
;
))á à
}** 	
public33 
async33 
Task33 
<33 
	TResponse33 #
?33# $
>33$ %
GetAsync33& .
<33. /
	TResponse33/ 8
>338 9
(339 :
Uri33: =
url33> A
,33A B
string33C I
?33I J
bearerToken33K V
=33W X
null33Y ]
)33] ^
where44 
	TResponse44 
:44 
class44 #
{55 	!
ArgumentNullException66 !
.66! "
ThrowIfNull66" -
(66- .
url66. 1
)661 2
;662 3
var88 

apiRequest88 
=88 
new88  

ApiRequest88! +
{99 
Url:: 
=:: 
url:: 
,:: 
BearerToken;; 
=;; 
bearerToken;; )
,;;) *
Method<< 
=<< 

HttpMethod<< #
.<<# $
Get<<$ '
,<<' (
}== 
;== 
return?? 
await?? 
this?? 
.?? %
ExecuteSimpleRequestAsync?? 7
<??7 8
	TResponse??8 A
>??A B
(??B C

apiRequest??C M
,??M N
$str??O T
)??T U
.??U V
ConfigureAwait??V d
(??d e
false??e j
)??j k
;??k l
}@@ 	
publicKK 
asyncKK 
TaskKK 
<KK 
	TResponseKK #
?KK# $
>KK$ %
	PostAsyncKK& /
<KK/ 0
TRequestKK0 8
,KK8 9
	TResponseKK: C
>KKC D
(KKD E
UriKKE H
urlKKI L
,KKL M
TRequestKKN V
bodyKKW [
,KK[ \
stringKK] c
?KKc d
bearerTokenKKe p
=KKq r
nullKKs w
)KKw x
whereLL 
TRequestLL 
:LL 
classLL "
whereMM 
	TResponseMM 
:MM 
classMM #
{NN 	!
ArgumentNullExceptionOO !
.OO! "
ThrowIfNullOO" -
(OO- .
urlOO. 1
)OO1 2
;OO2 3!
ArgumentNullExceptionPP !
.PP! "
ThrowIfNullPP" -
(PP- .
bodyPP. 2
)PP2 3
;PP3 4
varRR 

apiRequestRR 
=RR 
newRR  

ApiRequestRR! +
{SS 
UrlTT 
=TT 
urlTT 
,TT 
BearerTokenUU 
=UU 
bearerTokenUU )
,UU) *
BodyVV 
=VV 
bodyVV 
,VV 
MethodWW 
=WW 

HttpMethodWW #
.WW# $
PostWW$ (
,WW( )
}XX 
;XX 
returnZZ 
awaitZZ 
thisZZ 
.ZZ %
ExecuteSimpleRequestAsyncZZ 7
<ZZ7 8
	TResponseZZ8 A
>ZZA B
(ZZB C

apiRequestZZC M
,ZZM N
$strZZO U
)ZZU V
.ZZV W
ConfigureAwaitZZW e
(ZZe f
falseZZf k
)ZZk l
;ZZl m
}[[ 	
publicff 
asyncff 
Taskff 
<ff 
	TResponseff #
?ff# $
>ff$ %
PutAsyncff& .
<ff. /
TRequestff/ 7
,ff7 8
	TResponseff9 B
>ffB C
(ffC D
UriffD G
urlffH K
,ffK L
TRequestffM U
bodyffV Z
,ffZ [
stringff\ b
?ffb c
bearerTokenffd o
=ffp q
nullffr v
)ffv w
wheregg 
TRequestgg 
:gg 
classgg "
wherehh 
	TResponsehh 
:hh 
classhh #
{ii 	!
ArgumentNullExceptionjj !
.jj! "
ThrowIfNulljj" -
(jj- .
urljj. 1
)jj1 2
;jj2 3!
ArgumentNullExceptionkk !
.kk! "
ThrowIfNullkk" -
(kk- .
bodykk. 2
)kk2 3
;kk3 4
varmm 

apiRequestmm 
=mm 
newmm  

ApiRequestmm! +
{nn 
Urloo 
=oo 
urloo 
,oo 
BearerTokenpp 
=pp 
bearerTokenpp )
,pp) *
Bodyqq 
=qq 
bodyqq 
,qq 
Methodrr 
=rr 

HttpMethodrr #
.rr# $
Putrr$ '
,rr' (
}ss 
;ss 
returnuu 
awaituu 
thisuu 
.uu %
ExecuteSimpleRequestAsyncuu 7
<uu7 8
	TResponseuu8 A
>uuA B
(uuB C

apiRequestuuC M
,uuM N
$struuO T
)uuT U
.uuU V
ConfigureAwaituuV d
(uud e
falseuue j
)uuj k
;uuk l
}vv 	
public 
async 
Task 
< 
	TResponse #
?# $
>$ %
DeleteAsync& 1
<1 2
	TResponse2 ;
>; <
(< =
Uri= @
urlA D
,D E
stringF L
?L M
bearerTokenN Y
=Z [
null\ `
)` a
where
ÄÄ 
	TResponse
ÄÄ 
:
ÄÄ 
class
ÄÄ #
{
ÅÅ 	#
ArgumentNullException
ÇÇ !
.
ÇÇ! "
ThrowIfNull
ÇÇ" -
(
ÇÇ- .
url
ÇÇ. 1
)
ÇÇ1 2
;
ÇÇ2 3
var
ÑÑ 

apiRequest
ÑÑ 
=
ÑÑ 
new
ÑÑ  

ApiRequest
ÑÑ! +
{
ÖÖ 
Url
ÜÜ 
=
ÜÜ 
url
ÜÜ 
,
ÜÜ 
BearerToken
áá 
=
áá 
bearerToken
áá )
,
áá) *
Method
àà 
=
àà 

HttpMethod
àà #
.
àà# $
Delete
àà$ *
,
àà* +
}
ââ 
;
ââ 
return
ãã 
await
ãã 
this
ãã 
.
ãã '
ExecuteSimpleRequestAsync
ãã 7
<
ãã7 8
	TResponse
ãã8 A
>
ããA B
(
ããB C

apiRequest
ããC M
,
ããM N
$str
ããO W
)
ããW X
.
ããX Y
ConfigureAwait
ããY g
(
ããg h
false
ããh m
)
ããm n
;
ããn o
}
åå 	
public
îî 
async
îî 
Task
îî 
<
îî 
HttpApiResponse
îî )
<
îî) *
	TResponse
îî* 3
>
îî3 4
>
îî4 5
SendCustomAsync
îî6 E
<
îîE F
	TResponse
îîF O
>
îîO P
(
îîP Q
HttpRequest
îîQ \
request
îî] d
)
îîd e
where
ïï 
	TResponse
ïï 
:
ïï 
class
ïï #
{
ññ 	#
ArgumentNullException
óó !
.
óó! "
ThrowIfNull
óó" -
(
óó- .
request
óó. 5
)
óó5 6
;
óó6 7#
ArgumentNullException
òò !
.
òò! "
ThrowIfNull
òò" -
(
òò- .
request
òò. 5
.
òò5 6
Url
òò6 9
)
òò9 :
;
òò: ;
var
öö 
(
öö 
	processId
öö 
,
öö 
	stopwatch
öö %
)
öö% &
=
öö' (
this
öö) -
.
öö- .
_logger
öö. 5
.
öö5 6
StartProcess
öö6 B
(
ööB C
new
ööC F
{
õõ 
	Operation
úú 
=
úú 
$str
úú -
,
úú- .
Method
ùù 
=
ùù 
request
ùù  
.
ùù  !
Method
ùù! '
.
ùù' (
ToString
ùù( 0
(
ùù0 1
)
ùù1 2
,
ùù2 3
Url
ûû 
=
ûû 
request
ûû 
.
ûû 
Url
ûû !
.
ûû! "
ToString
ûû" *
(
ûû* +
)
ûû+ ,
,
ûû, -
}
üü 
)
üü 
;
üü 
var
°° 
response
°° 
=
°° 
new
°° 
HttpApiResponse
°° .
<
°°. /
	TResponse
°°/ 8
>
°°8 9
(
°°9 :
)
°°: ;
;
°°; <
try
££ 
{
§§ 
this
•• 
.
•• 
_logger
•• 
.
•• 
Info
•• !
(
••! "
$"
••" $
{
••$ %
request
••% ,
.
••, -
Method
••- 3
}
••3 4
$str
••4 H
{
••H I
request
••I P
.
••P Q
Url
••Q T
}
••T U
"
••U V
)
••V W
;
••W X
var
ßß 

apiRequest
ßß 
=
ßß  
CreateApiRequest
ßß! 1
(
ßß1 2
request
ßß2 9
.
ßß9 :
Url
ßß: =
,
ßß= >
request
ßß? F
.
ßßF G
BearerToken
ßßG R
,
ßßR S
request
ßßT [
.
ßß[ \
Body
ßß\ `
,
ßß` a
request
ßßb i
.
ßßi j
Method
ßßj p
)
ßßp q
;
ßßq r
var
®® 
result
®® 
=
®® 
await
®® "
this
®®# '
.
®®' ( 
_httpClientService
®®( :
.
®®: ;
	SendAsync
®®; D
<
®®D E
	TResponse
®®E N
>
®®N O
(
®®O P

apiRequest
®®P Z
)
®®Z [
.
®®[ \
ConfigureAwait
®®\ j
(
®®j k
false
®®k p
)
®®p q
;
®®q r
PopulateResponse
™™  
(
™™  !
response
™™! )
,
™™) *
result
™™+ 1
,
™™1 2
	stopwatch
™™3 <
)
™™< =
;
™™= >
this
´´ 
.
´´ 
LogRequestResult
´´ %
(
´´% &
request
´´& -
.
´´- .
Method
´´. 4
.
´´4 5
ToString
´´5 =
(
´´= >
)
´´> ?
,
´´? @
result
´´A G
,
´´G H
	stopwatch
´´I R
)
´´R S
;
´´S T
this
¨¨ 
.
¨¨ 
_logger
¨¨ 
.
¨¨ 

EndProcess
¨¨ '
(
¨¨' (
	processId
¨¨( 1
,
¨¨1 2
	stopwatch
¨¨3 <
,
¨¨< =
new
¨¨> A
{
¨¨B C
Success
¨¨D K
=
¨¨L M
result
¨¨N T
.
¨¨T U
	IsSuccess
¨¨U ^
,
¨¨^ _
result
¨¨` f
.
¨¨f g

StatusCode
¨¨g q
}
¨¨r s
)
¨¨s t
;
¨¨t u
return
ÆÆ 
response
ÆÆ 
;
ÆÆ  
}
ØØ 
catch
∞∞ 
(
∞∞ "
OutOfMemoryException
∞∞ '
ex
∞∞( *
)
∞∞* +
{
±± 
return
≤≤ 
this
≤≤ 
.
≤≤ (
HandleOutOfMemoryException
≤≤ 6
(
≤≤6 7
ex
≤≤7 9
,
≤≤9 :
response
≤≤; C
,
≤≤C D
	processId
≤≤E N
,
≤≤N O
	stopwatch
≤≤P Y
,
≤≤Y Z
request
≤≤[ b
.
≤≤b c
Url
≤≤c f
,
≤≤f g
request
≤≤h o
.
≤≤o p
Method
≤≤p v
.
≤≤v w
ToString
≤≤w 
(≤≤ Ä
)≤≤Ä Å
)≤≤Å Ç
;≤≤Ç É
}
≥≥ 
catch
¥¥ 
(
¥¥ $
StackOverflowException
¥¥ )
ex
¥¥* ,
)
¥¥, -
{
µµ 
return
∂∂ 
this
∂∂ 
.
∂∂ *
HandleStackOverflowException
∂∂ 8
(
∂∂8 9
ex
∂∂9 ;
,
∂∂; <
response
∂∂= E
,
∂∂E F
	processId
∂∂G P
,
∂∂P Q
	stopwatch
∂∂R [
,
∂∂[ \
request
∂∂] d
.
∂∂d e
Url
∂∂e h
,
∂∂h i
request
∂∂j q
.
∂∂q r
Method
∂∂r x
.
∂∂x y
ToString∂∂y Å
(∂∂Å Ç
)∂∂Ç É
)∂∂É Ñ
;∂∂Ñ Ö
}
∑∑ 
catch
∏∏ 
(
∏∏  
UriFormatException
∏∏ %
ex
∏∏& (
)
∏∏( )
{
ππ 
return
∫∫ 
this
∫∫ 
.
∫∫ &
HandleUriFormatException
∫∫ 4
(
∫∫4 5
ex
∫∫5 7
,
∫∫7 8
response
∫∫9 A
,
∫∫A B
	processId
∫∫C L
,
∫∫L M
	stopwatch
∫∫N W
,
∫∫W X
request
∫∫Y `
.
∫∫` a
Url
∫∫a d
,
∫∫d e
request
∫∫f m
.
∫∫m n
Method
∫∫n t
.
∫∫t u
ToString
∫∫u }
(
∫∫} ~
)
∫∫~ 
)∫∫ Ä
;∫∫Ä Å
}
ªª 
catch
ºº 
(
ºº #
TaskCanceledException
ºº (
ex
ºº) +
)
ºº+ ,
{
ΩΩ 
return
ææ 
this
ææ 
.
ææ )
HandleTaskCanceledException
ææ 7
(
ææ7 8
ex
ææ8 :
,
ææ: ;
response
ææ< D
,
ææD E
	processId
ææF O
,
ææO P
	stopwatch
ææQ Z
,
ææZ [
request
ææ\ c
.
ææc d
Url
ææd g
,
ææg h
request
ææi p
.
ææp q
Method
ææq w
.
ææw x
ToStringææx Ä
(ææÄ Å
)ææÅ Ç
)ææÇ É
;ææÉ Ñ
}
øø 
catch
¿¿ 
(
¿¿ "
HttpRequestException
¿¿ '
ex
¿¿( *
)
¿¿* +
{
¡¡ 
return
¬¬ 
this
¬¬ 
.
¬¬ (
HandleHttpRequestException
¬¬ 6
(
¬¬6 7
ex
¬¬7 9
,
¬¬9 :
response
¬¬; C
,
¬¬C D
	processId
¬¬E N
,
¬¬N O
	stopwatch
¬¬P Y
,
¬¬Y Z
request
¬¬[ b
.
¬¬b c
Url
¬¬c f
,
¬¬f g
request
¬¬h o
.
¬¬o p
Method
¬¬p v
.
¬¬v w
ToString
¬¬w 
(¬¬ Ä
)¬¬Ä Å
)¬¬Å Ç
;¬¬Ç É
}
√√ 
}
ƒƒ 	
public
ŒŒ 
async
ŒŒ 
Task
ŒŒ 
<
ŒŒ 
	TResponse
ŒŒ #
?
ŒŒ# $
>
ŒŒ$ %!
GetWithHeadersAsync
ŒŒ& 9
<
ŒŒ9 :
	TResponse
ŒŒ: C
>
ŒŒC D
(
ŒŒD E
Uri
œœ 
url
œœ 
,
œœ 
string
–– 
?
–– 
bearerToken
–– 
=
––  !
null
––" &
,
––& '

Dictionary
—— 
<
—— 
string
—— 
,
—— 
string
—— %
>
——% &
?
——& '
customHeaders
——( 5
=
——6 7
null
——8 <
)
——< =
where
““ 
	TResponse
““ 
:
““ 
class
““ #
{
”” 	#
ArgumentNullException
‘‘ !
.
‘‘! "
ThrowIfNull
‘‘" -
(
‘‘- .
url
‘‘. 1
)
‘‘1 2
;
‘‘2 3
var
÷÷ 

apiRequest
÷÷ 
=
÷÷ 
new
÷÷  

ApiRequest
÷÷! +
{
◊◊ 
Url
ÿÿ 
=
ÿÿ 
url
ÿÿ 
,
ÿÿ 
BearerToken
ŸŸ 
=
ŸŸ 
bearerToken
ŸŸ )
,
ŸŸ) *
Method
⁄⁄ 
=
⁄⁄ 

HttpMethod
⁄⁄ #
.
⁄⁄# $
Get
⁄⁄$ '
,
⁄⁄' (
}
€€ 
;
€€ 
if
›› 
(
›› 
customHeaders
›› 
!=
››  
null
››! %
)
››% &
{
ﬁﬁ 
foreach
ﬂﬂ 
(
ﬂﬂ 
var
ﬂﬂ 
header
ﬂﬂ #
in
ﬂﬂ$ &
customHeaders
ﬂﬂ' 4
)
ﬂﬂ4 5
{
‡‡ 

apiRequest
·· 
.
·· 
Headers
·· &
[
··& '
header
··' -
.
··- .
Key
··. 1
]
··1 2
=
··3 4
header
··5 ;
.
··; <
Value
··< A
;
··A B
}
‚‚ 
}
„„ 
return
ÂÂ 
await
ÂÂ 
this
ÂÂ 
.
ÂÂ '
ExecuteSimpleRequestAsync
ÂÂ 7
<
ÂÂ7 8
	TResponse
ÂÂ8 A
>
ÂÂA B
(
ÂÂB C

apiRequest
ÂÂC M
,
ÂÂM N
$str
ÂÂO T
)
ÂÂT U
.
ÂÂU V
ConfigureAwait
ÂÂV d
(
ÂÂd e
false
ÂÂe j
)
ÂÂj k
;
ÂÂk l
}
ÊÊ 	
public
ÚÚ 
async
ÚÚ 
Task
ÚÚ 
<
ÚÚ 
	TResponse
ÚÚ #
?
ÚÚ# $
>
ÚÚ$ %"
PostWithHeadersAsync
ÚÚ& :
<
ÚÚ: ;
TRequest
ÚÚ; C
,
ÚÚC D
	TResponse
ÚÚE N
>
ÚÚN O
(
ÚÚO P
Uri
ÛÛ 
url
ÛÛ 
,
ÛÛ 
TRequest
ÙÙ 
body
ÙÙ 
,
ÙÙ 
string
ıı 
?
ıı 
bearerToken
ıı 
=
ıı  !
null
ıı" &
,
ıı& '

Dictionary
ˆˆ 
<
ˆˆ 
string
ˆˆ 
,
ˆˆ 
string
ˆˆ %
>
ˆˆ% &
?
ˆˆ& '
customHeaders
ˆˆ( 5
=
ˆˆ6 7
null
ˆˆ8 <
)
ˆˆ< =
where
˜˜ 
TRequest
˜˜ 
:
˜˜ 
class
˜˜ "
where
¯¯ 
	TResponse
¯¯ 
:
¯¯ 
class
¯¯ #
{
˘˘ 	#
ArgumentNullException
˙˙ !
.
˙˙! "
ThrowIfNull
˙˙" -
(
˙˙- .
url
˙˙. 1
)
˙˙1 2
;
˙˙2 3#
ArgumentNullException
˚˚ !
.
˚˚! "
ThrowIfNull
˚˚" -
(
˚˚- .
body
˚˚. 2
)
˚˚2 3
;
˚˚3 4
var
˝˝ 

apiRequest
˝˝ 
=
˝˝ 
new
˝˝  

ApiRequest
˝˝! +
{
˛˛ 
Url
ˇˇ 
=
ˇˇ 
url
ˇˇ 
,
ˇˇ 
BearerToken
ÄÄ 
=
ÄÄ 
bearerToken
ÄÄ )
,
ÄÄ) *
Body
ÅÅ 
=
ÅÅ 
body
ÅÅ 
,
ÅÅ 
Method
ÇÇ 
=
ÇÇ 

HttpMethod
ÇÇ #
.
ÇÇ# $
Post
ÇÇ$ (
,
ÇÇ( )
}
ÉÉ 
;
ÉÉ 
if
ÖÖ 
(
ÖÖ 
customHeaders
ÖÖ 
!=
ÖÖ  
null
ÖÖ! %
)
ÖÖ% &
{
ÜÜ 
foreach
áá 
(
áá 
var
áá 
header
áá #
in
áá$ &
customHeaders
áá' 4
)
áá4 5
{
àà 

apiRequest
ââ 
.
ââ 
Headers
ââ &
[
ââ& '
header
ââ' -
.
ââ- .
Key
ââ. 1
]
ââ1 2
=
ââ3 4
header
ââ5 ;
.
ââ; <
Value
ââ< A
;
ââA B
}
ää 
}
ãã 
return
çç 
await
çç 
this
çç 
.
çç '
ExecuteSimpleRequestAsync
çç 7
<
çç7 8
	TResponse
çç8 A
>
ççA B
(
ççB C

apiRequest
ççC M
,
ççM N
$str
ççO U
)
ççU V
.
ççV W
ConfigureAwait
ççW e
(
ççe f
false
ççf k
)
ççk l
;
ççl m
}
éé 	
public
òò 
async
òò 
Task
òò 
<
òò 
HttpApiResponse
òò )
<
òò) *
	TResponse
òò* 3
>
òò3 4
>
òò4 5(
GetWithCircuitBreakerAsync
òò6 P
<
òòP Q
	TResponse
òòQ Z
>
òòZ [
(
òò[ \
Uri
ôô 
url
ôô 
,
ôô 
string
öö 
?
öö 
bearerToken
öö 
=
öö  !
null
öö" &
,
öö& '

Dictionary
õõ 
<
õõ 
string
õõ 
,
õõ 
string
õõ %
>
õõ% &
?
õõ& '
customHeaders
õõ( 5
=
õõ6 7
null
õõ8 <
)
õõ< =
where
úú 
	TResponse
úú 
:
úú 
class
úú #
{
ùù 	#
ArgumentNullException
ûû !
.
ûû! "
ThrowIfNull
ûû" -
(
ûû- .
url
ûû. 1
)
ûû1 2
;
ûû2 3
var
†† 
(
†† 
	processId
†† 
,
†† 
	stopwatch
†† %
)
††% &
=
††' (
this
††) -
.
††- .
_logger
††. 5
.
††5 6
StartProcess
††6 B
(
††B C
new
††C F
{
°° 
	Operation
¢¢ 
=
¢¢ 
$str
¢¢ 8
,
¢¢8 9
Url
££ 
=
££ 
url
££ 
.
££ 
ToString
££ "
(
££" #
)
££# $
,
££$ %
}
§§ 
)
§§ 
;
§§ 
var
¶¶ 
response
¶¶ 
=
¶¶ 
new
¶¶ 
HttpApiResponse
¶¶ .
<
¶¶. /
	TResponse
¶¶/ 8
>
¶¶8 9
(
¶¶9 :
)
¶¶: ;
;
¶¶; <
try
®® 
{
©© 
this
™™ 
.
™™ 
_logger
™™ 
.
™™ 
Info
™™ !
(
™™! "
$"
™™" $
$str
™™$ I
{
™™I J
url
™™J M
}
™™M N
"
™™N O
)
™™O P
;
™™P Q
var
¨¨ 

apiRequest
¨¨ 
=
¨¨  
new
¨¨! $

ApiRequest
¨¨% /
{
≠≠ 
Url
ÆÆ 
=
ÆÆ 
url
ÆÆ 
,
ÆÆ 
BearerToken
ØØ 
=
ØØ  !
bearerToken
ØØ" -
,
ØØ- .
Method
∞∞ 
=
∞∞ 

HttpMethod
∞∞ '
.
∞∞' (
Get
∞∞( +
,
∞∞+ ,
}
±± 
;
±± 
if
≥≥ 
(
≥≥ 
customHeaders
≥≥ !
!=
≥≥" $
null
≥≥% )
)
≥≥) *
{
¥¥ 
foreach
µµ 
(
µµ 
var
µµ  
header
µµ! '
in
µµ( *
customHeaders
µµ+ 8
)
µµ8 9
{
∂∂ 

apiRequest
∑∑ "
.
∑∑" #
Headers
∑∑# *
[
∑∑* +
header
∑∑+ 1
.
∑∑1 2
Key
∑∑2 5
]
∑∑5 6
=
∑∑7 8
header
∑∑9 ?
.
∑∑? @
Value
∑∑@ E
;
∑∑E F
}
∏∏ 
}
ππ 
var
ææ 
result
ææ 
=
ææ 
await
ææ "
this
ææ# '
.
ææ' (&
_resiliencePolicyService
ææ( @
.
ææ@ A$
CircuitBreakerPipeline
ææA W
.
ææW X
ExecuteAsync
ææX d
(
ææd e
async
øø 
cancellationToken
øø +
=>
øø, .
await
øø/ 4
this
øø5 9
.
øø9 : 
_httpClientService
øø: L
.
øøL M#
SendWithoutRetryAsync
øøM b
<
øøb c
	TResponse
øøc l
>
øøl m
(
øøm n

apiRequest
øøn x
)
øøx y
.
øøy z
ConfigureAwaitøøz à
(øøà â
falseøøâ é
)øøé è
,øøè ê
CancellationToken
¿¿ %
.
¿¿% &
None
¿¿& *
)
¿¿* +
.
¿¿+ ,
ConfigureAwait
¿¿, :
(
¿¿: ;
false
¿¿; @
)
¿¿@ A
;
¿¿A B
response
¬¬ 
.
¬¬ 
Data
¬¬ 
=
¬¬ 
result
¬¬  &
.
¬¬& '
Data
¬¬' +
;
¬¬+ ,
response
√√ 
.
√√ 

StatusCode
√√ #
=
√√$ %
result
√√& ,
.
√√, -

StatusCode
√√- 7
;
√√7 8
response
ƒƒ 
.
ƒƒ 
	IsSuccess
ƒƒ "
=
ƒƒ# $
result
ƒƒ% +
.
ƒƒ+ ,
	IsSuccess
ƒƒ, 5
;
ƒƒ5 6
response
≈≈ 
.
≈≈ 
ResponseTimeMs
≈≈ '
=
≈≈( )
	stopwatch
≈≈* 3
.
≈≈3 4!
ElapsedMilliseconds
≈≈4 G
;
≈≈G H
if
«« 
(
«« 
result
«« 
.
«« 
	IsSuccess
«« $
)
««$ %
{
»» 
this
…… 
.
…… 
_logger
……  
.
……  !
Info
……! %
(
……% &
$"
……& (
$str
……( U
{
……U V
result
……V \
.
……\ ]

StatusCode
……] g
}
……g h
$str
……h p
{
……p q
	stopwatch
……q z
.
……z {"
ElapsedMilliseconds……{ é
}……é è
$str……è ë
"……ë í
)……í ì
;……ì î
}
   
else
ÀÀ 
{
ÃÃ 
this
ÕÕ 
.
ÕÕ 
_logger
ÕÕ  
.
ÕÕ  !
Info
ÕÕ! %
(
ÕÕ% &
$"
ÕÕ& (
$str
ÕÕ( Q
{
ÕÕQ R
result
ÕÕR X
.
ÕÕX Y

StatusCode
ÕÕY c
}
ÕÕc d
"
ÕÕd e
)
ÕÕe f
;
ÕÕf g
response
ŒŒ 
.
ŒŒ 
ErrorMessage
ŒŒ )
=
ŒŒ* +
$"
ŒŒ, .
$str
ŒŒ. I
{
ŒŒI J
result
ŒŒJ P
.
ŒŒP Q

StatusCode
ŒŒQ [
}
ŒŒ[ \
"
ŒŒ\ ]
;
ŒŒ] ^
}
œœ 
this
—— 
.
—— 
_logger
—— 
.
—— 

EndProcess
—— '
(
——' (
	processId
——( 1
,
——1 2
	stopwatch
——3 <
,
——< =
new
——> A
{
——B C
Success
——D K
=
——L M
result
——N T
.
——T U
	IsSuccess
——U ^
,
——^ _
result
——` f
.
——f g

StatusCode
——g q
}
——r s
)
——s t
;
——t u
return
““ 
response
““ 
;
““  
}
”” 
catch
‘‘ 
(
‘‘ "
OutOfMemoryException
‘‘ '
ex
‘‘( *
)
‘‘* +
{
’’ 
return
÷÷ 
this
÷÷ 
.
÷÷ (
HandleOutOfMemoryException
÷÷ 6
(
÷÷6 7
ex
÷÷7 9
,
÷÷9 :
response
÷÷; C
,
÷÷C D
	processId
÷÷E N
,
÷÷N O
	stopwatch
÷÷P Y
,
÷÷Y Z
url
÷÷[ ^
,
÷÷^ _$
_getWithCircuitBreaker
÷÷` v
)
÷÷v w
;
÷÷w x
}
◊◊ 
catch
ÿÿ 
(
ÿÿ $
StackOverflowException
ÿÿ )
ex
ÿÿ* ,
)
ÿÿ, -
{
ŸŸ 
return
⁄⁄ 
this
⁄⁄ 
.
⁄⁄ *
HandleStackOverflowException
⁄⁄ 8
(
⁄⁄8 9
ex
⁄⁄9 ;
,
⁄⁄; <
response
⁄⁄= E
,
⁄⁄E F
	processId
⁄⁄G P
,
⁄⁄P Q
	stopwatch
⁄⁄R [
,
⁄⁄[ \
url
⁄⁄] `
,
⁄⁄` a$
_getWithCircuitBreaker
⁄⁄b x
)
⁄⁄x y
;
⁄⁄y z
}
€€ 
catch
‹‹ 
(
‹‹ 
Polly
‹‹ 
.
‹‹ 
CircuitBreaker
‹‹ '
.
‹‹' ($
BrokenCircuitException
‹‹( >
ex
‹‹? A
)
‹‹A B
{
›› 
return
ﬁﬁ 
this
ﬁﬁ 
.
ﬁﬁ *
HandleBrokenCircuitException
ﬁﬁ 8
(
ﬁﬁ8 9
ex
ﬁﬁ9 ;
,
ﬁﬁ; <
response
ﬁﬁ= E
,
ﬁﬁE F
	processId
ﬁﬁG P
,
ﬁﬁP Q
	stopwatch
ﬁﬁR [
,
ﬁﬁ[ \
url
ﬁﬁ] `
)
ﬁﬁ` a
;
ﬁﬁa b
}
ﬂﬂ 
catch
‡‡ 
(
‡‡ #
TaskCanceledException
‡‡ (
ex
‡‡) +
)
‡‡+ ,
{
·· 
return
‚‚ 
this
‚‚ 
.
‚‚ )
HandleTaskCanceledException
‚‚ 7
(
‚‚7 8
ex
‚‚8 :
,
‚‚: ;
response
‚‚< D
,
‚‚D E
	processId
‚‚F O
,
‚‚O P
	stopwatch
‚‚Q Z
,
‚‚Z [
url
‚‚\ _
,
‚‚_ `$
_getWithCircuitBreaker
‚‚a w
)
‚‚w x
;
‚‚x y
}
„„ 
catch
‰‰ 
(
‰‰ "
HttpRequestException
‰‰ '
ex
‰‰( *
)
‰‰* +
{
ÂÂ 
return
ÊÊ 
this
ÊÊ 
.
ÊÊ (
HandleHttpRequestException
ÊÊ 6
(
ÊÊ6 7
ex
ÊÊ7 9
,
ÊÊ9 :
response
ÊÊ; C
,
ÊÊC D
	processId
ÊÊE N
,
ÊÊN O
	stopwatch
ÊÊP Y
,
ÊÊY Z
url
ÊÊ[ ^
,
ÊÊ^ _$
_getWithCircuitBreaker
ÊÊ` v
)
ÊÊv w
;
ÊÊw x
}
ÁÁ 
}
ËË 	
public
ÙÙ 
async
ÙÙ 
Task
ÙÙ 
<
ÙÙ 
HttpApiResponse
ÙÙ )
<
ÙÙ) *
	TResponse
ÙÙ* 3
>
ÙÙ3 4
>
ÙÙ4 5)
PostWithCircuitBreakerAsync
ÙÙ6 Q
<
ÙÙQ R
TRequest
ÙÙR Z
,
ÙÙZ [
	TResponse
ÙÙ\ e
>
ÙÙe f
(
ÙÙf g
Uri
ıı 
url
ıı 
,
ıı 
TRequest
ˆˆ 
body
ˆˆ 
,
ˆˆ 
string
˜˜ 
?
˜˜ 
bearerToken
˜˜ 
=
˜˜  !
null
˜˜" &
,
˜˜& '

Dictionary
¯¯ 
<
¯¯ 
string
¯¯ 
,
¯¯ 
string
¯¯ %
>
¯¯% &
?
¯¯& '
customHeaders
¯¯( 5
=
¯¯6 7
null
¯¯8 <
)
¯¯< =
where
˘˘ 
TRequest
˘˘ 
:
˘˘ 
class
˘˘ "
where
˙˙ 
	TResponse
˙˙ 
:
˙˙ 
class
˙˙ #
{
˚˚ 	#
ArgumentNullException
¸¸ !
.
¸¸! "
ThrowIfNull
¸¸" -
(
¸¸- .
url
¸¸. 1
)
¸¸1 2
;
¸¸2 3#
ArgumentNullException
˝˝ !
.
˝˝! "
ThrowIfNull
˝˝" -
(
˝˝- .
body
˝˝. 2
)
˝˝2 3
;
˝˝3 4
var
ˇˇ 
(
ˇˇ 
	processId
ˇˇ 
,
ˇˇ 
	stopwatch
ˇˇ %
)
ˇˇ% &
=
ˇˇ' (
this
ˇˇ) -
.
ˇˇ- .
_logger
ˇˇ. 5
.
ˇˇ5 6
StartProcess
ˇˇ6 B
(
ˇˇB C
new
ˇˇC F
{
ÄÄ 
	Operation
ÅÅ 
=
ÅÅ 
$str
ÅÅ 9
,
ÅÅ9 :
Url
ÇÇ 
=
ÇÇ 
url
ÇÇ 
.
ÇÇ 
ToString
ÇÇ "
(
ÇÇ" #
)
ÇÇ# $
,
ÇÇ$ %
HasBody
ÉÉ 
=
ÉÉ 
true
ÉÉ 
,
ÉÉ 
}
ÑÑ 
)
ÑÑ 
;
ÑÑ 
var
ÜÜ 
response
ÜÜ 
=
ÜÜ 
new
ÜÜ 
HttpApiResponse
ÜÜ .
<
ÜÜ. /
	TResponse
ÜÜ/ 8
>
ÜÜ8 9
(
ÜÜ9 :
)
ÜÜ: ;
;
ÜÜ; <
try
àà 
{
ââ 
this
ää 
.
ää 
_logger
ää 
.
ää 
Info
ää !
(
ää! "
$"
ää" $
$str
ää$ J
{
ääJ K
url
ääK N
}
ääN O
"
ääO P
)
ääP Q
;
ääQ R
var
åå 

apiRequest
åå 
=
åå  
new
åå! $

ApiRequest
åå% /
{
çç 
Url
éé 
=
éé 
url
éé 
,
éé 
BearerToken
èè 
=
èè  !
bearerToken
èè" -
,
èè- .
Body
êê 
=
êê 
body
êê 
,
êê  
Method
ëë 
=
ëë 

HttpMethod
ëë '
.
ëë' (
Post
ëë( ,
,
ëë, -
}
íí 
;
íí 
if
îî 
(
îî 
customHeaders
îî !
!=
îî" $
null
îî% )
)
îî) *
{
ïï 
foreach
ññ 
(
ññ 
var
ññ  
header
ññ! '
in
ññ( *
customHeaders
ññ+ 8
)
ññ8 9
{
óó 

apiRequest
òò "
.
òò" #
Headers
òò# *
[
òò* +
header
òò+ 1
.
òò1 2
Key
òò2 5
]
òò5 6
=
òò7 8
header
òò9 ?
.
òò? @
Value
òò@ E
;
òòE F
}
ôô 
}
öö 
var
üü 
result
üü 
=
üü 
await
üü "
this
üü# '
.
üü' (&
_resiliencePolicyService
üü( @
.
üü@ A$
CircuitBreakerPipeline
üüA W
.
üüW X
ExecuteAsync
üüX d
(
üüd e
async
†† 
cancellationToken
†† +
=>
††, .
await
††/ 4
this
††5 9
.
††9 : 
_httpClientService
††: L
.
††L M#
SendWithoutRetryAsync
††M b
<
††b c
	TResponse
††c l
>
††l m
(
††m n

apiRequest
††n x
)
††x y
.
††y z
ConfigureAwait††z à
(††à â
false††â é
)††é è
,††è ê
CancellationToken
°° %
.
°°% &
None
°°& *
)
°°* +
.
°°+ ,
ConfigureAwait
°°, :
(
°°: ;
false
°°; @
)
°°@ A
;
°°A B
response
££ 
.
££ 
Data
££ 
=
££ 
result
££  &
.
££& '
Data
££' +
;
££+ ,
response
§§ 
.
§§ 

StatusCode
§§ #
=
§§$ %
result
§§& ,
.
§§, -

StatusCode
§§- 7
;
§§7 8
response
•• 
.
•• 
	IsSuccess
•• "
=
••# $
result
••% +
.
••+ ,
	IsSuccess
••, 5
;
••5 6
response
¶¶ 
.
¶¶ 
ResponseTimeMs
¶¶ '
=
¶¶( )
	stopwatch
¶¶* 3
.
¶¶3 4!
ElapsedMilliseconds
¶¶4 G
;
¶¶G H
if
®® 
(
®® 
result
®® 
.
®® 
	IsSuccess
®® $
)
®®$ %
{
©© 
this
™™ 
.
™™ 
_logger
™™  
.
™™  !
Info
™™! %
(
™™% &
$"
™™& (
$str
™™( V
{
™™V W
result
™™W ]
.
™™] ^

StatusCode
™™^ h
}
™™h i
$str
™™i q
{
™™q r
	stopwatch
™™r {
.
™™{ |"
ElapsedMilliseconds™™| è
}™™è ê
$str™™ê í
"™™í ì
)™™ì î
;™™î ï
}
´´ 
else
¨¨ 
{
≠≠ 
this
ÆÆ 
.
ÆÆ 
_logger
ÆÆ  
.
ÆÆ  !
Info
ÆÆ! %
(
ÆÆ% &
$"
ÆÆ& (
$str
ÆÆ( R
{
ÆÆR S
result
ÆÆS Y
.
ÆÆY Z

StatusCode
ÆÆZ d
}
ÆÆd e
"
ÆÆe f
)
ÆÆf g
;
ÆÆg h
response
ØØ 
.
ØØ 
ErrorMessage
ØØ )
=
ØØ* +
$"
ØØ, .
$str
ØØ. I
{
ØØI J
result
ØØJ P
.
ØØP Q

StatusCode
ØØQ [
}
ØØ[ \
"
ØØ\ ]
;
ØØ] ^
}
∞∞ 
this
≤≤ 
.
≤≤ 
_logger
≤≤ 
.
≤≤ 

EndProcess
≤≤ '
(
≤≤' (
	processId
≤≤( 1
,
≤≤1 2
	stopwatch
≤≤3 <
,
≤≤< =
new
≤≤> A
{
≤≤B C
Success
≤≤D K
=
≤≤L M
result
≤≤N T
.
≤≤T U
	IsSuccess
≤≤U ^
,
≤≤^ _
result
≤≤` f
.
≤≤f g

StatusCode
≤≤g q
}
≤≤r s
)
≤≤s t
;
≤≤t u
return
≥≥ 
response
≥≥ 
;
≥≥  
}
¥¥ 
catch
µµ 
(
µµ "
OutOfMemoryException
µµ '
ex
µµ( *
)
µµ* +
{
∂∂ 
return
∑∑ 
this
∑∑ 
.
∑∑ (
HandleOutOfMemoryException
∑∑ 6
(
∑∑6 7
ex
∑∑7 9
,
∑∑9 :
response
∑∑; C
,
∑∑C D
	processId
∑∑E N
,
∑∑N O
	stopwatch
∑∑P Y
,
∑∑Y Z
url
∑∑[ ^
,
∑∑^ _$
_getWithCircuitBreaker
∑∑` v
)
∑∑v w
;
∑∑w x
}
∏∏ 
catch
ππ 
(
ππ $
StackOverflowException
ππ )
ex
ππ* ,
)
ππ, -
{
∫∫ 
return
ªª 
this
ªª 
.
ªª *
HandleStackOverflowException
ªª 8
(
ªª8 9
ex
ªª9 ;
,
ªª; <
response
ªª= E
,
ªªE F
	processId
ªªG P
,
ªªP Q
	stopwatch
ªªR [
,
ªª[ \
url
ªª] `
,
ªª` a$
_getWithCircuitBreaker
ªªb x
)
ªªx y
;
ªªy z
}
ºº 
catch
ΩΩ 
(
ΩΩ 
Polly
ΩΩ 
.
ΩΩ 
CircuitBreaker
ΩΩ '
.
ΩΩ' ($
BrokenCircuitException
ΩΩ( >
ex
ΩΩ? A
)
ΩΩA B
{
ææ 
return
øø 
this
øø 
.
øø *
HandleBrokenCircuitException
øø 8
(
øø8 9
ex
øø9 ;
,
øø; <
response
øø= E
,
øøE F
	processId
øøG P
,
øøP Q
	stopwatch
øøR [
,
øø[ \
url
øø] `
)
øø` a
;
øøa b
}
¿¿ 
catch
¡¡ 
(
¡¡ #
TaskCanceledException
¡¡ (
ex
¡¡) +
)
¡¡+ ,
{
¬¬ 
return
√√ 
this
√√ 
.
√√ )
HandleTaskCanceledException
√√ 7
(
√√7 8
ex
√√8 :
,
√√: ;
response
√√< D
,
√√D E
	processId
√√F O
,
√√O P
	stopwatch
√√Q Z
,
√√Z [
url
√√\ _
,
√√_ `%
_postWithCircuitBreaker
√√a x
)
√√x y
;
√√y z
}
ƒƒ 
catch
≈≈ 
(
≈≈ "
HttpRequestException
≈≈ '
ex
≈≈( *
)
≈≈* +
{
∆∆ 
return
«« 
this
«« 
.
«« (
HandleHttpRequestException
«« 6
(
««6 7
ex
««7 9
,
««9 :
response
««; C
,
««C D
	processId
««E N
,
««N O
	stopwatch
««P Y
,
««Y Z
url
««[ ^
,
««^ _%
_postWithCircuitBreaker
««` w
)
««w x
;
««x y
}
»» 
}
…… 	
private
ÀÀ 
static
ÀÀ 

ApiRequest
ÀÀ !
CreateApiRequest
ÀÀ" 2
(
ÀÀ2 3
Uri
ÀÀ3 6
url
ÀÀ7 :
,
ÀÀ: ;
string
ÀÀ< B
?
ÀÀB C
bearerToken
ÀÀD O
,
ÀÀO P
object
ÀÀQ W
?
ÀÀW X
body
ÀÀY ]
,
ÀÀ] ^

HttpMethod
ÀÀ_ i
method
ÀÀj p
)
ÀÀp q
{
ÃÃ 	
return
ÕÕ 
new
ÕÕ 

ApiRequest
ÕÕ !
{
ŒŒ 
Url
œœ 
=
œœ 
url
œœ 
,
œœ 
BearerToken
–– 
=
–– 
bearerToken
–– )
,
––) *
Body
—— 
=
—— 
body
—— 
,
—— 
Method
““ 
=
““ 
method
““ 
,
““  
}
”” 
;
”” 
}
‘‘ 	
private
÷÷ 
static
÷÷ 
void
÷÷ 
PopulateResponse
÷÷ ,
<
÷÷, -
	TResponse
÷÷- 6
>
÷÷6 7
(
÷÷7 8
HttpApiResponse
◊◊ 
<
◊◊ 
	TResponse
◊◊ %
>
◊◊% &
response
◊◊' /
,
◊◊/ 0 
ApiSeguimientoCADS
ÿÿ 
.
ÿÿ 
Api
ÿÿ "
.
ÿÿ" #
Services
ÿÿ# +
.
ÿÿ+ ,
Models
ÿÿ, 2
.
ÿÿ2 3
ApiResponse
ÿÿ3 >
<
ÿÿ> ?
	TResponse
ÿÿ? H
>
ÿÿH I
result
ÿÿJ P
,
ÿÿP Q
System
ŸŸ 
.
ŸŸ 
Diagnostics
ŸŸ 
.
ŸŸ 
	Stopwatch
ŸŸ (
	stopwatch
ŸŸ) 2
)
ŸŸ2 3
where
⁄⁄ 
	TResponse
⁄⁄ 
:
⁄⁄ 
class
⁄⁄ #
{
€€ 	
response
‹‹ 
.
‹‹ 
Data
‹‹ 
=
‹‹ 
result
‹‹ "
.
‹‹" #
Data
‹‹# '
;
‹‹' (
response
›› 
.
›› 

StatusCode
›› 
=
››  !
result
››" (
.
››( )

StatusCode
››) 3
;
››3 4
response
ﬁﬁ 
.
ﬁﬁ 
	IsSuccess
ﬁﬁ 
=
ﬁﬁ  
result
ﬁﬁ! '
.
ﬁﬁ' (
	IsSuccess
ﬁﬁ( 1
;
ﬁﬁ1 2
response
ﬂﬂ 
.
ﬂﬂ 
ResponseTimeMs
ﬂﬂ #
=
ﬂﬂ$ %
	stopwatch
ﬂﬂ& /
.
ﬂﬂ/ 0!
ElapsedMilliseconds
ﬂﬂ0 C
;
ﬂﬂC D
if
·· 
(
·· 
!
·· 
result
·· 
.
·· 
	IsSuccess
·· !
)
··! "
{
‚‚ 
response
„„ 
.
„„ 
ErrorMessage
„„ %
=
„„& '
$"
„„( *
$str
„„* E
{
„„E F
result
„„F L
.
„„L M

StatusCode
„„M W
}
„„W X
"
„„X Y
;
„„Y Z
}
‰‰ 
}
ÂÂ 	
private
ÁÁ 
async
ÁÁ 
Task
ÁÁ 
<
ÁÁ 
	TResponse
ÁÁ $
?
ÁÁ$ %
>
ÁÁ% &'
ExecuteSimpleRequestAsync
ÁÁ' @
<
ÁÁ@ A
	TResponse
ÁÁA J
>
ÁÁJ K
(
ÁÁK L

ApiRequest
ÁÁL V

apiRequest
ÁÁW a
,
ÁÁa b
string
ÁÁc i

methodName
ÁÁj t
)
ÁÁt u
where
ËË 
	TResponse
ËË 
:
ËË 
class
ËË #
{
ÈÈ 	
var
ÍÍ 
(
ÍÍ 
	processId
ÍÍ 
,
ÍÍ 
	stopwatch
ÍÍ %
)
ÍÍ% &
=
ÍÍ' (
this
ÍÍ) -
.
ÍÍ- .
_logger
ÍÍ. 5
.
ÍÍ5 6
StartProcess
ÍÍ6 B
(
ÍÍB C
new
ÍÍC F
{
ÎÎ 
	Operation
ÏÏ 
=
ÏÏ 
$"
ÏÏ 
{
ÏÏ 

methodName
ÏÏ )
}
ÏÏ) *
$str
ÏÏ* /
"
ÏÏ/ 0
,
ÏÏ0 1
Url
ÌÌ 
=
ÌÌ 

apiRequest
ÌÌ  
.
ÌÌ  !
Url
ÌÌ! $
.
ÌÌ$ %
ToString
ÌÌ% -
(
ÌÌ- .
)
ÌÌ. /
,
ÌÌ/ 0
HasBody
ÓÓ 
=
ÓÓ 

apiRequest
ÓÓ $
.
ÓÓ$ %
Body
ÓÓ% )
!=
ÓÓ* ,
null
ÓÓ- 1
,
ÓÓ1 2
}
ÔÔ 
)
ÔÔ 
;
ÔÔ 
try
ÒÒ 
{
ÚÚ 
this
ÛÛ 
.
ÛÛ 
_logger
ÛÛ 
.
ÛÛ 
Info
ÛÛ !
(
ÛÛ! "
$"
ÛÛ" $
{
ÛÛ$ %

methodName
ÛÛ% /
}
ÛÛ/ 0
$str
ÛÛ0 =
{
ÛÛ= >

apiRequest
ÛÛ> H
.
ÛÛH I
Url
ÛÛI L
}
ÛÛL M
"
ÛÛM N
)
ÛÛN O
;
ÛÛO P
var
ıı 
result
ıı 
=
ıı 
await
ıı "
this
ıı# '
.
ıı' ( 
_httpClientService
ıı( :
.
ıı: ;
	SendAsync
ıı; D
<
ııD E
	TResponse
ııE N
>
ııN O
(
ııO P

apiRequest
ııP Z
)
ııZ [
.
ıı[ \
ConfigureAwait
ıı\ j
(
ııj k
false
ıık p
)
ııp q
;
ııq r
if
˜˜ 
(
˜˜ 
result
˜˜ 
.
˜˜ 
	IsSuccess
˜˜ $
)
˜˜$ %
{
¯¯ 
this
˘˘ 
.
˘˘ 
_logger
˘˘  
.
˘˘  !
Info
˘˘! %
(
˘˘% &
$"
˘˘& (
{
˘˘( )

methodName
˘˘) 3
}
˘˘3 4
$str
˘˘4 Q
{
˘˘Q R
result
˘˘R X
.
˘˘X Y

StatusCode
˘˘Y c
}
˘˘c d
"
˘˘d e
)
˘˘e f
;
˘˘f g
this
˙˙ 
.
˙˙ 
_logger
˙˙  
.
˙˙  !

EndProcess
˙˙! +
(
˙˙+ ,
	processId
˙˙, 5
,
˙˙5 6
	stopwatch
˙˙7 @
,
˙˙@ A
new
˙˙B E
{
˙˙F G
Success
˙˙H O
=
˙˙P Q
true
˙˙R V
,
˙˙V W
result
˙˙X ^
.
˙˙^ _

StatusCode
˙˙_ i
}
˙˙j k
)
˙˙k l
;
˙˙l m
return
˚˚ 
result
˚˚ !
.
˚˚! "
Data
˚˚" &
;
˚˚& '
}
¸¸ 
this
˛˛ 
.
˛˛ 
_logger
˛˛ 
.
˛˛ 
Info
˛˛ !
(
˛˛! "
$"
˛˛" $
{
˛˛$ %

methodName
˛˛% /
}
˛˛/ 0
$str
˛˛0 I
{
˛˛I J
result
˛˛J P
.
˛˛P Q

StatusCode
˛˛Q [
}
˛˛[ \
"
˛˛\ ]
)
˛˛] ^
;
˛˛^ _
this
ˇˇ 
.
ˇˇ 
_logger
ˇˇ 
.
ˇˇ 

EndProcess
ˇˇ '
(
ˇˇ' (
	processId
ˇˇ( 1
,
ˇˇ1 2
	stopwatch
ˇˇ3 <
,
ˇˇ< =
new
ˇˇ> A
{
ˇˇB C
Success
ˇˇD K
=
ˇˇL M
false
ˇˇN S
,
ˇˇS T
result
ˇˇU [
.
ˇˇ[ \

StatusCode
ˇˇ\ f
}
ˇˇg h
)
ˇˇh i
;
ˇˇi j
return
ÄÄ 
null
ÄÄ 
;
ÄÄ 
}
ÅÅ 
catch
ÇÇ 
(
ÇÇ "
OutOfMemoryException
ÇÇ '
ex
ÇÇ( *
)
ÇÇ* +
{
ÉÉ 
this
ÑÑ 
.
ÑÑ 
_logger
ÑÑ 
.
ÑÑ 
LogError
ÑÑ %
(
ÑÑ% &
ex
ÑÑ& (
,
ÑÑ( )
$"
ÑÑ* ,
$str
ÑÑ, M
{
ÑÑM N

methodName
ÑÑN X
}
ÑÑX Y
$str
ÑÑY ]
{
ÑÑ] ^

apiRequest
ÑÑ^ h
.
ÑÑh i
Url
ÑÑi l
}
ÑÑl m
"
ÑÑm n
)
ÑÑn o
;
ÑÑo p
this
ÖÖ 
.
ÖÖ 
_logger
ÖÖ 
.
ÖÖ 

EndProcess
ÖÖ '
(
ÖÖ' (
	processId
ÖÖ( 1
,
ÖÖ1 2
	stopwatch
ÖÖ3 <
,
ÖÖ< =
new
ÖÖ> A
{
ÖÖB C
Success
ÖÖD K
=
ÖÖL M
false
ÖÖN S
,
ÖÖS T
Error
ÖÖU Z
=
ÖÖ[ \
$str
ÖÖ] s
}
ÖÖt u
)
ÖÖu v
;
ÖÖv w
throw
ÜÜ 
new
ÜÜ '
InvalidOperationException
ÜÜ 3
(
ÜÜ3 4
$strÜÜ4 Å
,ÜÜÅ Ç
exÜÜÉ Ö
)ÜÜÖ Ü
;ÜÜÜ á
}
áá 
catch
àà 
(
àà $
StackOverflowException
àà )
ex
àà* ,
)
àà, -
{
ââ 
this
ää 
.
ää 
_logger
ää 
.
ää 
LogError
ää %
(
ää% &
ex
ää& (
,
ää( )
$"
ää* ,
$str
ää, \
{
ää\ ]

methodName
ää] g
}
ääg h
$str
ääh l
{
ääl m

apiRequest
ääm w
.
ääw x
Url
ääx {
}
ää{ |
"
ää| }
)
ää} ~
;
ää~ 
this
ãã 
.
ãã 
_logger
ãã 
.
ãã 

EndProcess
ãã '
(
ãã' (
	processId
ãã( 1
,
ãã1 2
	stopwatch
ãã3 <
,
ãã< =
new
ãã> A
{
ããB C
Success
ããD K
=
ããL M
false
ããN S
,
ããS T
Error
ããU Z
=
ãã[ \
$str
ãã] u
}
ããv w
)
ããw x
;
ããx y
throw
åå 
new
åå '
InvalidOperationException
åå 3
(
åå3 4
$stråå4 É
,ååÉ Ñ
exååÖ á
)ååá à
;ååà â
}
çç 
catch
éé 
(
éé  
UriFormatException
éé %
ex
éé& (
)
éé( )
{
èè 
this
êê 
.
êê 
_logger
êê 
.
êê 
LogError
êê %
(
êê% &
ex
êê& (
,
êê( )
$"
êê* ,
$str
êê, G
{
êêG H

apiRequest
êêH R
.
êêR S
Url
êêS V
}
êêV W
"
êêW X
)
êêX Y
;
êêY Z
this
ëë 
.
ëë 
_logger
ëë 
.
ëë 

EndProcess
ëë '
(
ëë' (
	processId
ëë( 1
,
ëë1 2
	stopwatch
ëë3 <
,
ëë< =
new
ëë> A
{
ëëB C
Success
ëëD K
=
ëëL M
false
ëëN S
,
ëëS T
Error
ëëU Z
=
ëë[ \
$str
ëë] q
}
ëër s
)
ëës t
;
ëët u
throw
íí 
new
íí '
InvalidOperationException
íí 3
(
íí3 4
$"
íí4 6
$str
íí6 _
{
íí_ `

methodName
íí` j
}
ííj k
"
íík l
,
ííl m
ex
íín p
)
ííp q
;
ííq r
}
ìì 
catch
îî 
(
îî #
TaskCanceledException
îî (
ex
îî) +
)
îî+ ,
{
ïï 
this
ññ 
.
ññ 
_logger
ññ 
.
ññ 
LogError
ññ %
(
ññ% &
ex
ññ& (
,
ññ( )
$"
ññ* ,
$str
ññ, @
{
ññ@ A

methodName
ññA K
}
ññK L
$str
ññL P
{
ññP Q

apiRequest
ññQ [
.
ññ[ \
Url
ññ\ _
}
ññ_ `
"
ññ` a
)
ñña b
;
ññb c
this
óó 
.
óó 
_logger
óó 
.
óó 

EndProcess
óó '
(
óó' (
	processId
óó( 1
,
óó1 2
	stopwatch
óó3 <
,
óó< =
new
óó> A
{
óóB C
Success
óóD K
=
óóL M
false
óóN S
,
óóS T
Error
óóU Z
=
óó[ \
$str
óó] t
}
óóu v
)
óóv w
;
óów x
throw
òò 
;
òò 
}
ôô 
catch
öö 
(
öö "
HttpRequestException
öö '
ex
öö( *
)
öö* +
{
õõ 
this
úú 
.
úú 
_logger
úú 
.
úú 
LogError
úú %
(
úú% &
ex
úú& (
,
úú( )
$"
úú* ,
$str
úú, >
{
úú> ?

methodName
úú? I
}
úúI J
$str
úúJ N
{
úúN O

apiRequest
úúO Y
.
úúY Z
Url
úúZ ]
}
úú] ^
"
úú^ _
)
úú_ `
;
úú` a
this
ùù 
.
ùù 
_logger
ùù 
.
ùù 

EndProcess
ùù '
(
ùù' (
	processId
ùù( 1
,
ùù1 2
	stopwatch
ùù3 <
,
ùù< =
new
ùù> A
{
ùùB C
Success
ùùD K
=
ùùL M
false
ùùN S
,
ùùS T
Error
ùùU Z
=
ùù[ \
$str
ùù] s
}
ùùt u
)
ùùu v
;
ùùv w
throw
ûû 
;
ûû 
}
üü 
catch
†† 
(
†† 
	Exception
†† 
ex
†† 
)
††  
{
°° 
this
¢¢ 
.
¢¢ 
_logger
¢¢ 
.
¢¢ 
LogError
¢¢ %
(
¢¢% &
ex
¢¢& (
,
¢¢( )
$"
¢¢* ,
$str
¢¢, I
{
¢¢I J

methodName
¢¢J T
}
¢¢T U
$str
¢¢U Y
{
¢¢Y Z

apiRequest
¢¢Z d
.
¢¢d e
Url
¢¢e h
}
¢¢h i
"
¢¢i j
)
¢¢j k
;
¢¢k l
this
££ 
.
££ 
_logger
££ 
.
££ 

EndProcess
££ '
(
££' (
	processId
££( 1
,
££1 2
	stopwatch
££3 <
,
££< =
new
££> A
{
££B C
Success
££D K
=
££L M
false
££N S
,
££S T
Error
££U Z
=
££[ \
$str
££] r
}
££s t
)
££t u
;
££u v
throw
§§ 
;
§§ 
}
•• 
}
¶¶ 	
private
®® 
void
®® 
LogRequestResult
®® %
<
®®% &
	TResponse
®®& /
>
®®/ 0
(
®®0 1
string
©© 

methodName
©© 
,
©© 
ApiResponse
™™ 
<
™™ 
	TResponse
™™ !
>
™™! "
result
™™# )
,
™™) *
System
´´ 
.
´´ 
Diagnostics
´´ 
.
´´ 
	Stopwatch
´´ (
	stopwatch
´´) 2
)
´´2 3
where
¨¨ 
	TResponse
¨¨ 
:
¨¨ 
class
¨¨ #
{
≠≠ 	
if
ÆÆ 
(
ÆÆ 
result
ÆÆ 
.
ÆÆ 
	IsSuccess
ÆÆ  
)
ÆÆ  !
{
ØØ 
this
∞∞ 
.
∞∞ 
_logger
∞∞ 
.
∞∞ 
Info
∞∞ !
(
∞∞! "
$"
∞∞" $
{
∞∞$ %

methodName
∞∞% /
}
∞∞/ 0
$str
∞∞0 M
{
∞∞M N
result
∞∞N T
.
∞∞T U

StatusCode
∞∞U _
}
∞∞_ `
$str
∞∞` h
{
∞∞h i
	stopwatch
∞∞i r
.
∞∞r s"
ElapsedMilliseconds∞∞s Ü
}∞∞Ü á
$str∞∞á â
"∞∞â ä
)∞∞ä ã
;∞∞ã å
}
±± 
else
≤≤ 
{
≥≥ 
this
¥¥ 
.
¥¥ 
_logger
¥¥ 
.
¥¥ 
Info
¥¥ !
(
¥¥! "
$"
¥¥" $
{
¥¥$ %

methodName
¥¥% /
}
¥¥/ 0
$str
¥¥0 I
{
¥¥I J
result
¥¥J P
.
¥¥P Q

StatusCode
¥¥Q [
}
¥¥[ \
"
¥¥\ ]
)
¥¥] ^
;
¥¥^ _
}
µµ 
}
∂∂ 	
private
∏∏ 
HttpApiResponse
∏∏ 
<
∏∏  
	TResponse
∏∏  )
>
∏∏) *(
HandleOutOfMemoryException
∏∏+ E
<
∏∏E F
	TResponse
∏∏F O
>
∏∏O P
(
∏∏P Q"
OutOfMemoryException
ππ !
ex
ππ" $
,
ππ$ %
HttpApiResponse
∫∫ 
<
∫∫ 
	TResponse
∫∫ &
>
∫∫& '
response
∫∫( 0
,
∫∫0 1
Guid
ªª 
	processId
ªª 
,
ªª 
System
ºº 
.
ºº 
Diagnostics
ºº 
.
ºº  
	Stopwatch
ºº  )
	stopwatch
ºº* 3
,
ºº3 4
Uri
ΩΩ 
url
ΩΩ 
,
ΩΩ 
string
ææ 

methodName
ææ 
)
ææ 
where
øø 
	TResponse
øø 
:
øø 
class
øø $
{
¿¿ 	
this
¡¡ 
.
¡¡ 
_logger
¡¡ 
.
¡¡ 
LogError
¡¡ !
(
¡¡! "
ex
¡¡" $
,
¡¡$ %
$"
¡¡& (
$str
¡¡( D
{
¡¡D E

methodName
¡¡E O
}
¡¡O P
$str
¡¡P T
{
¡¡T U
url
¡¡U X
}
¡¡X Y
"
¡¡Y Z
)
¡¡Z [
;
¡¡[ \
this
¬¬ 
.
¬¬ 
_logger
¬¬ 
.
¬¬ 

EndProcess
¬¬ #
(
¬¬# $
	processId
¬¬$ -
,
¬¬- .
	stopwatch
¬¬/ 8
,
¬¬8 9
new
¬¬: =
{
¬¬> ?
Success
¬¬@ G
=
¬¬H I
false
¬¬J O
,
¬¬O P
Error
¬¬Q V
=
¬¬W X
$str
¬¬Y o
}
¬¬p q
)
¬¬q r
;
¬¬r s
response
ƒƒ 
.
ƒƒ 
	IsSuccess
ƒƒ 
=
ƒƒ  
false
ƒƒ! &
;
ƒƒ& '
response
≈≈ 
.
≈≈ 

StatusCode
≈≈ 
=
≈≈  !
HttpStatusCode
≈≈" 0
.
≈≈0 1!
InternalServerError
≈≈1 D
;
≈≈D E
response
∆∆ 
.
∆∆ 
ErrorMessage
∆∆ !
=
∆∆" #
$str
∆∆$ f
;
∆∆f g
response
«« 
.
«« 
ResponseTimeMs
«« #
=
««$ %
	stopwatch
««& /
.
««/ 0!
ElapsedMilliseconds
««0 C
;
««C D
return
»» 
response
»» 
;
»» 
}
…… 	
private
ÀÀ 
HttpApiResponse
ÀÀ 
<
ÀÀ  
	TResponse
ÀÀ  )
>
ÀÀ) **
HandleStackOverflowException
ÀÀ+ G
<
ÀÀG H
	TResponse
ÀÀH Q
>
ÀÀQ R
(
ÀÀR S$
StackOverflowException
ÃÃ "
ex
ÃÃ# %
,
ÃÃ% &
HttpApiResponse
ÕÕ 
<
ÕÕ 
	TResponse
ÕÕ %
>
ÕÕ% &
response
ÕÕ' /
,
ÕÕ/ 0
Guid
ŒŒ 
	processId
ŒŒ 
,
ŒŒ 
System
œœ 
.
œœ 
Diagnostics
œœ 
.
œœ 
	Stopwatch
œœ (
	stopwatch
œœ) 2
,
œœ2 3
Uri
–– 
url
–– 
,
–– 
string
—— 

methodName
—— 
)
—— 
where
““ 
	TResponse
““ 
:
““ 
class
““ #
{
”” 	
this
‘‘ 
.
‘‘ 
_logger
‘‘ 
.
‘‘ 
LogError
‘‘ !
(
‘‘! "
ex
‘‘" $
,
‘‘$ %
$"
‘‘& (
$str
‘‘( S
{
‘‘S T

methodName
‘‘T ^
}
‘‘^ _
$str
‘‘_ c
{
‘‘c d
url
‘‘d g
}
‘‘g h
"
‘‘h i
)
‘‘i j
;
‘‘j k
this
’’ 
.
’’ 
_logger
’’ 
.
’’ 

EndProcess
’’ #
(
’’# $
	processId
’’$ -
,
’’- .
	stopwatch
’’/ 8
,
’’8 9
new
’’: =
{
’’> ?
Success
’’@ G
=
’’H I
false
’’J O
,
’’O P
Error
’’Q V
=
’’W X
$str
’’Y q
}
’’r s
)
’’s t
;
’’t u
response
◊◊ 
.
◊◊ 
	IsSuccess
◊◊ 
=
◊◊  
false
◊◊! &
;
◊◊& '
response
ÿÿ 
.
ÿÿ 

StatusCode
ÿÿ 
=
ÿÿ  !
HttpStatusCode
ÿÿ" 0
.
ÿÿ0 1!
InternalServerError
ÿÿ1 D
;
ÿÿD E
response
ŸŸ 
.
ŸŸ 
ErrorMessage
ŸŸ !
=
ŸŸ" #
$str
ŸŸ$ k
;
ŸŸk l
response
⁄⁄ 
.
⁄⁄ 
ResponseTimeMs
⁄⁄ #
=
⁄⁄$ %
	stopwatch
⁄⁄& /
.
⁄⁄/ 0!
ElapsedMilliseconds
⁄⁄0 C
;
⁄⁄C D
return
€€ 
response
€€ 
;
€€ 
}
‹‹ 	
private
ﬁﬁ 
HttpApiResponse
ﬁﬁ 
<
ﬁﬁ  
	TResponse
ﬁﬁ  )
>
ﬁﬁ) *&
HandleUriFormatException
ﬁﬁ+ C
<
ﬁﬁC D
	TResponse
ﬁﬁD M
>
ﬁﬁM N
(
ﬁﬁN O 
UriFormatException
ﬂﬂ 
ex
ﬂﬂ !
,
ﬂﬂ! "
HttpApiResponse
‡‡ 
<
‡‡ 
	TResponse
‡‡ %
>
‡‡% &
response
‡‡' /
,
‡‡/ 0
Guid
·· 
	processId
·· 
,
·· 
System
‚‚ 
.
‚‚ 
Diagnostics
‚‚ 
.
‚‚ 
	Stopwatch
‚‚ (
	stopwatch
‚‚) 2
,
‚‚2 3
Uri
„„ 
url
„„ 
,
„„ 
string
‰‰ 

methodName
‰‰ 
)
‰‰ 
where
ÂÂ 
	TResponse
ÂÂ 
:
ÂÂ 
class
ÂÂ #
{
ÊÊ 	
this
ÁÁ 
.
ÁÁ 
_logger
ÁÁ 
.
ÁÁ 
LogError
ÁÁ !
(
ÁÁ! "
ex
ÁÁ" $
,
ÁÁ$ %
$"
ÁÁ& (
$str
ÁÁ( C
{
ÁÁC D
url
ÁÁD G
}
ÁÁG H
$str
ÁÁH K
{
ÁÁK L

methodName
ÁÁL V
}
ÁÁV W
"
ÁÁW X
)
ÁÁX Y
;
ÁÁY Z
this
ËË 
.
ËË 
_logger
ËË 
.
ËË 

EndProcess
ËË #
(
ËË# $
	processId
ËË$ -
,
ËË- .
	stopwatch
ËË/ 8
,
ËË8 9
new
ËË: =
{
ËË> ?
Success
ËË@ G
=
ËËH I
false
ËËJ O
,
ËËO P
Error
ËËQ V
=
ËËW X
$str
ËËY m
}
ËËn o
)
ËËo p
;
ËËp q
response
ÍÍ 
.
ÍÍ 
	IsSuccess
ÍÍ 
=
ÍÍ  
false
ÍÍ! &
;
ÍÍ& '
response
ÎÎ 
.
ÎÎ 

StatusCode
ÎÎ 
=
ÎÎ  !
HttpStatusCode
ÎÎ" 0
.
ÎÎ0 1

BadRequest
ÎÎ1 ;
;
ÎÎ; <
response
ÏÏ 
.
ÏÏ 
ErrorMessage
ÏÏ !
=
ÏÏ" #
$"
ÏÏ$ &
$str
ÏÏ& 4
{
ÏÏ4 5
ex
ÏÏ5 7
.
ÏÏ7 8
Message
ÏÏ8 ?
}
ÏÏ? @
"
ÏÏ@ A
;
ÏÏA B
response
ÌÌ 
.
ÌÌ 
ResponseTimeMs
ÌÌ #
=
ÌÌ$ %
	stopwatch
ÌÌ& /
.
ÌÌ/ 0!
ElapsedMilliseconds
ÌÌ0 C
;
ÌÌC D
return
ÓÓ 
response
ÓÓ 
;
ÓÓ 
}
ÔÔ 	
private
ÒÒ 
HttpApiResponse
ÒÒ 
<
ÒÒ  
	TResponse
ÒÒ  )
>
ÒÒ) *)
HandleTaskCanceledException
ÒÒ+ F
<
ÒÒF G
	TResponse
ÒÒG P
>
ÒÒP Q
(
ÒÒQ R#
TaskCanceledException
ÚÚ !
ex
ÚÚ" $
,
ÚÚ$ %
HttpApiResponse
ÛÛ 
<
ÛÛ 
	TResponse
ÛÛ %
>
ÛÛ% &
response
ÛÛ' /
,
ÛÛ/ 0
Guid
ÙÙ 
	processId
ÙÙ 
,
ÙÙ 
System
ıı 
.
ıı 
Diagnostics
ıı 
.
ıı 
	Stopwatch
ıı (
	stopwatch
ıı) 2
,
ıı2 3
Uri
ˆˆ 
url
ˆˆ 
,
ˆˆ 
string
˜˜ 

methodName
˜˜ 
)
˜˜ 
where
¯¯ 
	TResponse
¯¯ 
:
¯¯ 
class
¯¯ #
{
˘˘ 	
this
˙˙ 
.
˙˙ 
_logger
˙˙ 
.
˙˙ 
LogError
˙˙ !
(
˙˙! "
ex
˙˙" $
,
˙˙$ %
$"
˙˙& (
$str
˙˙( <
{
˙˙< =

methodName
˙˙= G
}
˙˙G H
$str
˙˙H L
{
˙˙L M
url
˙˙M P
}
˙˙P Q
"
˙˙Q R
)
˙˙R S
;
˙˙S T
this
˚˚ 
.
˚˚ 
_logger
˚˚ 
.
˚˚ 

EndProcess
˚˚ #
(
˚˚# $
	processId
˚˚$ -
,
˚˚- .
	stopwatch
˚˚/ 8
,
˚˚8 9
new
˚˚: =
{
˚˚> ?
Success
˚˚@ G
=
˚˚H I
false
˚˚J O
,
˚˚O P
Error
˚˚Q V
=
˚˚W X
$str
˚˚Y p
}
˚˚q r
)
˚˚r s
;
˚˚s t
response
˝˝ 
.
˝˝ 
	IsSuccess
˝˝ 
=
˝˝  
false
˝˝! &
;
˝˝& '
response
˛˛ 
.
˛˛ 

StatusCode
˛˛ 
=
˛˛  !
HttpStatusCode
˛˛" 0
.
˛˛0 1
RequestTimeout
˛˛1 ?
;
˛˛? @
response
ˇˇ 
.
ˇˇ 
ErrorMessage
ˇˇ !
=
ˇˇ" #
$str
ˇˇ$ M
;
ˇˇM N
response
ÄÄ 
.
ÄÄ 
ResponseTimeMs
ÄÄ #
=
ÄÄ$ %
	stopwatch
ÄÄ& /
.
ÄÄ/ 0!
ElapsedMilliseconds
ÄÄ0 C
;
ÄÄC D
return
ÅÅ 
response
ÅÅ 
;
ÅÅ 
}
ÇÇ 	
private
ÑÑ 
HttpApiResponse
ÑÑ 
<
ÑÑ  
	TResponse
ÑÑ  )
>
ÑÑ) *(
HandleHttpRequestException
ÑÑ+ E
<
ÑÑE F
	TResponse
ÑÑF O
>
ÑÑO P
(
ÑÑP Q"
HttpRequestException
ÖÖ  
ex
ÖÖ! #
,
ÖÖ# $
HttpApiResponse
ÜÜ 
<
ÜÜ 
	TResponse
ÜÜ %
>
ÜÜ% &
response
ÜÜ' /
,
ÜÜ/ 0
Guid
áá 
	processId
áá 
,
áá 
System
àà 
.
àà 
Diagnostics
àà 
.
àà 
	Stopwatch
àà (
	stopwatch
àà) 2
,
àà2 3
Uri
ââ 
url
ââ 
,
ââ 
string
ää 

methodName
ää 
)
ää 
where
ãã 
	TResponse
ãã 
:
ãã 
class
ãã #
{
åå 	
this
çç 
.
çç 
_logger
çç 
.
çç 
LogError
çç !
(
çç! "
ex
çç" $
,
çç$ %
$"
çç& (
$str
çç( :
{
çç: ;

methodName
çç; E
}
ççE F
$str
ççF J
{
ççJ K
url
ççK N
}
ççN O
"
ççO P
)
ççP Q
;
ççQ R
this
éé 
.
éé 
_logger
éé 
.
éé 

EndProcess
éé #
(
éé# $
	processId
éé$ -
,
éé- .
	stopwatch
éé/ 8
,
éé8 9
new
éé: =
{
éé> ?
Success
éé@ G
=
ééH I
false
ééJ O
,
ééO P
Error
ééQ V
=
ééW X
$str
ééY o
}
éép q
)
ééq r
;
éér s
response
êê 
.
êê 
	IsSuccess
êê 
=
êê  
false
êê! &
;
êê& '
response
ëë 
.
ëë 

StatusCode
ëë 
=
ëë  !
HttpStatusCode
ëë" 0
.
ëë0 1 
ServiceUnavailable
ëë1 C
;
ëëC D
response
íí 
.
íí 
ErrorMessage
íí !
=
íí" #
$"
íí$ &
$str
íí& 4
{
íí4 5
ex
íí5 7
.
íí7 8
Message
íí8 ?
}
íí? @
"
íí@ A
;
ííA B
response
ìì 
.
ìì 
ResponseTimeMs
ìì #
=
ìì$ %
	stopwatch
ìì& /
.
ìì/ 0!
ElapsedMilliseconds
ìì0 C
;
ììC D
return
îî 
response
îî 
;
îî 
}
ïï 	
private
óó 
HttpApiResponse
óó 
<
óó  
	TResponse
óó  )
>
óó) **
HandleBrokenCircuitException
óó+ G
<
óóG H
	TResponse
óóH Q
>
óóQ R
(
óóR S
Polly
òò 
.
òò 
CircuitBreaker
òò  
.
òò  !$
BrokenCircuitException
òò! 7
ex
òò8 :
,
òò: ;
HttpApiResponse
ôô 
<
ôô 
	TResponse
ôô %
>
ôô% &
response
ôô' /
,
ôô/ 0
Guid
öö 
	processId
öö 
,
öö 
System
õõ 
.
õõ 
Diagnostics
õõ 
.
õõ 
	Stopwatch
õõ (
	stopwatch
õõ) 2
,
õõ2 3
Uri
úú 
url
úú 
)
úú 
where
ùù 
	TResponse
ùù 
:
ùù 
class
ùù #
{
ûû 	
this
üü 
.
üü 
_logger
üü 
.
üü 
LogError
üü !
(
üü! "
ex
üü" $
,
üü$ %
$"
üü& (
$str
üü( F
{
üüF G
url
üüG J
}
üüJ K
"
üüK L
)
üüL M
;
üüM N
this
†† 
.
†† 
_logger
†† 
.
†† 

EndProcess
†† #
(
††# $
	processId
††$ -
,
††- .
	stopwatch
††/ 8
,
††8 9
new
††: =
{
††> ?
Success
††@ G
=
††H I
false
††J O
,
††O P
Error
††Q V
=
††W X
$str
††Y q
}
††r s
)
††s t
;
††t u
response
¢¢ 
.
¢¢ 
	IsSuccess
¢¢ 
=
¢¢  
false
¢¢! &
;
¢¢& '
response
££ 
.
££ 

StatusCode
££ 
=
££  !
HttpStatusCode
££" 0
.
££0 1 
ServiceUnavailable
££1 C
;
££C D
response
§§ 
.
§§ 
ErrorMessage
§§ !
=
§§" #
$str
§§$ p
;
§§p q
response
•• 
.
•• 
ResponseTimeMs
•• #
=
••$ %
	stopwatch
••& /
.
••/ 0!
ElapsedMilliseconds
••0 C
;
••C D
return
¶¶ 
response
¶¶ 
;
¶¶ 
}
ßß 	
}
®® 
}©© Ü£
dC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\HttpClientService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
{ 
public 

partial 
class 
HttpClientService *
:+ ,
IHttpClientService- ?
{ 
private 
static 
readonly !
JsonSerializerOptions  5
_jsonOptions6 B
=C D
newE H
(H I
)I J
{ 	'
PropertyNameCaseInsensitive '
=( )
true* .
,. / 
PropertyNamingPolicy  
=! "
JsonNamingPolicy# 3
.3 4
	CamelCase4 =
,= >
} 	
;	 

[ 	
GeneratedRegex	 
( 
$str .
,. /
RegexOptions0 <
.< =
None= A
)A B
]B C
private 
static 
partial 
Regex $
EmptyDataPattern% 5
(5 6
)6 7
;7 8
private 
readonly 

HttpClient #
_http$ )
;) *
private 
readonly 

IAppLogger #
<# $
HttpClientService$ 5
>5 6
_logger7 >
;> ?
private   
readonly   $
IResiliencePolicyService   1$
_resiliencePolicyService  2 J
;  J K
public(( 
HttpClientService((  
(((  !

HttpClient)) 
http)) 
,)) 

IAppLogger** 
<** 
HttpClientService** (
>**( )
logger*** 0
,**0 1$
IResiliencePolicyService++ $#
resiliencePolicyService++% <
)++< =
{,, 	
this-- 
.-- 
_http-- 
=-- 
http-- 
??--  
throw--! &
new--' *!
ArgumentNullException--+ @
(--@ A
nameof--A G
(--G H
http--H L
)--L M
)--M N
;--N O
this.. 
... 
_logger.. 
=.. 
logger.. !
??.." $
throw..% *
new..+ .!
ArgumentNullException../ D
(..D E
nameof..E K
(..K L
logger..L R
)..R S
)..S T
;..T U
this// 
.// $
_resiliencePolicyService// )
=//* +#
resiliencePolicyService//, C
??//D F
throw//G L
new//M P!
ArgumentNullException//Q f
(//f g
nameof//g m
(//m n$
resiliencePolicyService	//n Ö
)
//Ö Ü
)
//Ü á
;
//á à
}00 	
public88 
async88 
Task88 
<88 
ApiResponse88 %
<88% &
T88& '
>88' (
>88( )
	SendAsync88* 3
<883 4
T884 5
>885 6
(886 7

ApiRequest887 A
request88B I
)88I J
{99 	
return:: 
await:: 
this:: 
.:: 
SendRequestAsync:: .
<::. /
T::/ 0
>::0 1
(::1 2
request::2 9
,::9 :
useRetry::; C
:::C D
true::E I
)::I J
.::J K
ConfigureAwait::K Y
(::Y Z
false::Z _
)::_ `
;::` a
};; 	
publicCC 
asyncCC 
TaskCC 
<CC 
ApiResponseCC %
<CC% &
TCC& '
>CC' (
>CC( )!
SendWithoutRetryAsyncCC* ?
<CC? @
TCC@ A
>CCA B
(CCB C

ApiRequestCCC M
requestCCN U
)CCU V
{DD 	
returnEE 
awaitEE 
thisEE 
.EE 
SendRequestAsyncEE .
<EE. /
TEE/ 0
>EE0 1
(EE1 2
requestEE2 9
,EE9 :
useRetryEE; C
:EEC D
falseEEE J
)EEJ K
.EEK L
ConfigureAwaitEEL Z
(EEZ [
falseEE[ `
)EE` a
;EEa b
}FF 	
publicOO 
asyncOO 
TaskOO 
<OO 
stringOO  
>OO  !
	PostAsyncOO" +
(OO+ ,
UriOO, /
urlOO0 3
,OO3 4
stringOO5 ;
jsonBodyOO< D
,OOD E

DictionaryOOF P
<OOP Q
stringOOQ W
,OOW X
stringOOY _
>OO_ `
?OO` a
headersOOb i
=OOj k
nullOOl p
)OOp q
{PP 	
thisQQ 
.QQ 
_httpQQ 
.QQ !
DefaultRequestHeadersQQ ,
.QQ, -
ClearQQ- 2
(QQ2 3
)QQ3 4
;QQ4 5
thisRR 
.RR 
_httpRR 
.RR !
DefaultRequestHeadersRR ,
.RR, -
AcceptRR- 3
.RR3 4
AddRR4 7
(RR7 8
newRR8 ;+
MediaTypeWithQualityHeaderValueRR< [
(RR[ \
$strRR\ n
)RRn o
)RRo p
;RRp q
ifTT 
(TT 
headersTT 
!=TT 
nullTT 
)TT  
{UU 
foreachVV 
(VV 
varVV 
headerVV #
inVV$ &
headersVV' .
)VV. /
{WW 
thisXX 
.XX 
_httpXX 
.XX !
DefaultRequestHeadersXX 4
.XX4 5
AddXX5 8
(XX8 9
headerXX9 ?
.XX? @
KeyXX@ C
,XXC D
headerXXE K
.XXK L
ValueXXL Q
)XXQ R
;XXR S
}YY 
}ZZ 
using\\ 
var\\ 
content\\ 
=\\ 
new\\  #
StringContent\\$ 1
(\\1 2
jsonBody\\2 :
,\\: ;
Encoding\\< D
.\\D E
UTF8\\E I
,\\I J
$str\\K ]
)\\] ^
;\\^ _
var^^ 
response^^ 
=^^ 
await^^  
this^^! %
.^^% &
_http^^& +
.^^+ ,
	PostAsync^^, 5
(^^5 6
url^^6 9
,^^9 :
content^^; B
)^^B C
.^^C D
ConfigureAwait^^D R
(^^R S
false^^S X
)^^X Y
;^^Y Z
var__ 
responseBody__ 
=__ 
await__ $
response__% -
.__- .
Content__. 5
.__5 6
ReadAsStringAsync__6 G
(__G H
)__H I
.__I J
ConfigureAwait__J X
(__X Y
false__Y ^
)__^ _
;___ `
responseaa 
.aa #
EnsureSuccessStatusCodeaa ,
(aa, -
)aa- .
;aa. /
returnbb 
responseBodybb 
;bb  
}cc 	
privateee 
staticee 
boolee 
IsMethodWithBodyee ,
(ee, -

HttpMethodee- 7
methodee8 >
)ee> ?
{ff 	
returngg 
methodgg 
==gg 

HttpMethodgg '
.gg' (
Postgg( ,
||gg- /
methodhh 
==hh 

HttpMethodhh '
.hh' (
Puthh( +
||hh, .
methodii 
==ii 

HttpMethodii '
.ii' (
Patchii( -
||ii. 0
methodjj 
==jj 

HttpMethodjj '
.jj' (
Deletejj( .
;jj. /
}kk 	
privatemm 
staticmm 
HttpRequestMessagemm )$
CreateHttpRequestMessagemm* B
(mmB C

ApiRequestmmC M
requestmmN U
,mmU V
stringmmW ]
?mm] ^
serializedBodymm_ m
)mmm n
{nn 	
varoo 
httpRequestoo 
=oo 
newoo !
HttpRequestMessageoo" 4
(oo4 5
requestoo5 <
.oo< =
Methodoo= C
,ooC D
requestooE L
.ooL M
UrlooM P
)ooP Q
;ooQ R
ifqq 
(qq 
requestqq 
.qq 
Headersqq 
!=qq  "
nullqq# '
)qq' (
{rr 
foreachss 
(ss 
varss 
headerss #
inss$ &
requestss' .
.ss. /
Headersss/ 6
)ss6 7
{tt 
httpRequestuu 
.uu  
Headersuu  '
.uu' (#
TryAddWithoutValidationuu( ?
(uu? @
headeruu@ F
.uuF G
KeyuuG J
,uuJ K
headeruuL R
.uuR S
ValueuuS X
)uuX Y
;uuY Z
}vv 
}ww 
ifyy 
(yy 
!yy 
stringyy 
.yy 
IsNullOrWhiteSpaceyy *
(yy* +
requestyy+ 2
.yy2 3
BearerTokenyy3 >
)yy> ?
)yy? @
{zz 
httpRequest{{ 
.{{ 
Headers{{ #
.{{# $
Authorization{{$ 1
={{2 3
new{{4 7%
AuthenticationHeaderValue{{8 Q
({{Q R
$str{{R Z
,{{Z [
request{{\ c
.{{c d
BearerToken{{d o
){{o p
;{{p q
}|| 
if~~ 
(~~ 
serializedBody~~ 
!=~~ !
null~~" &
)~~& '
{ 
httpRequest
ÄÄ 
.
ÄÄ 
Content
ÄÄ #
=
ÄÄ$ %
new
ÄÄ& )
StringContent
ÄÄ* 7
(
ÄÄ7 8
serializedBody
ÄÄ8 F
,
ÄÄF G
Encoding
ÄÄH P
.
ÄÄP Q
UTF8
ÄÄQ U
,
ÄÄU V
$str
ÄÄW i
)
ÄÄi j
;
ÄÄj k
}
ÅÅ 
return
ÉÉ 
httpRequest
ÉÉ 
;
ÉÉ 
}
ÑÑ 	
private
ââ 
static
ââ 
string
ââ $
PreprocessJsonResponse
ââ 4
(
ââ4 5
string
ââ5 ;
json
ââ< @
)
ââ@ A
{
ää 	
if
ãã 
(
ãã 
string
ãã 
.
ãã  
IsNullOrWhiteSpace
ãã )
(
ãã) *
json
ãã* .
)
ãã. /
)
ãã/ 0
{
åå 
return
çç 
json
çç 
;
çç 
}
éé 
if
êê 
(
êê 
json
êê 
.
êê 
Contains
êê 
(
êê 
$str
êê -
,
êê- .
StringComparison
êê/ ?
.
êê? @
Ordinal
êê@ G
)
êêG H
)
êêH I
{
ëë 
return
íí 
EmptyDataPattern
íí '
(
íí' (
)
íí( )
.
íí) *
Replace
íí* 1
(
íí1 2
json
íí2 6
,
íí6 7
$str
íí8 E
)
ííE F
;
ííF G
}
ìì 
return
ïï 
json
ïï 
;
ïï 
}
ññ 	
private
õõ 
async
õõ 
Task
õõ 
<
õõ 
ApiResponse
õõ &
<
õõ& '
T
õõ' (
>
õõ( )
>
õõ) *
SendRequestAsync
õõ+ ;
<
õõ; <
T
õõ< =
>
õõ= >
(
õõ> ?

ApiRequest
õõ? I
request
õõJ Q
,
õõQ R
bool
õõS W
useRetry
õõX `
)
õõ` a
{
úú 	#
ArgumentNullException
ùù !
.
ùù! "
ThrowIfNull
ùù" -
(
ùù- .
request
ùù. 5
)
ùù5 6
;
ùù6 7#
ArgumentNullException
ûû !
.
ûû! "
ThrowIfNull
ûû" -
(
ûû- .
request
ûû. 5
.
ûû5 6
Url
ûû6 9
)
ûû9 :
;
ûû: ;
var
†† 
responseEntity
†† 
=
††  
new
††! $
ApiResponse
††% 0
<
††0 1
T
††1 2
>
††2 3
(
††3 4
)
††4 5
;
††5 6%
CancellationTokenSource
°° #
?
°°# $
cts
°°% (
=
°°) *
null
°°+ /
;
°°/ 0
try
££ 
{
§§ 
cts
•• 
=
•• 
new
•• %
CancellationTokenSource
•• 1
(
••1 2
TimeSpan
••2 :
.
••: ;
FromSeconds
••; F
(
••F G
$num
••G J
)
••J K
)
••K L
;
••L M
this
ßß 
.
ßß 
LogRequestStart
ßß $
(
ßß$ %
request
ßß% ,
,
ßß, -
withoutRetry
ßß. :
:
ßß: ;
!
ßß< =
useRetry
ßß= E
)
ßßE F
;
ßßF G
var
®® 
serializedBody
®® "
=
®®# $
this
®®% )
.
®®) * 
PrepareRequestBody
®®* <
(
®®< =
request
®®= D
)
®®D E
;
®®E F
var
™™ 
result
™™ 
=
™™ 
useRetry
™™ %
?
´´ 
await
´´ 
this
´´  
.
´´  !%
ExecuteRequestWithRetry
´´! 8
(
´´8 9
request
´´9 @
,
´´@ A
serializedBody
´´B P
,
´´P Q
cts
´´R U
.
´´U V
Token
´´V [
)
´´[ \
.
´´\ ]
ConfigureAwait
´´] k
(
´´k l
false
´´l q
)
´´q r
:
¨¨ 
await
¨¨ 
this
¨¨  
.
¨¨  !(
ExecuteRequestWithoutRetry
¨¨! ;
(
¨¨; <
request
¨¨< C
,
¨¨C D
serializedBody
¨¨E S
,
¨¨S T
cts
¨¨U X
.
¨¨X Y
Token
¨¨Y ^
)
¨¨^ _
.
¨¨_ `
ConfigureAwait
¨¨` n
(
¨¨n o
false
¨¨o t
)
¨¨t u
;
¨¨u v
return
ÆÆ 
await
ÆÆ 
this
ÆÆ !
.
ÆÆ! "
ProcessResponse
ÆÆ" 1
<
ÆÆ1 2
T
ÆÆ2 3
>
ÆÆ3 4
(
ÆÆ4 5
result
ÆÆ5 ;
,
ÆÆ; <
responseEntity
ÆÆ= K
,
ÆÆK L
cts
ÆÆM P
.
ÆÆP Q
Token
ÆÆQ V
)
ÆÆV W
.
ÆÆW X
ConfigureAwait
ÆÆX f
(
ÆÆf g
false
ÆÆg l
)
ÆÆl m
;
ÆÆm n
}
ØØ 
catch
∞∞ 
(
∞∞ "
OutOfMemoryException
∞∞ '
ex
∞∞( *
)
∞∞* +
{
±± 
return
≤≤ 
this
≤≤ 
.
≤≤ 
HandleException
≤≤ +
<
≤≤+ ,
T
≤≤, -
>
≤≤- .
(
≤≤. /
ex
≤≤/ 1
,
≤≤1 2
request
≤≤3 :
,
≤≤: ;
responseEntity
≤≤< J
)
≤≤J K
;
≤≤K L
}
≥≥ 
catch
¥¥ 
(
¥¥ $
StackOverflowException
¥¥ )
ex
¥¥* ,
)
¥¥, -
{
µµ 
return
∂∂ 
this
∂∂ 
.
∂∂ 
HandleException
∂∂ +
<
∂∂+ ,
T
∂∂, -
>
∂∂- .
(
∂∂. /
ex
∂∂/ 1
,
∂∂1 2
request
∂∂3 :
,
∂∂: ;
responseEntity
∂∂< J
)
∂∂J K
;
∂∂K L
}
∑∑ 
catch
∏∏ 
(
∏∏ 
JsonException
∏∏  
ex
∏∏! #
)
∏∏# $
{
ππ 
return
∫∫ 
this
∫∫ 
.
∫∫ 
HandleException
∫∫ +
<
∫∫+ ,
T
∫∫, -
>
∫∫- .
(
∫∫. /
ex
∫∫/ 1
,
∫∫1 2
request
∫∫3 :
,
∫∫: ;
responseEntity
∫∫< J
)
∫∫J K
;
∫∫K L
}
ªª 
catch
ºº 
(
ºº #
TaskCanceledException
ºº (
ex
ºº) +
)
ºº+ ,
{
ΩΩ 
return
ææ 
this
ææ 
.
ææ 
HandleException
ææ +
<
ææ+ ,
T
ææ, -
>
ææ- .
(
ææ. /
ex
ææ/ 1
,
ææ1 2
request
ææ3 :
,
ææ: ;
responseEntity
ææ< J
)
ææJ K
;
ææK L
}
øø 
catch
¿¿ 
(
¿¿ (
OperationCanceledException
¿¿ -
ex
¿¿. 0
)
¿¿0 1
{
¡¡ 
return
¬¬ 
this
¬¬ 
.
¬¬ 
HandleException
¬¬ +
<
¬¬+ ,
T
¬¬, -
>
¬¬- .
(
¬¬. /
ex
¬¬/ 1
,
¬¬1 2
request
¬¬3 :
,
¬¬: ;
responseEntity
¬¬< J
)
¬¬J K
;
¬¬K L
}
√√ 
catch
ƒƒ 
(
ƒƒ "
HttpRequestException
ƒƒ '
ex
ƒƒ( *
)
ƒƒ* +
{
≈≈ 
return
∆∆ 
this
∆∆ 
.
∆∆ 
HandleException
∆∆ +
<
∆∆+ ,
T
∆∆, -
>
∆∆- .
(
∆∆. /
ex
∆∆/ 1
,
∆∆1 2
request
∆∆3 :
,
∆∆: ;
responseEntity
∆∆< J
)
∆∆J K
;
∆∆K L
}
«« 
catch
»» 
(
»» 
Polly
»» 
.
»» 
	RateLimit
»» "
.
»»" #(
RateLimitRejectedException
»»# =
ex
»»> @
)
»»@ A
{
…… 
return
   
this
   
.
   
HandleException
   +
<
  + ,
T
  , -
>
  - .
(
  . /
ex
  / 1
,
  1 2
request
  3 :
,
  : ;
responseEntity
  < J
)
  J K
;
  K L
}
ÀÀ 
catch
ÃÃ 
(
ÃÃ 
Polly
ÃÃ 
.
ÃÃ 
CircuitBreaker
ÃÃ '
.
ÃÃ' ($
BrokenCircuitException
ÃÃ( >
ex
ÃÃ? A
)
ÃÃA B
{
ÕÕ 
return
ŒŒ 
this
ŒŒ 
.
ŒŒ 
HandleException
ŒŒ +
<
ŒŒ+ ,
T
ŒŒ, -
>
ŒŒ- .
(
ŒŒ. /
ex
ŒŒ/ 1
,
ŒŒ1 2
request
ŒŒ3 :
,
ŒŒ: ;
responseEntity
ŒŒ< J
)
ŒŒJ K
;
ŒŒK L
}
œœ 
catch
–– 
(
–– 
Polly
–– 
.
–– 
Bulkhead
–– !
.
––! "'
BulkheadRejectedException
––" ;
ex
––< >
)
––> ?
{
—— 
return
““ 
this
““ 
.
““ 
HandleException
““ +
<
““+ ,
T
““, -
>
““- .
(
““. /
ex
““/ 1
,
““1 2
request
““3 :
,
““: ;
responseEntity
““< J
)
““J K
;
““K L
}
”” 
catch
‘‘ 
(
‘‘ 
Polly
‘‘ 
.
‘‘ 
Timeout
‘‘  
.
‘‘  !&
TimeoutRejectedException
‘‘! 9
ex
‘‘: <
)
‘‘< =
{
’’ 
return
÷÷ 
this
÷÷ 
.
÷÷ 
HandleException
÷÷ +
<
÷÷+ ,
T
÷÷, -
>
÷÷- .
(
÷÷. /
ex
÷÷/ 1
,
÷÷1 2
request
÷÷3 :
,
÷÷: ;
responseEntity
÷÷< J
)
÷÷J K
;
÷÷K L
}
◊◊ 
finally
ÿÿ 
{
ŸŸ 
cts
⁄⁄ 
?
⁄⁄ 
.
⁄⁄ 
Dispose
⁄⁄ 
(
⁄⁄ 
)
⁄⁄ 
;
⁄⁄ 
}
€€ 
}
‹‹ 	
private
ﬁﬁ 
void
ﬁﬁ 
LogRequestStart
ﬁﬁ $
(
ﬁﬁ$ %

ApiRequest
ﬁﬁ% /
request
ﬁﬁ0 7
,
ﬁﬁ7 8
bool
ﬁﬁ9 =
withoutRetry
ﬁﬁ> J
=
ﬁﬁK L
false
ﬁﬁM R
)
ﬁﬁR S
{
ﬂﬂ 	
var
‡‡ 
logInput
‡‡ 
=
‡‡ 
new
‡‡ 
{
·· 
Method
‚‚ 
=
‚‚ 
request
‚‚  
.
‚‚  !
Method
‚‚! '
.
‚‚' (
ToString
‚‚( 0
(
‚‚0 1
)
‚‚1 2
,
‚‚2 3
Url
„„ 
=
„„ 
request
„„ 
.
„„ 
Url
„„ !
.
„„! "
ToString
„„" *
(
„„* +
)
„„+ ,
,
„„, -
HasBody
‰‰ 
=
‰‰ 
request
‰‰ !
.
‰‰! "
Body
‰‰" &
!=
‰‰' )
null
‰‰* .
,
‰‰. /
HeaderCount
ÂÂ 
=
ÂÂ 
request
ÂÂ %
.
ÂÂ% &
Headers
ÂÂ& -
?
ÂÂ- .
.
ÂÂ. /
Count
ÂÂ/ 4
??
ÂÂ5 7
$num
ÂÂ8 9
,
ÂÂ9 :
}
ÊÊ 
;
ÊÊ 
this
ËË 
.
ËË 
_logger
ËË 
.
ËË 
StartProcess
ËË %
(
ËË% &
logInput
ËË& .
)
ËË. /
;
ËË/ 0
var
ÍÍ 
suffix
ÍÍ 
=
ÍÍ 
withoutRetry
ÍÍ %
?
ÍÍ& '
$str
ÍÍ( >
:
ÍÍ? @
string
ÍÍA G
.
ÍÍG H
Empty
ÍÍH M
;
ÍÍM N
this
ÎÎ 
.
ÎÎ 
_logger
ÎÎ 
.
ÎÎ 
Info
ÎÎ 
(
ÎÎ 
$"
ÎÎ  
$str
ÎÎ  3
{
ÎÎ3 4
request
ÎÎ4 ;
.
ÎÎ; <
Method
ÎÎ< B
}
ÎÎB C
$str
ÎÎC F
{
ÎÎF G
request
ÎÎG N
.
ÎÎN O
Url
ÎÎO R
}
ÎÎR S
{
ÎÎS T
suffix
ÎÎT Z
}
ÎÎZ [
"
ÎÎ[ \
)
ÎÎ\ ]
;
ÎÎ] ^
}
ÏÏ 	
private
ÓÓ 
string
ÓÓ 
?
ÓÓ  
PrepareRequestBody
ÓÓ *
(
ÓÓ* +

ApiRequest
ÓÓ+ 5
request
ÓÓ6 =
)
ÓÓ= >
{
ÔÔ 	
if
 
(
 
request
 
.
 
Body
 
==
 
null
  $
||
% '
!
( )
IsMethodWithBody
) 9
(
9 :
request
: A
.
A B
Method
B H
)
H I
)
I J
{
ÒÒ 
return
ÚÚ 
null
ÚÚ 
;
ÚÚ 
}
ÛÛ 
var
ıı 
serializedBody
ıı 
=
ıı  
JsonSerializer
ıı! /
.
ıı/ 0
	Serialize
ıı0 9
(
ıı9 :
request
ıı: A
.
ııA B
Body
ııB F
)
ııF G
;
ııG H
this
ˆˆ 
.
ˆˆ 
_logger
ˆˆ 
.
ˆˆ 
Debug
ˆˆ 
(
ˆˆ 
$"
ˆˆ !
$str
ˆˆ! 3
{
ˆˆ3 4
serializedBody
ˆˆ4 B
.
ˆˆB C
Length
ˆˆC I
}
ˆˆI J
$str
ˆˆJ U
"
ˆˆU V
)
ˆˆV W
;
ˆˆW X
if
¯¯ 
(
¯¯ 
request
¯¯ 
.
¯¯ 
Headers
¯¯ 
?
¯¯  
.
¯¯  !
Count
¯¯! &
>
¯¯' (
$num
¯¯) *
)
¯¯* +
{
˘˘ 
this
˙˙ 
.
˙˙ 
_logger
˙˙ 
.
˙˙ 
Debug
˙˙ "
(
˙˙" #
$"
˙˙# %
$str
˙˙% ;
{
˙˙; <
request
˙˙< C
.
˙˙C D
Headers
˙˙D K
.
˙˙K L
Count
˙˙L Q
}
˙˙Q R
"
˙˙R S
)
˙˙S T
;
˙˙T U
}
˚˚ 
if
˝˝ 
(
˝˝ 
!
˝˝ 
string
˝˝ 
.
˝˝  
IsNullOrWhiteSpace
˝˝ *
(
˝˝* +
request
˝˝+ 2
.
˝˝2 3
BearerToken
˝˝3 >
)
˝˝> ?
)
˝˝? @
{
˛˛ 
this
ˇˇ 
.
ˇˇ 
_logger
ˇˇ 
.
ˇˇ 
Debug
ˇˇ "
(
ˇˇ" #
$str
ˇˇ# =
)
ˇˇ= >
;
ˇˇ> ?
}
ÄÄ 
return
ÇÇ 
serializedBody
ÇÇ !
;
ÇÇ! "
}
ÉÉ 	
private
ÖÖ 
async
ÖÖ 
Task
ÖÖ 
<
ÖÖ !
HttpResponseMessage
ÖÖ .
>
ÖÖ. /%
ExecuteRequestWithRetry
ÖÖ0 G
(
ÖÖG H

ApiRequest
ÜÜ 
request
ÜÜ 
,
ÜÜ 
string
áá 
?
áá 
serializedBody
áá "
,
áá" #
CancellationToken
àà 
cancellationToken
àà /
)
àà/ 0
{
ââ 	
return
ää 
await
ää 
this
ää 
.
ää &
_resiliencePolicyService
ää 6
.
ää6 7
RetryPipeline
ää7 D
.
ääD E
ExecuteAsync
ääE Q
(
ääQ R
async
ãã 
ct
ãã 
=>
ãã 
{
åå 
using
çç 
var
çç 
httpRequest
çç )
=
çç* +&
CreateHttpRequestMessage
çç, D
(
ççD E
request
ççE L
,
ççL M
serializedBody
ççN \
)
çç\ ]
;
çç] ^
return
éé 
await
éé  
this
éé! %
.
éé% &
_http
éé& +
.
éé+ ,
	SendAsync
éé, 5
(
éé5 6
httpRequest
éé6 A
,
ééA B
ct
ééC E
)
ééE F
.
ééF G
ConfigureAwait
ééG U
(
ééU V
false
ééV [
)
éé[ \
;
éé\ ]
}
èè 
,
èè 
cancellationToken
êê !
)
êê! "
.
êê" #
ConfigureAwait
êê# 1
(
êê1 2
false
êê2 7
)
êê7 8
;
êê8 9
}
ëë 	
private
ìì 
async
ìì 
Task
ìì 
<
ìì !
HttpResponseMessage
ìì .
>
ìì. /(
ExecuteRequestWithoutRetry
ìì0 J
(
ììJ K

ApiRequest
îî 
request
îî 
,
îî 
string
ïï 
?
ïï 
serializedBody
ïï "
,
ïï" #
CancellationToken
ññ 
cancellationToken
ññ /
)
ññ/ 0
{
óó 	
using
òò 
var
òò 
httpRequest
òò !
=
òò" #&
CreateHttpRequestMessage
òò$ <
(
òò< =
request
òò= D
,
òòD E
serializedBody
òòF T
)
òòT U
;
òòU V
return
ôô 
await
ôô 
this
ôô 
.
ôô 
_http
ôô #
.
ôô# $
	SendAsync
ôô$ -
(
ôô- .
httpRequest
ôô. 9
,
ôô9 :
cancellationToken
ôô; L
)
ôôL M
.
ôôM N
ConfigureAwait
ôôN \
(
ôô\ ]
false
ôô] b
)
ôôb c
;
ôôc d
}
öö 	
private
úú 
async
úú 
Task
úú 
<
úú 
ApiResponse
úú &
<
úú& '
T
úú' (
>
úú( )
>
úú) *
ProcessResponse
úú+ :
<
úú: ;
T
úú; <
>
úú< =
(
úú= >!
HttpResponseMessage
ùù 
result
ùù  &
,
ùù& '
ApiResponse
ûû 
<
ûû 
T
ûû 
>
ûû 
responseEntity
ûû )
,
ûû) *
CancellationToken
üü 
cancellationToken
üü /
)
üü/ 0
{
†† 	
var
°° 
jsonResponse
°° 
=
°° 
await
°° $
result
°°% +
.
°°+ ,
Content
°°, 3
.
°°3 4
ReadAsStringAsync
°°4 E
(
°°E F
cancellationToken
°°F W
)
°°W X
.
°°X Y
ConfigureAwait
°°Y g
(
°°g h
false
°°h m
)
°°m n
;
°°n o
responseEntity
££ 
.
££ 

StatusCode
££ %
=
££& '
result
££( .
.
££. /

StatusCode
££/ 9
;
££9 :
responseEntity
§§ 
.
§§ 
RawResponse
§§ &
=
§§' (
jsonResponse
§§) 5
;
§§5 6
this
¶¶ 
.
¶¶ 
_logger
¶¶ 
.
¶¶ 
Info
¶¶ 
(
¶¶ 
$"
¶¶  
$str
¶¶  4
{
¶¶4 5
result
¶¶5 ;
.
¶¶; <

StatusCode
¶¶< F
}
¶¶F G
$str
¶¶G I
{
¶¶I J
(
¶¶J K
int
¶¶K N
)
¶¶N O
result
¶¶O U
.
¶¶U V

StatusCode
¶¶V `
}
¶¶` a
$str
¶¶a d
{
¶¶d e
jsonResponse
¶¶e q
?
¶¶q r
.
¶¶r s
Length
¶¶s y
??
¶¶z |
$num
¶¶} ~
}
¶¶~ 
$str¶¶ ä
"¶¶ä ã
)¶¶ã å
;¶¶å ç
if
®® 
(
®® 
result
®® 
.
®® !
IsSuccessStatusCode
®® *
&&
®®+ -
!
®®. /
string
®®/ 5
.
®®5 6 
IsNullOrWhiteSpace
®®6 H
(
®®H I
jsonResponse
®®I U
)
®®U V
)
®®V W
{
©© 
var
™™ 
cleanedJson
™™ 
=
™™  !$
PreprocessJsonResponse
™™" 8
(
™™8 9
jsonResponse
™™9 E
)
™™E F
;
™™F G
responseEntity
´´ 
.
´´ 
Data
´´ #
=
´´$ %
JsonSerializer
´´& 4
.
´´4 5
Deserialize
´´5 @
<
´´@ A
T
´´A B
>
´´B C
(
´´C D
cleanedJson
´´D O
,
´´O P
_jsonOptions
´´Q ]
)
´´] ^
;
´´^ _
this
¨¨ 
.
¨¨ 
_logger
¨¨ 
.
¨¨ 
Debug
¨¨ "
(
¨¨" #
$str
¨¨# I
)
¨¨I J
;
¨¨J K
}
≠≠ 
return
ØØ 
responseEntity
ØØ !
;
ØØ! "
}
∞∞ 	
private
≤≤ 
ApiResponse
≤≤ 
<
≤≤ 
T
≤≤ 
>
≤≤ 
HandleException
≤≤ .
<
≤≤. /
T
≤≤/ 0
>
≤≤0 1
(
≤≤1 2
	Exception
≤≤2 ;
ex
≤≤< >
,
≤≤> ?

ApiRequest
≤≤@ J
request
≤≤K R
,
≤≤R S
ApiResponse
≤≤T _
<
≤≤_ `
T
≤≤` a
>
≤≤a b
responseEntity
≤≤c q
)
≤≤q r
{
≥≥ 	
return
¥¥ 
ex
¥¥ 
switch
¥¥ 
{
µµ 
JsonException
∂∂ 
=>
∂∂  
this
∂∂! %
.
∂∂% &!
CreateErrorResponse
∂∂& 9
<
∂∂9 :
T
∂∂: ;
>
∂∂; <
(
∂∂< =
responseEntity
∂∂= K
,
∂∂K L
HttpStatusCode
∂∂M [
.
∂∂[ \

BadGateway
∂∂\ f
,
∂∂f g
$str
∂∂h 
,∂∂ Ä
ex∂∂Å É
,∂∂É Ñ
request∂∂Ö å
)∂∂å ç
,∂∂ç é#
TaskCanceledException
∑∑ %
=>
∑∑& (
this
∑∑) -
.
∑∑- .!
CreateErrorResponse
∑∑. A
<
∑∑A B
T
∑∑B C
>
∑∑C D
(
∑∑D E
responseEntity
∑∑E S
,
∑∑S T
HttpStatusCode
∑∑U c
.
∑∑c d
RequestTimeout
∑∑d r
,
∑∑r s
$str∑∑t ü
,∑∑ü †
ex∑∑° £
,∑∑£ §
request∑∑• ¨
,∑∑¨ ≠
$str∑∑Æ √
)∑∑√ ƒ
,∑∑ƒ ≈(
OperationCanceledException
∏∏ *
=>
∏∏+ -
this
∏∏. 2
.
∏∏2 3!
CreateErrorResponse
∏∏3 F
<
∏∏F G
T
∏∏G H
>
∏∏H I
(
∏∏I J
responseEntity
∏∏J X
,
∏∏X Y
HttpStatusCode
∏∏Z h
.
∏∏h i
RequestTimeout
∏∏i w
,
∏∏w x
$str∏∏y ï
,∏∏ï ñ
ex∏∏ó ô
,∏∏ô ö
request∏∏õ ¢
,∏∏¢ £
$str∏∏§ æ
)∏∏æ ø
,∏∏ø ¿"
HttpRequestException
ππ $
=>
ππ% '
this
ππ( ,
.
ππ, -!
CreateErrorResponse
ππ- @
<
ππ@ A
T
ππA B
>
ππB C
(
ππC D
responseEntity
ππD R
,
ππR S
HttpStatusCode
ππT b
.
ππb c 
ServiceUnavailable
ππc u
,
ππu v
$strππw ä
,ππä ã
exππå é
,ππé è
requestππê ó
,ππó ò
$strππô ±
)ππ± ≤
,ππ≤ ≥
Polly
∫∫ 
.
∫∫ 
	RateLimit
∫∫ 
.
∫∫  (
RateLimitRejectedException
∫∫  :
=>
∫∫; =
this
∫∫> B
.
∫∫B C!
CreateErrorResponse
∫∫C V
<
∫∫V W
T
∫∫W X
>
∫∫X Y
(
∫∫Y Z
responseEntity
∫∫Z h
,
∫∫h i
HttpStatusCode
∫∫j x
.
∫∫x y
TooManyRequests∫∫y à
,∫∫à â
$str∫∫ä ≤
,∫∫≤ ≥
ex∫∫¥ ∂
,∫∫∂ ∑
request∫∫∏ ø
,∫∫ø ¿
$str∫∫¡ €
)∫∫€ ‹
,∫∫‹ ›
Polly
ªª 
.
ªª 
CircuitBreaker
ªª $
.
ªª$ %$
BrokenCircuitException
ªª% ;
=>
ªª< >
this
ªª? C
.
ªªC D!
CreateErrorResponse
ªªD W
<
ªªW X
T
ªªX Y
>
ªªY Z
(
ªªZ [
responseEntity
ªª[ i
,
ªªi j
HttpStatusCode
ªªk y
.
ªªy z!
ServiceUnavailableªªz å
,ªªå ç
$strªªé ⁄
,ªª⁄ €
exªª‹ ﬁ
,ªªﬁ ﬂ
requestªª‡ Á
,ªªÁ Ë
$strªªÈ á
)ªªá à
,ªªà â
Polly
ºº 
.
ºº 
Bulkhead
ºº 
.
ºº '
BulkheadRejectedException
ºº 8
=>
ºº9 ;
this
ºº< @
.
ºº@ A!
CreateErrorResponse
ººA T
<
ººT U
T
ººU V
>
ººV W
(
ººW X
responseEntity
ººX f
,
ººf g
HttpStatusCode
ººh v
.
ººv w
TooManyRequestsººw Ü
,ººÜ á
$strººà À
,ººÀ Ã
exººÕ œ
,ººœ –
requestºº— ÿ
,ººÿ Ÿ
$strºº⁄ Û
)ººÛ Ù
,ººÙ ı
Polly
ΩΩ 
.
ΩΩ 
Timeout
ΩΩ 
.
ΩΩ &
TimeoutRejectedException
ΩΩ 6
=>
ΩΩ7 9
this
ΩΩ: >
.
ΩΩ> ?!
CreateErrorResponse
ΩΩ? R
<
ΩΩR S
T
ΩΩS T
>
ΩΩT U
(
ΩΩU V
responseEntity
ΩΩV d
,
ΩΩd e
HttpStatusCode
ΩΩf t
.
ΩΩt u
RequestTimeoutΩΩu É
,ΩΩÉ Ñ
$strΩΩÖ µ
,ΩΩµ ∂
exΩΩ∑ π
,ΩΩπ ∫
requestΩΩª ¬
,ΩΩ¬ √
$strΩΩƒ €
)ΩΩ€ ‹
,ΩΩ‹ ›
_
ææ 
=>
ææ 
this
ææ 
.
ææ !
CreateErrorResponse
ææ -
<
ææ- .
T
ææ. /
>
ææ/ 0
(
ææ0 1
responseEntity
ææ1 ?
,
ææ? @
HttpStatusCode
ææA O
.
ææO P!
InternalServerError
ææP c
,
ææc d
$str
ææe w
,
ææw x
ex
ææy {
,
ææ{ |
requestææ} Ñ
,ææÑ Ö
$strææÜ §
)ææ§ •
,ææ• ¶
}
øø 
;
øø 
}
¿¿ 	
private
¬¬ 
ApiResponse
¬¬ 
<
¬¬ 
T
¬¬ 
>
¬¬ !
CreateErrorResponse
¬¬ 2
<
¬¬2 3
T
¬¬3 4
>
¬¬4 5
(
¬¬5 6
ApiResponse
√√ 
<
√√ 
T
√√ 
>
√√ 
responseEntity
√√ )
,
√√) *
HttpStatusCode
ƒƒ 

statusCode
ƒƒ %
,
ƒƒ% &
string
≈≈ 
errorMessage
≈≈ 
,
≈≈  
	Exception
∆∆ 
ex
∆∆ 
,
∆∆ 

ApiRequest
«« 
request
«« 
,
«« 
string
»» 
?
»» 
	logPrefix
»» 
=
»» 
null
»»  $
)
»»$ %
{
…… 	
var
   

logMessage
   
=
   
	logPrefix
   &
!=
  ' )
null
  * .
?
ÀÀ 
$"
ÀÀ 
{
ÀÀ 
	logPrefix
ÀÀ 
}
ÀÀ 
$str
ÀÀ  
{
ÀÀ  !
request
ÀÀ! (
.
ÀÀ( )
Url
ÀÀ) ,
}
ÀÀ, -
"
ÀÀ- .
:
ÃÃ 
$"
ÃÃ 
{
ÃÃ 
errorMessage
ÃÃ !
}
ÃÃ! "
$str
ÃÃ" &
{
ÃÃ& '
request
ÃÃ' .
.
ÃÃ. /
Url
ÃÃ/ 2
}
ÃÃ2 3
"
ÃÃ3 4
;
ÃÃ4 5
this
ŒŒ 
.
ŒŒ 
_logger
ŒŒ 
.
ŒŒ 
LogError
ŒŒ !
(
ŒŒ! "
ex
ŒŒ" $
,
ŒŒ$ %

logMessage
ŒŒ& 0
)
ŒŒ0 1
;
ŒŒ1 2
responseEntity
œœ 
.
œœ 

StatusCode
œœ %
=
œœ& '

statusCode
œœ( 2
;
œœ2 3
responseEntity
–– 
.
–– 
RawResponse
–– &
=
––' (
ex
––) +
.
––+ ,
Message
––, 3
!=
––4 6
null
––7 ;
&&
––< >
errorMessage
––? K
.
––K L
Contains
––L T
(
––T U
$str
––U \
,
––\ ]
StringComparison
––^ n
.
––n o
Ordinal
––o v
)
––v w
?
—— 
$"
—— 
{
—— 
errorMessage
—— !
}
——! "
$str
——" $
{
——$ %
ex
——% '
.
——' (
Message
——( /
}
——/ 0
"
——0 1
:
““ 
errorMessage
““ 
;
““ 
return
‘‘ 
responseEntity
‘‘ !
;
‘‘! "
}
’’ 	
}
÷÷ 
}◊◊ Æ=
^C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Services\CadsService.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Services! )
{ 
public 

class 
CadsService 
( 
IOptions 
< 
CadsSettings 
> 
settings '
,' (
IHttpService 
httpService  
)  !
:" #
ICadsService$ 0
{ 
private 
readonly 
CadsSettings %
_cadssettings& 3
=4 5
settings6 >
?> ?
.? @
Value@ E
??F H
throwI N
newO R!
ArgumentNullExceptionS h
(h i
nameofi o
(o p
settingsp x
)x y
)y z
;z {
private 
readonly 
IHttpService %
_httpService& 2
=3 4
httpService5 @
??A C
throwD I
newJ M!
ArgumentNullExceptionN c
(c d
nameofd j
(j k
httpServicek v
)v w
)w x
;x y
public!! 
async!! 
Task!! 
<!! 
UserAccessResponse!! ,
?!!, -
>!!- .
ValideUserAccess!!/ ?
(!!? @!
ValidateAccessRequest!!@ U
request!!V ]
)!!] ^
{"" 	!
ArgumentNullException## !
.##! "
ThrowIfNull##" -
(##- .
request##. 5
)##5 6
;##6 7
try%% 
{&& 
var(( 
url(( 
=(( 
this(( 
.(( "
BuildValidateAccessUrl(( 5
(((5 6
request((6 =
)((= >
;((> ?
var++ 
result++ 
=++ 
await++ "
this++# '
.++' (
_httpService++( 4
.++4 5&
GetWithCircuitBreakerAsync++5 O
<++O P
UserAccessResponse++P b
>++b c
(++c d
url,, 
,,, 
request-- 
.-- 
Token-- !
)--! "
.--" #
ConfigureAwait--# 1
(--1 2
false--2 7
)--7 8
;--8 9
if00 
(00 
result00 
.00 

StatusCode00 %
==00& (
HttpStatusCode00) 7
.007 8
Unauthorized008 D
||00E G
result00H N
.00N O

StatusCode00O Y
==00Z \
HttpStatusCode00] k
.00k l
	Forbidden00l u
)00u v
{11 
return22 
null22 
;22  
}33 
if66 
(66 
result66 
.66 
	IsSuccess66 $
&&66% '
result66( .
.66. /
Data66/ 3
!=664 6
null667 ;
)66; <
{77 
return88 
result88 !
.88! "
Data88" &
;88& '
}99 
if<< 
(<< 
!<< 
result<< 
.<< 
	IsSuccess<< %
)<<% &
{== 
throw>> 
new>> %
InvalidOperationException>> 7
(>>7 8
$">>8 :
$str>>: t
{>>t u
result>>u {
.>>{ |

StatusCode	>>| Ü
}
>>Ü á
$str
>>á í
{
>>í ì
result
>>ì ô
.
>>ô ö
ErrorMessage
>>ö ¶
}
>>¶ ß
"
>>ß ®
)
>>® ©
;
>>© ™
}?? 
returnAA 
nullAA 
;AA 
}BB 
catchCC 
(CC 
UriFormatExceptionCC %
exCC& (
)CC( )
{DD 
throwEE 
newEE %
InvalidOperationExceptionEE 3
(EE3 4
$strEE4 g
,EEg h
exEEi k
)EEk l
;EEl m
}FF 
catchGG 
(GG %
InvalidOperationExceptionGG ,
)GG, -
{HH 
throwJJ 
;JJ 
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
throwNN 
newNN %
InvalidOperationExceptionNN 3
(NN3 4
$strNN4 c
,NNc d
exNNe g
)NNg h
;NNh i
}OO 
}PP 	
privateWW 
UriWW "
BuildValidateAccessUrlWW *
(WW* +!
ValidateAccessRequestWW+ @
requestWWA H
)WWH I
{XX 	
ifZZ 
(ZZ 
stringZZ 
.ZZ 
IsNullOrWhiteSpaceZZ )
(ZZ) *
thisZZ* .
.ZZ. /
_cadssettingsZZ/ <
.ZZ< =
BasePathZZ= E
)ZZE F
)ZZF G
{[[ 
throw\\ 
new\\ %
InvalidOperationException\\ 3
(\\3 4
$str\\4 m
)\\m n
;\\n o
}]] 
var`` 
baseUrl`` 
=`` 
$"`` 
{`` 
this`` !
.``! "
_cadssettings``" /
.``/ 0
BasePath``0 8
.``8 9
TrimEnd``9 @
(``@ A
$char``A D
)``D E
}``E F
$str``F G
{``G H
this``H L
.``L M
_cadssettings``M Z
.``Z [
	Endpoints``[ d
.``d e
ValidarSessionID``e u
?``u v
.``v w
	TrimStart	``w Ä
(
``Ä Å
$char
``Å Ñ
)
``Ñ Ö
??
``Ü à
string
``â è
.
``è ê
Empty
``ê ï
}
``ï ñ
"
``ñ ó
;
``ó ò
ifbb 
(bb 
!bb 
Uribb 
.bb 
	TryCreatebb 
(bb 
baseUrlbb &
,bb& '
UriKindbb( /
.bb/ 0
Absolutebb0 8
,bb8 9
outbb: =
varbb> A
baseUribbB I
)bbI J
)bbJ K
{cc 
throwdd 
newdd %
InvalidOperationExceptiondd 3
(dd3 4
$"dd4 6
$strdd6 ^
{dd^ _
baseUrldd_ f
}ddf g
"ddg h
)ddh i
;ddi j
}ee 
varhh 

uriBuilderhh 
=hh 
newhh  

UriBuilderhh! +
(hh+ ,
baseUrihh, 3
)hh3 4
;hh4 5
varii 
queryii 
=ii 
HttpUtilityii #
.ii# $
ParseQueryStringii$ 4
(ii4 5
stringii5 ;
.ii; <
Emptyii< A
)iiA B
;iiB C
querykk 
[kk 
$strkk 
]kk 
=kk 
requestkk "
.kk" #

RutTitularkk# -
;kk- .
queryll 
[ll 
$strll 
]ll 
=ll  
requestll! (
.ll( )
	SessionIdll) 2
;ll2 3
querymm 
[mm 
$strmm 
]mm 
=mm 
requestmm $
.mm$ %
Tokenmm% *
;mm* +
querynn 
[nn 
$strnn 
]nn 
=nn 
(nn 
(nn  
intnn  #
)nn# $
requestnn$ +
.nn+ ,
Origennn, 2
!nn2 3
)nn3 4
.nn4 5
ToStringnn5 =
(nn= >
CultureInfonn> I
.nnI J
InvariantCulturennJ Z
)nnZ [
;nn[ \

uriBuilderpp 
.pp 
Querypp 
=pp 
querypp $
.pp$ %
ToStringpp% -
(pp- .
)pp. /
;pp/ 0
returnrr 

uriBuilderrr 
.rr 
Urirr !
;rr! "
}ss 	
}tt 
}uu å$
fC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Security\Logger\StaticLogger.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Security! )
.) *
Logger* 0
{ 
public 

static 
class 
StaticLogger $
{ 
private 
const 
string 
_redAsciiColor +
=, -
$str. 8
;8 9
public 
static 
void 
LogInfo "
(" #
Type# '
logger( .
,. /
string0 6
mensaje7 >
)> ?
{ 	!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
logger. 4
)4 5
;5 6
var 
nlogger 
= 

LogManager $
.$ %
	GetLogger% .
(. /
logger/ 5
.5 6
FullName6 >
??? A
stringB H
.H I
EmptyI N
)N O
;O P
if 
( 
! 
string 
. 
IsNullOrWhiteSpace *
(* +
mensaje+ 2
)2 3
)3 4
{ 
nlogger 
. 
Info 
( 
mensaje $
)$ %
;% &
} 
}   	
public'' 
static'' 
void'' 

LogWarning'' %
(''% &
Type''& *
logger''+ 1
,''1 2
string''3 9
mensaje'': A
)''A B
{(( 	!
ArgumentNullException)) !
.))! "
ThrowIfNull))" -
())- .
logger)). 4
)))4 5
;))5 6
var++ 
nlogger++ 
=++ 

LogManager++ $
.++$ %
	GetLogger++% .
(++. /
logger++/ 5
.++5 6
FullName++6 >
??++? A
string++B H
.++H I
Empty++I N
)++N O
;++O P
if-- 
(-- 
!-- 
string-- 
.-- 
IsNullOrWhiteSpace-- *
(--* +
mensaje--+ 2
)--2 3
)--3 4
{.. 
nlogger// 
.// 
Warn// 
(// 
mensaje// $
)//$ %
;//% &
}00 
}11 	
public88 
static88 
void88 
LogDebug88 #
(88# $
Type88$ (
logger88) /
,88/ 0
string881 7
mensaje888 ?
)88? @
{99 	!
ArgumentNullException:: !
.::! "
ThrowIfNull::" -
(::- .
logger::. 4
)::4 5
;::5 6
var<< 
nlogger<< 
=<< 

LogManager<< $
.<<$ %
	GetLogger<<% .
(<<. /
logger<</ 5
.<<5 6
FullName<<6 >
??<<? A
string<<B H
.<<H I
Empty<<I N
)<<N O
;<<O P
if>> 
(>> 
!>> 
string>> 
.>> 
IsNullOrWhiteSpace>> *
(>>* +
mensaje>>+ 2
)>>2 3
)>>3 4
{?? 
nlogger@@ 
.@@ 
Debug@@ 
(@@ 
mensaje@@ %
)@@% &
;@@& '
}AA 
}BB 	
publicII 
staticII 
voidII 
LogErrorII #
(II# $
TypeII$ (
loggerII) /
,II/ 0
stringII1 7
mensajeII8 ?
)II? @
{JJ 	!
ArgumentNullExceptionKK !
.KK! "
ThrowIfNullKK" -
(KK- .
loggerKK. 4
)KK4 5
;KK5 6
varMM 
nloggerMM 
=MM 

LogManagerMM $
.MM$ %
	GetLoggerMM% .
(MM. /
loggerMM/ 5
.MM5 6
FullNameMM6 >
??MM? A
stringMMB H
.MMH I
EmptyMMI N
)MMN O
;MMO P
ifOO 
(OO 
!OO 
stringOO 
.OO 
IsNullOrWhiteSpaceOO *
(OO* +
mensajeOO+ 2
)OO2 3
)OO3 4
{PP 
nloggerQQ 
.QQ 
ErrorQQ 
(QQ 
$"QQ  
{QQ  !
_redAsciiColorQQ! /
}QQ/ 0
{QQ0 1
mensajeQQ1 8
}QQ8 9
"QQ9 :
)QQ: ;
;QQ; <
}RR 
}SS 	
}TT 
}UU ∂
dC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Security\Logger\IAppLogger.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Security! )
.) *
Logger* 0
{ 
public 

	interface 

IAppLogger 
<  
T  !
>! "
{ 

IAppLogger 
< 
T 
> 
Debug 
( 
params "
object# )
?) *
[* +
]+ ,
messages- 5
)5 6
;6 7

IAppLogger 
< 
T 
> 
Info 
( 
params !
object" (
?( )
[) *
]* +
messages, 4
)4 5
;5 6

IAppLogger$$ 
<$$ 
T$$ 
>$$ 
LogError$$ 
($$ 
params$$ %
object$$& ,
?$$, -
[$$- .
]$$. /
messages$$0 8
)$$8 9
;$$9 :

IAppLogger++ 
<++ 
T++ 
>++ 
LogError++ 
(++ 
	Exception++ (
ex++) +
)+++ ,
;++, -

IAppLogger33 
<33 
T33 
>33 
LogError33 
(33 
	Exception33 (
ex33) +
,33+ ,
string33- 3
message334 ;
)33; <
;33< =
(:: 	
Guid::	 
	ProcessId:: 
,:: 
	Stopwatch:: "
	Stopwatch::# ,
)::, -
StartProcess::. :
(::: ;
[::; <
CallerMemberName::< L
]::L M
string::N T

methodName::U _
=::` a
$str::b d
)::d e
;::e f
(BB 	
GuidBB	 
	ProcessIdBB 
,BB 
	StopwatchBB "
	StopwatchBB# ,
)BB, -
StartProcessBB. :
(BB: ;
objectBB; A
inputBBB G
,BBG H
[BBI J
CallerMemberNameBBJ Z
]BBZ [
stringBB\ b

methodNameBBc m
=BBn o
$strBBp r
)BBr s
;BBs t
voidJJ 

EndProcessJJ 
(JJ 
GuidJJ 
idJJ 
,JJ  
	StopwatchJJ! *
swJJ+ -
,JJ- .
[JJ/ 0
CallerMemberNameJJ0 @
]JJ@ A
stringJJB H

methodNameJJI S
=JJT U
$strJJV X
)JJX Y
;JJY Z
voidSS 

EndProcessSS 
(SS 
GuidSS 
idSS 
,SS  
	StopwatchSS! *
swSS+ -
,SS- .
objectSS/ 5
outputSS6 <
,SS< =
[SS> ?
CallerMemberNameSS? O
]SSO P
stringSSQ W

methodNameSSX b
=SSc d
$strSSe g
)SSg h
;SSh i
}TT 
}UU æT
iC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Security\Logger\BciExceptionLog.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Security! )
.) *
Logger* 0
{ 
public 

class 
BciExceptionLog  
{ 
private 
const 
string 
_redAsciiColor +
=, -
$str. 8
;8 9
public 
static 
bool "
ContieneInnerException 1
(1 2
	Exception2 ;
ex< >
)> ?
{ 	!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
ex. 0
)0 1
;1 2
return 
ex 
. 
InnerException $
?$ %
.% &
InnerException& 4
!=5 7
null8 <
;< =
} 	
public## 
static## 
string## (
ObtenerMensajeInnerException## 9
(##9 :
	Exception##: C
ex##D F
)##F G
{$$ 	!
ArgumentNullException%% !
.%%! "
ThrowIfNull%%" -
(%%- .
ex%%. 0
)%%0 1
;%%1 2
var'' 
mensajeInner'' 
='' 
string'' %
.''% &
Empty''& +
;''+ ,
if)) 
()) 
ex)) 
.)) 
InnerException)) !
!=))" $
null))% )
)))) *
{** 
mensajeInner++ 
=++ 
ex++ !
.++! "
InnerException++" 0
.++0 1
Message++1 8
;++8 9
if,, 
(,, 
ex,, 
.,, 
InnerException,, %
.,,% &
InnerException,,& 4
!=,,5 7
null,,8 <
),,< =
{-- 
mensajeInner..  
+=..! #
$str..$ )
+..* +
ex.., .
.... /
InnerException../ =
...= >
InnerException..> L
...L M
Message..M T
;..T U
}// 
}00 
return22 
mensajeInner22 
;22  
}33 	
public:: 
static:: 
void:: 
LogInformativo:: )
(::) *
string::* 0
mensaje::1 8
,::8 9
Type::: >
tipo::? C
)::C D
{;; 	
StaticLogger<< 
.<< 
LogInfo<<  
(<<  !
tipo<<! %
,<<% &
mensaje<<' .
)<<. /
;<</ 0
}== 	
publicEE 
	ExceptionEE 
RecibirExcepcionEE )
(EE) *
	ExceptionEE* 3
exEE4 6
,EE6 7
TypeEE8 <
loggerEE= C
)EEC D
{FF 	!
ArgumentNullExceptionGG !
.GG! "
ThrowIfNullGG" -
(GG- .
exGG. 0
)GG0 1
;GG1 2!
ArgumentNullExceptionHH !
.HH! "
ThrowIfNullHH" -
(HH- .
loggerHH. 4
)HH4 5
;HH5 6
varJJ 
nLogJJ 
=JJ 
thisJJ 
.JJ 
GetTypeJJ #
(JJ# $
)JJ$ %
;JJ% &
stringLL 
origenExcepcionLL "
=LL# $
exLL% '
.LL' (
SourceLL( .
??LL/ 1
$strLL2 G
;LLG H
stringMM 
mensajeExceptionMM #
=MM$ %
exMM& (
.MM( )
MessageMM) 0
;MM0 1
stringNN 
?NN 
stackTraceExcepcionNN '
=NN( )
exNN* ,
.NN, -

StackTraceNN- 7
??NN8 :
$strNN; U
;NNU V

MethodBaseOO 
?OO 
targetSiteExcepcionOO +
=OO, -
exOO. 0
.OO0 1

TargetSiteOO1 ;
;OO; <
intPP 
excepcionIdPP 
=PP 
exPP  
.PP  !
HResultPP! (
;PP( )
stringQQ 
mensajeInnerExQQ !
=QQ" #
exQQ$ &
.QQ& '
InnerExceptionQQ' 5
?QQ5 6
.QQ6 7
MessageQQ7 >
??QQ? A
stringQQB H
.QQH I
EmptyQQI N
;QQN O
ifSS 
(SS "
ContieneInnerExceptionSS &
(SS& '
exSS' )
)SS) *
)SS* +
{TT 
mensajeInnerExUU 
=UU  (
ObtenerMensajeInnerExceptionUU! =
(UU= >
exUU> @
)UU@ A
;UUA B
}VV 
varXX 
	mensajeExXX 
=XX 
ConstruirMensajeXX ,
(XX, -
origenExcepcionYY 
,YY  
mensajeExceptionZZ  
,ZZ  !
stackTraceExcepcion[[ #
,[[# $
targetSiteExcepcion\\ #
,\\# $
excepcionId]] 
,]] 
mensajeInnerEx^^ 
)^^ 
;^^  
LogParaExcepcion`` 
(`` 
	mensajeEx`` &
,``& '
nLog``( ,
)``, -
;``- .
returnbb 
exbb 
;bb 
}cc 	
privateee 
staticee 
voidee 
LogParaExcepcionee ,
(ee, -
stringee- 3
	mensajeExee4 =
,ee= >
Typeee? C
nLogeeD H
)eeH I
{ff 	
StaticLoggergg 
.gg 
LogErrorgg !
(gg! "
nLoggg" &
,gg& '
	mensajeExgg( 1
)gg1 2
;gg2 3
}hh 	
privatejj 
staticjj 
stringjj 
ConstruirMensajejj .
(jj. /
stringkk 
origenExcepcionkk "
,kk" #
stringll 
mensajeExceptionll #
,ll# $
stringmm 
stackTraceExcepcionmm &
,mm& '

MethodBasenn 
?nn 
targetSiteExcepcionnn +
,nn+ ,
intoo 
excepcionIdoo 
,oo 
stringpp 
mensajeInnerExpp !
)pp! "
{qq 	
varrr 
mensajeFormateadorr !
=rr" #
newrr$ '
StringBuilderrr( 5
(rr5 6
)rr6 7
;rr7 8
mensajeFormateadott 
.tt 

AppendLinett (
(tt( )
CultureInfott) 4
.tt4 5
InvariantCulturett5 E
,ttE F
$"ttG I
{ttI J
_redAsciiColorttJ X
}ttX Y
$str	ttY Ä
"
ttÄ Å
)
ttÅ Ç
;
ttÇ É
mensajeFormateadouu 
.uu 

AppendLineuu (
(uu( )
CultureInfouu) 4
.uu4 5
InvariantCultureuu5 E
,uuE F
$"uuG I
{uuI J
_redAsciiColoruuJ X
}uuX Y
$struuY l
"uul m
)uum n
;uun o
mensajeFormateadovv 
.vv 

AppendLinevv (
(vv( )
CultureInfovv) 4
.vv4 5
InvariantCulturevv5 E
,vvE F
$"vvG I
{vvI J
_redAsciiColorvvJ X
}vvX Y
$str	vvY Ä
"
vvÄ Å
)
vvÅ Ç
;
vvÇ É
mensajeFormateadoww 
.ww 

AppendLineww (
(ww( )
CultureInfoww) 4
.ww4 5
InvariantCultureww5 E
,wwE F
$"wwG I
{wwI J
_redAsciiColorwwJ X
}wwX Y
$strwwY _
{ww_ `
origenExcepcionww` o
}wwo p
"wwp q
)wwq r
;wwr s
mensajeFormateadoxx 
.xx 

AppendLinexx (
(xx( )
CultureInfoxx) 4
.xx4 5
InvariantCulturexx5 E
,xxE F
$"xxG I
{xxI J
_redAsciiColorxxJ X
}xxX Y
$strxxY b
{xxb c
mensajeExceptionxxc s
}xxs t
"xxt u
)xxu v
;xxv w
mensajeFormateadoyy 
.yy 

AppendLineyy (
(yy( )
CultureInfoyy) 4
.yy4 5
InvariantCultureyy5 E
,yyE F
$"yyG I
{yyI J
_redAsciiColoryyJ X
}yyX Y
$stryyY b
{yyb c
excepcionIdyyc n
}yyn o
"yyo p
)yyp q
;yyq r
mensajeFormateadozz 
.zz 

AppendLinezz (
(zz( )
CultureInfozz) 4
.zz4 5
InvariantCulturezz5 E
,zzE F
$"zzG I
{zzI J
_redAsciiColorzzJ X
}zzX Y
$strzzY f
{zzf g
targetSiteExcepcionzzg z
?zzz {
.zz{ |
ToString	zz| Ñ
(
zzÑ Ö
)
zzÖ Ü
??
zzá â
$str
zzä è
}
zzè ê
"
zzê ë
)
zzë í
;
zzí ì
if|| 
(|| 
!|| 
string|| 
.|| 
IsNullOrEmpty|| %
(||% &
mensajeInnerEx||& 4
)||4 5
)||5 6
{}} 
mensajeFormateado~~ !
.~~! "

AppendLine~~" ,
(~~, -
CultureInfo~~- 8
.~~8 9
InvariantCulture~~9 I
,~~I J
$"~~K M
{~~M N
_redAsciiColor~~N \
}~~\ ]
$str~~] n
{~~n o
mensajeInnerEx~~o }
}~~} ~
"~~~ 
)	~~ Ä
;
~~Ä Å
} 
mensajeFormateado
ÅÅ 
.
ÅÅ 

AppendLine
ÅÅ (
(
ÅÅ( )
CultureInfo
ÅÅ) 4
.
ÅÅ4 5
InvariantCulture
ÅÅ5 E
,
ÅÅE F
$"
ÅÅG I
{
ÅÅI J
_redAsciiColor
ÅÅJ X
}
ÅÅX Y
$str
ÅÅY e
"
ÅÅe f
)
ÅÅf g
;
ÅÅg h
mensajeFormateado
ÇÇ 
.
ÇÇ 

AppendLine
ÇÇ (
(
ÇÇ( )!
stackTraceExcepcion
ÇÇ) <
?
ÇÇ< =
.
ÇÇ= >
Replace
ÇÇ> E
(
ÇÇE F
$str
ÇÇF K
,
ÇÇK L
$"
ÇÇM O
{
ÇÇO P
_redAsciiColor
ÇÇP ^
}
ÇÇ^ _
$str
ÇÇ_ c
"
ÇÇc d
,
ÇÇd e
StringComparison
ÇÇf v
.
ÇÇv w
Ordinal
ÇÇw ~
)
ÇÇ~ 
)ÇÇ Ä
;ÇÇÄ Å
mensajeFormateado
ÉÉ 
.
ÉÉ 

AppendLine
ÉÉ (
(
ÉÉ( )
CultureInfo
ÉÉ) 4
.
ÉÉ4 5
InvariantCulture
ÉÉ5 E
,
ÉÉE F
$"
ÉÉG I
{
ÉÉI J
_redAsciiColor
ÉÉJ X
}
ÉÉX Y
$strÉÉY Ä
"ÉÉÄ Å
)ÉÉÅ Ç
;ÉÉÇ É
return
ÖÖ 
mensajeFormateado
ÖÖ $
.
ÖÖ$ %
ToString
ÖÖ% -
(
ÖÖ- .
)
ÖÖ. /
;
ÖÖ/ 0
}
ÜÜ 	
}
áá 
}àà ãé
cC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Security\Logger\AppLogger.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Security! )
.) *
Logger* 0
{ 
public 

class 
	AppLogger 
< 
T 
> 
: 

IAppLogger  *
<* +
T+ ,
>, -
{ 
private 
const 
string 
_blueAsciiColor ,
=- .
$str/ 9
;9 :
private 
const 
string 
_greenAsciiColor -
=. /
$str0 :
;: ;
private 
const 
string 
_redAsciiColor +
=, -
$str. 8
;8 9
private 
static 
readonly 
string  &
_genericName' 3
=4 5
typeof6 <
(< =
T= >
)> ?
.? @
Name@ D
;D E
private   
static   
readonly   !
JsonSerializerOptions    5"
_jsonSerializerOptions  6 L
=  M N
new  O R
(  R S
)  S T
{!! 	 
PropertyNamingPolicy""  
=""! "
JsonNamingPolicy""# 3
.""3 4
	CamelCase""4 =
,""= >
Encoder## 
=## 
JavaScriptEncoder## '
.##' (%
UnsafeRelaxedJsonEscaping##( A
,##A B
}$$ 	
;$$	 

private'' 
static'' 
readonly'' 
Action''  &
<''& '
ILogger''' .
,''. /
string''0 6
,''6 7
	Exception''8 A
?''A B
>''B C
_logDebugMessage''D T
=''U V
LoggerMessage(( 
.(( 
Define((  
<((  !
string((! '
>((' (
(((( )
LogLevel)) 
.)) 
Debug)) 
,)) 
new** 
EventId** 
(** 
$num** 
,** 
nameof** %
(**% &
Debug**& +
)**+ ,
)**, -
,**- .
$str++ 
)++ 
;++ 
private-- 
static-- 
readonly-- 
Action--  &
<--& '
ILogger--' .
,--. /
string--0 6
,--6 7
	Exception--8 A
?--A B
>--B C
_logInfoMessage--D S
=--T U
LoggerMessage.. 
... 
Define..  
<..  !
string..! '
>..' (
(..( )
LogLevel// 
.// 
Information// $
,//$ %
new00 
EventId00 
(00 
$num00 
,00 
nameof00 %
(00% &
Info00& *
)00* +
)00+ ,
,00, -
$str11 
)11 
;11 
private33 
static33 
readonly33 
Action33  &
<33& '
ILogger33' .
,33. /
string330 6
,336 7
	Exception338 A
?33A B
>33B C
_logErrorMessage33D T
=33U V
LoggerMessage44 
.44 
Define44  
<44  !
string44! '
>44' (
(44( )
LogLevel55 
.55 
Error55 
,55 
new66 
EventId66 
(66 
$num66 
,66 
nameof66 %
(66% &
LogError66& .
)66. /
)66/ 0
,660 1
$str77 
)77 
;77 
private99 
static99 
readonly99 
Action99  &
<99& '
ILogger99' .
,99. /
string990 6
,996 7
	Exception998 A
?99A B
>99B C
_logKeyMessage99D R
=99S T
LoggerMessage:: 
.:: 
Define::  
<::  !
string::! '
>::' (
(::( )
LogLevel;; 
.;; 
Information;; $
,;;$ %
new<< 
EventId<< 
(<< 
$num<< 
,<< 
$str<< '
)<<' (
,<<( )
$str== 
)== 
;== 
private?? 
readonly?? 
ILogger??  
<??  !
T??! "
>??" #
_logger??$ +
;??+ ,
private@@ 
string@@ 
_key@@ 
=@@ 
_genericName@@ *
;@@* +
publicFF 
	AppLoggerFF 
(FF 
ILoggerFF  
<FF  !
TFF! "
>FF" #
loggerFF$ *
)FF* +
{GG 	
thisHH 
.HH 
_loggerHH 
=HH 
loggerHH !
;HH! "
}II 	
publicPP 

IAppLoggerPP 
<PP 
TPP 
>PP 
DebugPP "
(PP" #
paramsPP# )
objectPP* 0
?PP0 1
[PP1 2
]PP2 3
messagesPP4 <
)PP< =
=>PP> @
thisPPA E
.PPE F
LogPPF I
(PPI J
LogLevelPPJ R
.PPR S
DebugPPS X
,PPX Y
messagesPPZ b
)PPb c
;PPc d
publicWW 

IAppLoggerWW 
<WW 
TWW 
>WW 
InfoWW !
(WW! "
paramsWW" (
objectWW) /
?WW/ 0
[WW0 1
]WW1 2
messagesWW3 ;
)WW; <
=>WW= ?
thisWW@ D
.WWD E
LogWWE H
(WWH I
LogLevelWWI Q
.WWQ R
InformationWWR ]
,WW] ^
messagesWW_ g
)WWg h
;WWh i
public^^ 

IAppLogger^^ 
<^^ 
T^^ 
>^^ 
LogError^^ %
(^^% &
params^^& ,
object^^- 3
?^^3 4
[^^4 5
]^^5 6
messages^^7 ?
)^^? @
=>^^A C
this^^D H
.^^H I
Log^^I L
(^^L M
LogLevel^^M U
.^^U V
Error^^V [
,^^[ \
messages^^] e
)^^e f
;^^f g
publicee 

IAppLoggeree 
<ee 
Tee 
>ee 
LogErroree %
(ee% &
	Exceptionee& /
exee0 2
)ee2 3
{ff 	!
ArgumentNullExceptiongg !
.gg! "
ThrowIfNullgg" -
(gg- .
exgg. 0
)gg0 1
;gg1 2
_logErrorMessagejj 
(jj 
thisjj !
.jj! "
_loggerjj" )
,jj) *
$"jj+ -
{jj- .
_redAsciiColorjj. <
}jj< =
$strjj= H
{jjH I
exjjI K
.jjK L
MessagejjL S
}jjS T
"jjT U
,jjU V
exjjW Y
)jjY Z
;jjZ [
thismm 
.mm 
BaseErrorLogsmm 
(mm 
exmm !
)mm! "
;mm" #
returnoo 
thisoo 
;oo 
}pp 	
publicxx 

IAppLoggerxx 
<xx 
Txx 
>xx 
LogErrorxx %
(xx% &
	Exceptionxx& /
exxx0 2
,xx2 3
stringxx4 :
messagexx; B
)xxB C
{yy 	!
ArgumentNullExceptionzz !
.zz! "
ThrowIfNullzz" -
(zz- .
exzz. 0
)zz0 1
;zz1 2!
ArgumentNullException{{ !
.{{! "
ThrowIfNull{{" -
({{- .
message{{. 5
){{5 6
;{{6 7
_logErrorMessage~~ 
(~~ 
this~~ !
.~~! "
_logger~~" )
,~~) *
$"~~+ -
{~~- .
_redAsciiColor~~. <
}~~< =
{~~= >
message~~> E
}~~E F
$str~~F H
{~~H I
ex~~I K
.~~K L
Message~~L S
}~~S T
"~~T U
,~~U V
ex~~W Y
)~~Y Z
;~~Z [
this
ÅÅ 
.
ÅÅ 
BaseErrorLogs
ÅÅ 
(
ÅÅ 
ex
ÅÅ !
)
ÅÅ! "
;
ÅÅ" #
return
ÉÉ 
this
ÉÉ 
;
ÉÉ 
}
ÑÑ 	
public
ãã 
(
ãã 
Guid
ãã 
	ProcessId
ãã 
,
ãã 
	Stopwatch
ãã  )
	Stopwatch
ãã* 3
)
ãã3 4
StartProcess
ãã5 A
(
ããA B
string
ããB H

methodName
ããI S
=
ããT U
$str
ããV X
)
ããX Y
{
åå 	
var
çç 
id
çç 
=
çç 
Guid
çç 
.
çç 
NewGuid
çç !
(
çç! "
)
çç" #
;
çç# $
var
éé 
correlationId
éé 
=
éé 
NLog
éé  $
.
éé$ %
ScopeContext
éé% 1
.
éé1 2
TryGetProperty
éé2 @
(
éé@ A
$str
ééA O
,
ééO P
out
ééQ T
var
ééU X
value
ééY ^
)
éé^ _
&&
éé` b
value
ééc h
!=
ééi k
null
éél p
?
èè 
value
èè 
.
èè 
ToString
èè  
(
èè  !
)
èè! "
:
êê 
$str
êê 
;
êê 
this
ëë 
.
ëë 
_key
ëë 
=
ëë 
$"
ëë 
{
ëë 
_genericName
ëë '
}
ëë' (
$str
ëë( )
{
ëë) *
correlationId
ëë* 7
}
ëë7 8
$str
ëë8 9
{
ëë9 :
id
ëë: <
}
ëë< =
"
ëë= >
;
ëë> ?
this
íí 
.
íí 
Info
íí 
(
íí 
$"
íí 
$str
íí /
{
íí/ 0

methodName
íí0 :
}
íí: ;
"
íí; <
)
íí< =
;
íí= >
return
ìì 
(
ìì 
id
ìì 
,
ìì 
	Stopwatch
ìì !
.
ìì! "
StartNew
ìì" *
(
ìì* +
)
ìì+ ,
)
ìì, -
;
ìì- .
}
îî 	
public
úú 
(
úú 
Guid
úú 
	ProcessId
úú 
,
úú 
	Stopwatch
úú  )
	Stopwatch
úú* 3
)
úú3 4
StartProcess
úú5 A
(
úúA B
object
úúB H
input
úúI N
,
úúN O
string
úúP V

methodName
úúW a
=
úúb c
$str
úúd f
)
úúf g
{
ùù 	
this
ûû 
.
ûû 
Info
ûû 
(
ûû 
$str
ûû &
)
ûû& '
;
ûû' (
this
üü 
.
üü 
Debug
üü 
(
üü 
input
üü 
)
üü 
;
üü 
return
†† 
this
†† 
.
†† 
StartProcess
†† $
(
††$ %

methodName
††% /
)
††/ 0
;
††0 1
}
°° 	
public
©© 
void
©© 

EndProcess
©© 
(
©© 
Guid
©© #
id
©©$ &
,
©©& '
	Stopwatch
©©( 1
sw
©©2 4
,
©©4 5
string
©©6 <

methodName
©©= G
=
©©H I
$str
©©J L
)
©©L M
{
™™ 	#
ArgumentNullException
´´ !
.
´´! "
ThrowIfNull
´´" -
(
´´- .
sw
´´. 0
)
´´0 1
;
´´1 2
sw
≠≠ 
.
≠≠ 
Stop
≠≠ 
(
≠≠ 
)
≠≠ 
;
≠≠ 
this
ÆÆ 
.
ÆÆ 
Info
ÆÆ 
(
ÆÆ 
$"
ÆÆ 
$str
ÆÆ -
{
ÆÆ- .

methodName
ÆÆ. 8
}
ÆÆ8 9
$str
ÆÆ9 A
{
ÆÆA B
sw
ÆÆB D
.
ÆÆD E
Elapsed
ÆÆE L
.
ÆÆL M
TotalMilliseconds
ÆÆM ^
}
ÆÆ^ _
$str
ÆÆ_ a
"
ÆÆa b
)
ÆÆb c
;
ÆÆc d
}
ØØ 	
public
∏∏ 
void
∏∏ 

EndProcess
∏∏ 
(
∏∏ 
Guid
∏∏ #
id
∏∏$ &
,
∏∏& '
	Stopwatch
∏∏( 1
sw
∏∏2 4
,
∏∏4 5
object
∏∏6 <
output
∏∏= C
,
∏∏C D
string
∏∏E K

methodName
∏∏L V
=
∏∏W X
$str
∏∏Y [
)
∏∏[ \
{
ππ 	
this
∫∫ 
.
∫∫ 

EndProcess
∫∫ 
(
∫∫ 
id
∫∫ 
,
∫∫ 
sw
∫∫  "
,
∫∫" #

methodName
∫∫$ .
)
∫∫. /
;
∫∫/ 0
this
ªª 
.
ªª 
Info
ªª 
(
ªª 
$str
ªª '
)
ªª' (
;
ªª( )
this
ºº 
.
ºº 
Debug
ºº 
(
ºº 
output
ºº 
)
ºº 
;
ºº 
}
ΩΩ 	
private
øø 
static
øø 
string
øø 
[
øø 
]
øø 
ProcessMessages
øø  /
(
øø/ 0
params
øø0 6
object
øø7 =
?
øø= >
[
øø> ?
]
øø? @
messages
øøA I
)
øøI J
{
¿¿ 	
return
¡¡ 
messages
¡¡ 
.
¬¬ 
Where
¬¬ 
(
¬¬ 
m
¬¬ 
=>
¬¬ 
m
¬¬ 
is
¬¬  
not
¬¬! $
null
¬¬% )
)
¬¬) *
.
√√ 
Select
√√ 
(
√√ 
m
√√ 
=>
√√ 
m
√√ 
as
√√ !
string
√√" (
??
√√) +
JsonSerializer
√√, :
.
√√: ;
	Serialize
√√; D
(
√√D E
m
√√E F
,
√√F G$
_jsonSerializerOptions
√√H ^
)
√√^ _
)
√√_ `
.
ƒƒ 
ToArray
ƒƒ 
(
ƒƒ 
)
ƒƒ 
;
ƒƒ 
}
≈≈ 	
private
«« 
void
«« 
BaseErrorLogs
«« "
(
««" #
	Exception
««# ,
ex
««- /
)
««/ 0
{
»» 	
new
…… 
BciExceptionLog
…… 
(
……  
)
……  !
.
……! "
RecibirExcepcion
……" 2
(
……2 3
ex
……3 5
,
……5 6
this
……7 ;
.
……; <
GetType
……< C
(
……C D
)
……D E
)
……E F
;
……F G
}
   	
[
ÃÃ 	
System
ÃÃ	 
.
ÃÃ 
Diagnostics
ÃÃ 
.
ÃÃ 
CodeAnalysis
ÃÃ (
.
ÃÃ( )
SuppressMessage
ÃÃ) 8
(
ÃÃ8 9
$str
ÃÃ9 F
,
ÃÃF G
$strÃÃH ä
,ÃÃä ã
JustificationÃÃå ô
=ÃÃö õ
$strÃÃú Ä
)ÃÃÄ Å
]ÃÃÅ Ç
private
ŒŒ 

IAppLogger
ŒŒ 
<
ŒŒ 
T
ŒŒ 
>
ŒŒ 
Log
ŒŒ !
(
ŒŒ! "
LogLevel
ŒŒ" *
level
ŒŒ+ 0
,
ŒŒ0 1
params
ŒŒ2 8
object
ŒŒ9 ?
?
ŒŒ? @
[
ŒŒ@ A
]
ŒŒA B
messages
ŒŒC K
)
ŒŒK L
{
œœ 	
Action
–– 
<
–– 
ILogger
–– 
,
–– 
string
–– "
,
––" #
	Exception
––$ -
?
––- .
>
––. /
	logAction
––0 9
=
––: ;
level
––< A
switch
––B H
{
—— 
LogLevel
““ 
.
““ 
Debug
““ 
=>
““ !
_logDebugMessage
““" 2
,
““2 3
LogLevel
”” 
.
”” 
Information
”” $
=>
””% '
_logInfoMessage
””( 7
,
””7 8
LogLevel
‘‘ 
.
‘‘ 
Error
‘‘ 
=>
‘‘ !
_logErrorMessage
‘‘" 2
,
‘‘2 3
_
’’ 
=>
’’ 
throw
’’ 
new
’’ )
ArgumentOutOfRangeException
’’ :
(
’’: ;
nameof
’’; A
(
’’A B
level
’’B G
)
’’G H
,
’’H I
level
’’J O
,
’’O P
null
’’Q U
)
’’U V
,
’’V W
}
÷÷ 
;
÷÷ 
var
ÿÿ 
colorPrefix
ÿÿ 
=
ÿÿ 
level
ÿÿ #
switch
ÿÿ$ *
{
ŸŸ 
LogLevel
⁄⁄ 
.
⁄⁄ 
Debug
⁄⁄ 
=>
⁄⁄ !
_blueAsciiColor
⁄⁄" 1
,
⁄⁄1 2
LogLevel
€€ 
.
€€ 
Information
€€ $
=>
€€% '
_greenAsciiColor
€€( 8
,
€€8 9
LogLevel
‹‹ 
.
‹‹ 
Error
‹‹ 
=>
‹‹ !
_redAsciiColor
‹‹" 0
,
‹‹0 1
_
›› 
=>
›› 
string
›› 
.
›› 
Empty
›› !
,
››! "
}
ﬁﬁ 
;
ﬁﬁ 
var
‡‡ 
processedMessages
‡‡ !
=
‡‡" #
ProcessMessages
‡‡$ 3
(
‡‡3 4
messages
‡‡4 <
)
‡‡< =
;
‡‡= >
if
„„ 
(
„„ 
processedMessages
„„ !
.
„„! "
Length
„„" (
>
„„) *
$num
„„+ ,
)
„„, -
{
‰‰ 
_logKeyMessage
ÂÂ 
(
ÂÂ 
this
ÂÂ #
.
ÂÂ# $
_logger
ÂÂ$ +
,
ÂÂ+ ,
$"
ÂÂ- /
{
ÂÂ/ 0
_greenAsciiColor
ÂÂ0 @
}
ÂÂ@ A
$str
ÂÂA D
{
ÂÂD E
this
ÂÂE I
.
ÂÂI J
_key
ÂÂJ N
}
ÂÂN O
"
ÂÂO P
,
ÂÂP Q
null
ÂÂR V
)
ÂÂV W
;
ÂÂW X
}
ÊÊ 
foreach
ÈÈ 
(
ÈÈ 
var
ÈÈ 
message
ÈÈ  
in
ÈÈ! #
processedMessages
ÈÈ$ 5
)
ÈÈ5 6
{
ÍÍ 
	logAction
ÎÎ 
(
ÎÎ 
this
ÎÎ 
.
ÎÎ 
_logger
ÎÎ &
,
ÎÎ& '
$"
ÎÎ( *
{
ÎÎ* +
colorPrefix
ÎÎ+ 6
}
ÎÎ6 7
{
ÎÎ7 8
message
ÎÎ8 ?
}
ÎÎ? @
"
ÎÎ@ A
,
ÎÎA B
null
ÎÎC G
)
ÎÎG H
;
ÎÎH I
}
ÏÏ 
return
ÓÓ 
this
ÓÓ 
;
ÓÓ 
}
ÔÔ 	
}
 
}ÒÒ ≈F
QC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Program.cs
var 
logger 

= 

LogManager 
. 
Setup 
( 
) 
.  %
LoadConfigurationFromFile  9
(9 :
$str: G
)G H
.H I!
GetCurrentClassLoggerI ^
(^ _
)_ `
;` a
logger 
. 
Info 
( 
$str B
)B C
;C D
try 
{ 
var 
builder 
= 
WebApplication  
.  !
CreateBuilder! .
(. /
args/ 3
)3 4
;4 5
Console 
. 
	WriteLine 
( 
$" 
$str %
{% &
builder& -
.- .
Environment. 9
.9 :
EnvironmentName: I
}I J
"J K
)K L
;L M
builder 
. 
Services 
. 
AddCors 
( 
options $
=>% '
{ 
options 
. 
	AddPolicy 
( 
$str $
,$ %
policy& ,
=>- /
{ 	
policy 
. 
AllowAnyOrigin !
(! "
)" #
. 
AllowAnyMethod !
(! "
)" #
. 
AllowAnyHeader !
(! "
)" #
;# $
} 	
)	 

;
 
} 
) 
; 
var!! 
environment!! 
=!! 
builder!! 
.!! 
Environment!! )
.!!) *
EnvironmentName!!* 9
;!!9 :
logger"" 

.""
 
Info"" 
("" 
$""" 
$str"" &
{""& '
environment""' 2
}""2 3
"""3 4
)""4 5
;""5 6
builder'' 
.'' 
Logging'' 
.'' 
ClearProviders'' "
(''" #
)''# $
;''$ %
builder(( 
.(( 
Host(( 
.(( 
UseNLog(( 
((( 
)(( 
;(( 
builder-- 
.-- 
Services-- 
.-- 
AddSingleton-- !
(--! "
typeof--" (
(--( )

IAppLogger--) 3
<--3 4
>--4 5
)--5 6
,--6 7
typeof--8 >
(--> ?
	AppLogger--? H
<--H I
>--I J
)--J K
)--K L
;--L M
builder.. 
... 
Services.. 
... 
AddHealthChecks.. $
(..$ %
)..% &
;..& '
builder33 
.33 
Services33 
.33 
AddControllers33 #
(33# $
)33$ %
;33% &
builder44 
.44 
Services44 
.44 #
AddEndpointsApiExplorer44 ,
(44, -
)44- .
;44. /
builder55 
.55 
Services55 
.55 
AddSwaggerGen55 "
(55" #
)55# $
;55$ %
builder66 
.66 
Services66 
.66 
ConfigureOptions66 %
<66% &#
ConfigureSwaggerOptions66& =
>66= >
(66> ?
)66? @
;66@ A
builder99 
.99 
Services99 
.99 
AddApiVersioning99 %
(99% &
options99& -
=>99. 0
{:: 
options;; 
.;; /
#AssumeDefaultVersionWhenUnspecified;; 3
=;;4 5
true;;6 :
;;;: ;
options<< 
.<< 
DefaultApiVersion<< !
=<<" #
new<<$ '

ApiVersion<<( 2
(<<2 3
$num<<3 4
,<<4 5
$num<<6 7
)<<7 8
;<<8 9
options== 
.== 
ReportApiVersions== !
===" #
true==$ (
;==( )
}>> 
)>> 
.>> 
AddApiExplorer>> 
(>> 
options>> 
=>>>  
{?? 
options@@ 
.@@ 
GroupNameFormat@@ 
=@@  !
$str@@" *
;@@* +
optionsAA 
.AA %
SubstituteApiVersionInUrlAA )
=AA* +
trueAA, 0
;AA0 1
}BB 
)BB 
;BB 
builderEE 
.EE )
AddSeguimientoCadsSettingsMapEE )
(EE) *
)EE* +
;EE+ ,
builderFF 
.FF &
AddSeguimientoCadsServicesFF &
(FF& '
)FF' (
;FF( )
builderGG 
.GG &
AddSeguimientoCadsSecurityGG &
(GG& '
)GG' (
;GG( )
varLL 
appLL 
=LL 
builderLL 
.LL 
BuildLL 
(LL 
)LL 
;LL 
varNN 
providerNN 
=NN 
appNN 
.NN 
ServicesNN 
.NN  
GetRequiredServiceNN  2
<NN2 3*
IApiVersionDescriptionProviderNN3 Q
>NNQ R
(NNR S
)NNS T
;NNT U
appPP 
.PP 

UseSwaggerPP 
(PP 
)PP 
;PP 
appQQ 
.QQ 
UseSwaggerUIQQ 
(QQ 
optionsQQ 
=>QQ 
{RR 
providerSS 
.SS "
ApiVersionDescriptionsSS '
.TT 
OrderByDescendingTT 
(TT 
dTT  
=>TT! #
dTT$ %
.TT% &

ApiVersionTT& 0
)TT0 1
.UU 
SelectUU 
(UU 
descriptionUU 
=>UU  "
(UU# $
descriptionUU$ /
.UU/ 0
	GroupNameUU0 9
,UU9 :
UrlUU; >
:UU> ?
$"UU@ B
$strUUB K
{UUK L
descriptionUUL W
.UUW X
	GroupNameUUX a
}UUa b
$strUUb o
"UUo p
)UUp q
)UUq r
.VV 
ToListVV 
(VV 
)VV 
.WW 
ForEachWW 
(WW 
itemWW 
=>WW 
optionsWW $
.WW$ %
SwaggerEndpointWW% 4
(WW4 5
itemWW5 9
.WW9 :
UrlWW: =
,WW= >
itemWW? C
.WWC D
	GroupNameWWD M
.WWM N
ToUpperInvariantWWN ^
(WW^ _
)WW_ `
)WW` a
)WWa b
;WWb c
}XX 
)XX 
;XX 
app[[ 
.[[ 
UseMiddleware[[ 
<[[ #
CorrelationIdMiddleware[[ -
>[[- .
([[. /
)[[/ 0
;[[0 1
app\\ 
.\\ 
UseMiddleware\\ 
<\\ %
GlobalExceptionMiddleware\\ /
>\\/ 0
(\\0 1
)\\1 2
;\\2 3
app]] 
.]] 
UseCors]] 
(]] 
$str]] 
)]] 
;]] 
app^^ 
.^^ 
UseHttpsRedirection^^ 
(^^ 
)^^ 
;^^ 
app__ 
.__ 
UseAuthentication__ 
(__ 
)__ 
;__ 
app`` 
.`` 
UseAuthorization`` 
(`` 
)`` 
;`` 
appaa 
.aa 
MapHealthChecksaa 
(aa 
$straa !
)aa! "
;aa" #
appbb 
.bb 
MapControllersbb 
(bb 
)bb 
;bb 
awaitdd 	
appdd
 
.dd 
RunAsyncdd 
(dd 
)dd 
.dd 
ConfigureAwaitdd '
(dd' (
falsedd( -
)dd- .
;dd. /
}ee 
catchff 
(ff 
	Exceptionff 
exff 
)ff 
{gg 
varhh 
wrappedhh 
=hh 
newhh %
InvalidOperationExceptionhh /
(hh/ 0
$strhh0 a
,hha b
exhhc e
)hhe f
;hhf g
loggerii 

.ii
 
Fatalii 
(ii 
exii 
,ii 
wrappedii 
.ii 
Messageii $
)ii$ %
;ii% &
throwjj 	
wrappedjj
 
;jj 
}kk 
finallyll 
{mm 
loggernn 

.nn
 
Infonn 
(nn 
$strnn E
)nnE F
;nnF G

LogManageroo 
.oo 
Shutdownoo 
(oo 
)oo 
;oo 
}pp 
publicuu 
partialuu 
classuu 
Programuu 
{vv 
	protectedzz 
Programzz 
(zz 
)zz 
{{{ 
}|| 
}}} ¨
eC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Settings\JwtSettings.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Settings( 0
{ 
public		 

record		 
JwtSettings		 
{

 
public 
string 
Issuer 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
public 
string 
Key 
{ 
get 
;  
set! $
;$ %
}& '
=( )
null* .
!. /
;/ 0
} 
} ≈
ÜC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Settings\ExternalApis\EPSiniestroPorAseguradoSettings.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Settings( 0
.0 1
ExternalApis1 =
{ 
public		 

class		 +
EPSiniestroPorAseguradoSettings		 0
{

 
public 
string 
BasePath 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
string 
Auth 
{ 
get  
;  !
set" %
;% &
}' (
=) *
null+ /
!/ 0
;0 1
public 
string 
TokenCABName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
string 
TokenCABValue #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
null4 8
!8 9
;9 :
public"" 
string"" 

CookieName""  
{""! "
get""# &
;""& '
set""( +
;""+ ,
}""- .
=""/ 0
null""1 5
!""5 6
;""6 7
public'' 
string'' 
CookieValue'' !
{''" #
get''$ '
;''' (
set'') ,
;'', -
}''. /
=''0 1
null''2 6
!''6 7
;''7 8
[,, 	
System,,	 
.,, 
Diagnostics,, 
.,, 
CodeAnalysis,, (
.,,( )
SuppressMessage,,) 8
(,,8 9
$str,,9 A
,,,A B
$str,,C p
,,,p q
Justification,,r 
=
,,Ä Å
$str
,,Ç ≥
)
,,≥ ¥
]
,,¥ µ
public-- 
string-- $
ValidarAccesoMultipleUrl-- .
{--/ 0
get--1 4
;--4 5
set--6 9
;--9 :
}--; <
=--= >
null--? C
!--C D
;--D E
}.. 
}// Ω
ÖC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Settings\ExternalApis\EPGetdatosdelsiniestroSettings.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Settings( 0
.0 1
ExternalApis1 =
{ 
public		 

class		 *
EPGetdatosdelsiniestroSettings		 /
:		0 1
EPBaseSettings		2 @
{

 
public 
string 
	ADCCOName 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
null0 4
!4 5
;5 6
public 
string 

ADCCOValue  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
} 
} Í
uC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Settings\ExternalApis\EPBaseSettings.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Settings( 0
.0 1
ExternalApis1 =
{ 
public		 

class		 
EPBaseSettings		 
{

 
public 
string 
BasePath 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
string 
Auth 
{ 
get  
;  !
set" %
;% &
}' (
=) *
null+ /
!/ 0
;0 1
} 
} ı
sC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Settings\ExternalApis\CadsSettings.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Settings( 0
.0 1
ExternalApis1 =
{ 
public		 

class		 
CadsSettings		 
{

 
public 
string 
BasePath 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
ApiCadsEndpoints 
	Endpoints  )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
null: >
!> ?
;? @
} 
} ü
wC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Settings\ExternalApis\ApiCadsEndpoints.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Settings( 0
.0 1
ExternalApis1 =
{ 
public		 

class		 
ApiCadsEndpoints		 !
{

 
public 
string 
ValidarSessionID &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
null7 ;
!; <
;< =
} 
} „
xC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Siniestros\SiniestrosResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2

Siniestros2 <
{ 
public 

class 
SiniestrosResponse #
{ 
[ 	
JsonPropertyName	 
( 
$str  
)  !
]! "
public 
IReadOnlyCollection "
<" #"
SiniestrosDataResponse# 9
>9 :
?: ;
Data< @
{A B
getC F
;F G
setH K
;K L
}M N
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
string 
? 
Status 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
JsonPropertyName	 
( 
$str &
)& '
]' (
public 
string 
? 

Comentario !
{" #
get$ '
;' (
set) ,
;, -
}. /
[## 	
JsonPropertyName##	 
(## 
$str## %
)##% &
]##& '
public$$ 
int$$ 
?$$ 
	SessionId$$ 
{$$ 
get$$  #
;$$# $
set$$% (
;$$( )
}$$* +
}%% 
}&& “z
C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Siniestros\SiniestrosDetDataResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2

Siniestros2 <
{ 
public 

class %
SiniestrosDetDataResponse *
{ 
public 
int 
NSINIE 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
NPATEN 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
CODVEH 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
TIPVEH 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
CMARCA 
{ 
get  #
;# $
set% (
;( )
}* +
public   
string   
?   
DESMAR   
{   
get    #
;  # $
set  % (
;  ( )
}  * +
public## 
string## 
?## 
CMODEL## 
{## 
get##  #
;### $
set##% (
;##( )
}##* +
public&& 
string&& 
?&& 
DESMOL&& 
{&& 
get&&  #
;&&# $
set&&% (
;&&( )
}&&* +
public)) 
string)) 
?)) 
CODVER)) 
{)) 
get))  #
;))# $
set))% (
;))( )
}))* +
public,, 
string,, 
?,, 
DESVER,, 
{,, 
get,,  #
;,,# $
set,,% (
;,,( )
},,* +
public// 
int// 
FANOFA// 
{// 
get// 
;//  
set//! $
;//$ %
}//& '
public22 
string22 
?22 
FECSIN22 
{22 
get22  #
;22# $
set22% (
;22( )
}22* +
public55 
string55 
?55 
FECAVI55 
{55 
get55  #
;55# $
set55% (
;55( )
}55* +
public88 
string88 
?88 
FechaIngresoSistema88 *
{88+ ,
get88- 0
;880 1
set882 5
;885 6
}887 8
public;; 
string;; 
?;; 
EstadoSiniestro;; &
{;;' (
get;;) ,
;;;, -
set;;. 1
;;;1 2
};;3 4
public>> 
string>> 
?>> 
CCOAF1>> 
{>> 
get>>  #
;>># $
set>>% (
;>>( )
}>>* +
publicAA 
stringAA 
?AA 
CCOAF2AA 
{AA 
getAA  #
;AA# $
setAA% (
;AA( )
}AA* +
publicDD 
stringDD 
?DD 
CCOAF3DD 
{DD 
getDD  #
;DD# $
setDD% (
;DD( )
}DD* +
publicGG 
intGG 
NRUTLIQGG 
{GG 
getGG  
;GG  !
setGG" %
;GG% &
}GG' (
publicJJ 
stringJJ 
?JJ 
DRUTLIQJJ 
{JJ  
getJJ! $
;JJ$ %
setJJ& )
;JJ) *
}JJ+ ,
publicMM 
stringMM 
?MM 
NOMBLIQMM 
{MM  
getMM! $
;MM$ %
setMM& )
;MM) *
}MM+ ,
publicPP 
longPP 
FONOLIQPP 
{PP 
getPP !
;PP! "
setPP# &
;PP& '
}PP( )
publicSS 
stringSS 
?SS 
CELULIQSS 
{SS  
getSS! $
;SS$ %
setSS& )
;SS) *
}SS+ ,
publicVV 
stringVV 
?VV 
EMAILIQVV 
{VV  
getVV! $
;VV$ %
setVV& )
;VV) *
}VV+ ,
publicYY 
intYY 
NrutAboYY 
{YY 
getYY  
;YY  !
setYY" %
;YY% &
}YY' (
public\\ 
string\\ 
?\\ 
DrutAbo\\ 
{\\  
get\\! $
;\\$ %
set\\& )
;\\) *
}\\+ ,
public__ 
string__ 
?__ 
NombrAbo__ 
{__  !
get__" %
;__% &
set__' *
;__* +
}__, -
publicbb 
stringbb 
?bb 
EmailAbobb 
{bb  !
getbb" %
;bb% &
setbb' *
;bb* +
}bb, -
publicee 
stringee 
?ee 
CTPR01ee 
{ee 
getee  #
;ee# $
setee% (
;ee( )
}ee* +
publichh 
stringhh 
?hh 
CLIENTEhh 
{hh  
gethh! $
;hh$ %
sethh& )
;hh) *
}hh+ ,
publickk 
decimalkk 
VTDEDUkk 
{kk 
getkk  #
;kk# $
setkk% (
;kk( )
}kk* +
publicnn 
stringnn 
?nn 
CGRADOnn 
{nn 
getnn  #
;nn# $
setnn% (
;nn( )
}nn* +
publicqq 
stringqq 
?qq 
DESGRAqq 
{qq 
getqq  #
;qq# $
setqq% (
;qq( )
}qq* +
publictt 
stringtt 
?tt 
CCOLISItt 
{tt  
gettt! $
;tt$ %
settt& )
;tt) *
}tt+ ,
publicww 
stringww 
?ww 
COLISIONww 
{ww  !
getww" %
;ww% &
setww' *
;ww* +
}ww, -
publiczz 
stringzz 
?zz 
CROBOzz 
{zz 
getzz "
;zz" #
setzz$ '
;zz' (
}zz) *
public}} 
string}} 
?}} 
IAPARICI}} 
{}}  !
get}}" %
;}}% &
set}}' *
;}}* +
}}}, -
public
ÄÄ 
int
ÄÄ 
CANTERCE
ÄÄ 
{
ÄÄ 
get
ÄÄ !
;
ÄÄ! "
set
ÄÄ# &
;
ÄÄ& '
}
ÄÄ( )
public
ÉÉ 
string
ÉÉ 
?
ÉÉ 
XDEACC
ÉÉ 
{
ÉÉ 
get
ÉÉ  #
;
ÉÉ# $
set
ÉÉ% (
;
ÉÉ( )
}
ÉÉ* +
public
ÜÜ 
string
ÜÜ 
?
ÜÜ 
NOMBRDEN
ÜÜ 
{
ÜÜ  !
get
ÜÜ" %
;
ÜÜ% &
set
ÜÜ' *
;
ÜÜ* +
}
ÜÜ, -
public
ââ 
string
ââ 
?
ââ 
EMAILDEN
ââ 
{
ââ  !
get
ââ" %
;
ââ% &
set
ââ' *
;
ââ* +
}
ââ, -
public
åå 
string
åå 
?
åå 
FONO1DEN
åå 
{
åå  !
get
åå" %
;
åå% &
set
åå' *
;
åå* +
}
åå, -
public
èè 
string
èè 
?
èè 
FONO2DEN
èè 
{
èè  !
get
èè" %
;
èè% &
set
èè' *
;
èè* +
}
èè, -
public
íí 
string
íí 
?
íí 
NOMBRASE
íí 
{
íí  !
get
íí" %
;
íí% &
set
íí' *
;
íí* +
}
íí, -
public
ïï 
string
ïï 
?
ïï 
EMAILASE
ïï 
{
ïï  !
get
ïï" %
;
ïï% &
set
ïï' *
;
ïï* +
}
ïï, -
public
òò 
string
òò 
?
òò 
FONO1ASE
òò 
{
òò  !
get
òò" %
;
òò% &
set
òò' *
;
òò* +
}
òò, -
public
õõ 
string
õõ 
?
õõ 
FONO2ASE
õõ 
{
õõ  !
get
õõ" %
;
õõ% &
set
õõ' *
;
õõ* +
}
õõ, -
public
ûû 
string
ûû 
?
ûû 
IndComunicAse
ûû $
{
ûû% &
get
ûû' *
;
ûû* +
set
ûû, /
;
ûû/ 0
}
ûû1 2
public
°° 
string
°° 
?
°° 
CSUCUR
°° 
{
°° 
get
°°  #
;
°°# $
set
°°% (
;
°°( )
}
°°* +
public
§§ 
string
§§ 
?
§§ 
CRAMO
§§ 
{
§§ 
get
§§ "
;
§§" #
set
§§$ '
;
§§' (
}
§§) *
public
ßß 
string
ßß 
?
ßß 
CTPDOC
ßß 
{
ßß 
get
ßß  #
;
ßß# $
set
ßß% (
;
ßß( )
}
ßß* +
public
™™ 
int
™™ 
NDOCTO
™™ 
{
™™ 
get
™™ 
;
™™  
set
™™! $
;
™™$ %
}
™™& '
public
≠≠ 
int
≠≠ 
NITEM
≠≠ 
{
≠≠ 
get
≠≠ 
;
≠≠ 
set
≠≠  #
;
≠≠# $
}
≠≠% &
public
∞∞ 
int
∞∞ 
NRIESG
∞∞ 
{
∞∞ 
get
∞∞ 
;
∞∞  
set
∞∞! $
;
∞∞$ %
}
∞∞& '
public
≥≥ 
string
≥≥ 
?
≥≥ 
CHASIS
≥≥ 
{
≥≥ 
get
≥≥  #
;
≥≥# $
set
≥≥% (
;
≥≥( )
}
≥≥* +
public
∂∂ 
string
∂∂ 
?
∂∂ 
NMOTOR
∂∂ 
{
∂∂ 
get
∂∂  #
;
∂∂# $
set
∂∂% (
;
∂∂( )
}
∂∂* +
public
ππ 
string
ππ 
?
ππ 
XCOLOR
ππ 
{
ππ 
get
ππ  #
;
ππ# $
set
ππ% (
;
ππ( )
}
ππ* +
public
ºº 
string
ºº 
?
ºº 
NPUERTAS
ºº 
{
ºº  !
get
ºº" %
;
ºº% &
set
ºº' *
;
ºº* +
}
ºº, -
public
øø 
int
øø 
RUTCONDUCTO
øø 
{
øø  
get
øø! $
;
øø$ %
set
øø& )
;
øø) *
}
øø+ ,
public
¬¬ 
string
¬¬ 
?
¬¬ 
DIGCONDUCTO
¬¬ "
{
¬¬# $
get
¬¬% (
;
¬¬( )
set
¬¬* -
;
¬¬- .
}
¬¬/ 0
public
≈≈ 
string
≈≈ 
?
≈≈ 
NOMBRCONDUC
≈≈ "
{
≈≈# $
get
≈≈% (
;
≈≈( )
set
≈≈* -
;
≈≈- .
}
≈≈/ 0
public
»» 
string
»» 
?
»» 
EMAILCONDUC
»» "
{
»»# $
get
»»% (
;
»»( )
set
»»* -
;
»»- .
}
»»/ 0
public
ÀÀ 
string
ÀÀ 
?
ÀÀ 
FONOCONDUC1
ÀÀ "
{
ÀÀ# $
get
ÀÀ% (
;
ÀÀ( )
set
ÀÀ* -
;
ÀÀ- .
}
ÀÀ/ 0
public
ŒŒ 
string
ŒŒ 
?
ŒŒ 
FONOCONDUC2
ŒŒ "
{
ŒŒ# $
get
ŒŒ% (
;
ŒŒ( )
set
ŒŒ* -
;
ŒŒ- .
}
ŒŒ/ 0
public
—— 
string
—— 
?
—— 
DesEtapa
—— 
{
——  !
get
——" %
;
——% &
set
——' *
;
——* +
}
——, -
public
‘‘ 
string
‘‘ 
?
‘‘ 
	MonedaPol
‘‘  
{
‘‘! "
get
‘‘# &
;
‘‘& '
set
‘‘( +
;
‘‘+ ,
}
‘‘- .
public
◊◊ 
decimal
◊◊ 
	PerdEstim
◊◊  
{
◊◊! "
get
◊◊# &
;
◊◊& '
set
◊◊( +
;
◊◊+ ,
}
◊◊- .
public
⁄⁄ 
decimal
⁄⁄ 
	PerdTotal
⁄⁄  
{
⁄⁄! "
get
⁄⁄# &
;
⁄⁄& '
set
⁄⁄( +
;
⁄⁄+ ,
}
⁄⁄- .
public
›› 
string
›› 
?
›› 
NombreTaller
›› #
{
››$ %
get
››& )
;
››) *
set
››+ .
;
››. /
}
››0 1
public
‡‡ 
string
‡‡ 
?
‡‡ 
DireccTaller
‡‡ #
{
‡‡$ %
get
‡‡& )
;
‡‡) *
set
‡‡+ .
;
‡‡. /
}
‡‡0 1
public
„„ 
string
„„ 
?
„„ 
FechaEntrega
„„ #
{
„„$ %
get
„„& )
;
„„) *
set
„„+ .
;
„„. /
}
„„0 1
public
ÊÊ 
string
ÊÊ 
?
ÊÊ 
CodigoEstado
ÊÊ #
{
ÊÊ$ %
get
ÊÊ& )
;
ÊÊ) *
set
ÊÊ+ .
;
ÊÊ. /
}
ÊÊ0 1
public
ÈÈ 
string
ÈÈ 
?
ÈÈ 
FechaAsignacion
ÈÈ &
{
ÈÈ' (
get
ÈÈ) ,
;
ÈÈ, -
set
ÈÈ. 1
;
ÈÈ1 2
}
ÈÈ3 4
public
ÏÏ 
string
ÏÏ 
?
ÏÏ 
DireccionSin
ÏÏ #
{
ÏÏ$ %
get
ÏÏ& )
;
ÏÏ) *
set
ÏÏ+ .
;
ÏÏ. /
}
ÏÏ0 1
public
ÔÔ 
string
ÔÔ 
?
ÔÔ 
CodigoEvento
ÔÔ #
{
ÔÔ$ %
get
ÔÔ& )
;
ÔÔ) *
set
ÔÔ+ .
;
ÔÔ. /
}
ÔÔ0 1
public
ÚÚ 
string
ÚÚ 
?
ÚÚ 
DescriEvento
ÚÚ #
{
ÚÚ$ %
get
ÚÚ& )
;
ÚÚ) *
set
ÚÚ+ .
;
ÚÚ. /
}
ÚÚ0 1
public
ıı 
string
ıı 
?
ıı 
	Comisaria
ıı  
{
ıı! "
get
ıı# &
;
ıı& '
set
ıı( +
;
ıı+ ,
}
ıı- .
public
¯¯ 
string
¯¯ 
?
¯¯ 

FechaConst
¯¯ !
{
¯¯" #
get
¯¯$ '
;
¯¯' (
set
¯¯) ,
;
¯¯, -
}
¯¯. /
public
˚˚ 
int
˚˚ 

FolioConst
˚˚ 
{
˚˚ 
get
˚˚  #
;
˚˚# $
set
˚˚% (
;
˚˚( )
}
˚˚* +
public
˛˛ 
int
˛˛ 
ParrafoConst
˛˛ 
{
˛˛  !
get
˛˛" %
;
˛˛% &
set
˛˛' *
;
˛˛* +
}
˛˛, -
public
ÅÅ 
string
ÅÅ 
?
ÅÅ 
IndFallecido
ÅÅ #
{
ÅÅ$ %
get
ÅÅ& )
;
ÅÅ) *
set
ÅÅ+ .
;
ÅÅ. /
}
ÅÅ0 1
public
ÑÑ 
string
ÑÑ 
?
ÑÑ 
DinamicaSin
ÑÑ "
{
ÑÑ# $
get
ÑÑ% (
;
ÑÑ( )
set
ÑÑ* -
;
ÑÑ- .
}
ÑÑ/ 0
public
áá 
string
áá 
?
áá 
CampoAlerta
áá "
{
áá# $
get
áá% (
;
áá( )
set
áá* -
;
áá- .
}
áá/ 0
public
ää 
int
ää 
RutDenunciante
ää !
{
ää" #
get
ää$ '
;
ää' (
set
ää) ,
;
ää, -
}
ää. /
public
çç 
string
çç 
?
çç 
DvDenunciante
çç $
{
çç% &
get
çç' *
;
çç* +
set
çç, /
;
çç/ 0
}
çç1 2
}
éé 
}èè ˙
C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Siniestros\SiniestrosDetalleResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2

Siniestros2 <
{ 
public 

class %
SiniestrosDetalleResponse *
{ 
[ 	
JsonPropertyName	 
( 
$str  
)  !
]! "
public 
IReadOnlyCollection "
<" #(
SiniestroDetalleDataResponse# ?
>? @
?@ A
DataB F
{G H
getI L
;L M
setN Q
;Q R
}S T
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
string 
? 
Status 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
JsonPropertyName	 
( 
$str &
)& '
]' (
public 
string 
? 

Comentario !
{" #
get$ '
;' (
set) ,
;, -
}. /
["" 	
JsonPropertyName""	 
("" 
$str"" %
)""% &
]""& '
public## 
string## 
?## 
	SessionId##  
{##! "
get### &
;##& '
set##( +
;##+ ,
}##- .
}$$ 
}%% 
|C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Siniestros\SiniestrosDataResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2

Siniestros2 <
{ 
public 

class "
SiniestrosDataResponse '
{ 
[ 	
JsonPropertyName	 
( 
$str '
)' (
]( )
public 
string 
? 
RutCorredor "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
JsonPropertyName	 
( 
$str +
)+ ,
], -
public 
int 
? 
NumeroSiniestro #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
JsonPropertyName	 
( 
$str *
)* +
]+ ,
public 
string 
? 
FechaSiniestro %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[## 	
JsonPropertyName##	 
(## 
$str## )
)##) *
]##* +
public$$ 
string$$ 
?$$ 
FechaDenuncia$$ $
{$$% &
get$$' *
;$$* +
set$$, /
;$$/ 0
}$$1 2
[)) 	
JsonPropertyName))	 
()) 
$str)) (
)))( )
]))) *
public** 
string** 
?** 
CodigoEstado** #
{**$ %
get**& )
;**) *
set**+ .
;**. /
}**0 1
[// 	
JsonPropertyName//	 
(// 
$str// "
)//" #
]//# $
public00 
string00 
?00 
Estado00 
{00 
get00  #
;00# $
set00% (
;00( )
}00* +
[55 	
JsonPropertyName55	 
(55 
$str55 '
)55' (
]55( )
public66 
string66 
?66 
CodigoEtapa66 "
{66# $
get66% (
;66( )
set66* -
;66- .
}66/ 0
[;; 	
JsonPropertyName;;	 
(;; 
$str;; !
);;! "
];;" #
public<< 
string<< 
?<< 
Etapa<< 
{<< 
get<< "
;<<" #
set<<$ '
;<<' (
}<<) *
[AA 	
JsonPropertyNameAA	 
(AA 
$strAA  
)AA  !
]AA! "
publicBB 
stringBB 
?BB 
RamoBB 
{BB 
getBB !
;BB! "
setBB# &
;BB& '
}BB( )
[GG 	
JsonPropertyNameGG	 
(GG 
$strGG (
)GG( )
]GG) *
publicII 
stringII 
?II 
NumeroPolizaII #
{II$ %
getII& )
;II) *
setII+ .
;II. /
}II0 1
[NN 	
JsonPropertyNameNN	 
(NN 
$strNN &
)NN& '
]NN' (
publicOO 
stringOO 
?OO 

NumeroItemOO !
{OO" #
getOO$ '
;OO' (
setOO) ,
;OO, -
}OO. /
[TT 	
JsonPropertyNameTT	 
(TT 
$strTT $
)TT$ %
]TT% &
publicUU 
stringUU 
?UU 
TipoDanoUU 
{UU  !
getUU" %
;UU% &
setUU' *
;UU* +
}UU, -
}VV 
}WW †S
ÇC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Siniestros\SiniestroDetalleDataResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2

Siniestros2 <
{ 
public 

class (
SiniestroDetalleDataResponse -
{ 
[ 	
JsonPropertyName	 
( 
$str )
)) *
]* +
public 
string 
? 
CodigoEmpresa $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
JsonPropertyName	 
( 
$str )
)) *
]* +
public 
string 
? 
NombreEmpresa $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
JsonPropertyName	 
( 
$str +
)+ ,
], -
public 
string 
? 
NumeroSiniestro &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
[## 	
JsonPropertyName##	 
(## 
$str## *
)##* +
]##+ ,
public$$ 
string$$ 
?$$ 
CodigoSucursal$$ %
{$$& '
get$$( +
;$$+ ,
set$$- 0
;$$0 1
}$$2 3
[)) 	
JsonPropertyName))	 
()) 
$str)) /
)))/ 0
]))0 1
public** 
string** 
?** 
CodigoTipoDocumento** *
{**+ ,
get**- 0
;**0 1
set**2 5
;**5 6
}**7 8
[// 	
JsonPropertyName//	 
(// 
$str// +
)//+ ,
]//, -
public00 
string00 
?00 
NumeroDocumento00 &
{00' (
get00) ,
;00, -
set00. 1
;001 2
}003 4
[55 	
JsonPropertyName55	 
(55 
$str55 &
)55& '
]55' (
public66 
string66 
?66 

NumeroItem66 !
{66" #
get66$ '
;66' (
set66) ,
;66, -
}66. /
[;; 	
JsonPropertyName;;	 
(;; 
$str;; (
);;( )
];;) *
public<< 
string<< 
?<< 
NumeroRiesgo<< #
{<<$ %
get<<& )
;<<) *
set<<+ .
;<<. /
}<<0 1
[AA 	
JsonPropertyNameAA	 
(AA 
$strAA &
)AA& '
]AA' (
publicBB 
stringBB 
?BB 

CodigoRamoBB !
{BB" #
getBB$ '
;BB' (
setBB) ,
;BB, -
}BB. /
[GG 	
JsonPropertyNameGG	 
(GG 
$strGG )
)GG) *
]GG* +
publicHH 
stringHH 
?HH 
RutLiquidadorHH $
{HH% &
getHH' *
;HH* +
setHH, /
;HH/ 0
}HH1 2
[MM 	
JsonPropertyNameMM	 
(MM 
$strMM ,
)MM, -
]MM- .
publicNN 
stringNN 
?NN 
NombreLiquidadorNN '
{NN( )
getNN* -
;NN- .
setNN/ 2
;NN2 3
}NN4 5
[SS 	
JsonPropertyNameSS	 
(SS 
$strSS *
)SS* +
]SS+ ,
publicTT 
stringTT 
?TT 
ZonaLiquidadorTT %
{TT& '
getTT( +
;TT+ ,
setTT- 0
;TT0 1
}TT2 3
[YY 	
JsonPropertyNameYY	 
(YY 
$strYY %
)YY% &
]YY& '
publicZZ 
stringZZ 
?ZZ 
	RutTallerZZ  
{ZZ! "
getZZ# &
;ZZ& '
setZZ( +
;ZZ+ ,
}ZZ- .
[__ 	
JsonPropertyName__	 
(__ 
$str__ '
)__' (
]__( )
public`` 
string`` 
?`` 
LocalTaller`` "
{``# $
get``% (
;``( )
set``* -
;``- .
}``/ 0
[ee 	
JsonPropertyNameee	 
(ee 
$stree (
)ee( )
]ee) *
publicff 
stringff 
?ff 
NombreTallerff #
{ff$ %
getff& )
;ff) *
setff+ .
;ff. /
}ff0 1
[kk 	
JsonPropertyNamekk	 
(kk 
$strkk +
)kk+ ,
]kk, -
publicll 
stringll 
?ll 
DireccionTallerll &
{ll' (
getll) ,
;ll, -
setll. 1
;ll1 2
}ll3 4
[qq 	
JsonPropertyNameqq	 
(qq 
$strqq .
)qq. /
]qq/ 0
publicrr 
stringrr 
?rr 
FechaEntradaTallerrr )
{rr* +
getrr, /
;rr/ 0
setrr1 4
;rr4 5
}rr6 7
[ww 	
JsonPropertyNameww	 
(ww 
$strww -
)ww- .
]ww. /
publicxx 
stringxx 
?xx 
FechaSalidaTallerxx (
{xx) *
getxx+ .
;xx. /
setxx0 3
;xx3 4
}xx5 6
[}} 	
JsonPropertyName}}	 
(}} 
$str}} (
)}}( )
]}}) *
public~~ 
string~~ 
?~~ 
DiasEnTaller~~ #
{~~$ %
get~~& )
;~~) *
set~~+ .
;~~. /
}~~0 1
[
ÉÉ 	
JsonPropertyName
ÉÉ	 
(
ÉÉ 
$str
ÉÉ /
)
ÉÉ/ 0
]
ÉÉ0 1
public
ÑÑ 
string
ÑÑ 
?
ÑÑ !
FechaActEstadoEqems
ÑÑ *
{
ÑÑ+ ,
get
ÑÑ- 0
;
ÑÑ0 1
set
ÑÑ2 5
;
ÑÑ5 6
}
ÑÑ7 8
[
ââ 	
JsonPropertyName
ââ	 
(
ââ 
$str
ââ +
)
ââ+ ,
]
ââ, -
public
ää 
string
ää 
?
ää 
EstadoSiniestro
ää &
{
ää' (
get
ää) ,
;
ää, -
set
ää. 1
;
ää1 2
}
ää3 4
[
èè 	
JsonPropertyName
èè	 
(
èè 
$str
èè *
)
èè* +
]
èè+ ,
public
êê 
string
êê 
?
êê 
EtapaSiniestro
êê %
{
êê& '
get
êê( +
;
êê+ ,
set
êê- 0
;
êê0 1
}
êê2 3
[
ïï 	
JsonPropertyName
ïï	 
(
ïï 
$str
ïï (
)
ïï( )
]
ïï) *
public
ññ 
string
ññ 
?
ññ 
RutAsegurado
ññ #
{
ññ$ %
get
ññ& )
;
ññ) *
set
ññ+ .
;
ññ. /
}
ññ0 1
[
õõ 	
JsonPropertyName
õõ	 
(
õõ 
$str
õõ .
)
õõ. /
]
õõ/ 0
public
úú 
string
úú 
?
úú  
FechaIngresoTaller
úú )
{
úú* +
get
úú, /
;
úú/ 0
set
úú1 4
;
úú4 5
}
úú6 7
[
°° 	
JsonPropertyName
°°	 
(
°° 
$str
°° #
)
°°# $
]
°°$ %
public
¢¢ 
string
¢¢ 
?
¢¢ 
Patente
¢¢ 
{
¢¢  
get
¢¢! $
;
¢¢$ %
set
¢¢& )
;
¢¢) *
}
¢¢+ ,
[
ßß 	
JsonPropertyName
ßß	 
(
ßß 
$str
ßß %
)
ßß% &
]
ßß& '
public
®® 
string
®® 
?
®® 
	JefeZonal
®®  
{
®®! "
get
®®# &
;
®®& '
set
®®( +
;
®®+ ,
}
®®- .
[
≠≠ 	
JsonPropertyName
≠≠	 
(
≠≠ 
$str
≠≠ /
)
≠≠/ 0
]
≠≠0 1
public
ÆÆ 
string
ÆÆ 
?
ÆÆ !
ClasificacionTaller
ÆÆ *
{
ÆÆ+ ,
get
ÆÆ- 0
;
ÆÆ0 1
set
ÆÆ2 5
;
ÆÆ5 6
}
ÆÆ7 8
[
≥≥ 	
JsonPropertyName
≥≥	 
(
≥≥ 
$str
≥≥ )
)
≥≥) *
]
≥≥* +
public
¥¥ 
string
¥¥ 
?
¥¥ 
FechaDenuncio
¥¥ $
{
¥¥% &
get
¥¥' *
;
¥¥* +
set
¥¥, /
;
¥¥/ 0
}
¥¥1 2
[
ππ 	
JsonPropertyName
ππ	 
(
ππ 
$str
ππ -
)
ππ- .
]
ππ. /
public
∫∫ 
string
∫∫ 
?
∫∫ 
CodigoEtapaRiesgo
∫∫ (
{
∫∫) *
get
∫∫+ .
;
∫∫. /
set
∫∫0 3
;
∫∫3 4
}
∫∫5 6
[
øø 	
JsonPropertyName
øø	 
(
øø 
$str
øø 2
)
øø2 3
]
øø3 4
public
¿¿ 
string
¿¿ 
?
¿¿ $
DescripcionEtapaRiesgo
¿¿ -
{
¿¿. /
get
¿¿0 3
;
¿¿3 4
set
¿¿5 8
;
¿¿8 9
}
¿¿: ;
[
≈≈ 	
JsonPropertyName
≈≈	 
(
≈≈ 
$str
≈≈ *
)
≈≈* +
]
≈≈+ ,
public
∆∆ 
string
∆∆ 
?
∆∆ 
TipoLiquidador
∆∆ %
{
∆∆& '
get
∆∆( +
;
∆∆+ ,
set
∆∆- 0
;
∆∆0 1
}
∆∆2 3
[
ÀÀ 	
JsonPropertyName
ÀÀ	 
(
ÀÀ 
$str
ÀÀ /
)
ÀÀ/ 0
]
ÀÀ0 1
public
ÃÃ 
string
ÃÃ 
?
ÃÃ !
GlosaTipoLiquidador
ÃÃ *
{
ÃÃ+ ,
get
ÃÃ- 0
;
ÃÃ0 1
set
ÃÃ2 5
;
ÃÃ5 6
}
ÃÃ7 8
[
—— 	
JsonPropertyName
——	 
(
—— 
$str
—— +
)
——+ ,
]
——, -
public
““ 
string
““ 
?
““ 
CodigoCobertura
““ &
{
““' (
get
““) ,
;
““, -
set
““. 1
;
““1 2
}
““3 4
[
◊◊ 	
JsonPropertyName
◊◊	 
(
◊◊ 
$str
◊◊ 0
)
◊◊0 1
]
◊◊1 2
public
ÿÿ 
string
ÿÿ 
?
ÿÿ "
DescripcionCobertura
ÿÿ +
{
ÿÿ, -
get
ÿÿ. 1
;
ÿÿ1 2
set
ÿÿ3 6
;
ÿÿ6 7
}
ÿÿ8 9
}
ŸŸ 
}⁄⁄ •
oC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Http\HttpApiResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2
Http2 6
{ 
public 

class 
HttpApiResponse  
<  !
T! "
>" #
where 
T 
: 
class 
{ 
public 
T 
? 
Data 
{ 
get 
; 
set !
;! "
}# $
public 
HttpStatusCode 

StatusCode (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
bool 
	IsSuccess 
{ 
get  #
;# $
set% (
;( )
}* +
public!! 
string!! 
?!! 
ErrorMessage!! #
{!!$ %
get!!& )
;!!) *
set!!+ .
;!!. /
}!!0 1
public&& 

Dictionary&& 
<&& 
string&&  
,&&  !
string&&" (
>&&( )
ResponseHeaders&&* 9
{&&: ;
get&&< ?
;&&? @
}&&A B
=&&C D
new&&E H
(&&H I
)&&I J
;&&J K
public++ 
long++ 
ResponseTimeMs++ "
{++# $
get++% (
;++( )
set++* -
;++- .
}++/ 0
public00 
string00 
?00 

RawContent00 !
{00" #
get00$ '
;00' (
set00) ,
;00, -
}00. /
}11 
}22 Ú
oC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Cads\UserDataResonse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2
Cads2 6
{ 
public 

class 
UserDataResonse  
{ 
[ 	
JsonPropertyName	 
( 
$str %
)% &
]& '
public 
int 
	IdUsuario 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
string 
? 
Nombre 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
JsonPropertyName	 
( 
$str $
)$ %
]% &
public 
string 
? 
Apellido 
{  !
get" %
;% &
set' *
;* +
}, -
[## 	
JsonPropertyName##	 
(## 
$str## !
)##! "
]##" #
public$$ 
string$$ 
?$$ 
Email$$ 
{$$ 
get$$ "
;$$" #
set$$$ '
;$$' (
}$$) *
}%% 
}&& ò
rC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Responses\Cads\UserAccessResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
	Responses( 1
.1 2
Cads2 6
{ 
public 

class 
UserAccessResponse #
{ 
[ 	
JsonPropertyName	 
( 
$str  
)  !
]! "
public 
UserDataResonse 
? 
Data  $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
JsonPropertyName	 
( 
$str #
)# $
]$ %
public 
string 
? 
Version 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
[## 	
JsonPropertyName##	 
(## 
$str## $
)##$ %
]##% &
public$$ 
string$$ 
?$$ 
HostName$$ 
{$$  !
get$$" %
;$$% &
set$$' *
;$$* +
}$$, -
[)) 	
JsonPropertyName))	 
()) 
$str)) '
)))' (
]))( )
public** 
string** 
?** 
CodeVersion** "
{**# $
get**% (
;**( )
set*** -
;**- .
}**/ 0
}++ 
},, ¡
cC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Requests\TokenData.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Requests( 0
{ 
public 

record 
	TokenData 
{ 
public 
int 
	EsTitular 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
Rol 
{ 
get 
; 
set !
;! "
}# $
public 
int 
Origen 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
	SessionId 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
null0 4
!4 5
;5 6
public 
string 

RutTitular  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
public$$ 
string$$ 
Solicitante$$ !
{$$" #
get$$$ '
;$$' (
set$$) ,
;$$, -
}$$. /
=$$0 1
null$$2 6
!$$6 7
;$$7 8
public)) 
string)) 
Nombres)) 
{)) 
get))  #
;))# $
set))% (
;))( )
}))* +
=)), -
null)). 2
!))2 3
;))3 4
public.. 
string.. 
	Apellidos.. 
{..  !
get.." %
;..% &
set..' *
;..* +
}.., -
=... /
null..0 4
!..4 5
;..5 6
public33 
string33 
Email33 
{33 
get33 !
;33! "
set33# &
;33& '
}33( )
=33* +
null33, 0
!330 1
;331 2
public88 
string88 
TokenOrigen88 !
{88" #
get88$ '
;88' (
set88) ,
;88, -
}88. /
=880 1
null882 6
!886 7
;887 8
}99 
}:: Í
vC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Requests\Siniestros\SiniestrosRequest.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Requests( 0
.0 1

Siniestros1 ;
{ 
public		 

record		 
SiniestrosRequest		 #
{

 
public 
string 
? 
RutAsegurado #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} 
yC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Requests\Siniestros\SiniestrosDetRequest.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Requests( 0
.0 1

Siniestros1 ;
{ 
public 

class  
SiniestrosDetRequest %
{ 
public 
int 
INsinie 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
INdocto 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ˘
jC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Requests\Http\HttpRequest.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Requests( 0
.0 1
Http1 5
{ 
public 

class 
HttpRequest 
{ 
required 
public 
Uri 
Url 
{  !
get" %
;% &
set' *
;* +
}, -
required 
public 

HttpMethod "
Method# )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
string 
? 
BearerToken "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
object 
? 
Body 
{ 
get !
;! "
set# &
;& '
}( )
public$$ 

Dictionary$$ 
<$$ 
string$$  
,$$  !
string$$" (
>$$( )
CustomHeaders$$* 7
{$$8 9
get$$: =
;$$= >
}$$? @
=$$A B
new$$C F
($$F G
)$$G H
;$$H I
public)) 
int)) 
?)) 
TimeoutSeconds)) "
{))# $
get))% (
;))( )
set))* -
;))- .
}))/ 0
public.. 
string.. 
ContentType.. !
{.." #
get..$ '
;..' (
set..) ,
;.., -
}... /
=..0 1
$str..2 D
;..D E
}// 
}00 ã

gC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Requests\GlobalRequest.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Requests( 0
{ 
public 

record 
GlobalRequest 
{ 
public 
string 
? 
Token 
{ 
get "
;" #
set$ '
;' (
}) *
public 
DateTime 
? 

Expiration #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
EOrigen 
? 
Origen 
{  
get! $
;$ %
set& )
;) *
}+ ,
public   
string   

RutaOrigen    
{  ! "
get  # &
;  & '
set  ( +
;  + ,
}  - .
=  / 0
null  1 5
!  5 6
;  6 7
public%% 
string%% 
?%% 
	SessionId%%  
{%%! "
get%%# &
;%%& '
set%%( +
;%%+ ,
}%%- .
}&& 
}'' ë	
tC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Requests\Cads\ValidateAccessRequest.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Requests( 0
.0 1
Cads1 5
{ 
public 

record !
ValidateAccessRequest '
:( )
GlobalRequest* 7
{ 
public 
string 
? 

RutTitular !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
RutSolicitante %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
ERol 
? 
Rol 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
? 
RutCorredor "
{# $
get% (
;( )
set* -
;- .
}/ 0
}   
}!! ¥
[C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Enums\ERol.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Enums( -
{ 
public

 

enum

 
ERol

 
{ 
None 
= 
$num 
, 
Titular 
= 
$num 
, 
Corredor 
= 
$num 
, 
} 
} Ú
^C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Enums\EOrigen.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Enums( -
{ 
public

 

enum

 
EOrigen

 
{ 
None 
= 
$num 
, 
Web 
= 
$num 
, 
App 
= 
$num 
, 
Ofv 
= 
$num 
, 
} 
}   õ

^C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Enums\EClaims.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Enums( -
{ 
public		 

static		 
class		 
EClaims		 
{

 
public 
const 
string 
TokenOrigen '
=( )
nameof* 0
(0 1
TokenOrigen1 <
)< =
;= >
public 
const 
string 
Solicitante '
=( )
nameof* 0
(0 1
Solicitante1 <
)< =
;= >
public 
const 
string 
Nombres #
=$ %
nameof& ,
(, -
Nombres- 4
)4 5
;5 6
public 
const 
string 
	Apellidos %
=& '
nameof( .
(. /
	Apellidos/ 8
)8 9
;9 :
public"" 
const"" 
string"" 
Email"" !
=""" #
nameof""$ *
(""* +
Email""+ 0
)""0 1
;""1 2
}## 
}$$ ∑
qC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\DTOs\Siniestros\TipoSiniestroDto.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
DTOs( ,
., -

Siniestros- 7
{ 
public

 

class

 
TipoSiniestroDto

 !
{ 
public 
string 
Nombre 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
public 
bool 
Visible 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ◊
rC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\DTOs\Siniestros\SiniestrosDataDto.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
DTOs( ,
., -

Siniestros- 7
{ 
public

 

class

 
SiniestrosDataDto

 "
{ 
public 
IList 
< 
TipoSiniestroDto %
>% &
TiposSiniestros' 6
{7 8
get9 <
;< =
}> ?
=@ A
newB E
ListF J
<J K
TipoSiniestroDtoK [
>[ \
(\ ]
)] ^
;^ _
public 
IList 
< 
SiniestroDto !
>! "

Siniestros# -
{. /
get0 3
;3 4
}5 6
=7 8
new9 <
List= A
<A B
SiniestroDtoB N
>N O
(O P
)P Q
;Q R
} 
} å
mC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\DTOs\Siniestros\SiniestroDto.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
DTOs( ,
., -

Siniestros- 7
{ 
public

 

class

 
SiniestroDto

 
{ 
public 
string 
NumSiniestro "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
public 
string 
TipoSinistros #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
public 
string 
GlosaSiniestro $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
public 
string 
FechaDenuncio #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
public## 
string## 
EstadoSinistro## $
{##% &
get##' *
;##* +
set##, /
;##/ 0
}##1 2
=##3 4
string##5 ;
.##; <
Empty##< A
;##A B
public(( 
string(( 
EstadoDenuncio(( $
{((% &
get((' *
;((* +
set((, /
;((/ 0
}((1 2
=((3 4
string((5 ;
.((; <
Empty((< A
;((A B
public-- 
bool-- 
AccionesPendientes-- &
{--' (
get--) ,
;--, -
set--. 1
;--1 2
}--3 4
}.. 
}// ’
bC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Common\HeaderBase.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Common( .
{ 
public

 

sealed

 
class

 

HeaderBase

 "
{ 
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
$str. R
;R S
} 
} ´

eC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Models\Common\FrontResponse.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Models! '
.' (
Common( .
{ 
public 

class 
FrontResponse 
< 
T  
>  !
{ 
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
public 
T 
? 
Data 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
	ErrorCode  
{! "
get# &
;& '
set( +
;+ ,
}- .
public$$ 
string$$ 
?$$ 
	Timestamp$$  
{$$! "
get$$# &
;$$& '
set$$( +
;$$+ ,
}$$- .
}%% 
}&& ∂7
oC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Middlewares\GlobalExceptionMiddleware.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Middlewares! ,
{ 
public 

sealed 
class %
GlobalExceptionMiddleware 1
{ 
private 
static 
readonly !
JsonSerializerOptions  5
_serializerOptions6 H
=I J
newK N
(N O
)O P
{ 	 
PropertyNamingPolicy  
=! "
JsonNamingPolicy# 3
.3 4
	CamelCase4 =
,= >
} 	
;	 

private 
readonly 

IAppLogger #
<# $%
GlobalExceptionMiddleware$ =
>= >
_logger? F
;F G
private 
readonly 
RequestDelegate (
_next) .
;. /
public!! %
GlobalExceptionMiddleware!! (
(!!( )
RequestDelegate!!) 8
next!!9 =
,!!= >

IAppLogger!!? I
<!!I J%
GlobalExceptionMiddleware!!J c
>!!c d
logger!!e k
)!!k l
{"" 	
this## 
.## 
_next## 
=## 
next## 
??##  
throw##! &
new##' *!
ArgumentNullException##+ @
(##@ A
nameof##A G
(##G H
next##H L
)##L M
)##M N
;##N O
this$$ 
.$$ 
_logger$$ 
=$$ 
logger$$ !
??$$" $
throw$$% *
new$$+ .!
ArgumentNullException$$/ D
($$D E
nameof$$E K
($$K L
logger$$L R
)$$R S
)$$S T
;$$T U
}%% 	
public,, 
async,, 
Task,, 
InvokeAsync,, %
(,,% &
HttpContext,,& 1
context,,2 9
),,9 :
{-- 	!
ArgumentNullException.. !
...! "
ThrowIfNull.." -
(..- .
context... 5
)..5 6
;..6 7
try00 
{11 
await22 
this22 
.22 
_next22  
(22  !
context22! (
)22( )
.22) *
ConfigureAwait22* 8
(228 9
false229 >
)22> ?
;22? @
}33 
catch44 
(44 
	Exception44 
	exception44 &
)44& '
when44( ,
(44- .
	exception44. 7
is448 :
not44; >&
OperationCanceledException44? Y
)44Y Z
{55 
this66 
.66 
_logger66 
.66 
LogError66 %
(66% &
	exception66& /
,66/ 0
$"661 3
$str663 X
{66X Y
context66Y `
.66` a
Request66a h
.66h i
Path66i m
}66m n
$str66n p
{66p q
context66q x
.66x y
Request	66y Ä
.
66Ä Å
Method
66Å á
}
66á à
$str
66à ë
{
66ë í
	exception
66í õ
.
66õ ú
GetType
66ú £
(
66£ §
)
66§ •
.
66• ¶
Name
66¶ ™
}
66™ ´
"
66´ ¨
)
66¨ ≠
;
66≠ Æ
await77  
HandleExceptionAsync77 *
(77* +
context77+ 2
,772 3
	exception774 =
,77= >
this77? C
.77C D
_logger77D K
)77K L
.77L M
ConfigureAwait77M [
(77[ \
false77\ a
)77a b
;77b c
}88 
}99 	
private;; 
static;; 
async;; 
Task;; ! 
HandleExceptionAsync;;" 6
(;;6 7
HttpContext;;7 B
context;;C J
,;;J K
	Exception;;L U
	exception;;V _
,;;_ `

IAppLogger;;a k
<;;k l&
GlobalExceptionMiddleware	;;l Ö
>
;;Ö Ü
logger
;;á ç
)
;;ç é
{<< 	
var== 

statusCode== 
=== 
	exception== &
switch==' -
{>> 
NotFoundException?? !
=>??" $
(??% &
int??& )
)??) *
HttpStatusCode??* 8
.??8 9
NotFound??9 A
,??A B
ValidationException@@ #
=>@@$ &
(@@' (
int@@( +
)@@+ ,
HttpStatusCode@@, :
.@@: ;

BadRequest@@; E
,@@E F
_AA 
=>AA 
(AA 
intAA 
)AA 
HttpStatusCodeAA (
.AA( )
InternalServerErrorAA) <
,AA< =
}BB 
;BB 
ifDD 
(DD 
contextDD 
.DD 
ResponseDD  
.DD  !

HasStartedDD! +
)DD+ ,
{EE 
loggerFF 
.FF 
LogErrorFF 
(FF  
$"FF  "
$strFF" m
{FFm n
contextFFn u
.FFu v
RequestFFv }
.FF} ~
Path	FF~ Ç
}
FFÇ É
$str
FFÉ ê
{
FFê ë
	exception
FFë ö
.
FFö õ
GetType
FFõ ¢
(
FF¢ £
)
FF£ §
.
FF§ •
Name
FF• ©
}
FF© ™
"
FF™ ´
)
FF´ ¨
;
FF¨ ≠
throwGG 
	exceptionGG 
;GG  
}HH 
loggerJJ 
.JJ 
InfoJJ 
(JJ 
$"JJ 
$strJJ C
{JJC D

statusCodeJJD N
}JJN O
$strJJO Z
{JJZ [
	exceptionJJ[ d
.JJd e
MessageJJe l
}JJl m
$strJJm u
{JJu v
contextJJv }
.JJ} ~
Request	JJ~ Ö
.
JJÖ Ü
Path
JJÜ ä
}
JJä ã
"
JJã å
)
JJå ç
;
JJç é
contextKK 
.KK 
ResponseKK 
.KK 

StatusCodeKK '
=KK( )

statusCodeKK* 4
;KK4 5
contextLL 
.LL 
ResponseLL 
.LL 
ContentTypeLL (
=LL) *
$strLL+ =
;LL= >
varNN 
responseNN 
=NN 
newNN 
{OO 

statusCodePP 
,PP 
messageQQ 
=QQ 
	exceptionQQ #
.QQ# $
MessageQQ$ +
,QQ+ ,
}RR 
;RR 
varTT 
payloadTT 
=TT 
JsonSerializerTT (
.TT( )
	SerializeTT) 2
(TT2 3
responseTT3 ;
,TT; <
_serializerOptionsTT= O
)TTO P
;TTP Q
awaitUU 
contextUU 
.UU 
ResponseUU "
.UU" #

WriteAsyncUU# -
(UU- .
payloadUU. 5
)UU5 6
.UU6 7
ConfigureAwaitUU7 E
(UUE F
falseUUF K
)UUK L
;UUL M
}VV 	
}WW 
}XX °
mC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Middlewares\CorrelationIdMiddleware.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Middlewares! ,
{ 
public 

sealed 
class #
CorrelationIdMiddleware /
{ 
private 
const 
string #
CorrelationIdHeaderName 4
=5 6
$str7 I
;I J
private 
const 
string %
CorrelationIdPropertyName 6
=7 8
$str9 G
;G H
private 
readonly 
RequestDelegate (
_next) .
;. /
public #
CorrelationIdMiddleware &
(& '
RequestDelegate' 6
next7 ;
); <
{ 	
this 
. 
_next 
= 
next 
??  
throw! &
new' *!
ArgumentNullException+ @
(@ A
nameofA G
(G H
nextH L
)L M
)M N
;N O
} 	
public## 
async## 
Task## 
InvokeAsync## %
(##% &
HttpContext##& 1
context##2 9
)##9 :
{$$ 	!
ArgumentNullException%% !
.%%! "
ThrowIfNull%%" -
(%%- .
context%%. 5
)%%5 6
;%%6 7
var)) 
correlationId)) 
=)) 
context))  '
.))' (
Request))( /
.))/ 0
Headers))0 7
[))7 8#
CorrelationIdHeaderName))8 O
]))O P
.))P Q
ToString))Q Y
())Y Z
)))Z [
;))[ \
if++ 
(++ 
string++ 
.++ 
IsNullOrWhiteSpace++ )
(++) *
correlationId++* 7
)++7 8
)++8 9
{,, 
correlationId-- 
=-- 
Guid--  $
.--$ %
NewGuid--% ,
(--, -
)--- .
.--. /
ToString--/ 7
(--7 8
)--8 9
;--9 :
}.. 
using11 
(11 
ScopeContext11 
.11  
PushProperty11  ,
(11, -%
CorrelationIdPropertyName11- F
,11F G
correlationId11H U
)11U V
)11V W
{22 
context44 
.44 
Response44  
.44  !
Headers44! (
[44( )#
CorrelationIdHeaderName44) @
]44@ A
=44B C
correlationId44D Q
;44Q R
await77 
this77 
.77 
_next77  
(77  !
context77! (
)77( )
.77) *
ConfigureAwait77* 8
(778 9
false779 >
)77> ?
;77? @
}88 
}99 	
}:: 
};; â
ÉC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Infrastructure\Swagger\CorrelationIdHeaderOperationFilter.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Infrastructure! /
./ 0
Swagger0 7
{ 
internal 
sealed 
class .
"CorrelationIdHeaderOperationFilter <
:= >
IOperationFilter? O
{ 
public 
void 
Apply 
( 
OpenApiOperation *
	operation+ 4
,4 5"
OperationFilterContext6 L
contextM T
)T U
{ 	!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
	operation. 7
)7 8
;8 9!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
context. 5
)5 6
;6 7
	operation 
. 

Parameters  
??=! $
new% (
List) -
<- .
OpenApiParameter. >
>> ?
(? @
)@ A
;A B
if 
( 
	operation 
. 

Parameters $
.$ %
Any% (
(( )
	parameter) 2
=>3 5
	parameter6 ?
.? @
In@ B
==C E
ParameterLocationF W
.W X
HeaderX ^
&&_ a
	parameterb k
.k l
Namel p
==q s
$str	t Ü
)
Ü á
)
á à
{ 
return 
; 
} 
	operation 
. 

Parameters  
.  !
Add! $
($ %
new% (
OpenApiParameter) 9
{   
Name!! 
=!! 
$str!! )
,!!) *
In"" 
="" 
ParameterLocation"" &
.""& '
Header""' -
,""- .
Description## 
=## 
$str## O
,##O P
Required$$ 
=$$ 
true$$ 
,$$  
Schema%% 
=%% 
new%% 
OpenApiSchema%% *
{&& 
Type'' 
='' 
$str'' #
,''# $
Format(( 
=(( 
$str(( #
,((# $
})) 
,)) 
}** 
)** 
;** 
}++ 	
},, 
}-- €
[C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Helpers\LogHelper.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Helpers! (
{ 
public		 

static		 
class		 
	LogHelper		 !
{

 
public 
static 
string 
MaskRut $
($ %
string% +
rut, /
)/ 0
{ 	
if 
( 
string 
. 
IsNullOrEmpty $
($ %
rut% (
)( )
||* ,
rut- 0
.0 1
Length1 7
<8 9
$num: ;
); <
{ 
return 
$str 
; 
} 
return 
$" 
$str 
{ 
rut 
[ 
^ 
$num  
..  "
]" #
}# $
"$ %
;% &
} 	
public 
static 
string 
	MaskEmail &
(& '
string' -
email. 3
)3 4
{   	
if!! 
(!! 
string!! 
.!! 
IsNullOrEmpty!! $
(!!$ %
email!!% *
)!!* +
)!!+ ,
{"" 
return## 
$str## 
;## 
}$$ 
var&& 
parts&& 
=&& 
email&& 
.&& 
Split&& #
(&&# $
$char&&$ '
)&&' (
;&&( )
return'' 
$"'' 
{'' 
parts'' 
['' 
$num'' 
]'' 
['' 
..'' !
$num''! "
]''" #
}''# $
$str''$ (
{''( )
parts'') .
[''. /
$num''/ 0
]''0 1
}''1 2
"''2 3
;''3 4
}(( 	
})) 
}** Ç
_C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Handlers\UsersHandler.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Handlers! )
{ 
public 

class 
UsersHandler 
: 
IUsersHandler  -
{ 
private 
const 
string 
_httpPrefix (
=) *
$str+ 4
;4 5
private 
const 
string 
_httpsPrefix )
=* +
$str, 6
;6 7
private 
readonly 

IAppLogger #
<# $
UsersHandler$ 0
>0 1
_logger2 9
;9 :
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
private 
readonly 
ICadsService %
_cadsService& 2
;2 3
private 
readonly 
ITokenService &
_tokenService' 4
;4 5
public%% 
UsersHandler%% 
(%% 

IAppLogger&& 
<&& 
UsersHandler&& #
>&&# $
logger&&% +
,&&+ ,
IConfiguration'' 
configuration'' (
,''( )
ICadsService(( 
cadsService(( $
,(($ %
ITokenService)) 
tokenService)) &
)))& '
{** 	
this++ 
.++ 
_logger++ 
=++ 
logger++ !
??++" $
throw++% *
new+++ .!
ArgumentNullException++/ D
(++D E
nameof++E K
(++K L
logger++L R
)++R S
)++S T
;++T U
this,, 
.,, 
_configuration,, 
=,,  !
configuration,," /
??,,0 2
throw,,3 8
new,,9 <!
ArgumentNullException,,= R
(,,R S
nameof,,S Y
(,,Y Z
configuration,,Z g
),,g h
),,h i
;,,i j
this-- 
.-- 
_cadsService-- 
=-- 
cadsService--  +
??--, .
throw--/ 4
new--5 8!
ArgumentNullException--9 N
(--N O
nameof--O U
(--U V
cadsService--V a
)--a b
)--b c
;--c d
this.. 
... 
_tokenService.. 
=..  
tokenService..! -
??... 0
throw..1 6
new..7 :!
ArgumentNullException..; P
(..P Q
nameof..Q W
(..W X
tokenService..X d
)..d e
)..e f
;..f g
}// 	
public66 
async66 
Task66 
<66 
string66  
>66  !
GenerarUrlFrontend66" 4
(664 5!
ValidateAccessRequest665 J
request66K R
)66R S
{77 	!
ArgumentNullException88 !
.88! "
ThrowIfNull88" -
(88- .
request88. 5
)885 6
;886 7
	TokenData99 
	tokenData99 
;99  
string:: 
token:: 
;:: 
this<< 
.<< 
_logger<< 
.<< 
Info<< 
(<< 
$str<< A
)<<A B
;<<B C
if?? 
(?? 
string?? 
.?? 
IsNullOrWhiteSpace?? )
(??) *
request??* 1
.??1 2

RutTitular??2 <
)??< =
)??= >
{@@ 
thisAA 
.AA 
_loggerAA 
.AA 
LogErrorAA %
(AA% &
$strAA& [
)AA[ \
;AA\ ]
throwBB 
newBB 
ArgumentExceptionBB +
(BB+ ,
$strBB, P
,BBP Q
nameofBBR X
(BBX Y
requestBBY `
)BB` a
)BBa b
;BBb c
}CC 
ifEE 
(EE 
requestEE 
.EE 
OrigenEE 
==EE !
EOrigenEE" )
.EE) *
NoneEE* .
)EE. /
{FF 
thisGG 
.GG 
_loggerGG 
.GG 
LogErrorGG %
(GG% &
$"GG& (
$strGG( M
{GGM N
requestGGN U
.GGU V
OrigenGGV \
}GG\ ]
$strGG] ^
"GG^ _
)GG_ `
;GG` a
throwHH 
newHH 
ArgumentExceptionHH +
(HH+ ,
$strHH, G
,HHG H
nameofHHI O
(HHO P
requestHHP W
)HHW X
)HHX Y
;HHY Z
}II 
ifKK 
(KK 
requestKK 
.KK 
RolKK 
==KK 
ERolKK #
.KK# $
NoneKK$ (
)KK( )
{LL 
thisMM 
.MM 
_loggerMM 
.MM 
LogErrorMM %
(MM% &
$"MM& (
$strMM( J
{MMJ K
requestMMK R
.MMR S
RolMMS V
}MMV W
$strMMW X
"MMX Y
)MMY Z
;MMZ [
throwNN 
newNN 
ArgumentExceptionNN +
(NN+ ,
$strNN, D
,NND E
nameofNNF L
(NNL M
requestNNM T
)NNT U
)NNU V
;NNV W
}OO 
varQQ 
userAccessResponseQQ "
=QQ# $
awaitQQ% *
thisQQ+ /
.QQ/ 0
_cadsServiceQQ0 <
.QQ< =
ValideUserAccessQQ= M
(QQM N
requestQQN U
)QQU V
.QQV W
ConfigureAwaitQQW e
(QQe f
falseQQf k
)QQk l
;QQl m
ifSS 
(SS 
userAccessResponseSS "
?SS" #
.SS# $
DataSS$ (
?SS( )
.SS) *
	IdUsuarioSS* 3
isSS4 6
nullSS7 ;
)SS; <
{TT 
returnUU 
awaitUU 
RedirectToOriginUU -
(UU- .
requestUU. 5
.UU5 6

RutaOrigenUU6 @
)UU@ A
.UUA B
ConfigureAwaitUUB P
(UUP Q
falseUUQ V
)UUV W
;UUW X
}VV 
varYY 
urlBaseYY 
=YY 
thisYY 
.YY 
_configurationYY -
[YY- .
$strYY. @
]YY@ A
??ZZ 
throwZZ 
newZZ %
InvalidOperationExceptionZZ 6
(ZZ6 7
$strZZ7 l
)ZZl m
;ZZm n
this[[ 
.[[ 
_logger[[ 
.[[ 
Debug[[ 
([[ 
$"[[ !
$str[[! E
{[[E F
urlBase[[F M
}[[M N
"[[N O
)[[O P
;[[P Q
var^^ 
	sessionId^^ 
=^^ 
Guid^^  
.^^  !
NewGuid^^! (
(^^( )
)^^) *
.^^* +
ToString^^+ 3
(^^3 4
$str^^4 7
)^^7 8
;^^8 9
this__ 
.__ 
_logger__ 
.__ 
Debug__ 
(__ 
$"__ !
$str__! 5
{__5 6
	sessionId__6 ?
}__? @
"__@ A
)__A B
;__B C
	tokenDatabb 
=bb 
newbb 
	TokenDatabb %
{cc 
Origendd 
=dd 
(dd 
intdd 
)dd 
requestdd %
.dd% &
Origendd& ,
!dd, -
,dd- .
Rolee 
=ee 
(ee 
intee 
)ee 
requestee "
.ee" #
Rolee# &
!ee& '
,ee' (
	SessionIdff 
=ff 
	sessionIdff %
,ff% &
Solicitantegg 
=gg 
requestgg %
.gg% &
RutSolicitantegg& 4
??gg5 7
stringgg8 >
.gg> ?
Emptygg? D
,ggD E
Nombreshh 
=hh 
userAccessResponsehh ,
.hh, -
Datahh- 1
.hh1 2
Nombrehh2 8
??hh9 ;
stringhh< B
.hhB C
EmptyhhC H
,hhH I
	Apellidosii 
=ii 
userAccessResponseii .
.ii. /
Dataii/ 3
.ii3 4
Apellidoii4 <
??ii= ?
stringii@ F
.iiF G
EmptyiiG L
,iiL M
Emailjj 
=jj 
userAccessResponsejj *
.jj* +
Datajj+ /
.jj/ 0
Emailjj0 5
??jj6 8
stringjj9 ?
.jj? @
Emptyjj@ E
,jjE F
TokenOrigenkk 
=kk 
requestkk %
.kk% &
Tokenkk& +
??kk, .
stringkk/ 5
.kk5 6
Emptykk6 ;
,kk; <
}ll 
;ll 
tokennn 
=nn 
thisnn 
.nn 
_tokenServicenn &
.nn& '
GenerateTokennn' 4
(nn4 5
	tokenDatann5 >
)nn> ?
;nn? @
thisoo 
.oo 
_loggeroo 
.oo 
Debugoo 
(oo 
$stroo <
)oo< =
;oo= >
varrr 
sbrr 
=rr 
newrr 
StringBuilderrr &
(rr& '
urlBaserr' .
)rr. /
;rr/ 0
charss 
sepss 
=ss 
urlBasess 
.ss 
Containsss '
(ss' (
$charss( +
,ss+ ,
StringComparisonss- =
.ss= >
Ordinalss> E
)ssE F
?ssG H
$charssI L
:ssM N
$charssO R
;ssR S
voiduu 
AppendParamuu 
(uu 
stringuu #
keyuu$ '
,uu' (
stringuu) /
?uu/ 0
valueuu1 6
)uu6 7
{vv 
sbww 
.ww 
Appendww 
(ww 
sepww 
)ww 
;ww 
sbxx 
.xx 
Appendxx 
(xx 
keyxx 
)xx 
;xx 
sbyy 
.yy 
Appendyy 
(yy 
$charyy 
)yy 
;yy 
sbzz 
.zz 
Appendzz 
(zz 
Urizz 
.zz 
EscapeDataStringzz .
(zz. /
valuezz/ 4
??zz5 7
$strzz8 ;
)zz; <
)zz< =
;zz= >
sep{{ 
={{ 
$char{{ 
;{{ 
}|| 
AppendParam~~ 
(~~ 
$str~~ !
,~~! "
request~~# *
.~~* +

RutTitular~~+ 5
)~~5 6
;~~6 7
AppendParam 
( 
$str  
,  !
(" #
(# $
int$ '
)' (
request( /
./ 0
Origen0 6
)6 7
.7 8
ToString8 @
(@ A
CultureInfoA L
.L M
InvariantCultureM ]
)] ^
)^ _
;_ `
AppendParam
ÄÄ 
(
ÄÄ 
$str
ÄÄ "
,
ÄÄ" #
request
ÄÄ$ +
.
ÄÄ+ ,
RutCorredor
ÄÄ, 7
)
ÄÄ7 8
;
ÄÄ8 9
AppendParam
ÅÅ 
(
ÅÅ 
$str
ÅÅ 
,
ÅÅ 
(
ÅÅ  
(
ÅÅ  !
int
ÅÅ! $
)
ÅÅ$ %
request
ÅÅ% ,
.
ÅÅ, -
Rol
ÅÅ- 0
)
ÅÅ0 1
.
ÅÅ1 2
ToString
ÅÅ2 :
(
ÅÅ: ;
CultureInfo
ÅÅ; F
.
ÅÅF G
InvariantCulture
ÅÅG W
)
ÅÅW X
)
ÅÅX Y
;
ÅÅY Z
AppendParam
ÇÇ 
(
ÇÇ 
$str
ÇÇ #
,
ÇÇ# $
Helper
ÇÇ% +
.
ÇÇ+ ,
NormalizarRuta
ÇÇ, :
(
ÇÇ: ;
request
ÇÇ; B
.
ÇÇB C

RutaOrigen
ÇÇC M
)
ÇÇM N
)
ÇÇN O
;
ÇÇO P
AppendParam
ÉÉ 
(
ÉÉ 
$str
ÉÉ $
,
ÉÉ$ %
$str
ÉÉ& 2
)
ÉÉ2 3
;
ÉÉ3 4
AppendParam
ÑÑ 
(
ÑÑ 
$str
ÑÑ #
,
ÑÑ# $
	sessionId
ÑÑ% .
)
ÑÑ. /
;
ÑÑ/ 0
AppendParam
ÖÖ 
(
ÖÖ 
$str
ÖÖ #
,
ÖÖ# $ 
userAccessResponse
ÖÖ% 7
.
ÖÖ7 8
Data
ÖÖ8 <
.
ÖÖ< =
	IdUsuario
ÖÖ= F
.
ÖÖF G
ToString
ÖÖG O
(
ÖÖO P
CultureInfo
ÖÖP [
.
ÖÖ[ \
InvariantCulture
ÖÖ\ l
)
ÖÖl m
)
ÖÖm n
;
ÖÖn o
AppendParam
ÜÜ 
(
ÜÜ 
$str
ÜÜ 
,
ÜÜ  
token
ÜÜ! &
)
ÜÜ& '
;
ÜÜ' (
var
áá 
urlFinal
áá 
=
áá 
sb
áá 
.
áá 
ToString
áá &
(
áá& '
)
áá' (
;
áá( )
this
ââ 
.
ââ 
_logger
ââ 
.
ââ 
Info
ââ 
(
ââ 
$"
ââ  
$str
ââ  E
{
ââE F
urlFinal
ââF N
.
ââN O
Length
ââO U
}
ââU V
$str
ââV a
"
ââa b
)
ââb c
;
ââc d
return
ãã 
await
ãã 
RedirectToOrigin
ãã )
(
ãã) *
urlFinal
ãã* 2
)
ãã2 3
.
ãã3 4
ConfigureAwait
ãã4 B
(
ããB C
false
ããC H
)
ããH I
;
ããI J
}
åå 	
private
éé 
static
éé 
async
éé 
Task
éé !
<
éé! "
string
éé" (
>
éé( )
RedirectToOrigin
éé* :
(
éé: ;
string
éé; A
	urlOrigen
ééB K
)
ééK L
{
èè 	#
ArgumentNullException
êê !
.
êê! "
ThrowIfNull
êê" -
(
êê- .
	urlOrigen
êê. 7
)
êê7 8
;
êê8 9
if
íí 
(
íí 
	urlOrigen
íí 
.
íí 
Contains
íí "
(
íí" #
$str
íí# )
,
íí) *
StringComparison
íí+ ;
.
íí; <
Ordinal
íí< C
)
ííC D
)
ííD E
{
ìì 
return
îî 
	urlOrigen
îî  
;
îî  !
}
ïï 
try
óó 
{
òò 
if
öö 
(
öö 
!
öö 
Uri
öö 
.
öö 
	TryCreate
öö "
(
öö" #
_httpPrefix
öö# .
+
öö/ 0
	urlOrigen
öö1 :
,
öö: ;
UriKind
öö< C
.
ööC D
Absolute
ööD L
,
ööL M
out
ööN Q
Uri
ööR U
?
ööU V
testUri
ööW ^
)
öö^ _
)
öö_ `
{
õõ 
return
ùù 
_httpsPrefix
ùù '
+
ùù( )
	urlOrigen
ùù* 3
;
ùù3 4
}
ûû 
bool
†† 
result
†† 
=
†† 
await
†† #
Helper
††$ *
.
††* +
UrlExistsAsync
††+ 9
(
††9 :
testUri
††: A
)
††A B
.
††B C
ConfigureAwait
††C Q
(
††Q R
false
††R W
)
††W X
;
††X Y
string
°° 
prefix
°° 
=
°° 
result
°°  &
?
°°' (
_httpPrefix
°°) 4
:
°°5 6
_httpsPrefix
°°7 C
;
°°C D
return
¢¢ 
prefix
¢¢ 
+
¢¢ 
	urlOrigen
¢¢  )
;
¢¢) *
}
££ 
catch
§§ 
(
§§ "
HttpRequestException
§§ '
)
§§' (
{
•• 
return
ßß 
_httpsPrefix
ßß #
+
ßß$ %
	urlOrigen
ßß& /
;
ßß/ 0
}
®® 
catch
©© 
(
©© #
TaskCanceledException
©© (
)
©©( )
{
™™ 
return
¨¨ 
_httpsPrefix
¨¨ #
+
¨¨$ %
	urlOrigen
¨¨& /
;
¨¨/ 0
}
≠≠ 
catch
ÆÆ 
(
ÆÆ '
InvalidOperationException
ÆÆ ,
)
ÆÆ, -
{
ØØ 
return
±± 
_httpsPrefix
±± #
+
±±$ %
	urlOrigen
±±& /
;
±±/ 0
}
≤≤ 
}
≥≥ 	
}
¥¥ 
}µµ ÷
XC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Helpers\Helper.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Helpers! (
{ 
public		 

static		 
class		 
Helper		 
{

 
private 
static 
readonly 

HttpClient  *
_sharedHttpClient+ <
== >
new? B
(B C
)C D
{ 	
Timeout 
= 
TimeSpan 
. 
FromSeconds *
(* +
$num+ -
)- .
,. /
} 	
;	 

public 
static 
async 
Task  
<  !
bool! %
>% &
UrlExistsAsync' 5
(5 6
Uri6 9
url: =
)= >
{ 	
try 
{ 
HttpResponseMessage #
response$ ,
=- .
await/ 4
_sharedHttpClient5 F
.F G
GetAsyncG O
(O P
urlP S
)S T
.T U
ConfigureAwaitU c
(c d
falsed i
)i j
;j k
return 
response 
.  
IsSuccessStatusCode  3
;3 4
} 
catch 
(  
HttpRequestException '
)' (
{ 
return 
false 
; 
}   
catch!! 
(!! !
TaskCanceledException!! (
)!!( )
{"" 
return$$ 
false$$ 
;$$ 
}%% 
catch&& 
(&& &
OperationCanceledException&& -
)&&- .
{'' 
return)) 
false)) 
;)) 
}** 
}++ 	
public22 
static22 
string22 
NormalizarRuta22 +
(22+ ,
string22, 2
?222 3
ruta224 8
)228 9
{33 	
if44 
(44 
string44 
.44 
IsNullOrWhiteSpace44 )
(44) *
ruta44* .
)44. /
)44/ 0
{55 
return66 
$str66 
;66 
}77 
return99 
ruta99 
.99 
Replace99 
(99  
$str99  #
,99# $
$str99% (
,99( )
StringComparison99* :
.99: ;
Ordinal99; B
)99B C
;99C D
}:: 	
};; 
}<< ’
kC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Handlers\Interfaces\IUsersHandler.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Handlers! )
.) *

Interfaces* 4
{ 
public 

	interface 
IUsersHandler "
{ 
Task 
< 
string 
> 
GenerarUrlFrontend '
(' (!
ValidateAccessRequest( =
request> E
)E F
;F G
} 
} ·∂
dC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Handlers\SiniestrosHandler.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Handlers! )
{ 
public 

class 
SiniestrosHandler "
:# $
ISiniestrosHandler% 7
{ 
private 
readonly 

IAppLogger #
<# $
SiniestrosHandler$ 5
>5 6
_logger7 >
;> ?
private 
readonly 
ISiniestrosService +
_siniestrosService, >
;> ?
private 
readonly $
IResiliencePolicyService 1$
_resiliencePolicyService2 J
;J K
public"" 
SiniestrosHandler""  
(""  !

IAppLogger## 
<## 
SiniestrosHandler## (
>##( )
logger##* 0
,##0 1
ISiniestrosService$$ 
siniestrosService$$ 0
,$$0 1$
IResiliencePolicyService%% $#
resiliencePolicyService%%% <
)%%< =
{&& 	
this'' 
.'' 
_logger'' 
='' 
logger'' !
??''" $
throw''% *
new''+ .!
ArgumentNullException''/ D
(''D E
nameof''E K
(''K L
logger''L R
)''R S
)''S T
;''T U
this(( 
.(( 
_siniestrosService(( #
=(($ %
siniestrosService((& 7
??((8 :
throw((; @
new((A D!
ArgumentNullException((E Z
(((Z [
nameof(([ a
(((a b
siniestrosService((b s
)((s t
)((t u
;((u v
this)) 
.)) $
_resiliencePolicyService)) )
=))* +#
resiliencePolicyService)), C
??))D F
throw))G L
new))M P!
ArgumentNullException))Q f
())f g
nameof))g m
())m n$
resiliencePolicyService	))n Ö
)
))Ö Ü
)
))Ü á
;
))á à
}** 	
public11 
async11 
Task11 
<11 
SiniestrosResponse11 ,
>11, -%
GetSiniestrosPorAsegurado11. G
(11G H
SiniestrosRequest11H Y
request11Z a
)11a b
{22 	!
ArgumentNullException33 !
.33! "
ThrowIfNull33" -
(33- .
request33. 5
)335 6
;336 7
this55 
.55 
_logger55 
.55 
Info55 
(55 
$"55  
{55  !
this55! %
.55% &
GetType55& -
(55- .
)55. /
.55/ 0
FullName550 8
}558 9
$str559 ]
"55] ^
)55^ _
;55_ `
if88 
(88 
string88 
.88 
IsNullOrWhiteSpace88 )
(88) *
request88* 1
.881 2
RutAsegurado882 >
)88> ?
)88? @
{99 
this:: 
.:: 
_logger:: 
.:: 
LogError:: %
(::% &
$str::& ]
)::] ^
;::^ _
throw;; 
new;; 
ArgumentException;; +
(;;+ ,
$str;;, P
,;;P Q
nameof;;R X
(;;X Y
request;;Y `
);;` a
);;a b
;;;b c
}<< 
var>> 
siniestrosResponse>> "
=>># $
await>>% *
this>>+ /
.>>/ 0
_siniestrosService>>0 B
.>>B C%
GetSiniestrosPorAsegurado>>C \
(>>\ ]
request>>] d
)>>d e
.>>e f
ConfigureAwait>>f t
(>>t u
false>>u z
)>>z {
;>>{ |
if@@ 
(@@ 
siniestrosResponse@@ "
==@@# %
null@@& *
)@@* +
{AA 
throwBB 
newBB %
InvalidOperationExceptionBB 3
(BB3 4
$strBB4 h
)BBh i
;BBi j
}CC 
returnEE 
siniestrosResponseEE %
;EE% &
}FF 	
publicMM 
asyncMM 
TaskMM 
<MM %
SiniestrosDetalleResponseMM 3
>MM3 4 
GetDetalleSiniestrosMM5 I
(MMI J 
SiniestrosDetRequestMMJ ^
requestMM_ f
)MMf g
{NN 	!
ArgumentNullExceptionOO !
.OO! "
ThrowIfNullOO" -
(OO- .
requestOO. 5
)OO5 6
;OO6 7
thisQQ 
.QQ 
_loggerQQ 
.QQ 
InfoQQ 
(QQ 
$"QQ  
{QQ  !
thisQQ! %
.QQ% &
GetTypeQQ& -
(QQ- .
)QQ. /
.QQ/ 0
FullNameQQ0 8
}QQ8 9
$strQQ9 ]
"QQ] ^
)QQ^ _
;QQ_ `
ifTT 
(TT 
requestTT 
.TT 
INsinieTT 
<=TT  "
$numTT# $
)TT$ %
{UU 
thisVV 
.VV 
_loggerVV 
.VV 
LogErrorVV %
(VV% &
$strVV& u
)VVu v
;VVv w
throwWW 
newWW 
ArgumentExceptionWW +
(WW+ ,
$strWW, l
)WWl m
;WWm n
}XX 
ifZZ 
(ZZ 
requestZZ 
.ZZ 
INdoctoZZ 
<=ZZ  "
$numZZ# $
)ZZ$ %
{[[ 
this\\ 
.\\ 
_logger\\ 
.\\ 
LogError\\ %
(\\% &
$str\\& u
)\\u v
;\\v w
throw]] 
new]] 
ArgumentException]] +
(]]+ ,
$str]], l
)]]l m
;]]m n
}^^ 
var`` )
siniestrosDetalleDataResponse`` -
=``. /
await``0 5
this``6 :
.``: ;
_siniestrosService``; M
.``M N 
GetDatosDelSiniestro``N b
(``b c
request``c j
)``j k
.``k l
ConfigureAwait``l z
(``z {
false	``{ Ä
)
``Ä Å
;
``Å Ç
returnbb )
siniestrosDetalleDataResponsebb 0
;bb0 1
}cc 	
publicjj 
asyncjj 
Taskjj 
<jj 
SiniestrosDataDtojj +
>jj+ ,,
 GetSiniestrosDetallePorAseguradojj- M
(jjM N
stringjjN T
rutjjU X
)jjX Y
{kk 	
ArgumentExceptionll 
.ll #
ThrowIfNullOrWhiteSpacell 5
(ll5 6
rutll6 9
)ll9 :
;ll: ;
thisnn 
.nn 
_loggernn 
.nn 
Infonn 
(nn 
$"nn  
{nn  !
thisnn! %
.nn% &
GetTypenn& -
(nn- .
)nn. /
.nn/ 0
FullNamenn0 8
}nn8 9
$strnn9 s
{nns t
rutnnt w
}nnw x
"nnx y
)nny z
;nnz {
ifqq 
(qq 
!qq 
RutValidatorqq 
.qq 
Validarqq %
(qq% &
rutqq& )
)qq) *
)qq* +
{rr 
thisss 
.ss 
_loggerss 
.ss 
LogErrorss %
(ss% &
$"ss& (
$strss( S
{ssS T
rutssT W
}ssW X
"ssX Y
)ssY Z
;ssZ [
throwtt 
newtt 
ArgumentExceptiontt +
(tt+ ,
$strtt, P
,ttP Q
nameofttR X
(ttX Y
rutttY \
)tt\ ]
)tt] ^
;tt^ _
}uu 
stringxx 
	rutLimpioxx 
=xx 
RutValidatorxx +
.xx+ ,
ObtenerNumeroRutxx, <
(xx< =
rutxx= @
)xx@ A
;xxA B
varyy 
requestyy 
=yy 
newyy 
SiniestrosRequestyy /
{yy0 1
RutAseguradoyy2 >
=yy? @
	rutLimpioyyA J
}yyK L
;yyL M
this|| 
.|| 
_logger|| 
.|| 
Debug|| 
(|| 
$"|| !
{||! "
this||" &
.||& '
GetType||' .
(||. /
)||/ 0
.||0 1
FullName||1 9
}||9 :
$str||: e
{||e f
	rutLimpio||f o
}||o p
"||p q
)||q r
;||r s
var}} !
lstSiniestrosResponse}} %
=}}& '
await}}( -
this}}. 2
.}}2 3%
GetSiniestrosPorAsegurado}}3 L
(}}L M
request}}M T
)}}T U
.}}U V
ConfigureAwait}}V d
(}}d e
false}}e j
)}}j k
;}}k l
if
ÄÄ 
(
ÄÄ #
lstSiniestrosResponse
ÄÄ %
.
ÄÄ% &
Data
ÄÄ& *
==
ÄÄ+ -
null
ÄÄ. 2
||
ÄÄ3 5#
lstSiniestrosResponse
ÄÄ6 K
.
ÄÄK L
Data
ÄÄL P
.
ÄÄP Q
Count
ÄÄQ V
==
ÄÄW Y
$num
ÄÄZ [
)
ÄÄ[ \
{
ÅÅ 
this
ÇÇ 
.
ÇÇ 
_logger
ÇÇ 
.
ÇÇ 
Info
ÇÇ !
(
ÇÇ! "
$"
ÇÇ" $
{
ÇÇ$ %
this
ÇÇ% )
.
ÇÇ) *
GetType
ÇÇ* 1
(
ÇÇ1 2
)
ÇÇ2 3
.
ÇÇ3 4
FullName
ÇÇ4 <
}
ÇÇ< =
$str
ÇÇ= j
{
ÇÇj k
rut
ÇÇk n
}
ÇÇn o
"
ÇÇo p
)
ÇÇp q
;
ÇÇq r
return
ÉÉ 
new
ÉÉ 
SiniestrosDataDto
ÉÉ ,
(
ÉÉ, -
)
ÉÉ- .
;
ÉÉ. /
}
ÑÑ 
var
áá '
lstSiniestrosDataResponse
áá )
=
áá* +
this
áá, 0
.
áá0 1"
ProcesarSiniestrosVP
áá1 E
(
ááE F#
lstSiniestrosResponse
ááF [
.
áá[ \
Data
áá\ `
)
áá` a
;
ááa b
if
ââ 
(
ââ '
lstSiniestrosDataResponse
ââ )
.
ââ) *
Count
ââ* /
==
ââ0 2
$num
ââ3 4
)
ââ4 5
{
ää 
this
ãã 
.
ãã 
_logger
ãã 
.
ãã 
Info
ãã !
(
ãã! "
$"
ãã" $
{
ãã$ %
this
ãã% )
.
ãã) *
GetType
ãã* 1
(
ãã1 2
)
ãã2 3
.
ãã3 4
FullName
ãã4 <
}
ãã< =
$str
ãã= p
{
ããp q
rut
ããq t
}
ããt u
"
ããu v
)
ããv w
;
ããw x
return
åå 
new
åå 
SiniestrosDataDto
åå ,
(
åå, -
)
åå- .
;
åå. /
}
çç 
var
êê 
siniestrosDataDTO
êê !
=
êê" #
await
êê$ )
this
êê* .
.
êê. /#
EnriquecerConDetalles
êê/ D
(
êêD E'
lstSiniestrosDataResponse
êêE ^
)
êê^ _
.
êê_ `
ConfigureAwait
êê` n
(
êên o
false
êêo t
)
êêt u
;
êêu v
if
ìì 
(
ìì 
siniestrosDataDTO
ìì !
.
ìì! "

Siniestros
ìì" ,
.
ìì, -
Count
ìì- 2
>
ìì3 4
$num
ìì5 6
)
ìì6 7
{
îî 
siniestrosDataDTO
ïï !
.
ïï! "
TiposSiniestros
ïï" 1
.
ïï1 2
Add
ïï2 5
(
ïï5 6
new
ïï6 9
TipoSiniestroDto
ïï: J
{
ññ 
Nombre
óó 
=
óó 
$str
óó '
,
óó' (
Visible
òò 
=
òò 
true
òò "
,
òò" #
}
ôô 
)
ôô 
;
ôô 
}
öö 
this
úú 
.
úú 
_logger
úú 
.
úú 
Info
úú 
(
úú 
$"
úú  
{
úú  !
this
úú! %
.
úú% &
GetType
úú& -
(
úú- .
)
úú. /
.
úú/ 0
FullName
úú0 8
}
úú8 9
$str
úú9 o
{
úúo p 
siniestrosDataDTOúúp Å
.úúÅ Ç

SiniestrosúúÇ å
.úúå ç
Countúúç í
}úúí ì
"úúì î
)úúî ï
;úúï ñ
return
ûû 
siniestrosDataDTO
ûû $
;
ûû$ %
}
üü 	
private
¶¶ 
List
¶¶ 
<
¶¶ 
(
¶¶ "
SiniestrosDetRequest
¶¶ *
Request
¶¶+ 2
,
¶¶2 3$
SiniestrosDataResponse
¶¶4 J
OriginalData
¶¶K W
)
¶¶W X
>
¶¶X Y"
ProcesarSiniestrosVP
¶¶Z n
(
¶¶n o!
IReadOnlyCollection
ßß 
<
ßß  $
SiniestrosDataResponse
ßß  6
>
ßß6 7

siniestros
ßß8 B
)
ßßB C
{
®® 	
var
©© 
	resultado
©© 
=
©© 
new
©© 
List
©©  $
<
©©$ %
(
©©% &"
SiniestrosDetRequest
©©& :
Request
©©; B
,
©©B C$
SiniestrosDataResponse
©©D Z
OriginalData
©©[ g
)
©©g h
>
©©h i
(
©©i j
)
©©j k
;
©©k l
var
¨¨ 
siniestrosVP
¨¨ 
=
¨¨ 

siniestros
¨¨ )
.
≠≠ 
Where
≠≠ 
(
≠≠ 
p
≠≠ 
=>
≠≠ 
p
≠≠ 
.
≠≠ 
Ramo
≠≠ "
==
≠≠# %
$str
≠≠& *
&&
≠≠+ -
p
≠≠. /
.
≠≠/ 0
NumeroSiniestro
≠≠0 ?
.
≠≠? @
HasValue
≠≠@ H
&&
≠≠I K
!
≠≠L M
string
≠≠M S
.
≠≠S T 
IsNullOrWhiteSpace
≠≠T f
(
≠≠f g
p
≠≠g h
.
≠≠h i
NumeroPoliza
≠≠i u
)
≠≠u v
)
≠≠v w
.
ÆÆ 
ToList
ÆÆ 
(
ÆÆ 
)
ÆÆ 
;
ÆÆ 
foreach
∞∞ 
(
∞∞ 
var
∞∞ 
s
∞∞ 
in
∞∞ 
siniestrosVP
∞∞ *
)
∞∞* +
{
±± 
var
≥≥ 
numeroPolizaStr
≥≥ #
=
≥≥$ %
new
≥≥& )
string
≥≥* 0
(
≥≥0 1
s
≥≥1 2
.
≥≥2 3
NumeroPoliza
≥≥3 ?
!
≥≥? @
.
≥≥@ A
Where
≥≥A F
(
≥≥F G
char
≥≥G K
.
≥≥K L
IsDigit
≥≥L S
)
≥≥S T
.
≥≥T U
ToArray
≥≥U \
(
≥≥\ ]
)
≥≥] ^
)
≥≥^ _
;
≥≥_ `
if
∂∂ 
(
∂∂ 
!
∂∂ 
int
∂∂ 
.
∂∂ 
TryParse
∂∂ !
(
∂∂! "
numeroPolizaStr
∂∂" 1
,
∂∂1 2
CultureInfo
∂∂3 >
.
∂∂> ?
InvariantCulture
∂∂? O
,
∂∂O P
out
∂∂Q T
int
∂∂U X
numeroDocto
∂∂Y d
)
∂∂d e
)
∂∂e f
{
∑∑ 
this
∏∏ 
.
∏∏ 
_logger
∏∏  
.
∏∏  !
Debug
∏∏! &
(
∏∏& '
$"
∏∏' )
$str
∏∏) J
{
∏∏J K
s
∏∏K L
.
∏∏L M
NumeroPoliza
∏∏M Y
}
∏∏Y Z
$str
∏∏Z u
"
∏∏u v
)
∏∏v w
;
∏∏w x
continue
ππ 
;
ππ 
}
∫∫ 
var
ºº 

detRequest
ºº 
=
ºº  
new
ºº! $"
SiniestrosDetRequest
ºº% 9
{
ΩΩ 
INsinie
ææ 
=
ææ 
s
ææ 
.
ææ  
NumeroSiniestro
ææ  /
!
ææ/ 0
.
ææ0 1
Value
ææ1 6
,
ææ6 7
INdocto
øø 
=
øø 
numeroDocto
øø )
,
øø) *
}
¿¿ 
;
¿¿ 
	resultado
¬¬ 
.
¬¬ 
Add
¬¬ 
(
¬¬ 
(
¬¬ 

detRequest
¬¬ )
,
¬¬) *
s
¬¬+ ,
)
¬¬, -
)
¬¬- .
;
¬¬. /
}
√√ 
return
∆∆ 
	resultado
∆∆ 
.
«« 

DistinctBy
«« 
(
«« 
x
«« 
=>
««  
new
««! $
{
««% &
x
««' (
.
««( )
Request
««) 0
.
««0 1
INsinie
««1 8
,
««8 9
x
««: ;
.
««; <
Request
««< C
.
««C D
INdocto
««D K
}
««L M
)
««M N
.
»» 
ToList
»» 
(
»» 
)
»» 
;
»» 
}
…… 	
private
–– 
async
–– 
Task
–– 
<
–– 
SiniestrosDataDto
–– ,
>
––, -#
EnriquecerConDetalles
––. C
(
––C D
List
—— 
<
—— 
(
—— "
SiniestrosDetRequest
—— &
Request
——' .
,
——. /$
SiniestrosDataResponse
——0 F
OriginalData
——G S
)
——S T
>
——T U"
siniestrosConRequest
——V j
)
——j k
{
““ 	
var
”” 
siniestrosDataDTO
”” !
=
””" #
new
””$ '
SiniestrosDataDto
””( 9
(
””9 :
)
””: ;
;
””; <
var
÷÷ 
tasks
÷÷ 
=
÷÷ "
siniestrosConRequest
÷÷ ,
.
÷÷, -
Select
÷÷- 3
(
÷÷3 4
async
÷÷4 9
item
÷÷: >
=>
÷÷? A
{
◊◊ 
try
ÿÿ 
{
ŸŸ 
var
€€ #
siniestrosDetResponse
€€ -
=
€€. /
await
€€0 5
this
€€6 :
.
€€: ;&
_resiliencePolicyService
€€; S
.
€€S T
BulkheadPipeline
€€T d
.
€€d e
ExecuteAsync
€€e q
(
€€q r
async
‹‹ 
_
‹‹ 
=>
‹‹  "
await
‹‹# (
this
‹‹) -
.
‹‹- ."
GetDetalleSiniestros
‹‹. B
(
‹‹B C
item
‹‹C G
.
‹‹G H
Request
‹‹H O
)
‹‹O P
.
‹‹P Q
ConfigureAwait
‹‹Q _
(
‹‹_ `
false
‹‹` e
)
‹‹e f
,
‹‹f g
CancellationToken
›› )
.
››) *
None
››* .
)
››. /
.
››/ 0
ConfigureAwait
››0 >
(
››> ?
false
››? D
)
››D E
;
››E F
if
ﬂﬂ 
(
ﬂﬂ #
siniestrosDetResponse
ﬂﬂ -
.
ﬂﬂ- .
Data
ﬂﬂ. 2
==
ﬂﬂ3 5
null
ﬂﬂ6 :
)
ﬂﬂ: ;
{
‡‡ 
this
·· 
.
·· 
_logger
·· $
.
··$ %
Debug
··% *
(
··* +
$"
··+ -
$str
··- W
{
··W X
item
··X \
.
··\ ]
Request
··] d
.
··d e
INsinie
··e l
}
··l m
"
··m n
)
··n o
;
··o p
return
‚‚ 
null
‚‚ #
;
‚‚# $
}
„„ 
var
ÊÊ 
dtos
ÊÊ 
=
ÊÊ 
new
ÊÊ "
List
ÊÊ# '
<
ÊÊ' (
SiniestroDto
ÊÊ( 4
>
ÊÊ4 5
(
ÊÊ5 6
)
ÊÊ6 7
;
ÊÊ7 8
foreach
ÁÁ 
(
ÁÁ 
var
ÁÁ  
detalle
ÁÁ! (
in
ÁÁ) +#
siniestrosDetResponse
ÁÁ, A
.
ÁÁA B
Data
ÁÁB F
)
ÁÁF G
{
ËË 
dtos
ÈÈ 
.
ÈÈ 
Add
ÈÈ  
(
ÈÈ  !
new
ÈÈ! $
SiniestroDto
ÈÈ% 1
{
ÍÍ 
NumSiniestro
ÎÎ (
=
ÎÎ) *
item
ÎÎ+ /
.
ÎÎ/ 0
OriginalData
ÎÎ0 <
.
ÎÎ< =
NumeroSiniestro
ÎÎ= L
?
ÎÎL M
.
ÎÎM N
ToString
ÎÎN V
(
ÎÎV W
CultureInfo
ÎÎW b
.
ÎÎb c
InvariantCulture
ÎÎc s
)
ÎÎs t
??
ÎÎu w
string
ÎÎx ~
.
ÎÎ~ 
EmptyÎÎ Ñ
,ÎÎÑ Ö
TipoSinistros
ÏÏ )
=
ÏÏ* +
$str
ÏÏ, 2
,
ÏÏ2 3
GlosaSiniestro
ÌÌ *
=
ÌÌ+ ,
$"
ÌÌ- /
$str
ÌÌ/ 8
{
ÌÌ8 9
detalle
ÌÌ9 @
.
ÌÌ@ A
Patente
ÌÌA H
}
ÌÌH I
"
ÌÌI J
,
ÌÌJ K
FechaDenuncio
ÓÓ )
=
ÓÓ* +
item
ÓÓ, 0
.
ÓÓ0 1
OriginalData
ÓÓ1 =
.
ÓÓ= >
FechaDenuncia
ÓÓ> K
??
ÓÓL N
string
ÓÓO U
.
ÓÓU V
Empty
ÓÓV [
,
ÓÓ[ \
EstadoSinistro
ÔÔ *
=
ÔÔ+ ,
item
ÔÔ- 1
.
ÔÔ1 2
OriginalData
ÔÔ2 >
.
ÔÔ> ?
Estado
ÔÔ? E
??
ÔÔF H
string
ÔÔI O
.
ÔÔO P
Empty
ÔÔP U
,
ÔÔU V
EstadoDenuncio
 *
=
+ ,
item
- 1
.
1 2
OriginalData
2 >
.
> ?
CodigoEstado
? K
??
L N
string
O U
.
U V
Empty
V [
,
[ \ 
AccionesPendientes
ÒÒ .
=
ÒÒ/ 0
false
ÒÒ1 6
,
ÒÒ6 7
}
ÚÚ 
)
ÚÚ 
;
ÚÚ 
}
ÛÛ 
return
ıı 
dtos
ıı 
;
ıı  
}
ˆˆ 
catch
˜˜ 
(
˜˜ 
ArgumentException
˜˜ (
ex
˜˜) +
)
˜˜+ ,
{
¯¯ 
this
˘˘ 
.
˘˘ 
_logger
˘˘  
.
˘˘  !
LogError
˘˘! )
(
˘˘) *
ex
˘˘* ,
,
˘˘, -
$"
˘˘. 0
$str
˘˘0 e
{
˘˘e f
item
˘˘f j
.
˘˘j k
Request
˘˘k r
.
˘˘r s
INsinie
˘˘s z
}
˘˘z {
"
˘˘{ |
)
˘˘| }
;
˘˘} ~
return
˙˙ 
null
˙˙ 
;
˙˙  
}
˚˚ 
catch
¸¸ 
(
¸¸ '
InvalidOperationException
¸¸ 0
ex
¸¸1 3
)
¸¸3 4
{
˝˝ 
this
˛˛ 
.
˛˛ 
_logger
˛˛  
.
˛˛  !
LogError
˛˛! )
(
˛˛) *
ex
˛˛* ,
,
˛˛, -
$"
˛˛. 0
$str
˛˛0 W
{
˛˛W X
item
˛˛X \
.
˛˛\ ]
Request
˛˛] d
.
˛˛d e
INsinie
˛˛e l
}
˛˛l m
"
˛˛m n
)
˛˛n o
;
˛˛o p
return
ˇˇ 
null
ˇˇ 
;
ˇˇ  
}
ÄÄ 
}
ÅÅ 
)
ÅÅ 
;
ÅÅ 
var
ÑÑ 
results
ÑÑ 
=
ÑÑ 
await
ÑÑ 
Task
ÑÑ  $
.
ÑÑ$ %
WhenAll
ÑÑ% ,
(
ÑÑ, -
tasks
ÑÑ- 2
)
ÑÑ2 3
.
ÑÑ3 4
ConfigureAwait
ÑÑ4 B
(
ÑÑB C
false
ÑÑC H
)
ÑÑH I
;
ÑÑI J
foreach
áá 
(
áá 
var
áá 
dto
áá 
in
áá 
results
áá  '
.
áá' (
Where
áá( -
(
áá- .
r
áá. /
=>
áá0 2
r
áá3 4
!=
áá5 7
null
áá8 <
)
áá< =
.
áá= >

SelectMany
áá> H
(
ááH I
r
ááI J
=>
ááK M
r
ááN O
!
ááO P
)
ááP Q
)
ááQ R
{
àà 
siniestrosDataDTO
ââ !
.
ââ! "

Siniestros
ââ" ,
.
ââ, -
Add
ââ- 0
(
ââ0 1
dto
ââ1 4
)
ââ4 5
;
ââ5 6
}
ää 
return
åå 
siniestrosDataDTO
åå $
;
åå$ %
}
çç 	
}
éé 
}èè ö
pC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Handlers\Interfaces\ISiniestrosHandler.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Handlers! )
.) *

Interfaces* 4
{ 
public 

	interface 
ISiniestrosHandler '
{ 
Task 
< 
SiniestrosDataDto 
> ,
 GetSiniestrosDetallePorAsegurado  @
(@ A
stringA G
rutH K
)K L
;L M
Task 
< 
SiniestrosResponse 
>  %
GetSiniestrosPorAsegurado! :
(: ;
SiniestrosRequest; L
requestM T
)T U
;U V
Task!! 
<!! %
SiniestrosDetalleResponse!! &
>!!& ' 
GetDetalleSiniestros!!( <
(!!< = 
SiniestrosDetRequest!!= Q
request!!R Y
)!!Y Z
;!!Z [
}"" 
}## ı
jC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Handlers\Interfaces\IHttpHandler.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Handlers! )
.) *

Interfaces* 4
{ 
public 

	interface 
IHttpHandler !
{ 
Task 
< 
	TResponse 
? 
> "
GetWithValidationAsync /
</ 0
	TResponse0 9
>9 :
(: ;
Uri 
url 
, 
string 
? 
bearerToken 
=  !
null" &
,& '
Func 
< 
	TResponse 
? 
, 
bool !
>! "
?" #
validateResponse$ 4
=5 6
null7 ;
); <
where 
	TResponse 
: 
class #
;# $
Task'' 
<'' 
	TResponse'' 
?'' 
>'' #
PostWithValidationAsync'' 0
<''0 1
TRequest''1 9
,''9 :
	TResponse''; D
>''D E
(''E F
Uri(( 
url(( 
,(( 
TRequest)) 
body)) 
,)) 
string** 
?** 
bearerToken** 
=**  !
null**" &
,**& '
Func++ 
<++ 
TRequest++ 
,++ 
bool++ 
>++  
?++  !
validateRequest++" 1
=++2 3
null++4 8
,++8 9
Func,, 
<,, 
	TResponse,, 
?,, 
,,, 
bool,, !
>,,! "
?,," #
validateResponse,,$ 4
=,,5 6
null,,7 ;
),,; <
where-- 
TRequest-- 
:-- 
class-- "
where.. 
	TResponse.. 
:.. 
class.. #
;..# $
Task77 
<77 
List77 
<77 
	TResponse77 
?77 
>77 
>77 
GetMultipleAsync77 /
<77/ 0
	TResponse770 9
>779 :
(77: ;
IEnumerable88 
<88 
Uri88 
>88 
urls88 !
,88! "
string99 
?99 
bearerToken99 
=99  !
null99" &
)99& '
where:: 
	TResponse:: 
::: 
class:: #
;::# $
TaskEE 
<EE 
	TResponseEE 
?EE 
>EE 
GetWithRetryAsyncEE *
<EE* +
	TResponseEE+ 4
>EE4 5
(EE5 6
UriFF 
urlFF 
,FF 
stringGG 
?GG 
bearerTokenGG 
=GG  !
nullGG" &
,GG& '
intHH 

maxRetriesHH 
=HH 
$numHH 
,HH 
intII 
delayMsII 
=II 
$numII 
)II 
whereJJ 
	TResponseJJ 
:JJ 
classJJ #
;JJ# $
TaskSS 
<SS 
HttpApiResponseSS 
<SS 
	TResponseSS &
>SS& '
>SS' (%
ExecuteCustomRequestAsyncSS) B
<SSB C
	TResponseSSC L
>SSL M
(SSM N
HttpRequestTT 
requestTT 
,TT  
FuncUU 
<UU 
HttpApiResponseUU  
<UU  !
	TResponseUU! *
>UU* +
,UU+ ,
TaskUU- 1
<UU1 2
HttpApiResponseUU2 A
<UUA B
	TResponseUUB K
>UUK L
>UUL M
>UUM N
?UUN O
processResponseUUP _
=UU` a
nullUUb f
)UUf g
whereVV 
	TResponseVV 
:VV 
classVV #
;VV# $
}WW 
}XX Ì 
^C:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Handlers\HttpHandler.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Handlers! )
{ 
public 

class 
HttpHandler 
: 
IHttpHandler +
{ 
private 
readonly 
IHttpService %
_httpService& 2
;2 3
private 
readonly 

IAppLogger #
<# $
HttpHandler$ /
>/ 0
_logger1 8
;8 9
public 
HttpHandler 
( 
IHttpService 
httpService $
,$ %

IAppLogger   
<   
HttpHandler   "
>  " #
logger  $ *
)  * +
{!! 	
this"" 
."" 
_httpService"" 
="" 
httpService""  +
??"", .
throw""/ 4
new""5 8!
ArgumentNullException""9 N
(""N O
nameof""O U
(""U V
httpService""V a
)""a b
)""b c
;""c d
this## 
.## 
_logger## 
=## 
logger## !
??##" $
throw##% *
new##+ .!
ArgumentNullException##/ D
(##D E
nameof##E K
(##K L
logger##L R
)##R S
)##S T
;##T U
}$$ 	
public.. 
async.. 
Task.. 
<.. 
	TResponse.. #
?..# $
>..$ %"
GetWithValidationAsync..& <
<..< =
	TResponse..= F
>..F G
(..G H
Uri// 
url// 
,// 
string00 
?00 
bearerToken00 
=00  !
null00" &
,00& '
Func11 
<11 
	TResponse11 
?11 
,11 
bool11 !
>11! "
?11" #
validateResponse11$ 4
=115 6
null117 ;
)11; <
where22 
	TResponse22 
:22 
class22 #
{33 	!
ArgumentNullException44 !
.44! "
ThrowIfNull44" -
(44- .
url44. 1
)441 2
;442 3
this66 
.66 
_logger66 
.66 
Info66 
(66 
$"66  
$str66  @
{66@ A
url66A D
}66D E
"66E F
)66F G
;66G H
try88 
{99 
var:: 
response:: 
=:: 
await:: $
this::% )
.::) *
_httpService::* 6
.::6 7
GetAsync::7 ?
<::? @
	TResponse::@ I
>::I J
(::J K
url::K N
,::N O
bearerToken::P [
)::[ \
.::\ ]
ConfigureAwait::] k
(::k l
false::l q
)::q r
;::r s
if<< 
(<< 
response<< 
==<< 
null<<  $
)<<$ %
{== 
this>> 
.>> 
_logger>>  
.>>  !
Info>>! %
(>>% &
$">>& (
$str>>( >
{>>> ?
url>>? B
}>>B C
">>C D
)>>D E
;>>E F
return?? 
null?? 
;??  
}@@ 
ifCC 
(CC 
validateResponseCC $
!=CC% '
nullCC( ,
&&CC- /
!CC0 1
validateResponseCC1 A
(CCA B
responseCCB J
)CCJ K
)CCK L
{DD 
thisEE 
.EE 
_loggerEE  
.EE  !
InfoEE! %
(EE% &
$"EE& (
$strEE( ]
{EE] ^
urlEE^ a
}EEa b
"EEb c
)EEc d
;EEd e
returnFF 
nullFF 
;FF  
}GG 
thisII 
.II 
_loggerII 
.II 
InfoII !
(II! "
$"II" $
$strII$ F
{IIF G
urlIIG J
}IIJ K
"IIK L
)IIL M
;IIM N
returnJJ 
responseJJ 
;JJ  
}KK 
catchLL 
(LL %
InvalidOperationExceptionLL ,
exLL- /
)LL/ 0
{MM 
thisNN 
.NN 
_loggerNN 
.NN 
LogErrorNN %
(NN% &
exNN& (
,NN( )
$"NN* ,
$strNN, W
{NNW X
urlNNX [
}NN[ \
"NN\ ]
)NN] ^
;NN^ _
throwOO 
;OO 
}PP 
catchQQ 
(QQ  
HttpRequestExceptionQQ '
exQQ( *
)QQ* +
{RR 
thisSS 
.SS 
_loggerSS 
.SS 
LogErrorSS %
(SS% &
exSS& (
,SS( )
$"SS* ,
$strSS, Q
{SSQ R
urlSSR U
}SSU V
"SSV W
)SSW X
;SSX Y
throwTT 
;TT 
}UU 
}VV 	
publiccc 
asynccc 
Taskcc 
<cc 
	TResponsecc #
?cc# $
>cc$ %#
PostWithValidationAsynccc& =
<cc= >
TRequestcc> F
,ccF G
	TResponseccH Q
>ccQ R
(ccR S
Uridd 
urldd 
,dd 
TRequestee 
bodyee 
,ee 
stringff 
?ff 
bearerTokenff 
=ff  !
nullff" &
,ff& '
Funcgg 
<gg 
TRequestgg 
,gg 
boolgg 
>gg  
?gg  !
validateRequestgg" 1
=gg2 3
nullgg4 8
,gg8 9
Funchh 
<hh 
	TResponsehh 
?hh 
,hh 
boolhh !
>hh! "
?hh" #
validateResponsehh$ 4
=hh5 6
nullhh7 ;
)hh; <
whereii 
TRequestii 
:ii 
classii "
wherejj 
	TResponsejj 
:jj 
classjj #
{kk 	!
ArgumentNullExceptionll !
.ll! "
ThrowIfNullll" -
(ll- .
urlll. 1
)ll1 2
;ll2 3!
ArgumentNullExceptionmm !
.mm! "
ThrowIfNullmm" -
(mm- .
bodymm. 2
)mm2 3
;mm3 4
thisoo 
.oo 
_loggeroo 
.oo 
Infooo 
(oo 
$"oo  
$stroo  A
{ooA B
urlooB E
}ooE F
"ooF G
)ooG H
;ooH I
tryqq 
{rr 
iftt 
(tt 
validateRequesttt #
!=tt$ &
nulltt' +
&&tt, .
!tt/ 0
validateRequesttt0 ?
(tt? @
bodytt@ D
)ttD E
)ttE F
{uu 
thisvv 
.vv 
_loggervv  
.vv  !
Infovv! %
(vv% &
$"vv& (
$strvv( Z
{vvZ [
urlvv[ ^
}vv^ _
"vv_ `
)vv` a
;vva b
throwww 
newww 
ArgumentExceptionww /
(ww/ 0
$strww0 `
)ww` a
;wwa b
}xx 
varzz 
responsezz 
=zz 
awaitzz $
thiszz% )
.zz) *
_httpServicezz* 6
.zz6 7
	PostAsynczz7 @
<zz@ A
TRequestzzA I
,zzI J
	TResponsezzK T
>zzT U
(zzU V
urlzzV Y
,zzY Z
bodyzz[ _
,zz_ `
bearerTokenzza l
)zzl m
.zzm n
ConfigureAwaitzzn |
(zz| }
false	zz} Ç
)
zzÇ É
;
zzÉ Ñ
if|| 
(|| 
response|| 
==|| 
null||  $
)||$ %
{}} 
this~~ 
.~~ 
_logger~~  
.~~  !
Info~~! %
(~~% &
$"~~& (
$str~~( >
{~~> ?
url~~? B
}~~B C
"~~C D
)~~D E
;~~E F
return 
null 
;  
}
ÄÄ 
if
ÉÉ 
(
ÉÉ 
validateResponse
ÉÉ $
!=
ÉÉ% '
null
ÉÉ( ,
&&
ÉÉ- /
!
ÉÉ0 1
validateResponse
ÉÉ1 A
(
ÉÉA B
response
ÉÉB J
)
ÉÉJ K
)
ÉÉK L
{
ÑÑ 
this
ÖÖ 
.
ÖÖ 
_logger
ÖÖ  
.
ÖÖ  !
Info
ÖÖ! %
(
ÖÖ% &
$"
ÖÖ& (
$str
ÖÖ( ]
{
ÖÖ] ^
url
ÖÖ^ a
}
ÖÖa b
"
ÖÖb c
)
ÖÖc d
;
ÖÖd e
return
ÜÜ 
null
ÜÜ 
;
ÜÜ  
}
áá 
this
ââ 
.
ââ 
_logger
ââ 
.
ââ 
Info
ââ !
(
ââ! "
$"
ââ" $
$str
ââ$ C
{
ââC D
url
ââD G
}
ââG H
"
ââH I
)
ââI J
;
ââJ K
return
ää 
response
ää 
;
ää  
}
ãã 
catch
åå 
(
åå 
ArgumentException
åå $
ex
åå% '
)
åå' (
{
çç 
this
éé 
.
éé 
_logger
éé 
.
éé 
LogError
éé %
(
éé% &
ex
éé& (
,
éé( )
$str
éé* b
)
ééb c
;
ééc d
throw
èè 
;
èè 
}
êê 
catch
ëë 
(
ëë '
InvalidOperationException
ëë ,
ex
ëë- /
)
ëë/ 0
{
íí 
this
ìì 
.
ìì 
_logger
ìì 
.
ìì 
LogError
ìì %
(
ìì% &
ex
ìì& (
,
ìì( )
$"
ìì* ,
$str
ìì, R
{
ììR S
url
ììS V
}
ììV W
"
ììW X
)
ììX Y
;
ììY Z
throw
îî 
;
îî 
}
ïï 
catch
ññ 
(
ññ "
HttpRequestException
ññ '
ex
ññ( *
)
ññ* +
{
óó 
this
òò 
.
òò 
_logger
òò 
.
òò 
LogError
òò %
(
òò% &
ex
òò& (
,
òò( )
$"
òò* ,
$str
òò, L
{
òòL M
url
òòM P
}
òòP Q
"
òòQ R
)
òòR S
;
òòS T
throw
ôô 
;
ôô 
}
öö 
}
õõ 	
public
§§ 
async
§§ 
Task
§§ 
<
§§ 
List
§§ 
<
§§ 
	TResponse
§§ (
?
§§( )
>
§§) *
>
§§* +
GetMultipleAsync
§§, <
<
§§< =
	TResponse
§§= F
>
§§F G
(
§§G H
IEnumerable
•• 
<
•• 
Uri
•• 
>
•• 
urls
•• 
,
•• 
string
¶¶ 
?
¶¶ 
bearerToken
¶¶ 
=
¶¶ 
null
¶¶ "
)
¶¶" #
where
ßß 
	TResponse
ßß 
:
ßß 
class
ßß 
{
®® 	#
ArgumentNullException
©© !
.
©©! "
ThrowIfNull
©©" -
(
©©- .
urls
©©. 2
)
©©2 3
;
©©3 4
var
¨¨ 
urlList
¨¨ 
=
¨¨ 
urls
¨¨ 
.
¨¨ 
ToList
¨¨ %
(
¨¨% &
)
¨¨& '
;
¨¨' (
if
ÆÆ 
(
ÆÆ 
urlList
ÆÆ 
.
ÆÆ 
Count
ÆÆ 
==
ÆÆ  
$num
ÆÆ! "
)
ÆÆ" #
{
ØØ 
this
∞∞ 
.
∞∞ 
_logger
∞∞ 
.
∞∞ 
Info
∞∞ !
(
∞∞! "
$str
∞∞" Q
)
∞∞Q R
;
∞∞R S
return
±± 
new
±± 
(
±± 
)
±± 
;
±± 
}
≤≤ 
this
¥¥ 
.
¥¥ 
_logger
¥¥ 
.
¥¥ 
Info
¥¥ 
(
¥¥ 
$"
¥¥  
$str
¥¥  *
{
¥¥* +
urlList
¥¥+ 2
.
¥¥2 3
Count
¥¥3 8
}
¥¥8 9
$str
¥¥9 T
"
¥¥T U
)
¥¥U V
;
¥¥V W
try
∂∂ 
{
∑∑ 
var
ππ 
tasks
ππ 
=
ππ 
urlList
ππ #
.
ππ# $
Select
ππ$ *
(
ππ* +
url
ππ+ .
=>
ππ/ 1
this
ππ2 6
.
ππ6 7
_httpService
ππ7 C
.
ππC D
GetAsync
ππD L
<
ππL M
	TResponse
ππM V
>
ππV W
(
ππW X
url
ππX [
,
ππ[ \
bearerToken
ππ] h
)
ππh i
)
ππi j
;
ππj k
var
ªª 
results
ªª 
=
ªª 
await
ªª #
Task
ªª$ (
.
ªª( )
WhenAll
ªª) 0
(
ªª0 1
tasks
ªª1 6
)
ªª6 7
.
ªª7 8
ConfigureAwait
ªª8 F
(
ªªF G
false
ªªG L
)
ªªL M
;
ªªM N
var
ΩΩ 
successCount
ΩΩ  
=
ΩΩ! "
results
ΩΩ# *
.
ΩΩ* +
Count
ΩΩ+ 0
(
ΩΩ0 1
r
ΩΩ1 2
=>
ΩΩ3 5
r
ΩΩ6 7
!=
ΩΩ8 :
null
ΩΩ; ?
)
ΩΩ? @
;
ΩΩ@ A
this
ææ 
.
ææ 
_logger
ææ 
.
ææ 
Info
ææ !
(
ææ! "
$"
ææ" $
$str
ææ$ 0
{
ææ0 1
successCount
ææ1 =
}
ææ= >
$str
ææ> ?
{
ææ? @
urlList
ææ@ G
.
ææG H
Count
ææH M
}
ææM N
$str
ææN b
"
ææb c
)
ææc d
;
ææd e
return
¿¿ 
results
¿¿ 
.
¿¿ 
ToList
¿¿ %
(
¿¿% &
)
¿¿& '
;
¿¿' (
}
¡¡ 
catch
¬¬ 
(
¬¬ '
InvalidOperationException
¬¬ ,
ex
¬¬- /
)
¬¬/ 0
{
√√ 
this
ƒƒ 
.
ƒƒ 
_logger
ƒƒ 
.
ƒƒ 
LogError
ƒƒ %
(
ƒƒ% &
ex
ƒƒ& (
,
ƒƒ( )
$str
ƒƒ* V
)
ƒƒV W
;
ƒƒW X
throw
≈≈ 
;
≈≈ 
}
∆∆ 
catch
«« 
(
«« "
HttpRequestException
«« '
ex
««( *
)
««* +
{
»» 
this
…… 
.
…… 
_logger
…… 
.
…… 
LogError
…… %
(
……% &
ex
……& (
,
……( )
$str
……* P
)
……P Q
;
……Q R
throw
   
;
   
}
ÀÀ 
}
ÃÃ 	
public
◊◊ 
async
◊◊ 
Task
◊◊ 
<
◊◊ 
	TResponse
◊◊ #
?
◊◊# $
>
◊◊$ %
GetWithRetryAsync
◊◊& 7
<
◊◊7 8
	TResponse
◊◊8 A
>
◊◊A B
(
◊◊B C
Uri
ÿÿ 
url
ÿÿ 
,
ÿÿ 
string
ŸŸ 
?
ŸŸ 
bearerToken
ŸŸ 
=
ŸŸ  !
null
ŸŸ" &
,
ŸŸ& '
int
⁄⁄ 

maxRetries
⁄⁄ 
=
⁄⁄ 
$num
⁄⁄ 
,
⁄⁄ 
int
€€ 
delayMs
€€ 
=
€€ 
$num
€€ 
)
€€ 
where
‹‹ 
	TResponse
‹‹ 
:
‹‹ 
class
‹‹ #
{
›› 	#
ArgumentNullException
ﬁﬁ !
.
ﬁﬁ! "
ThrowIfNull
ﬁﬁ" -
(
ﬁﬁ- .
url
ﬁﬁ. 1
)
ﬁﬁ1 2
;
ﬁﬁ2 3
if
‡‡ 
(
‡‡ 

maxRetries
‡‡ 
<
‡‡ 
$num
‡‡ 
)
‡‡ 
{
·· 
throw
‚‚ 
new
‚‚ 
ArgumentException
‚‚ +
(
‚‚+ ,
$str
‚‚, X
,
‚‚X Y
nameof
‚‚Z `
(
‚‚` a

maxRetries
‚‚a k
)
‚‚k l
)
‚‚l m
;
‚‚m n
}
„„ 
if
ÂÂ 
(
ÂÂ 
delayMs
ÂÂ 
<
ÂÂ 
$num
ÂÂ 
)
ÂÂ 
{
ÊÊ 
throw
ÁÁ 
new
ÁÁ 
ArgumentException
ÁÁ +
(
ÁÁ+ ,
$str
ÁÁ, Q
,
ÁÁQ R
nameof
ÁÁS Y
(
ÁÁY Z
delayMs
ÁÁZ a
)
ÁÁa b
)
ÁÁb c
;
ÁÁc d
}
ËË 
this
ÍÍ 
.
ÍÍ 
_logger
ÍÍ 
.
ÍÍ 
Info
ÍÍ 
(
ÍÍ 
$"
ÍÍ  
$str
ÍÍ  >
{
ÍÍ> ?

maxRetries
ÍÍ? I
}
ÍÍI J
$str
ÍÍJ O
{
ÍÍO P
url
ÍÍP S
}
ÍÍS T
"
ÍÍT U
)
ÍÍU V
;
ÍÍV W
for
ÏÏ 
(
ÏÏ 
int
ÏÏ 
attempt
ÏÏ 
=
ÏÏ 
$num
ÏÏ  
;
ÏÏ  !
attempt
ÏÏ" )
<=
ÏÏ* ,

maxRetries
ÏÏ- 7
;
ÏÏ7 8
attempt
ÏÏ9 @
++
ÏÏ@ B
)
ÏÏB C
{
ÌÌ 
try
ÓÓ 
{
ÔÔ 
this
 
.
 
_logger
  
.
  !
Debug
! &
(
& '
$"
' )
$str
) 1
{
1 2
attempt
2 9
}
9 :
$str
: ;
{
; <

maxRetries
< F
}
F G
$str
G N
{
N O
url
O R
}
R S
"
S T
)
T U
;
U V
var
ÚÚ 
response
ÚÚ  
=
ÚÚ! "
await
ÚÚ# (
this
ÚÚ) -
.
ÚÚ- .
_httpService
ÚÚ. :
.
ÚÚ: ;
GetAsync
ÚÚ; C
<
ÚÚC D
	TResponse
ÚÚD M
>
ÚÚM N
(
ÚÚN O
url
ÚÚO R
,
ÚÚR S
bearerToken
ÚÚT _
)
ÚÚ_ `
.
ÚÚ` a
ConfigureAwait
ÚÚa o
(
ÚÚo p
false
ÚÚp u
)
ÚÚu v
;
ÚÚv w
if
ÙÙ 
(
ÙÙ 
response
ÙÙ  
!=
ÙÙ! #
null
ÙÙ$ (
)
ÙÙ( )
{
ıı 
this
ˆˆ 
.
ˆˆ 
_logger
ˆˆ $
.
ˆˆ$ %
Info
ˆˆ% )
(
ˆˆ) *
$"
ˆˆ* ,
$str
ˆˆ, C
{
ˆˆC D
attempt
ˆˆD K
}
ˆˆK L
$str
ˆˆL M
{
ˆˆM N

maxRetries
ˆˆN X
}
ˆˆX Y
$str
ˆˆY `
{
ˆˆ` a
url
ˆˆa d
}
ˆˆd e
"
ˆˆe f
)
ˆˆf g
;
ˆˆg h
return
˜˜ 
response
˜˜ '
;
˜˜' (
}
¯¯ 
this
˙˙ 
.
˙˙ 
_logger
˙˙  
.
˙˙  !
Info
˙˙! %
(
˙˙% &
$"
˙˙& (
$str
˙˙( B
{
˙˙B C
attempt
˙˙C J
}
˙˙J K
$str
˙˙K L
{
˙˙L M

maxRetries
˙˙M W
}
˙˙W X
$str
˙˙X _
{
˙˙_ `
url
˙˙` c
}
˙˙c d
"
˙˙d e
)
˙˙e f
;
˙˙f g
}
˚˚ 
catch
¸¸ 
(
¸¸ "
HttpRequestException
¸¸ +
ex
¸¸, .
)
¸¸. /
{
˝˝ 
this
˛˛ 
.
˛˛ 
_logger
˛˛  
.
˛˛  !
Info
˛˛! %
(
˛˛% &
$"
˛˛& (
$str
˛˛( 9
{
˛˛9 :
attempt
˛˛: A
}
˛˛A B
$str
˛˛B C
{
˛˛C D

maxRetries
˛˛D N
}
˛˛N O
$str
˛˛O V
{
˛˛V W
url
˛˛W Z
}
˛˛Z [
$str
˛˛[ ^
{
˛˛^ _
ex
˛˛_ a
.
˛˛a b
Message
˛˛b i
}
˛˛i j
"
˛˛j k
)
˛˛k l
;
˛˛l m
if
ÅÅ 
(
ÅÅ 
attempt
ÅÅ 
<
ÅÅ  !

maxRetries
ÅÅ" ,
)
ÅÅ, -
{
ÇÇ 
this
ÉÉ 
.
ÉÉ 
_logger
ÉÉ $
.
ÉÉ$ %
Debug
ÉÉ% *
(
ÉÉ* +
$"
ÉÉ+ -
$str
ÉÉ- 7
{
ÉÉ7 8
delayMs
ÉÉ8 ?
}
ÉÉ? @
$str
ÉÉ@ a
"
ÉÉa b
)
ÉÉb c
;
ÉÉc d
await
ÑÑ 
Task
ÑÑ "
.
ÑÑ" #
Delay
ÑÑ# (
(
ÑÑ( )
delayMs
ÑÑ) 0
)
ÑÑ0 1
.
ÑÑ1 2
ConfigureAwait
ÑÑ2 @
(
ÑÑ@ A
false
ÑÑA F
)
ÑÑF G
;
ÑÑG H
}
ÖÖ 
else
ÜÜ 
{
áá 
this
àà 
.
àà 
_logger
àà $
.
àà$ %
LogError
àà% -
(
àà- .
ex
àà. 0
,
àà0 1
$"
àà2 4
$str
àà4 V
{
ààV W
url
ààW Z
}
ààZ [
"
àà[ \
)
àà\ ]
;
àà] ^
throw
ââ 
;
ââ 
}
ää 
}
ãã 
catch
åå 
(
åå '
InvalidOperationException
åå 0
ex
åå1 3
)
åå3 4
{
çç 
this
éé 
.
éé 
_logger
éé  
.
éé  !
LogError
éé! )
(
éé) *
ex
éé* ,
,
éé, -
$"
éé. 0
$str
éé0 N
{
ééN O
attempt
ééO V
}
ééV W
$str
ééW X
{
ééX Y

maxRetries
ééY c
}
ééc d
$str
ééd k
{
éék l
url
éél o
}
ééo p
"
éép q
)
ééq r
;
éér s
throw
èè 
;
èè 
}
êê 
}
ëë 
this
ìì 
.
ìì 
_logger
ìì 
.
ìì 
Info
ìì 
(
ìì 
$"
ìì  
$str
ìì  *
{
ìì* +

maxRetries
ìì+ 5
}
ìì5 6
$str
ìì6 c
{
ììc d
url
ììd g
}
ììg h
"
ììh i
)
ììi j
;
ììj k
return
îî 
null
îî 
;
îî 
}
ïï 	
public
ûû 
async
ûû 
Task
ûû 
<
ûû 
HttpApiResponse
ûû )
<
ûû) *
	TResponse
ûû* 3
>
ûû3 4
>
ûû4 5'
ExecuteCustomRequestAsync
ûû6 O
<
ûûO P
	TResponse
ûûP Y
>
ûûY Z
(
ûûZ [
HttpRequest
üü 
request
üü 
,
üü  
Func
†† 
<
†† 
HttpApiResponse
††  
<
††  !
	TResponse
††! *
>
††* +
,
††+ ,
Task
††- 1
<
††1 2
HttpApiResponse
††2 A
<
††A B
	TResponse
††B K
>
††K L
>
††L M
>
††M N
?
††N O
processResponse
††P _
=
††` a
null
††b f
)
††f g
where
°° 
	TResponse
°° 
:
°° 
class
°° #
{
¢¢ 	#
ArgumentNullException
££ !
.
££! "
ThrowIfNull
££" -
(
££- .
request
££. 5
)
££5 6
;
££6 7
this
•• 
.
•• 
_logger
•• 
.
•• 
Info
•• 
(
•• 
$"
••  
$str
••  A
{
••A B
request
••B I
.
••I J
Method
••J P
}
••P Q
$str
••Q U
{
••U V
request
••V ]
.
••] ^
Url
••^ a
}
••a b
"
••b c
)
••c d
;
••d e
try
ßß 
{
®® 
var
©© 
response
©© 
=
©© 
await
©© $
this
©©% )
.
©©) *
_httpService
©©* 6
.
©©6 7
SendCustomAsync
©©7 F
<
©©F G
	TResponse
©©G P
>
©©P Q
(
©©Q R
request
©©R Y
)
©©Y Z
.
©©Z [
ConfigureAwait
©©[ i
(
©©i j
false
©©j o
)
©©o p
;
©©p q
if
¨¨ 
(
¨¨ 
processResponse
¨¨ #
!=
¨¨$ &
null
¨¨' +
)
¨¨+ ,
{
≠≠ 
this
ÆÆ 
.
ÆÆ 
_logger
ÆÆ  
.
ÆÆ  !
Debug
ÆÆ! &
(
ÆÆ& '
$"
ÆÆ' )
$str
ÆÆ) P
{
ÆÆP Q
request
ÆÆQ X
.
ÆÆX Y
Url
ÆÆY \
}
ÆÆ\ ]
"
ÆÆ] ^
)
ÆÆ^ _
;
ÆÆ_ `
response
ØØ 
=
ØØ 
await
ØØ $
processResponse
ØØ% 4
(
ØØ4 5
response
ØØ5 =
)
ØØ= >
.
ØØ> ?
ConfigureAwait
ØØ? M
(
ØØM N
false
ØØN S
)
ØØS T
;
ØØT U
}
∞∞ 
this
≤≤ 
.
≤≤ 
_logger
≤≤ 
.
≤≤ 
Info
≤≤ !
(
≤≤! "
$"
≤≤" $
$str
≤≤$ O
{
≤≤O P
response
≤≤P X
.
≤≤X Y

StatusCode
≤≤Y c
}
≤≤c d
$str
≤≤d l
{
≤≤l m
response
≤≤m u
.
≤≤u v
ResponseTimeMs≤≤v Ñ
}≤≤Ñ Ö
$str≤≤Ö á
"≤≤á à
)≤≤à â
;≤≤â ä
return
¥¥ 
response
¥¥ 
;
¥¥  
}
µµ 
catch
∂∂ 
(
∂∂ '
InvalidOperationException
∂∂ ,
ex
∂∂- /
)
∂∂/ 0
{
∑∑ 
this
∏∏ 
.
∏∏ 
_logger
∏∏ 
.
∏∏ 
LogError
∏∏ %
(
∏∏% &
ex
∏∏& (
,
∏∏( )
$"
∏∏* ,
$str
∏∏, \
{
∏∏\ ]
request
∏∏] d
.
∏∏d e
Url
∏∏e h
}
∏∏h i
"
∏∏i j
)
∏∏j k
;
∏∏k l
throw
ππ 
;
ππ 
}
∫∫ 
catch
ªª 
(
ªª "
HttpRequestException
ªª '
ex
ªª( *
)
ªª* +
{
ºº 
this
ΩΩ 
.
ΩΩ 
_logger
ΩΩ 
.
ΩΩ 
LogError
ΩΩ %
(
ΩΩ% &
ex
ΩΩ& (
,
ΩΩ( )
$"
ΩΩ* ,
$str
ΩΩ, V
{
ΩΩV W
request
ΩΩW ^
.
ΩΩ^ _
Url
ΩΩ_ b
}
ΩΩb c
"
ΩΩc d
)
ΩΩd e
;
ΩΩe f
throw
ææ 
;
ææ 
}
øø 
}
¿¿ 	
}
¡¡ 
}¬¬ ∆
hC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Exceptions\ValidationException.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !

Exceptions! +
{ 
public 

class 
ValidationException $
:% &
	Exception' 0
{ 
public 
ValidationException "
(" #
)# $
{ 	
} 	
public 
ValidationException "
(" #
string# )
message* 1
)1 2
: 
base 
( 
message 
) 
{   	
}!! 	
public(( 
ValidationException(( "
(((" #
string((# )
message((* 1
,((1 2
	Exception((3 <
innerException((= K
)((K L
:)) 
base)) 
()) 
message)) 
,)) 
innerException)) *
)))* +
{** 	
}++ 	
},, 
}-- º
fC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Exceptions\NotFoundException.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !

Exceptions! +
{ 
public 

class 
NotFoundException "
:# $
	Exception% .
{ 
public 
NotFoundException  
(  !
)! "
{ 	
} 	
public 
NotFoundException  
(  !
string! '
message( /
)/ 0
: 
base 
( 
message 
) 
{   	
}!! 	
public(( 
NotFoundException((  
(((  !
string((! '
message((( /
,((/ 0
	Exception((1 :
innerException((; I
)((I J
:)) 
base)) 
()) 
message)) 
,)) 
innerException)) *
)))* +
{** 	
}++ 	
},, 
}-- Ôk
eC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Controllers\UsersController.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[ 

ApiVersion 
( 
$str 
) 
] 
[ 
Route 

(
 
$str 3
)3 4
]4 5
public 

class 
UsersController  
:! "
ControllerBase# 1
{ 
private 
readonly 
IUsersHandler &
_handler' /
;/ 0
private 
readonly 

IAppLogger #
<# $
UsersController$ 3
>3 4
_logger5 <
;< =
public   
UsersController   
(   
IUsersHandler   ,
handler  - 4
,  4 5

IAppLogger  6 @
<  @ A
UsersController  A P
>  P Q
logger  R X
)  X Y
{!! 	
this"" 
."" 
_handler"" 
="" 
handler"" #
??""$ &
throw""' ,
new""- 0!
ArgumentNullException""1 F
(""F G
nameof""G M
(""M N
handler""N U
)""U V
)""V W
;""W X
this## 
.## 
_logger## 
=## 
logger## !
??##" $
throw##% *
new##+ .!
ArgumentNullException##/ D
(##D E
nameof##E K
(##K L
logger##L R
)##R S
)##S T
;##T U
}$$ 	
[++ 	
HttpPost++	 
(++ 
$str++ 
)++ 
]++ 
[,, 	
AllowAnonymous,,	 
],, 
[-- 	 
ProducesResponseType--	 
(-- 
typeof-- $
(--$ %
string--% +
)--+ ,
,--, -
StatusCodes--. 9
.--9 :
Status302Found--: H
)--H I
]--I J
[.. 	 
ProducesResponseType..	 
(.. 
StatusCodes.. )
...) *
Status400BadRequest..* =
)..= >
]..> ?
[// 	 
ProducesResponseType//	 
(// 
StatusCodes// )
.//) *(
Status500InternalServerError//* F
)//F G
]//G H
public00 
async00 
Task00 
<00 
IActionResult00 '
>00' (
Validate00) 1
(001 2
[002 3
FromForm003 ;
]00; <!
ValidateAccessRequest00= R
request00S Z
)00Z [
{11 	
this22 
.22 
_logger22 
.22 
Info22 
(22 
$str22 C
)22C D
;22D E
var44 
logInput44 
=44 
this44 
.44  
CreateLogInput44  .
(44. /
request44/ 6
)446 7
;447 8
var55 
(55 
	processId55 
,55 
	stopwatch55 %
)55% &
=55' (
this55) -
.55- .
_logger55. 5
.555 6
StartProcess556 B
(55B C
logInput55C K
)55K L
;55L M
try77 
{88 
if99 
(99 
request99 
==99 
null99 #
)99# $
{:: 
this;; 
.;; 
_logger;;  
.;;  !
LogError;;! )
(;;) *
$str;;* ;
);;; <
;;;< =
this<< 
.<< 
_logger<<  
.<<  !

EndProcess<<! +
(<<+ ,
	processId<<, 5
,<<5 6
	stopwatch<<7 @
,<<@ A
new<<B E
{<<F G
Success<<H O
=<<P Q
false<<R W
,<<W X
Error<<Y ^
=<<_ `
$str<<a n
}<<o p
)<<p q
;<<q r
return== 
this== 
.==  

BadRequest==  *
(==* +
new==+ .
{==/ 0
Message==1 8
===9 :
$str==; \
}==] ^
)==^ _
;==_ `
}>> 
this@@ 
.@@ 
_logger@@ 
.@@ 
Debug@@ "
(@@" #
$str@@# K
)@@K L
;@@L M
varBB 
urlFrontendBB 
=BB  !
awaitBB" '
thisBB( ,
.BB, -
_handlerBB- 5
.BB5 6
GenerarUrlFrontendBB6 H
(BBH I
requestBBI P
)BBP Q
.BBQ R
ConfigureAwaitBBR `
(BB` a
falseBBa f
)BBf g
;BBg h
thisDD 
.DD 
_loggerDD 
.DD 
InfoDD !
(DD! "
$"DD" $
$strDD$ ?
{DD? @
urlFrontendDD@ K
}DDK L
"DDL M
)DDM N
;DDN O
thisEE 
.EE 
_loggerEE 
.EE 

EndProcessEE '
(EE' (
	processIdEE( 1
,EE1 2
	stopwatchEE3 <
,EE< =
newEE> A
{EEB C
SuccessEED K
=EEL M
trueEEN R
,EER S
ActionEET Z
=EE[ \
$strEE] g
}EEh i
)EEi j
;EEj k
returnGG 
thisGG 
.GG 
RedirectGG $
(GG$ %
urlFrontendGG% 0
)GG0 1
;GG1 2
}HH 
catchII 
(II  
OutOfMemoryExceptionII '
exII( *
)II* +
{JJ 
thisKK 
.KK 
_loggerKK 
.KK 
LogErrorKK %
(KK% &
exKK& (
,KK( )
$str	KK* Ü
)
KKÜ á
;
KKá à
thisLL 
.LL 
_loggerLL 
.LL 

EndProcessLL '
(LL' (
	processIdLL( 1
,LL1 2
	stopwatchLL3 <
,LL< =
newLL> A
{LLB C
SuccessLLD K
=LLL M
falseLLN S
,LLS T
ErrorLLU Z
=LL[ \
$strLL] s
}LLt u
)LLu v
;LLv w
returnMM 
thisMM 
.MM 

StatusCodeMM &
(MM& '
StatusCodesMM' 2
.MM2 3(
Status500InternalServerErrorMM3 O
,MMO P
newMMQ T
{MMU V
MessageMMW ^
=MM_ `
$str	MMa ¨
}
MM≠ Æ
)
MMÆ Ø
;
MMØ ∞
}NN 
catchOO 
(OO "
StackOverflowExceptionOO )
exOO* ,
)OO, -
{PP 
thisQQ 
.QQ 
_loggerQQ 
.QQ 
LogErrorQQ %
(QQ% &
exQQ& (
,QQ( )
$strQQ* z
)QQz {
;QQ{ |
thisRR 
.RR 
_loggerRR 
.RR 

EndProcessRR '
(RR' (
	processIdRR( 1
,RR1 2
	stopwatchRR3 <
,RR< =
newRR> A
{RRB C
SuccessRRD K
=RRL M
falseRRN S
,RRS T
ErrorRRU Z
=RR[ \
$strRR] u
}RRv w
)RRw x
;RRx y
returnSS 
thisSS 
.SS 

StatusCodeSS &
(SS& '
StatusCodesSS' 2
.SS2 3(
Status500InternalServerErrorSS3 O
,SSO P
newSSQ T
{SSU V
MessageSSW ^
=SS_ `
$str	SSa ß
}
SS® ©
)
SS© ™
;
SS™ ´
}TT 
catchUU 
(UU !
ArgumentNullExceptionUU (
exUU) +
)UU+ ,
{VV 
thisWW 
.WW 
_loggerWW 
.WW 
LogErrorWW %
(WW% &
exWW& (
,WW( )
$strWW* J
)WWJ K
;WWK L
thisXX 
.XX 
_loggerXX 
.XX 

EndProcessXX '
(XX' (
	processIdXX( 1
,XX1 2
	stopwatchXX3 <
,XX< =
newXX> A
{XXB C
SuccessXXD K
=XXL M
falseXXN S
,XXS T
ErrorXXU Z
=XX[ \
$strXX] t
}XXu v
)XXv w
;XXw x
returnYY 
thisYY 
.YY 

BadRequestYY &
(YY& '
newYY' *
{YY+ ,
exYY- /
.YY/ 0
MessageYY0 7
}YY8 9
)YY9 :
;YY: ;
}ZZ 
catch[[ 
([[ 
ArgumentException[[ $
ex[[% '
)[[' (
{\\ 
this]] 
.]] 
_logger]] 
.]] 
LogError]] %
(]]% &
ex]]& (
,]]( )
$str]]* N
)]]N O
;]]O P
this^^ 
.^^ 
_logger^^ 
.^^ 

EndProcess^^ '
(^^' (
	processId^^( 1
,^^1 2
	stopwatch^^3 <
,^^< =
new^^> A
{^^B C
Success^^D K
=^^L M
false^^N S
,^^S T
Error^^U Z
=^^[ \
$str^^] p
}^^q r
)^^r s
;^^s t
return__ 
this__ 
.__ 

BadRequest__ &
(__& '
new__' *
{__+ ,
ex__- /
.__/ 0
Message__0 7
}__8 9
)__9 :
;__: ;
}`` 
catchaa 
(aa %
InvalidOperationExceptionaa ,
exaa- /
)aa/ 0
{bb 
thiscc 
.cc 
_loggercc 
.cc 
LogErrorcc %
(cc% &
excc& (
,cc( )
$strcc* `
)cc` a
;cca b
thisdd 
.dd 
_loggerdd 
.dd 

EndProcessdd '
(dd' (
	processIddd( 1
,dd1 2
	stopwatchdd3 <
,dd< =
newdd> A
{ddB C
SuccessddD K
=ddL M
falseddN S
,ddS T
ErrorddU Z
=dd[ \
$strdd] x
}ddy z
)ddz {
;dd{ |
returnff 
thisff 
.ff 

StatusCodeff &
(ff& '
StatusCodesgg 
.gg  (
Status500InternalServerErrorgg  <
,gg< =
newhh 
{hh 
exhh 
.hh 
Messagehh $
}hh% &
)hh& '
;hh' (
}ii 
}jj 	
privatell 
objectll 
CreateLogInputll %
(ll% &!
ValidateAccessRequestll& ;
?ll; <
requestll= D
)llD E
{mm 	
ifnn 
(nn 
requestnn 
==nn 
nullnn 
)nn  
{oo 
thispp 
.pp 
_loggerpp 
.pp 
Debugpp "
(pp" #
$strpp# ]
)pp] ^
;pp^ _
returnqq 
newqq 
{rr 

RutTitularss 
=ss  
$strss! '
,ss' (
Origentt 
=tt 
$strtt #
,tt# $
Roluu 
=uu 
$struu  
,uu  !
}vv 
;vv 
}ww 
thisyy 
.yy 
_loggeryy 
.yy 
Debugyy 
(yy 
$stryy F
)yyF G
;yyG H
returnzz 
newzz 
{{{ 

RutTitular|| 
=|| 
!|| 
string|| $
.||$ %
IsNullOrWhiteSpace||% 7
(||7 8
request||8 ?
.||? @

RutTitular||@ J
)||J K
?}} 
this}} 
.}} 
SafeMaskRut}} &
(}}& '
request}}' .
.}}. /

RutTitular}}/ 9
)}}9 :
:~~ 
$str~~ 
,~~ 
Origen 
= 
request  
.  !
Origen! '
.' (
ToString( 0
(0 1
)1 2
,2 3
Rol
ÄÄ 
=
ÄÄ 
request
ÄÄ 
.
ÄÄ 
Rol
ÄÄ !
.
ÄÄ! "
ToString
ÄÄ" *
(
ÄÄ* +
)
ÄÄ+ ,
,
ÄÄ, -
}
ÅÅ 
;
ÅÅ 
}
ÇÇ 	
private
ÑÑ 
string
ÑÑ 
SafeMaskRut
ÑÑ "
(
ÑÑ" #
string
ÑÑ# )
rut
ÑÑ* -
)
ÑÑ- .
{
ÖÖ 	
try
ÜÜ 
{
áá 
var
àà 
masked
àà 
=
àà 
	LogHelper
àà &
.
àà& '
MaskRut
àà' .
(
àà. /
rut
àà/ 2
)
àà2 3
;
àà3 4
this
ââ 
.
ââ 
_logger
ââ 
.
ââ 
Debug
ââ "
(
ââ" #
$str
ââ# A
)
ââA B
;
ââB C
return
ää 
masked
ää 
;
ää 
}
ãã 
catch
åå 
(
åå 
ArgumentException
åå $
ex
åå% '
)
åå' (
{
çç 
this
éé 
.
éé 
_logger
éé 
.
éé 
LogError
éé %
(
éé% &
ex
éé& (
,
éé( )
$str
éé* `
)
éé` a
;
ééa b
return
èè 
$str
èè %
;
èè% &
}
êê 
catch
ëë 
(
ëë 
FormatException
ëë "
ex
ëë# %
)
ëë% &
{
íí 
this
ìì 
.
ìì 
_logger
ìì 
.
ìì 
LogError
ìì %
(
ìì% &
ex
ìì& (
,
ìì( )
$str
ìì* k
)
ììk l
;
ììl m
return
îî 
$str
îî %
;
îî% &
}
ïï 
}
ññ 	
}
óó 
}òò Ôd
jC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Controllers\SiniestrosController.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[ 

ApiVersion 
( 
$str 
) 
] 
[ 
Route 

(
 
$str '
)' (
]( )
public 

class  
SiniestrosController %
:& '
ControllerBase( 6
{ 
private 
readonly 
ISiniestrosHandler +
_handler, 4
;4 5
private 
readonly 

IAppLogger #
<# $ 
SiniestrosController$ 8
>8 9
_logger: A
;A B
public##  
SiniestrosController## #
(### $
ISiniestrosHandler##$ 6
handler##7 >
,##> ?

IAppLogger##@ J
<##J K 
SiniestrosController##K _
>##_ `
logger##a g
)##g h
{$$ 	
this%% 
.%% 
_handler%% 
=%% 
handler%% #
??%%$ &
throw%%' ,
new%%- 0!
ArgumentNullException%%1 F
(%%F G
nameof%%G M
(%%M N
handler%%N U
)%%U V
)%%V W
;%%W X
this&& 
.&& 
_logger&& 
=&& 
logger&& !
??&&" $
throw&&% *
new&&+ .!
ArgumentNullException&&/ D
(&&D E
nameof&&E K
(&&K L
logger&&L R
)&&R S
)&&S T
;&&T U
}'' 	
[.. 	
HttpGet..	 
(.. 
$str.. +
)..+ ,
].., -
[// 	 
ProducesResponseType//	 
(// 
typeof// $
(//$ %
SiniestrosResponse//% 7
)//7 8
,//8 9
StatusCodes//: E
.//E F
Status200OK//F Q
)//Q R
]//R S
[00 	 
ProducesResponseType00	 
(00 
typeof00 $
(00$ %
string00% +
)00+ ,
,00, -
StatusCodes00. 9
.009 :
Status302Found00: H
)00H I
]00I J
[11 	 
ProducesResponseType11	 
(11 
StatusCodes11 )
.11) *
Status400BadRequest11* =
)11= >
]11> ?
[22 	 
ProducesResponseType22	 
(22 
StatusCodes22 )
.22) *(
Status500InternalServerError22* F
)22F G
]22G H
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' ((
GetDetSiniestrosPorAsegurado33) E
(33E F
[33F G
	FromRoute33G P
]33P Q
string33R X
rut33Y \
)33\ ]
{44 	
var66 
logInput66 
=66 
new66 
{77 
RutAsegurado88 
=88 
!88  
string88  &
.88& '
IsNullOrWhiteSpace88' 9
(889 :
rut88: =
)88= >
?88? @
	LogHelper88A J
.88J K
MaskRut88K R
(88R S
rut88S V
)88V W
:88X Y
$str88Z `
,88` a
}99 
;99 
this;; 
.;; 
_logger;; 
.;; 
Info;; 
(;; 
$";;  
{;;  !
this;;! %
.;;% &
GetType;;& -
(;;- .
);;. /
.;;/ 0
Name;;0 4
};;4 5
$str;;5 l
";;l m
);;m n
;;;n o
var<< 
(<< 
	processId<< 
,<< 
	stopwatch<< %
)<<% &
=<<' (
this<<) -
.<<- .
_logger<<. 5
.<<5 6
StartProcess<<6 B
(<<B C
logInput<<C K
)<<K L
;<<L M
try>> 
{?? 
if@@ 
(@@ 
string@@ 
.@@ 
IsNullOrWhiteSpace@@ -
(@@- .
rut@@. 1
)@@1 2
)@@2 3
{AA 
thisBB 
.BB 
_loggerBB  
.BB  !
LogErrorBB! )
(BB) *
$"BB* ,
{BB, -
thisBB- 1
.BB1 2
GetTypeBB2 9
(BB9 :
)BB: ;
.BB; <
NameBB< @
}BB@ A
$strBBA a
"BBa b
)BBb c
;BBc d
returnCC 
thisCC 
.CC  

BadRequestCC  *
(CC* +
CreateErrorResponseCC+ >
<CC> ?
objectCC? E
>CCE F
(CCF G
$strDD >
,DD> ?
$strEE *
)EE* +
)EE+ ,
;EE, -
}FF 
thisHH 
.HH 
_loggerHH 
.HH 
DebugHH "
(HH" #
$"HH# %
{HH% &
thisHH& *
.HH* +
GetTypeHH+ 2
(HH2 3
)HH3 4
.HH4 5
NameHH5 9
}HH9 :
$strHH: _
"HH_ `
)HH` a
;HHa b
varII 
siniestrosDataDTOII %
=II& '
awaitII( -
thisII. 2
.II2 3
_handlerII3 ;
.II; <,
 GetSiniestrosDetallePorAseguradoII< \
(II\ ]
rutII] `
)II` a
.IIa b
ConfigureAwaitIIb p
(IIp q
falseIIq v
)IIv w
;IIw x
varKK 
(KK 
messageKK 
,KK 
dataKK "
)KK" #
=KK$ %#
ProcessSiniestrosResultKK& =
(KK= >
siniestrosDataDTOKK> O
,KKO P
rutKKQ T
)KKT U
;KKU V
varMM 
responseMM 
=MM 
newMM "
FrontResponseMM# 0
<MM0 1
SiniestrosDataDtoMM1 B
>MMB C
{NN 
SuccessOO 
=OO 
trueOO "
,OO" #
MessagePP 
=PP 
messagePP %
,PP% &
DataQQ 
=QQ 
dataQQ 
,QQ  
	TimestampRR 
=RR 
DateTimeRR  (
.RR( )
UtcNowRR) /
.RR/ 0
ToStringRR0 8
(RR8 9
$strRR9 <
,RR< =
CultureInfoRR> I
.RRI J
InvariantCultureRRJ Z
)RRZ [
,RR[ \
}SS 
;SS 
returnUU 
thisUU 
.UU 
OkUU 
(UU 
responseUU '
)UU' (
;UU( )
}VV 
catchWW 
(WW 
ArgumentExceptionWW $
exWW% '
)WW' (
{XX 
thisYY 
.YY 
_loggerYY 
.YY 
LogErrorYY %
(YY% &
exYY& (
,YY( )
$"YY* ,
{YY, -
thisYY- 1
.YY1 2
GetTypeYY2 9
(YY9 :
)YY: ;
.YY; <
NameYY< @
}YY@ A
$strYYA a
"YYa b
)YYb c
;YYc d
returnZZ 
thisZZ 
.ZZ 

BadRequestZZ &
(ZZ& '
CreateErrorResponseZZ' :
<ZZ: ;
objectZZ; A
>ZZA B
(ZZB C
exZZC E
.ZZE F
MessageZZF M
,ZZM N
$strZZO a
)ZZa b
)ZZb c
;ZZc d
}[[ 
catch\\ 
(\\ &
OperationCanceledException\\ -
ex\\. 0
)\\0 1
{]] 
this^^ 
.^^ 
_logger^^ 
.^^ 
LogError^^ %
(^^% &
ex^^& (
,^^( )
$"^^* ,
{^^, -
this^^- 1
.^^1 2
GetType^^2 9
(^^9 :
)^^: ;
.^^; <
Name^^< @
}^^@ A
$str^^A p
"^^p q
)^^q r
;^^r s
return__ 
this__ 
.__ 

StatusCode__ &
(__& '
StatusCodes`` 
.``  #
Status408RequestTimeout``  7
,``7 8
CreateErrorResponseaa '
<aa' (
objectaa( .
>aa. /
(aa/ 0
$strbb O
,bbO P
$strcc -
)cc- .
)cc. /
;cc/ 0
}dd 
catchee 
(ee %
InvalidOperationExceptionee ,
exee- /
)ee/ 0
{ff 
thisgg 
.gg 
_loggergg 
.gg 
LogErrorgg %
(gg% &
exgg& (
,gg( )
$"gg* ,
{gg, -
thisgg- 1
.gg1 2
GetTypegg2 9
(gg9 :
)gg: ;
.gg; <
Namegg< @
}gg@ A
$strggA _
"gg_ `
)gg` a
;gga b
returnhh 
thishh 
.hh 

StatusCodehh &
(hh& '
StatusCodesii 
.ii  (
Status500InternalServerErrorii  <
,ii< =
CreateErrorResponsejj '
<jj' (
objectjj( .
>jj. /
(jj/ 0
$strjj0 Q
,jjQ R
$strjjS c
)jjc d
)jjd e
;jje f
}kk 
catchll 
(ll  
KeyNotFoundExceptionll '
exll( *
)ll* +
{mm 
thisnn 
.nn 
_loggernn 
.nn 
LogErrornn %
(nn% &
exnn& (
,nn( )
$"nn* ,
{nn, -
thisnn- 1
.nn1 2
GetTypenn2 9
(nn9 :
)nn: ;
.nn; <
Namenn< @
}nn@ A
$strnnA [
"nn[ \
)nn\ ]
;nn] ^
returnoo 
thisoo 
.oo 
NotFoundoo $
(oo$ %
CreateErrorResponseoo% 8
<oo8 9
objectoo9 ?
>oo? @
(oo@ A
$strpp ?
,pp? @
$strqq 
)qq  
)qq  !
;qq! "
}rr 
finallyss 
{tt 
ifuu 
(uu 
	stopwatchuu 
!=uu  
nulluu! %
&&uu& (
	processIduu) 2
!=uu3 5
Guiduu6 :
.uu: ;
Emptyuu; @
)uu@ A
{vv 
thisww 
.ww 
_loggerww  
.ww  !

EndProcessww! +
(ww+ ,
	processIdww, 5
,ww5 6
	stopwatchww7 @
)ww@ A
;wwA B
}xx 
}yy 
}zz 	
private
ÇÇ 
static
ÇÇ 
(
ÇÇ 
string
ÇÇ 
Message
ÇÇ &
,
ÇÇ& '
SiniestrosDataDto
ÇÇ( 9
?
ÇÇ9 :
Data
ÇÇ; ?
)
ÇÇ? @%
ProcessSiniestrosResult
ÇÇA X
(
ÇÇX Y
SiniestrosDataDto
ÉÉ 
siniestrosDataDTO
ÉÉ /
,
ÉÉ/ 0
string
ÑÑ 
rut
ÑÑ 
)
ÑÑ 
{
ÖÖ 	
if
ÜÜ 
(
ÜÜ 
siniestrosDataDTO
ÜÜ !
.
ÜÜ! "

Siniestros
ÜÜ" ,
.
ÜÜ, -
Count
ÜÜ- 2
==
ÜÜ3 5
$num
ÜÜ6 7
)
ÜÜ7 8
{
áá 
return
àà 
(
àà 
$"
àà 
{
àà 
rut
àà 
}
àà 
$str
àà >
"
àà> ?
,
àà? @
null
ààA E
)
ààE F
;
ààF G
}
ââ 
return
ãã 
(
ãã 
$"
ãã 
{
ãã 
rut
ãã 
}
ãã 
$str
ãã >
"
ãã> ?
,
ãã? @
siniestrosDataDTO
ããA R
)
ããR S
;
ããS T
}
åå 	
private
ïï 
static
ïï 
FrontResponse
ïï $
<
ïï$ %
T
ïï% &
>
ïï& '!
CreateErrorResponse
ïï( ;
<
ïï; <
T
ïï< =
>
ïï= >
(
ïï> ?
string
ïï? E
message
ïïF M
,
ïïM N
string
ïïO U
	errorCode
ïïV _
)
ïï_ `
{
ññ 	
return
óó 
new
óó 
FrontResponse
óó $
<
óó$ %
T
óó% &
>
óó& '
{
òò 
Success
ôô 
=
ôô 
false
ôô 
,
ôô  
Message
öö 
=
öö 
message
öö !
,
öö! "
Data
õõ 
=
õõ 
default
õõ 
,
õõ 
	ErrorCode
úú 
=
úú 
	errorCode
úú %
,
úú% &
	Timestamp
ùù 
=
ùù 
DateTime
ùù $
.
ùù$ %
UtcNow
ùù% +
.
ùù+ ,
ToString
ùù, 4
(
ùù4 5
$str
ùù5 8
,
ùù8 9
CultureInfo
ùù: E
.
ùùE F
InvariantCulture
ùùF V
)
ùùV W
,
ùùW X
}
ûû 
;
ûû 
}
üü 	
}
†† 
}°° Œ≥
dC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Controllers\FakeController.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[   

ApiVersion   
(   
$str   
)   
]   
[!! 
Route!! 

(!!
 
$str!! 3
)!!3 4
]!!4 5
public"" 

class"" 
FakeController"" 
:""  !
ControllerBase""" 0
{## 
private$$ 
readonly$$ 

IAppLogger$$ #
<$$# $
FakeController$$$ 2
>$$2 3
_logger$$4 ;
;$$; <
private%% 
readonly%% 
IUsersHandler%% &
_handler%%' /
;%%/ 0
private&& 
readonly&& +
EPSiniestroPorAseguradoSettings&& 8
	_settings&&9 B
;&&B C
private'' 
readonly'' 
IHttpClientService'' +
_httpClientService'', >
;''> ?
private(( 
readonly(( 
string(( &
_getsiniestrosporasegurado((  :
=((; <
$str(c= 
;cc 
privateee 
readonlyee 
stringee 
_siniestroDataJsonee  2
=ee3 4
$str	e∞5 
;
∞∞ 
public
ππ 
FakeController
ππ 
(
ππ 

IAppLogger
ππ (
<
ππ( )
FakeController
ππ) 7
>
ππ7 8
logger
ππ9 ?
,
ππ? @
IUsersHandler
ππA N
handler
ππO V
,
ππV W
IOptions
ππX `
<
ππ` a.
EPSiniestroPorAseguradoSettingsππa Ä
>ππÄ Å
settingsππÇ ä
,ππä ã"
IHttpClientServiceππå û!
httpClientServiceππü ∞
)ππ∞ ±
{
∫∫ 	
this
ªª 
.
ªª 
_logger
ªª 
=
ªª 
logger
ªª !
??
ªª" $
throw
ªª% *
new
ªª+ .#
ArgumentNullException
ªª/ D
(
ªªD E
nameof
ªªE K
(
ªªK L
logger
ªªL R
)
ªªR S
)
ªªS T
;
ªªT U
this
ºº 
.
ºº 
_handler
ºº 
=
ºº 
handler
ºº #
??
ºº$ &
throw
ºº' ,
new
ºº- 0#
ArgumentNullException
ºº1 F
(
ººF G
nameof
ººG M
(
ººM N
handler
ººN U
)
ººU V
)
ººV W
;
ººW X
this
ΩΩ 
.
ΩΩ 
	_settings
ΩΩ 
=
ΩΩ 
settings
ΩΩ %
?
ΩΩ% &
.
ΩΩ& '
Value
ΩΩ' ,
??
ΩΩ- /
throw
ΩΩ0 5
new
ΩΩ6 9#
ArgumentNullException
ΩΩ: O
(
ΩΩO P
nameof
ΩΩP V
(
ΩΩV W
settings
ΩΩW _
)
ΩΩ_ `
)
ΩΩ` a
;
ΩΩa b
this
ææ 
.
ææ  
_httpClientService
ææ #
=
ææ$ %
httpClientService
ææ& 7
??
ææ8 :
throw
ææ; @
new
ææA D#
ArgumentNullException
ææE Z
(
ææZ [
nameof
ææ[ a
(
ææa b
httpClientService
ææb s
)
ææs t
)
ææt u
;
ææu v
}
øø 	
[
«« 	
HttpPost
««	 
(
«« 
$str
«« 
)
«« 
]
«« 
[
»» 	
AllowAnonymous
»»	 
]
»» 
[
…… 	"
ProducesResponseType
……	 
(
…… 
typeof
…… $
(
……$ %
string
……% +
)
……+ ,
,
……, -
StatusCodes
……. 9
.
……9 :
Status302Found
……: H
)
……H I
]
……I J
[
   	"
ProducesResponseType
  	 
(
   
StatusCodes
   )
.
  ) *!
Status400BadRequest
  * =
)
  = >
]
  > ?
[
ÀÀ 	"
ProducesResponseType
ÀÀ	 
(
ÀÀ 
StatusCodes
ÀÀ )
.
ÀÀ) **
Status500InternalServerError
ÀÀ* F
)
ÀÀF G
]
ÀÀG H
public
ÃÃ 
async
ÃÃ 
Task
ÃÃ 
<
ÃÃ 
IActionResult
ÃÃ '
>
ÃÃ' (
LoginDirecto
ÃÃ) 5
(
ÃÃ5 6
string
ÃÃ6 <

rutTitular
ÃÃ= G
,
ÃÃG H
string
ÃÃI O
passTitular
ÃÃP [
)
ÃÃ[ \
{
ÕÕ 	
var
œœ 
logInput
œœ 
=
œœ 
new
œœ 
{
–– 

rutTitular
—— 
,
—— 
}
““ 
;
““ 
this
‘‘ 
.
‘‘ 
_logger
‘‘ 
.
‘‘ 
Info
‘‘ 
(
‘‘ 
$"
‘‘  
{
‘‘  !
this
‘‘! %
.
‘‘% &
GetType
‘‘& -
(
‘‘- .
)
‘‘. /
.
‘‘/ 0
Name
‘‘0 4
}
‘‘4 5
$str
‘‘5 _
"
‘‘_ `
)
‘‘` a
;
‘‘a b
var
’’ 
(
’’ 
	processId
’’ 
,
’’ 
	stopwatch
’’ %
)
’’% &
=
’’' (
this
’’) -
.
’’- .
_logger
’’. 5
.
’’5 6
StartProcess
’’6 B
(
’’B C
logInput
’’C K
)
’’K L
;
’’L M
try
÷÷ 
{
◊◊ 
if
ÿÿ 
(
ÿÿ 

rutTitular
ÿÿ 
==
ÿÿ !
null
ÿÿ" &
)
ÿÿ& '
{
ŸŸ 
this
⁄⁄ 
.
⁄⁄ 
_logger
⁄⁄  
.
⁄⁄  !
LogError
⁄⁄! )
(
⁄⁄) *
$"
⁄⁄* ,
{
⁄⁄, -
this
⁄⁄- 1
.
⁄⁄1 2
GetType
⁄⁄2 9
(
⁄⁄9 :
)
⁄⁄: ;
.
⁄⁄; <
Name
⁄⁄< @
}
⁄⁄@ A
$str
⁄⁄A V
"
⁄⁄V W
)
⁄⁄W X
;
⁄⁄X Y
return
€€ 
this
€€ 
.
€€  

BadRequest
€€  *
(
€€* +
new
€€+ .
{
€€/ 0
Message
€€1 8
=
€€9 :
$str
€€; Z
}
€€[ \
)
€€\ ]
;
€€] ^
}
‹‹ 
if
ﬁﬁ 
(
ﬁﬁ 
passTitular
ﬁﬁ 
==
ﬁﬁ  "
null
ﬁﬁ# '
)
ﬁﬁ' (
{
ﬂﬂ 
this
‡‡ 
.
‡‡ 
_logger
‡‡  
.
‡‡  !
LogError
‡‡! )
(
‡‡) *
$"
‡‡* ,
{
‡‡, -
this
‡‡- 1
.
‡‡1 2
GetType
‡‡2 9
(
‡‡9 :
)
‡‡: ;
.
‡‡; <
Name
‡‡< @
}
‡‡@ A
$str
‡‡A W
"
‡‡W X
)
‡‡X Y
;
‡‡Y Z
return
·· 
this
·· 
.
··  

BadRequest
··  *
(
··* +
new
··+ .
{
··/ 0
Message
··1 8
=
··9 :
$str
··; [
}
··\ ]
)
··] ^
;
··^ _
}
‚‚ 
this
‰‰ 
.
‰‰ 
_logger
‰‰ 
.
‰‰ 
Debug
‰‰ "
(
‰‰" #
$"
‰‰# %
{
‰‰% &
this
‰‰& *
.
‰‰* +
GetType
‰‰+ 2
(
‰‰2 3
)
‰‰3 4
.
‰‰4 5
Name
‰‰5 9
}
‰‰9 :
$str
‰‰: c
"
‰‰c d
)
‰‰d e
;
‰‰e f
string
ÂÂ 
urlFrontend
ÂÂ "
=
ÂÂ# $
await
ÂÂ% *
this
ÂÂ+ /
.
ÂÂ/ 0
	LoginFake
ÂÂ0 9
(
ÂÂ9 :

rutTitular
ÂÂ: D
.
ÂÂD E
Trim
ÂÂE I
(
ÂÂI J
)
ÂÂJ K
,
ÂÂK L
passTitular
ÂÂM X
.
ÂÂX Y
Trim
ÂÂY ]
(
ÂÂ] ^
)
ÂÂ^ _
)
ÂÂ_ `
.
ÂÂ` a
ConfigureAwait
ÂÂa o
(
ÂÂo p
false
ÂÂp u
)
ÂÂu v
;
ÂÂv w
this
ÊÊ 
.
ÊÊ 
_logger
ÊÊ 
.
ÊÊ 
Info
ÊÊ !
(
ÊÊ! "
$"
ÊÊ" $
{
ÊÊ$ %
this
ÊÊ% )
.
ÊÊ) *
GetType
ÊÊ* 1
(
ÊÊ1 2
)
ÊÊ2 3
.
ÊÊ3 4
Name
ÊÊ4 8
}
ÊÊ8 9
$str
ÊÊ9 o
"
ÊÊo p
)
ÊÊp q
;
ÊÊq r
await
ÁÁ 
Task
ÁÁ 
.
ÁÁ 
CompletedTask
ÁÁ (
.
ÁÁ( )
ConfigureAwait
ÁÁ) 7
(
ÁÁ7 8
false
ÁÁ8 =
)
ÁÁ= >
;
ÁÁ> ?
return
ËË 
this
ËË 
.
ËË 
Content
ËË #
(
ËË# $
urlFrontend
ËË$ /
,
ËË/ 0
$str
ËË1 =
)
ËË= >
;
ËË> ?
}
ÈÈ 
catch
ÍÍ 
(
ÍÍ 
ArgumentException
ÍÍ $
ex
ÍÍ% '
)
ÍÍ' (
{
ÎÎ 
this
ÏÏ 
.
ÏÏ 
_logger
ÏÏ 
.
ÏÏ 
LogError
ÏÏ %
(
ÏÏ% &
ex
ÏÏ& (
)
ÏÏ( )
;
ÏÏ) *
return
ÌÌ 
this
ÌÌ 
.
ÌÌ 

BadRequest
ÌÌ &
(
ÌÌ& '
new
ÌÌ' *
{
ÌÌ+ ,
ex
ÌÌ- /
.
ÌÌ/ 0
Message
ÌÌ0 7
,
ÌÌ7 8
}
ÌÌ9 :
)
ÌÌ: ;
;
ÌÌ; <
}
ÓÓ 
catch
ÔÔ 
(
ÔÔ '
InvalidOperationException
ÔÔ ,
ex
ÔÔ- /
)
ÔÔ/ 0
{
 
this
ÒÒ 
.
ÒÒ 
_logger
ÒÒ 
.
ÒÒ 
LogError
ÒÒ %
(
ÒÒ% &
ex
ÒÒ& (
)
ÒÒ( )
;
ÒÒ) *
return
ÚÚ 
this
ÚÚ 
.
ÚÚ 

StatusCode
ÚÚ &
(
ÚÚ& '
StatusCodes
ÛÛ 
.
ÛÛ  *
Status500InternalServerError
ÛÛ  <
,
ÛÛ< =
new
ÙÙ 
{
ÙÙ 
ex
ÙÙ 
.
ÙÙ 
Message
ÙÙ $
,
ÙÙ$ %
}
ÙÙ& '
)
ÙÙ' (
;
ÙÙ( )
}
ıı 
finally
ˆˆ 
{
˜˜ 
if
¯¯ 
(
¯¯ 
	stopwatch
¯¯ 
!=
¯¯  
null
¯¯! %
&&
¯¯& (
	processId
¯¯) 2
!=
¯¯3 5
Guid
¯¯6 :
.
¯¯: ;
Empty
¯¯; @
)
¯¯@ A
{
˘˘ 
this
˙˙ 
.
˙˙ 
_logger
˙˙  
.
˙˙  !

EndProcess
˙˙! +
(
˙˙+ ,
	processId
˙˙, 5
,
˙˙5 6
	stopwatch
˙˙7 @
)
˙˙@ A
;
˙˙A B
}
˚˚ 
}
¸¸ 
}
˝˝ 	
[
ÑÑ 	
HttpPost
ÑÑ	 
(
ÑÑ 
$str
ÑÑ 
)
ÑÑ 
]
ÑÑ 
[
ÖÖ 	
SwaggerIgnore
ÖÖ	 
]
ÖÖ 
[
ÜÜ 	
AllowAnonymous
ÜÜ	 
]
ÜÜ 
[
áá 	"
ProducesResponseType
áá	 
(
áá 
typeof
áá $
(
áá$ %
string
áá% +
)
áá+ ,
,
áá, -
StatusCodes
áá. 9
.
áá9 :
Status302Found
áá: H
)
ááH I
]
ááI J
[
àà 	"
ProducesResponseType
àà	 
(
àà 
StatusCodes
àà )
.
àà) *!
Status400BadRequest
àà* =
)
àà= >
]
àà> ?
[
ââ 	"
ProducesResponseType
ââ	 
(
ââ 
StatusCodes
ââ )
.
ââ) **
Status500InternalServerError
ââ* F
)
ââF G
]
ââG H
public
ää 
async
ää 
Task
ää 
<
ää 
IActionResult
ää '
>
ää' (
Validate
ää) 1
(
ää1 2
[
ää2 3
FromForm
ää3 ;
]
ää; <#
ValidateAccessRequest
ää= R
request
ääS Z
)
ääZ [
{
ãã 	
var
çç 
logInput
çç 
=
çç 
new
çç 
{
éé 

RutTitular
èè 
=
èè 
request
èè $
?
èè$ %
.
èè% &

RutTitular
èè& 0
!=
èè1 3
null
èè4 8
?
èè9 :
request
èè; B
.
èèB C

RutTitular
èèC M
:
èèN O
$str
èèP V
,
èèV W
Origen
êê 
=
êê 
request
êê  
?
êê  !
.
êê! "
Origen
êê" (
.
êê( )
ToString
êê) 1
(
êê1 2
)
êê2 3
??
êê4 6
$str
êê7 =
,
êê= >
Rol
ëë 
=
ëë 
request
ëë 
?
ëë 
.
ëë 
Rol
ëë "
.
ëë" #
ToString
ëë# +
(
ëë+ ,
)
ëë, -
??
ëë. 0
$str
ëë1 7
,
ëë7 8
}
íí 
;
íí 
this
îî 
.
îî 
_logger
îî 
.
îî 
Info
îî 
(
îî 
$"
îî  
{
îî  !
this
îî! %
.
îî% &
GetType
îî& -
(
îî- .
)
îî. /
.
îî/ 0
Name
îî0 4
}
îî4 5
$str
îî5 [
"
îî[ \
)
îî\ ]
;
îî] ^
var
ïï 
(
ïï 
	processId
ïï 
,
ïï 
	stopwatch
ïï %
)
ïï% &
=
ïï' (
this
ïï) -
.
ïï- .
_logger
ïï. 5
.
ïï5 6
StartProcess
ïï6 B
(
ïïB C
logInput
ïïC K
)
ïïK L
;
ïïL M
try
ññ 
{
óó 
if
òò 
(
òò 
request
òò 
==
òò 
null
òò #
)
òò# $
{
ôô 
this
öö 
.
öö 
_logger
öö  
.
öö  !
LogError
öö! )
(
öö) *
$"
öö* ,
{
öö, -
this
öö- 1
.
öö1 2
GetType
öö2 9
(
öö9 :
)
öö: ;
.
öö; <
Name
öö< @
}
öö@ A
$str
ööA S
"
ööS T
)
ööT U
;
ööU V
return
õõ 
this
õõ 
.
õõ  

BadRequest
õõ  *
(
õõ* +
new
õõ+ .
{
õõ/ 0
Message
õõ1 8
=
õõ9 :
$str
õõ; \
}
õõ] ^
)
õõ^ _
;
õõ_ `
}
úú 
this
ûû 
.
ûû 
_logger
ûû 
.
ûû 
Debug
ûû "
(
ûû" #
$"
ûû# %
{
ûû% &
this
ûû& *
.
ûû* +
GetType
ûû+ 2
(
ûû2 3
)
ûû3 4
.
ûû4 5
Name
ûû5 9
}
ûû9 :
$str
ûû: c
"
ûûc d
)
ûûd e
;
ûûe f
var
üü 
urlFrontend
üü 
=
üü  !
this
üü" &
.
üü& ' 
_siniestroDataJson
üü' 9
;
üü9 :
this
°° 
.
°° 
_logger
°° 
.
°° 
Info
°° !
(
°°! "
$"
°°" $
{
°°$ %
this
°°% )
.
°°) *
GetType
°°* 1
(
°°1 2
)
°°2 3
.
°°3 4
Name
°°4 8
}
°°8 9
$str
°°9 o
"
°°o p
)
°°p q
;
°°q r
await
¢¢ 
Task
¢¢ 
.
¢¢ 
CompletedTask
¢¢ (
.
¢¢( )
ConfigureAwait
¢¢) 7
(
¢¢7 8
false
¢¢8 =
)
¢¢= >
;
¢¢> ?
return
££ 
this
££ 
.
££ 
Redirect
££ $
(
££$ %
urlFrontend
££% 0
)
££0 1
;
££1 2
}
§§ 
catch
•• 
(
•• 
ArgumentException
•• $
ex
••% '
)
••' (
{
¶¶ 
this
ßß 
.
ßß 
_logger
ßß 
.
ßß 
LogError
ßß %
(
ßß% &
ex
ßß& (
)
ßß( )
;
ßß) *
return
®® 
this
®® 
.
®® 

BadRequest
®® &
(
®®& '
new
®®' *
{
®®+ ,
ex
®®- /
.
®®/ 0
Message
®®0 7
,
®®7 8
}
®®9 :
)
®®: ;
;
®®; <
}
©© 
catch
™™ 
(
™™ '
InvalidOperationException
™™ ,
ex
™™- /
)
™™/ 0
{
´´ 
this
¨¨ 
.
¨¨ 
_logger
¨¨ 
.
¨¨ 
LogError
¨¨ %
(
¨¨% &
ex
¨¨& (
)
¨¨( )
;
¨¨) *
return
≠≠ 
this
≠≠ 
.
≠≠ 

StatusCode
≠≠ &
(
≠≠& '
StatusCodes
ÆÆ 
.
ÆÆ  *
Status500InternalServerError
ÆÆ  <
,
ÆÆ< =
new
ØØ 
{
ØØ 
ex
ØØ 
.
ØØ 
Message
ØØ $
,
ØØ$ %
}
ØØ& '
)
ØØ' (
;
ØØ( )
}
∞∞ 
finally
±± 
{
≤≤ 
if
≥≥ 
(
≥≥ 
	stopwatch
≥≥ 
!=
≥≥  
null
≥≥! %
&&
≥≥& (
	processId
≥≥) 2
!=
≥≥3 5
Guid
≥≥6 :
.
≥≥: ;
Empty
≥≥; @
)
≥≥@ A
{
¥¥ 
this
µµ 
.
µµ 
_logger
µµ  
.
µµ  !

EndProcess
µµ! +
(
µµ+ ,
	processId
µµ, 5
,
µµ5 6
	stopwatch
µµ7 @
)
µµ@ A
;
µµA B
}
∂∂ 
}
∑∑ 
}
∏∏ 	
[
øø 	
HttpGet
øø	 
(
øø 
$str
øø +
)
øø+ ,
]
øø, -
[
¿¿ 	
AllowAnonymous
¿¿	 
]
¿¿ 
[
¡¡ 	"
ProducesResponseType
¡¡	 
(
¡¡ 
typeof
¡¡ $
(
¡¡$ % 
SiniestrosResponse
¡¡% 7
)
¡¡7 8
,
¡¡8 9
StatusCodes
¡¡: E
.
¡¡E F
Status200OK
¡¡F Q
)
¡¡Q R
]
¡¡R S
[
¬¬ 	"
ProducesResponseType
¬¬	 
(
¬¬ 
typeof
¬¬ $
(
¬¬$ %
string
¬¬% +
)
¬¬+ ,
,
¬¬, -
StatusCodes
¬¬. 9
.
¬¬9 :
Status302Found
¬¬: H
)
¬¬H I
]
¬¬I J
[
√√ 	"
ProducesResponseType
√√	 
(
√√ 
StatusCodes
√√ )
.
√√) *!
Status400BadRequest
√√* =
)
√√= >
]
√√> ?
[
ƒƒ 	"
ProducesResponseType
ƒƒ	 
(
ƒƒ 
StatusCodes
ƒƒ )
.
ƒƒ) **
Status500InternalServerError
ƒƒ* F
)
ƒƒF G
]
ƒƒG H
public
≈≈ 
async
≈≈ 
Task
≈≈ 
<
≈≈ 
IActionResult
≈≈ '
>
≈≈' (*
GetDetSiniestrosPorAsegurado
≈≈) E
(
≈≈E F
[
≈≈F G
	FromRoute
≈≈G P
]
≈≈P Q
string
≈≈R X
rut
≈≈Y \
)
≈≈\ ]
{
∆∆ 	
var
»» 
logInput
»» 
=
»» 
new
»» 
{
…… 
RutAsegurado
   
=
   
!
    
string
    &
.
  & ' 
IsNullOrWhiteSpace
  ' 9
(
  9 :
rut
  : =
)
  = >
?
  ? @
rut
  A D
:
  E F
$str
  G M
,
  M N
}
ÀÀ 
;
ÀÀ 
this
ÕÕ 
.
ÕÕ 
_logger
ÕÕ 
.
ÕÕ 
Info
ÕÕ 
(
ÕÕ 
$"
ÕÕ  
{
ÕÕ  !
this
ÕÕ! %
.
ÕÕ% &
GetType
ÕÕ& -
(
ÕÕ- .
)
ÕÕ. /
.
ÕÕ/ 0
FullName
ÕÕ0 8
}
ÕÕ8 9
$str
ÕÕ9 p
"
ÕÕp q
)
ÕÕq r
;
ÕÕr s
var
ŒŒ 
(
ŒŒ 
	processId
ŒŒ 
,
ŒŒ 
	stopwatch
ŒŒ %
)
ŒŒ% &
=
ŒŒ' (
this
ŒŒ) -
.
ŒŒ- .
_logger
ŒŒ. 5
.
ŒŒ5 6
StartProcess
ŒŒ6 B
(
ŒŒB C
logInput
ŒŒC K
)
ŒŒK L
;
ŒŒL M
try
œœ 
{
–– 
if
—— 
(
—— 
string
—— 
.
——  
IsNullOrWhiteSpace
—— -
(
——- .
rut
——. 1
)
——1 2
)
——2 3
{
““ 
this
”” 
.
”” 
_logger
””  
.
””  !
LogError
””! )
(
””) *
$"
””* ,
{
””, -
this
””- 1
.
””1 2
GetType
””2 9
(
””9 :
)
””: ;
.
””; <
FullName
””< D
}
””D E
$str
””E W
"
””W X
)
””X Y
;
””Y Z
return
‘‘ 
this
‘‘ 
.
‘‘  

BadRequest
‘‘  *
(
‘‘* +
new
‘‘+ .
FrontResponse
‘‘/ <
<
‘‘< =
object
‘‘= C
>
‘‘C D
{
’’ 
Success
÷÷ 
=
÷÷  !
false
÷÷" '
,
÷÷' (
Message
◊◊ 
=
◊◊  !
$str
◊◊" H
,
◊◊H I
Data
ÿÿ 
=
ÿÿ 
null
ÿÿ #
,
ÿÿ# $
	ErrorCode
ŸŸ !
=
ŸŸ" #
$str
ŸŸ$ 6
,
ŸŸ6 7
	Timestamp
⁄⁄ !
=
⁄⁄" #
DateTime
⁄⁄$ ,
.
⁄⁄, -
UtcNow
⁄⁄- 3
.
⁄⁄3 4
ToString
⁄⁄4 <
(
⁄⁄< =
$str
⁄⁄= @
,
⁄⁄@ A
CultureInfo
⁄⁄B M
.
⁄⁄M N
InvariantCulture
⁄⁄N ^
)
⁄⁄^ _
,
⁄⁄_ `
}
€€ 
)
€€ 
;
€€ 
}
‹‹ 
bool
ﬁﬁ 
esValido
ﬁﬁ 
=
ﬁﬁ 
RutValidator
ﬁﬁ  ,
.
ﬁﬁ, -
Validar
ﬁﬁ- 4
(
ﬁﬁ4 5
rut
ﬁﬁ5 8
)
ﬁﬁ8 9
;
ﬁﬁ9 :
if
‡‡ 
(
‡‡ 
!
‡‡ 
esValido
‡‡ 
)
‡‡ 
{
·· 
this
‚‚ 
.
‚‚ 
_logger
‚‚  
.
‚‚  !
LogError
‚‚! )
(
‚‚) *
$"
‚‚* ,
{
‚‚, -
this
‚‚- 1
.
‚‚1 2
GetType
‚‚2 9
(
‚‚9 :
)
‚‚: ;
.
‚‚; <
FullName
‚‚< D
}
‚‚D E
$str
‚‚E _
{
‚‚_ `
rut
‚‚` c
}
‚‚c d
"
‚‚d e
)
‚‚e f
;
‚‚f g
return
„„ 
this
„„ 
.
„„  

BadRequest
„„  *
(
„„* +
new
„„+ .
FrontResponse
„„/ <
<
„„< =
object
„„= C
>
„„C D
{
‰‰ 
Success
ÂÂ 
=
ÂÂ  !
false
ÂÂ" '
,
ÂÂ' (
Message
ÊÊ 
=
ÊÊ  !
$str
ÊÊ" F
,
ÊÊF G
Data
ÁÁ 
=
ÁÁ 
null
ÁÁ #
,
ÁÁ# $
	ErrorCode
ËË !
=
ËË" #
$str
ËË$ 1
,
ËË1 2
	Timestamp
ÈÈ !
=
ÈÈ" #
DateTime
ÈÈ$ ,
.
ÈÈ, -
UtcNow
ÈÈ- 3
.
ÈÈ3 4
ToString
ÈÈ4 <
(
ÈÈ< =
$str
ÈÈ= @
,
ÈÈ@ A
CultureInfo
ÈÈB M
.
ÈÈM N
InvariantCulture
ÈÈN ^
)
ÈÈ^ _
,
ÈÈ_ `
}
ÍÍ 
)
ÍÍ 
;
ÍÍ 
}
ÎÎ 
this
ÌÌ 
.
ÌÌ 
_logger
ÌÌ 
.
ÌÌ 
Debug
ÌÌ "
(
ÌÌ" #
$"
ÌÌ# %
{
ÌÌ% &
this
ÌÌ& *
.
ÌÌ* +
GetType
ÌÌ+ 2
(
ÌÌ2 3
)
ÌÌ3 4
.
ÌÌ4 5
FullName
ÌÌ5 =
}
ÌÌ= >
$str
ÌÌ> g
"
ÌÌg h
)
ÌÌh i
;
ÌÌi j
var
 ,
getsiniestrosporaseguradoArray
 2
=
3 4
JsonSerializer
5 C
.
C D
Deserialize
D O
<
O P
JsonElement
P [
>
[ \
(
\ ]
this
] a
.
a b(
_getsiniestrosporasegurado
b |
)
| }
;
} ~
var
ÒÒ 
siniestrosList
ÒÒ "
=
ÒÒ# $
this
ÒÒ% )
.
ÒÒ) *%
ParseSiniestrosFromJson
ÒÒ* A
(
ÒÒA B,
getsiniestrosporaseguradoArray
ÒÒB `
)
ÒÒ` a
;
ÒÒa b 
SiniestrosResponse
ÛÛ "#
lstSiniestrosResponse
ÛÛ# 8
=
ÛÛ9 :
new
ÛÛ; >
(
ÛÛ> ?
)
ÛÛ? @
{
ÛÛA B
Data
ÛÛC G
=
ÛÛH I
siniestrosList
ÛÛJ X
}
ÛÛY Z
;
ÛÛZ [
var
ˆˆ '
lstSiniestrosDataResponse
ˆˆ -
=
ˆˆ. /
this
ˆˆ0 4
.
ˆˆ4 5!
ProcessVPSiniestros
ˆˆ5 H
(
ˆˆH I#
lstSiniestrosResponse
ˆˆI ^
.
ˆˆ^ _
Data
ˆˆ_ c
)
ˆˆc d
;
ˆˆd e
var
˘˘ 
siniestrosArray
˘˘ #
=
˘˘$ %
JsonSerializer
˘˘& 4
.
˘˘4 5
Deserialize
˘˘5 @
<
˘˘@ A
JsonElement
˘˘A L
>
˘˘L M
(
˘˘M N
this
˘˘N R
.
˘˘R S 
_siniestroDataJson
˘˘S e
)
˘˘e f
;
˘˘f g
var
˙˙ 
siniestrosDataDTO
˙˙ %
=
˙˙& '
this
˙˙( ,
.
˙˙, -!
CreateSiniestrosDTO
˙˙- @
(
˙˙@ A'
lstSiniestrosDataResponse
˙˙A Z
,
˙˙Z [
siniestrosArray
˙˙\ k
)
˙˙k l
;
˙˙l m
var
¸¸ 
response
¸¸ 
=
¸¸ 
new
¸¸ "
FrontResponse
¸¸# 0
<
¸¸0 1
SiniestrosDataDto
¸¸1 B
>
¸¸B C
{
˝˝ 
Success
˛˛ 
=
˛˛ 
true
˛˛ "
,
˛˛" #
Message
ˇˇ 
=
ˇˇ 
$"
ˇˇ  
{
ˇˇ  !
rut
ˇˇ! $
}
ˇˇ$ %
$str
ˇˇ% H
"
ˇˇH I
,
ˇˇI J
Data
ÄÄ 
=
ÄÄ 
siniestrosDataDTO
ÄÄ ,
,
ÄÄ, -
	Timestamp
ÅÅ 
=
ÅÅ 
DateTime
ÅÅ  (
.
ÅÅ( )
UtcNow
ÅÅ) /
.
ÅÅ/ 0
ToString
ÅÅ0 8
(
ÅÅ8 9
$str
ÅÅ9 <
,
ÅÅ< =
CultureInfo
ÅÅ> I
.
ÅÅI J
InvariantCulture
ÅÅJ Z
)
ÅÅZ [
,
ÅÅ[ \
}
ÇÇ 
;
ÇÇ 
await
ÉÉ 
Task
ÉÉ 
.
ÉÉ 
CompletedTask
ÉÉ (
.
ÉÉ( )
ConfigureAwait
ÉÉ) 7
(
ÉÉ7 8
false
ÉÉ8 =
)
ÉÉ= >
;
ÉÉ> ?
return
ÖÖ 
this
ÖÖ 
.
ÖÖ 
Ok
ÖÖ 
(
ÖÖ 
response
ÖÖ '
)
ÖÖ' (
;
ÖÖ( )
}
ÜÜ 
catch
áá 
(
áá 
ArgumentException
áá $
ex
áá% '
)
áá' (
{
àà 
this
ââ 
.
ââ 
_logger
ââ 
.
ââ 
LogError
ââ %
(
ââ% &
ex
ââ& (
)
ââ( )
;
ââ) *
return
ää 
this
ää 
.
ää 

BadRequest
ää &
(
ää& '
new
ää' *
FrontResponse
ää+ 8
<
ää8 9
object
ää9 ?
>
ää? @
{
ãã 
Success
åå 
=
åå 
false
åå #
,
åå# $
Message
çç 
=
çç 
ex
çç  
.
çç  !
Message
çç! (
,
çç( )
Data
éé 
=
éé 
null
éé 
,
éé  
	ErrorCode
èè 
=
èè 
$str
èè  2
,
èè2 3
	Timestamp
êê 
=
êê 
DateTime
êê  (
.
êê( )
UtcNow
êê) /
.
êê/ 0
ToString
êê0 8
(
êê8 9
$str
êê9 <
,
êê< =
CultureInfo
êê> I
.
êêI J
InvariantCulture
êêJ Z
)
êêZ [
,
êê[ \
}
ëë 
)
ëë 
;
ëë 
}
íí 
catch
ìì 
(
ìì 
JsonException
ìì  
ex
ìì! #
)
ìì# $
{
îî 
this
ïï 
.
ïï 
_logger
ïï 
.
ïï 
LogError
ïï %
(
ïï% &
ex
ïï& (
)
ïï( )
;
ïï) *
return
ññ 
this
ññ 
.
ññ 

BadRequest
ññ &
(
ññ& '
new
ññ' *
FrontResponse
ññ+ 8
<
ññ8 9
object
ññ9 ?
>
ññ? @
{
óó 
Success
òò 
=
òò 
false
òò #
,
òò# $
Message
ôô 
=
ôô 
$str
ôô _
,
ôô_ `
Data
öö 
=
öö 
null
öö 
,
öö  
	ErrorCode
õõ 
=
õõ 
$str
õõ  ,
,
õõ, -
	Timestamp
úú 
=
úú 
DateTime
úú  (
.
úú( )
UtcNow
úú) /
.
úú/ 0
ToString
úú0 8
(
úú8 9
$str
úú9 <
,
úú< =
CultureInfo
úú> I
.
úúI J
InvariantCulture
úúJ Z
)
úúZ [
,
úú[ \
}
ùù 
)
ùù 
;
ùù 
}
ûû 
catch
üü 
(
üü '
InvalidOperationException
üü ,
ex
üü- /
)
üü/ 0
{
†† 
this
°° 
.
°° 
_logger
°° 
.
°° 
LogError
°° %
(
°°% &
ex
°°& (
)
°°( )
;
°°) *
return
¢¢ 
this
¢¢ 
.
¢¢ 

StatusCode
¢¢ &
(
¢¢& '
StatusCodes
££ 
.
££  *
Status500InternalServerError
££  <
,
££< =
new
§§ 
FrontResponse
§§ %
<
§§% &
object
§§& ,
>
§§, -
{
•• 
Success
¶¶ 
=
¶¶  !
false
¶¶" '
,
¶¶' (
Message
ßß 
=
ßß  !
$str
ßß" C
,
ßßC D
Data
®® 
=
®® 
null
®® #
,
®®# $
	ErrorCode
©© !
=
©©" #
$str
©©$ 4
,
©©4 5
	Timestamp
™™ !
=
™™" #
DateTime
™™$ ,
.
™™, -
UtcNow
™™- 3
.
™™3 4
ToString
™™4 <
(
™™< =
$str
™™= @
,
™™@ A
CultureInfo
™™B M
.
™™M N
InvariantCulture
™™N ^
)
™™^ _
,
™™_ `
}
´´ 
)
´´ 
;
´´ 
}
¨¨ 
finally
≠≠ 
{
ÆÆ 
if
ØØ 
(
ØØ 
	stopwatch
ØØ 
!=
ØØ  
null
ØØ! %
&&
ØØ& (
	processId
ØØ) 2
!=
ØØ3 5
Guid
ØØ6 :
.
ØØ: ;
Empty
ØØ; @
)
ØØ@ A
{
∞∞ 
this
±± 
.
±± 
_logger
±±  
.
±±  !

EndProcess
±±! +
(
±±+ ,
	processId
±±, 5
,
±±5 6
	stopwatch
±±7 @
)
±±@ A
;
±±A B
}
≤≤ 
}
≥≥ 
}
¥¥ 	
[
ºº 	
HttpPost
ºº	 
(
ºº 
$str
ºº 
)
ºº 
]
ºº 
[
ΩΩ 	
SwaggerIgnore
ΩΩ	 
]
ΩΩ 
[
ææ 	"
ProducesResponseType
ææ	 
(
ææ 
typeof
ææ $
(
ææ$ % 
SiniestrosResponse
ææ% 7
)
ææ7 8
,
ææ8 9
StatusCodes
ææ: E
.
ææE F
Status200OK
ææF Q
)
ææQ R
]
ææR S
[
øø 	"
ProducesResponseType
øø	 
(
øø 
typeof
øø $
(
øø$ %
string
øø% +
)
øø+ ,
,
øø, -
StatusCodes
øø. 9
.
øø9 :
Status302Found
øø: H
)
øøH I
]
øøI J
[
¿¿ 	"
ProducesResponseType
¿¿	 
(
¿¿ 
StatusCodes
¿¿ )
.
¿¿) *!
Status400BadRequest
¿¿* =
)
¿¿= >
]
¿¿> ?
[
¡¡ 	"
ProducesResponseType
¡¡	 
(
¡¡ 
StatusCodes
¡¡ )
.
¡¡) **
Status500InternalServerError
¡¡* F
)
¡¡F G
]
¡¡G H
public
¬¬ 
async
¬¬ 
Task
¬¬ 
<
¬¬ 
string
¬¬  
>
¬¬  !
	LoginFake
¬¬" +
(
¬¬+ ,
string
¬¬, 2
rut
¬¬3 6
,
¬¬6 7
string
¬¬8 >
pass
¬¬? C
)
¬¬C D
{
√√ 	
try
ƒƒ 
{
≈≈ 
var
«« 
jsonBody
«« 
=
«« 
$$"""
«»
$str»… 
{{
…… 
rut
…… !
}}
……! #
$str
… # !
{{
  ! #
pass
  # '
}}
  ' )
$str
 Õ) #

                """
ÕŒ 
;
ŒŒ 
var
—— 
headers
—— 
=
—— 
new
—— !

Dictionary
——" ,
<
——, -
string
——- 3
,
——3 4
string
——5 ;
>
——; <
{
““ 
{
”” 
this
”” 
.
”” 
	_settings
”” $
.
””$ %
TokenCABName
””% 1
,
””1 2
this
””3 7
.
””7 8
	_settings
””8 A
.
””A B
TokenCABValue
””B O
}
””P Q
,
””Q R
{
‘‘ 
this
‘‘ 
.
‘‘ 
	_settings
‘‘ $
.
‘‘$ %

CookieName
‘‘% /
,
‘‘/ 0
this
‘‘1 5
.
‘‘5 6
	_settings
‘‘6 ?
.
‘‘? @
CookieValue
‘‘@ K
}
‘‘L M
,
‘‘M N
}
’’ 
;
’’ 
var
◊◊ 
responseBody
◊◊  
=
◊◊! "
await
◊◊# (
this
◊◊) -
.
◊◊- . 
_httpClientService
◊◊. @
.
◊◊@ A
	PostAsync
◊◊A J
(
◊◊J K
new
◊◊K N
Uri
◊◊O R
(
◊◊R S
this
◊◊S W
.
◊◊W X
	_settings
◊◊X a
.
◊◊a b&
ValidarAccesoMultipleUrl
◊◊b z
)
◊◊z {
,
◊◊{ |
jsonBody◊◊} Ö
,◊◊Ö Ü
headers◊◊á é
)◊◊é è
.◊◊è ê
ConfigureAwait◊◊ê û
(◊◊û ü
false◊◊ü §
)◊◊§ •
;◊◊• ¶
using
⁄⁄ 
var
⁄⁄ 
doc
⁄⁄ 
=
⁄⁄ 
JsonDocument
⁄⁄  ,
.
⁄⁄, -
Parse
⁄⁄- 2
(
⁄⁄2 3
responseBody
⁄⁄3 ?
)
⁄⁄? @
;
⁄⁄@ A
string
‹‹ 
?
‹‹ 
	sessionId
‹‹ !
=
‹‹" #
doc
‹‹$ '
.
‹‹' (
RootElement
‹‹( 3
.
‹‹3 4
TryGetProperty
‹‹4 B
(
‹‹B C
$str
‹‹C N
,
‹‹N O
out
‹‹P S
var
‹‹T W
sessionProp
‹‹X c
)
‹‹c d
?
›› 
sessionProp
›› !
.
››! "
	GetString
››" +
(
››+ ,
)
››, -
:
ﬁﬁ 
null
ﬁﬁ 
;
ﬁﬁ 
string
‡‡ 
?
‡‡ 
token
‡‡ 
=
‡‡ 
null
‡‡  $
;
‡‡$ %
if
·· 
(
·· 
doc
·· 
.
·· 
RootElement
·· #
.
··# $
TryGetProperty
··$ 2
(
··2 3
$str
··3 B
,
··B C
out
··D G
var
··H K
tokensArray
··L W
)
··W X
&&
··Y [
tokensArray
‚‚ 
.
‚‚  
	ValueKind
‚‚  )
==
‚‚* ,
JsonValueKind
‚‚- :
.
‚‚: ;
Array
‚‚; @
)
‚‚@ A
{
„„ 
foreach
‰‰ 
(
‰‰ 
var
‰‰  
item
‰‰! %
in
‰‰& (
tokensArray
‰‰) 4
.
‰‰4 5
EnumerateArray
‰‰5 C
(
‰‰C D
)
‰‰D E
)
‰‰E F
{
ÂÂ 
if
ÊÊ 
(
ÊÊ 
item
ÊÊ  
.
ÊÊ  !
TryGetProperty
ÊÊ! /
(
ÊÊ/ 0
$str
ÊÊ0 B
,
ÊÊB C
out
ÊÊD G
var
ÊÊH K
codigo
ÊÊL R
)
ÊÊR S
&&
ÊÊT V
string
ÁÁ "
.
ÁÁ" #
Equals
ÁÁ# )
(
ÁÁ) *
codigo
ÁÁ* 0
.
ÁÁ0 1
	GetString
ÁÁ1 :
(
ÁÁ: ;
)
ÁÁ; <
,
ÁÁ< =
$str
ÁÁ> H
,
ÁÁH I
StringComparison
ÁÁJ Z
.
ÁÁZ [
Ordinal
ÁÁ[ b
)
ÁÁb c
&&
ÁÁd f
item
ËË  
.
ËË  !
TryGetProperty
ËË! /
(
ËË/ 0
$str
ËË0 7
,
ËË7 8
out
ËË9 <
var
ËË= @
	tokenProp
ËËA J
)
ËËJ K
)
ËËK L
{
ÈÈ 
token
ÍÍ !
=
ÍÍ" #
	tokenProp
ÍÍ$ -
.
ÍÍ- .
	GetString
ÍÍ. 7
(
ÍÍ7 8
)
ÍÍ8 9
;
ÍÍ9 :
break
ÎÎ !
;
ÎÎ! "
}
ÏÏ 
}
ÌÌ 
}
ÓÓ 
var
 
request
 
=
 
new
 !#
ValidateAccessRequest
" 7
{
ÒÒ 

RutTitular
ÚÚ 
=
ÚÚ  
rut
ÚÚ! $
,
ÚÚ$ %
RutSolicitante
ÛÛ "
=
ÛÛ# $
rut
ÛÛ% (
,
ÛÛ( )
Rol
ÙÙ 
=
ÙÙ 
ERol
ÙÙ 
.
ÙÙ 
Titular
ÙÙ &
,
ÙÙ& '
RutCorredor
ıı 
=
ıı  !
rut
ıı" %
,
ıı% &
Token
ˆˆ 
=
ˆˆ 
token
ˆˆ !
,
ˆˆ! "

Expiration
˜˜ 
=
˜˜  
DateTime
˜˜! )
.
˜˜) *
UtcNow
˜˜* 0
.
˜˜0 1
AddHours
˜˜1 9
(
˜˜9 :
$num
˜˜: ;
)
˜˜; <
,
˜˜< =
Origen
¯¯ 
=
¯¯ 
EOrigen
¯¯ $
.
¯¯$ %
Web
¯¯% (
,
¯¯( )

RutaOrigen
˘˘ 
=
˘˘  
$str
˘˘! <
,
˘˘< =
	SessionId
˙˙ 
=
˙˙ 
	sessionId
˙˙  )
,
˙˙) *
}
˚˚ 
;
˚˚ 
string
˝˝ 
urlFinal
˝˝ 
=
˝˝  !
await
˝˝" '
this
˝˝( ,
.
˝˝, -
_handler
˝˝- 5
.
˝˝5 6 
GenerarUrlFrontend
˝˝6 H
(
˝˝H I
request
˝˝I P
)
˝˝P Q
.
˝˝Q R
ConfigureAwait
˝˝R `
(
˝˝` a
false
˝˝a f
)
˝˝f g
;
˝˝g h
return
˛˛ 
urlFinal
˛˛ 
.
˛˛  
Replace
˛˛  '
(
˛˛' (
$str
˛˛( 0
,
˛˛0 1
$str
˛˛2 8
,
˛˛8 9
StringComparison
˛˛: J
.
˛˛J K
OrdinalIgnoreCase
˛˛K \
)
˛˛\ ]
;
˛˛] ^
}
ˇˇ 
catch
ÄÄ 
(
ÄÄ "
HttpRequestException
ÄÄ '
httpEx
ÄÄ( .
)
ÄÄ. /
{
ÅÅ 
this
ÇÇ 
.
ÇÇ 
_logger
ÇÇ 
.
ÇÇ 
LogError
ÇÇ %
(
ÇÇ% &
httpEx
ÇÇ& ,
)
ÇÇ, -
;
ÇÇ- .
return
ÉÉ 
$"
ÉÉ 
$str
ÉÉ =
{
ÉÉ= >
httpEx
ÉÉ> D
.
ÉÉD E
Message
ÉÉE L
}
ÉÉL M
"
ÉÉM N
;
ÉÉN O
}
ÑÑ 
catch
ÖÖ 
(
ÖÖ #
TaskCanceledException
ÖÖ (
tex
ÖÖ) ,
)
ÖÖ, -
{
ÜÜ 
this
áá 
.
áá 
_logger
áá 
.
áá 
LogError
áá %
(
áá% &
tex
áá& )
)
áá) *
;
áá* +
return
àà 
$"
àà 
$str
àà Y
{
ààY Z
tex
ààZ ]
.
àà] ^
Message
àà^ e
}
ààe f
"
ààf g
;
ààg h
}
ââ 
catch
ää 
(
ää 
JsonException
ää  
jsonEx
ää! '
)
ää' (
{
ãã 
this
åå 
.
åå 
_logger
åå 
.
åå 
LogError
åå %
(
åå% &
jsonEx
åå& ,
)
åå, -
;
åå- .
throw
çç 
new
çç '
InvalidOperationException
çç 3
(
çç3 4
$"
çç4 6
$str
çç6 W
{
ççW X
jsonEx
ççX ^
.
çç^ _
Message
çç_ f
}
ççf g
"
ççg h
,
ççh i
jsonEx
ççj p
)
ççp q
;
ççq r
}
éé 
catch
èè 
(
èè '
InvalidOperationException
èè ,
invEx
èè- 2
)
èè2 3
{
êê 
this
ëë 
.
ëë 
_logger
ëë 
.
ëë 
LogError
ëë %
(
ëë% &
invEx
ëë& +
)
ëë+ ,
;
ëë, -
return
íí 
$"
íí 
$str
íí 7
{
íí7 8
invEx
íí8 =
.
íí= >
Message
íí> E
}
ííE F
"
ííF G
;
ííG H
}
ìì 
}
îî 	
private
ùù 
static
ùù 
string
ùù 
GetPropertySafe
ùù -
(
ùù- .
JsonElement
ùù. 9
element
ùù: A
,
ùùA B
string
ùùC I
propertyName
ùùJ V
,
ùùV W
string
ùùX ^
defaultValue
ùù_ k
=
ùùl m
$str
ùùn p
)
ùùp q
{
ûû 	
return
üü 
element
üü 
.
üü 
TryGetProperty
üü )
(
üü) *
propertyName
üü* 6
,
üü6 7
out
üü8 ;
var
üü< ?
prop
üü@ D
)
üüD E
?
üüF G
prop
üüH L
.
üüL M
	GetString
üüM V
(
üüV W
)
üüW X
??
üüY [
defaultValue
üü\ h
:
üüi j
defaultValue
üük w
;
üüw x
}
†† 	
private
ßß 
List
ßß 
<
ßß $
SiniestrosDataResponse
ßß +
>
ßß+ ,%
ParseSiniestrosFromJson
ßß- D
(
ßßD E
JsonElement
ßßE P
	jsonArray
ßßQ Z
)
ßßZ [
{
®® 	
var
©© 
siniestrosList
©© 
=
©©  
new
©©! $
List
©©% )
<
©©) *$
SiniestrosDataResponse
©©* @
>
©©@ A
(
©©A B
)
©©B C
;
©©C D
foreach
´´ 
(
´´ 
var
´´ 
siniestroData
´´ &
in
´´' )
	jsonArray
´´* 3
.
´´3 4
EnumerateArray
´´4 B
(
´´B C
)
´´C D
)
´´D E
{
¨¨ 
var
≠≠ 
siniestroResponse
≠≠ %
=
≠≠& '
this
≠≠( ,
.
≠≠, -
TryParseSiniestro
≠≠- >
(
≠≠> ?
siniestroData
≠≠? L
)
≠≠L M
;
≠≠M N
if
ÆÆ 
(
ÆÆ 
siniestroResponse
ÆÆ %
!=
ÆÆ& (
null
ÆÆ) -
)
ÆÆ- .
{
ØØ 
siniestrosList
∞∞ "
.
∞∞" #
Add
∞∞# &
(
∞∞& '
siniestroResponse
∞∞' 8
)
∞∞8 9
;
∞∞9 :
}
±± 
}
≤≤ 
return
¥¥ 
siniestrosList
¥¥ !
;
¥¥! "
}
µµ 	
private
ºº $
SiniestrosDataResponse
ºº &
?
ºº& '
TryParseSiniestro
ºº( 9
(
ºº9 :
JsonElement
ºº: E
siniestroData
ººF S
)
ººS T
{
ΩΩ 	
var
ææ 
numeroSiniestro
ææ 
=
ææ  !
GetPropertySafe
ææ" 1
(
ææ1 2
siniestroData
ææ2 ?
,
ææ? @
$str
ææA R
)
ææR S
;
ææS T
if
¿¿ 
(
¿¿ 
!
¿¿ 
int
¿¿ 
.
¿¿ 
TryParse
¿¿ 
(
¿¿ 
numeroSiniestro
¿¿ -
,
¿¿- .
CultureInfo
¿¿/ :
.
¿¿: ;
InvariantCulture
¿¿; K
,
¿¿K L
out
¿¿M P
int
¿¿Q T
numSiniestro
¿¿U a
)
¿¿a b
)
¿¿b c
{
¡¡ 
this
¬¬ 
.
¬¬ 
_logger
¬¬ 
.
¬¬ 
Debug
¬¬ "
(
¬¬" #
$"
¬¬# %
$str
¬¬% I
{
¬¬I J
numeroSiniestro
¬¬J Y
}
¬¬Y Z
$str
¬¬Z u
"
¬¬u v
)
¬¬v w
;
¬¬w x
return
√√ 
null
√√ 
;
√√ 
}
ƒƒ 
return
∆∆ 
new
∆∆ $
SiniestrosDataResponse
∆∆ -
{
«« 
RutCorredor
»» 
=
»» 
GetPropertySafe
»» -
(
»»- .
siniestroData
»». ;
,
»»; <
$str
»»= J
)
»»J K
,
»»K L
NumeroSiniestro
…… 
=
……  !
numSiniestro
……" .
,
……. /
FechaSiniestro
   
=
    
GetPropertySafe
  ! 0
(
  0 1
siniestroData
  1 >
,
  > ?
$str
  @ P
)
  P Q
,
  Q R
FechaDenuncia
ÀÀ 
=
ÀÀ 
GetPropertySafe
ÀÀ  /
(
ÀÀ/ 0
siniestroData
ÀÀ0 =
,
ÀÀ= >
$str
ÀÀ? N
)
ÀÀN O
,
ÀÀO P
CodigoEstado
ÃÃ 
=
ÃÃ 
GetPropertySafe
ÃÃ .
(
ÃÃ. /
siniestroData
ÃÃ/ <
,
ÃÃ< =
$str
ÃÃ> L
)
ÃÃL M
,
ÃÃM N
Estado
ÕÕ 
=
ÕÕ 
GetPropertySafe
ÕÕ (
(
ÕÕ( )
siniestroData
ÕÕ) 6
,
ÕÕ6 7
$str
ÕÕ8 @
)
ÕÕ@ A
,
ÕÕA B
CodigoEtapa
ŒŒ 
=
ŒŒ 
GetPropertySafe
ŒŒ -
(
ŒŒ- .
siniestroData
ŒŒ. ;
,
ŒŒ; <
$str
ŒŒ= J
)
ŒŒJ K
,
ŒŒK L
Etapa
œœ 
=
œœ 
GetPropertySafe
œœ '
(
œœ' (
siniestroData
œœ( 5
,
œœ5 6
$str
œœ7 >
)
œœ> ?
,
œœ? @
Ramo
–– 
=
–– 
GetPropertySafe
–– &
(
––& '
siniestroData
––' 4
,
––4 5
$str
––6 <
)
––< =
,
––= >
NumeroPoliza
—— 
=
—— 
GetPropertySafe
—— .
(
——. /
siniestroData
——/ <
,
——< =
$str
——> L
)
——L M
,
——M N

NumeroItem
““ 
=
““ 
GetPropertySafe
““ ,
(
““, -
siniestroData
““- :
,
““: ;
$str
““< H
)
““H I
,
““I J
TipoDano
”” 
=
”” 
GetPropertySafe
”” *
(
””* +
siniestroData
””+ 8
,
””8 9
$str
””: D
)
””D E
,
””E F
}
‘‘ 
;
‘‘ 
}
’’ 	
private
‹‹ 
List
‹‹ 
<
‹‹ 
(
‹‹ "
SiniestrosDetRequest
‹‹ *
Request
‹‹+ 2
,
‹‹2 3$
SiniestrosDataResponse
‹‹4 J
OriginalData
‹‹K W
)
‹‹W X
>
‹‹X Y!
ProcessVPSiniestros
‹‹Z m
(
‹‹m n!
IReadOnlyCollection
›› 
<
››  $
SiniestrosDataResponse
››  6
>
››6 7

siniestros
››8 B
)
››B C
{
ﬁﬁ 	
var
ﬂﬂ 
result
ﬂﬂ 
=
ﬂﬂ 
new
ﬂﬂ 
List
ﬂﬂ !
<
ﬂﬂ! "
(
ﬂﬂ" #"
SiniestrosDetRequest
ﬂﬂ# 7
Request
ﬂﬂ8 ?
,
ﬂﬂ? @$
SiniestrosDataResponse
ﬂﬂA W
OriginalData
ﬂﬂX d
)
ﬂﬂd e
>
ﬂﬂe f
(
ﬂﬂf g
)
ﬂﬂg h
;
ﬂﬂh i
foreach
·· 
(
·· 
var
·· 
s
·· 
in
·· 

siniestros
·· (
.
··( )
Where
··) .
(
··. /
p
··/ 0
=>
··1 3
string
··4 :
.
··: ;
Equals
··; A
(
··A B
p
··B C
.
··C D
Ramo
··D H
,
··H I
$str
··J N
,
··N O
StringComparison
··P `
.
··` a
Ordinal
··a h
)
··h i
&&
··j l
p
··m n
.
··n o
NumeroSiniestro
··o ~
.
··~ 
HasValue·· á
&&··à ä
!··ã å
string··å í
.··í ì"
IsNullOrWhiteSpace··ì •
(··• ¶
p··¶ ß
.··ß ®
NumeroPoliza··® ¥
)··¥ µ
)··µ ∂
)··∂ ∑
{
‚‚ 
var
„„ 
numeroPolizaStr
„„ #
=
„„$ %
new
„„& )
string
„„* 0
(
„„0 1
s
„„1 2
.
„„2 3
NumeroPoliza
„„3 ?
!
„„? @
.
„„@ A
Where
„„A F
(
„„F G
char
„„G K
.
„„K L
IsDigit
„„L S
)
„„S T
.
„„T U
ToArray
„„U \
(
„„\ ]
)
„„] ^
)
„„^ _
;
„„_ `
if
ÂÂ 
(
ÂÂ 
!
ÂÂ 
int
ÂÂ 
.
ÂÂ 
TryParse
ÂÂ !
(
ÂÂ! "
numeroPolizaStr
ÂÂ" 1
,
ÂÂ1 2
CultureInfo
ÂÂ3 >
.
ÂÂ> ?
InvariantCulture
ÂÂ? O
,
ÂÂO P
out
ÂÂQ T
int
ÂÂU X
numeroDocto
ÂÂY d
)
ÂÂd e
)
ÂÂe f
{
ÊÊ 
this
ÁÁ 
.
ÁÁ 
_logger
ÁÁ  
.
ÁÁ  !
Debug
ÁÁ! &
(
ÁÁ& '
$"
ÁÁ' )
$str
ÁÁ) J
{
ÁÁJ K
s
ÁÁK L
.
ÁÁL M
NumeroPoliza
ÁÁM Y
}
ÁÁY Z
$str
ÁÁZ u
"
ÁÁu v
)
ÁÁv w
;
ÁÁw x
continue
ËË 
;
ËË 
}
ÈÈ 
var
ÎÎ 

detRequest
ÎÎ 
=
ÎÎ  
new
ÎÎ! $"
SiniestrosDetRequest
ÎÎ% 9
{
ÏÏ 
INsinie
ÌÌ 
=
ÌÌ 
s
ÌÌ 
.
ÌÌ  
NumeroSiniestro
ÌÌ  /
!
ÌÌ/ 0
.
ÌÌ0 1
Value
ÌÌ1 6
,
ÌÌ6 7
INdocto
ÓÓ 
=
ÓÓ 
numeroDocto
ÓÓ )
,
ÓÓ) *
}
ÔÔ 
;
ÔÔ 
result
ÒÒ 
.
ÒÒ 
Add
ÒÒ 
(
ÒÒ 
(
ÒÒ 

detRequest
ÒÒ &
,
ÒÒ& '
s
ÒÒ( )
)
ÒÒ) *
)
ÒÒ* +
;
ÒÒ+ ,
}
ÚÚ 
return
ÙÙ 
result
ÙÙ 
.
ÙÙ 

DistinctBy
ÙÙ $
(
ÙÙ$ %
x
ÙÙ% &
=>
ÙÙ' )
new
ÙÙ* -
{
ÙÙ. /
x
ÙÙ0 1
.
ÙÙ1 2
Request
ÙÙ2 9
.
ÙÙ9 :
INsinie
ÙÙ: A
,
ÙÙA B
x
ÙÙC D
.
ÙÙD E
Request
ÙÙE L
.
ÙÙL M
INdocto
ÙÙM T
}
ÙÙU V
)
ÙÙV W
.
ÙÙW X
ToList
ÙÙX ^
(
ÙÙ^ _
)
ÙÙ_ `
;
ÙÙ` a
}
ıı 	
private
˝˝ 
SiniestrosDataDto
˝˝ !!
CreateSiniestrosDTO
˝˝" 5
(
˝˝5 6
List
˛˛ 
<
˛˛ 
(
˛˛ "
SiniestrosDetRequest
˛˛ &
Request
˛˛' .
,
˛˛. /$
SiniestrosDataResponse
˛˛0 F
OriginalData
˛˛G S
)
˛˛S T
>
˛˛T U'
lstSiniestrosDataResponse
˛˛V o
,
˛˛o p
JsonElement
ˇˇ 
siniestrosArray
ˇˇ '
)
ˇˇ' (
{
ÄÄ 	
var
ÅÅ 
siniestrosDataDTO
ÅÅ !
=
ÅÅ" #
new
ÅÅ$ '
SiniestrosDataDto
ÅÅ( 9
(
ÅÅ9 :
)
ÅÅ: ;
;
ÅÅ; <
siniestrosDataDTO
ÇÇ 
.
ÇÇ 
TiposSiniestros
ÇÇ -
.
ÇÇ- .
Add
ÇÇ. 1
(
ÇÇ1 2
new
ÇÇ2 5
TipoSiniestroDto
ÇÇ6 F
{
ÇÇG H
Nombre
ÇÇI O
=
ÇÇP Q
$str
ÇÇR \
,
ÇÇ\ ]
Visible
ÇÇ^ e
=
ÇÇf g
true
ÇÇh l
}
ÇÇm n
)
ÇÇn o
;
ÇÇo p
foreach
ÑÑ 
(
ÑÑ 
var
ÑÑ 
item
ÑÑ 
in
ÑÑ  '
lstSiniestrosDataResponse
ÑÑ! :
)
ÑÑ: ;
{
ÖÖ 
var
ÜÜ 
siniestroDto
ÜÜ  
=
ÜÜ! "
this
ÜÜ# '
.
ÜÜ' ( 
CreateSiniestroDto
ÜÜ( :
(
ÜÜ: ;
item
ÜÜ; ?
,
ÜÜ? @
siniestrosArray
ÜÜA P
)
ÜÜP Q
;
ÜÜQ R
if
áá 
(
áá 
siniestroDto
áá  
!=
áá! #
null
áá$ (
)
áá( )
{
àà 
siniestrosDataDTO
ââ %
.
ââ% &

Siniestros
ââ& 0
.
ââ0 1
Add
ââ1 4
(
ââ4 5
siniestroDto
ââ5 A
)
ââA B
;
ââB C
}
ää 
}
ãã 
return
çç 
siniestrosDataDTO
çç $
;
çç$ %
}
éé 	
private
ññ 
SiniestroDto
ññ 
?
ññ  
CreateSiniestroDto
ññ 0
(
ññ0 1
(
óó "
SiniestrosDetRequest
óó !
Request
óó" )
,
óó) *$
SiniestrosDataResponse
óó+ A
OriginalData
óóB N
)
óóN O
item
óóP T
,
óóT U
JsonElement
òò 
siniestrosArray
òò '
)
òò' (
{
ôô 	
var
öö  
numeroSiniestroStr
öö "
=
öö# $
item
öö% )
.
öö) *
OriginalData
öö* 6
.
öö6 7
NumeroSiniestro
öö7 F
?
ööF G
.
ööG H
ToString
ööH P
(
ööP Q
CultureInfo
ööQ \
.
öö\ ]
InvariantCulture
öö] m
)
ööm n
??
ööo q
string
öör x
.
ööx y
Empty
ööy ~
;
öö~ 
var
õõ #
siniestroDataNullable
õõ %
=
õõ& '
siniestrosArray
õõ( 7
.
õõ7 8
EnumerateArray
õõ8 F
(
õõF G
)
õõG H
.
úú 
FirstOrDefault
úú 
(
úú  
s
úú  !
=>
úú" $
string
úú% +
.
úú+ ,
Equals
úú, 2
(
úú2 3
GetPropertySafe
úú3 B
(
úúB C
s
úúC D
,
úúD E
$str
úúF W
)
úúW X
,
úúX Y 
numeroSiniestroStr
úúZ l
,
úúl m
StringComparison
úún ~
.
úú~ 
Ordinalúú Ü
)úúÜ á
)úúá à
;úúà â
if
ûû 
(
ûû #
siniestroDataNullable
ûû %
.
ûû% &
	ValueKind
ûû& /
==
ûû0 2
JsonValueKind
ûû3 @
.
ûû@ A
	Undefined
ûûA J
)
ûûJ K
{
üü 
this
†† 
.
†† 
_logger
†† 
.
†† 
Debug
†† "
(
††" #
$"
††# %
$str
††% U
{
††U V 
numeroSiniestroStr
††V h
}
††h i
$str††i Ñ
"††Ñ Ö
)††Ö Ü
;††Ü á
return
°° 
null
°° 
;
°° 
}
¢¢ 
var
§§ 
patente
§§ 
=
§§ 
GetPropertySafe
§§ )
(
§§) *#
siniestroDataNullable
§§* ?
,
§§? @
$str
§§A J
)
§§J K
;
§§K L
return
¶¶ 
new
¶¶ 
SiniestroDto
¶¶ #
{
ßß 
NumSiniestro
®® 
=
®®  
numeroSiniestroStr
®® 1
,
®®1 2
TipoSinistros
©© 
=
©© 
$str
©©  &
,
©©& '
GlosaSiniestro
™™ 
=
™™  
$"
™™! #
$str
™™# ,
{
™™, -
patente
™™- 4
}
™™4 5
"
™™5 6
,
™™6 7
FechaDenuncio
´´ 
=
´´ 
item
´´  $
.
´´$ %
OriginalData
´´% 1
.
´´1 2
FechaDenuncia
´´2 ?
??
´´@ B
string
´´C I
.
´´I J
Empty
´´J O
,
´´O P
EstadoSinistro
¨¨ 
=
¨¨  
item
¨¨! %
.
¨¨% &
OriginalData
¨¨& 2
.
¨¨2 3
Estado
¨¨3 9
??
¨¨: <
string
¨¨= C
.
¨¨C D
Empty
¨¨D I
,
¨¨I J
EstadoDenuncio
≠≠ 
=
≠≠  
item
≠≠! %
.
≠≠% &
OriginalData
≠≠& 2
.
≠≠2 3
CodigoEstado
≠≠3 ?
??
≠≠@ B
string
≠≠C I
.
≠≠I J
Empty
≠≠J O
,
≠≠O P 
AccionesPendientes
ÆÆ "
=
ÆÆ# $
false
ÆÆ% *
,
ÆÆ* +
}
ØØ 
;
ØØ 
}
∞∞ 	
}
±± 
}≤≤ •-
oC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Configuration\ConfigureSwaggerOptions.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Configuration! .
{ 
internal 
sealed 
class #
ConfigureSwaggerOptions 1
:2 3"
IConfigureNamedOptions4 J
<J K
SwaggerGenOptionsK \
>\ ]
{ 
private 
readonly *
IApiVersionDescriptionProvider 7
	_provider8 A
;A B
public #
ConfigureSwaggerOptions &
(& '*
IApiVersionDescriptionProvider' E
providerF N
)N O
{ 	
this 
. 
	_provider 
= 
provider %
??& (
throw) .
new/ 2!
ArgumentNullException3 H
(H I
nameofI O
(O P
providerP X
)X Y
)Y Z
;Z [
} 	
public!! 
void!! 
	Configure!! 
(!! 
SwaggerGenOptions!! /
options!!0 7
)!!7 8
{"" 	!
ArgumentNullException## !
.##! "
ThrowIfNull##" -
(##- .
options##. 5
)##5 6
;##6 7
options%% 
.%% !
AddSecurityDefinition%% )
(%%) *
$str%%* 2
,%%2 3
new%%4 7!
OpenApiSecurityScheme%%8 M
{&& 
Name'' 
='' 
$str'' &
,''& '
Type(( 
=(( 
SecuritySchemeType(( )
.(() *
ApiKey((* 0
,((0 1
Scheme)) 
=)) 
$str)) !
,))! "
BearerFormat** 
=** 
$str** $
,**$ %
In++ 
=++ 
ParameterLocation++ &
.++& '
Header++' -
,++- .
Description,, 
=,, 
$str,, x
,,,x y
}-- 
)-- 
;-- 
options// 
.// "
AddSecurityRequirement// *
(//* +
new//+ .&
OpenApiSecurityRequirement/// I
{00 
{11 
new22 !
OpenApiSecurityScheme22 -
{33 
	Reference44 !
=44" #
new44$ '
OpenApiReference44( 8
{55 
Type66  
=66! "
ReferenceType66# 0
.660 1
SecurityScheme661 ?
,66? @
Id77 
=77  
$str77! )
,77) *
}88 
,88 
}99 
,99 
Array:: 
.:: 
Empty:: 
<::  
string::  &
>::& '
(::' (
)::( )
};; 
,;; 
}<< 
)<< 
;<< 
foreach>> 
(>> 
var>> 
description>> $
in>>% '
this>>( ,
.>>, -
	_provider>>- 6
.>>6 7"
ApiVersionDescriptions>>7 M
.>>M N
OrderByDescending>>N _
(>>_ `
d>>` a
=>>>b d
d>>e f
.>>f g

ApiVersion>>g q
)>>q r
)>>r s
{?? 
options@@ 
.@@ 

SwaggerDoc@@ "
(@@" #
description@@# .
.@@. /
	GroupName@@/ 8
,@@8 9
CreateVersionInfo@@: K
(@@K L
description@@L W
)@@W X
)@@X Y
;@@Y Z
varBB 
xmlFileBB 
=BB 
$"BB  
{BB  !
AssemblyBB! )
.BB) * 
GetExecutingAssemblyBB* >
(BB> ?
)BB? @
.BB@ A
GetNameBBA H
(BBH I
)BBI J
.BBJ K
NameBBK O
}BBO P
$strBBP T
"BBT U
;BBU V
varCC 
xmlPathCC 
=CC 
PathCC "
.CC" #
CombineCC# *
(CC* +

AppContextCC+ 5
.CC5 6
BaseDirectoryCC6 C
,CCC D
xmlFileCCE L
)CCL M
;CCM N
optionsDD 
.DD 
IncludeXmlCommentsDD *
(DD* +
xmlPathDD+ 2
,DD2 3(
includeControllerXmlCommentsDD4 P
:DDP Q
trueDDR V
)DDV W
;DDW X
}EE 
}FF 	
publicII 
voidII 
	ConfigureII 
(II 
stringII $
?II$ %
nameII& *
,II* +
SwaggerGenOptionsII, =
optionsII> E
)IIE F
{JJ 	
thisKK 
.KK 
	ConfigureKK 
(KK 
optionsKK "
)KK" #
;KK# $
}LL 	
privateNN 
staticNN 
OpenApiInfoNN "
CreateVersionInfoNN# 4
(NN4 5!
ApiVersionDescriptionNN5 J
descriptionNNK V
)NNV W
{OO 	
varPP 
infoPP 
=PP 
newPP 
OpenApiInfoPP &
{QQ 
TitleRR 
=RR 
$strRR 0
,RR0 1
VersionSS 
=SS 
descriptionSS %
.SS% &

ApiVersionSS& 0
.SS0 1
ToStringSS1 9
(SS9 :
)SS: ;
,SS; <
DescriptionTT 
=TT 
$strTT e
,TTe f
}UU 
;UU 
ifWW 
(WW 
descriptionWW 
.WW 
IsDeprecatedWW (
)WW( )
{XX 
infoYY 
.YY 
DescriptionYY  
+=YY! #
$strYY$ L
;YYL M
}ZZ 
return\\ 
info\\ 
;\\ 
}]] 	
}^^ 
}__ Ù
xC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Configuration\ConfigureServicesAndRepositories.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Configuration! .
{ 
public 

static 
class ,
 ConfigureServicesAndRepositories 8
{ 
public 
static !
WebApplicationBuilder +&
AddSeguimientoCadsServices, F
(F G
thisG K!
WebApplicationBuilderL a
builderb i
)i j
{ 	!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
builder. 5
)5 6
;6 7
builder 
. 
Services 
. 
AddSingleton )
<) *$
IResiliencePolicyService* B
,B C#
ResiliencePolicyServiceD [
>[ \
(\ ]
)] ^
;^ _
builder 
. 
Services 
. 
	AddScoped &
<& '
ITokenService' 4
,4 5
TokenService6 B
>B C
(C D
)D E
;E F
builder 
. 
Services 
. 
AddHttpClient *
<* +
IHttpClientService+ =
,= >
HttpClientService? P
>P Q
(Q R
)R S
;S T
builder 
. 
Services 
. 
	AddScoped &
<& '
IUsersHandler' 4
,4 5
UsersHandler6 B
>B C
(C D
)D E
;E F
builder   
.   
Services   
.   
	AddScoped   &
<  & '
ICadsService  ' 3
,  3 4
CadsService  5 @
>  @ A
(  A B
)  B C
;  C D
builder!! 
.!! 
Services!! 
.!! 
	AddScoped!! &
<!!& '
ISiniestrosService!!' 9
,!!9 :
SiniestrosService!!; L
>!!L M
(!!M N
)!!N O
;!!O P
builder"" 
."" 
Services"" 
."" 
	AddScoped"" &
<""& '
ISiniestrosHandler""' 9
,""9 :
SiniestrosHandler""; L
>""L M
(""M N
)""N O
;""O P
builder## 
.## 
Services## 
.## 
	AddScoped## &
<##& '
IHttpService##' 3
,##3 4
HttpService##5 @
>##@ A
(##A B
)##B C
;##C D
builder$$ 
.$$ 
Services$$ 
.$$ 
	AddScoped$$ &
<$$& '
IHttpHandler$$' 3
,$$3 4
HttpHandler$$5 @
>$$@ A
($$A B
)$$B C
;$$C D
return%% 
builder%% 
;%% 
}&& 	
}'' 
}(( ß-
hC:\Analisis\SistemasAnalizar\apiseguimientocads\ApiSeguimientoCADS.Api\Configuration\ConfigureProgram.cs
	namespace 	
ApiSeguimientoCADS
 
. 
Api  
.  !
Configuration! .
{ 
public 

static 
class 
ConfigureProgram (
{ 
public 
static !
WebApplicationBuilder +&
AddSeguimientoCadsSecurity, F
(F G
thisG K!
WebApplicationBuilderL a
builderb i
)i j
{ 	!
ArgumentNullException !
.! "
ThrowIfNull" -
(- .
builder. 5
)5 6
;6 7
var 
jwtKey 
= 
builder  
.  !
Configuration! .
[. /
$str/ 8
]8 9
?? 
throw 
new %
InvalidOperationException 4
(4 5
$str5 Z
)Z [
;[ \
var 
	jwtIssuer 
= 
builder #
.# $
Configuration$ 1
[1 2
$str2 >
]> ?
??  "
throw# (
new) ,%
InvalidOperationException- F
(F G
$strG o
)o p
;p q
if"" 
("" 
builder"" 
."" 
Environment"" #
.""# $
IsDevelopment""$ 1
(""1 2
)""2 3
)""3 4
{## 
builder$$ 
.$$ 
Services$$  
.$$  !
AddAuthentication$$! 2
($$2 3
JwtBearerDefaults$$3 D
.$$D E 
AuthenticationScheme$$E Y
)$$Y Z
.%% 
AddJwtBearer%%  
(%%  !
options%%! (
=>%%) +
{&& 
options'' 
.'' %
TokenValidationParameters'' 8
=''9 :
new''; >%
TokenValidationParameters''? X
{(( 
ValidateIssuer)) )
=))* +
true)), 0
,))0 1
ValidateAudience** +
=**, -
true**. 2
,**2 3
ValidateLifetime++ +
=++, -
true++. 2
,++2 3$
ValidateIssuerSigningKey,, 3
=,,4 5
false,,6 ;
,,,; <
}-- 
;-- 
}.. 
).. 
;.. 
}// 
else00 
{11 
builder22 
.22 
Services22  
.22  !
AddAuthentication22! 2
(222 3
JwtBearerDefaults223 D
.22D E 
AuthenticationScheme22E Y
)22Y Z
.33 
AddJwtBearer33  
(33  !
options33! (
=>33) +
{44 
options55 
.55 %
TokenValidationParameters55 8
=559 :
new55; >%
TokenValidationParameters55? X
{66 
ValidateIssuer77 )
=77* +
true77, 0
,770 1
ValidateAudience88 +
=88, -
true88. 2
,882 3
ValidateLifetime99 +
=99, -
true99. 2
,992 3$
ValidateIssuerSigningKey:: 3
=::4 5
true::6 :
,::: ;
ValidIssuer;; &
=;;' (
	jwtIssuer;;) 2
,;;2 3
ValidAudience<< (
=<<) *
	jwtIssuer<<+ 4
,<<4 5
IssuerSigningKey== +
===, -
new==. 1 
SymmetricSecurityKey==2 F
(==F G
Encoding==G O
.==O P
UTF8==P T
.==T U
GetBytes==U ]
(==] ^
jwtKey==^ d
)==d e
)==e f
,==f g
}>> 
;>> 
}?? 
)?? 
;?? 
}@@ 
returnBB 
builderBB 
;BB 
}CC 	
publicJJ 
staticJJ !
WebApplicationBuilderJJ +)
AddSeguimientoCadsSettingsMapJJ, I
(JJI J
thisJJJ N!
WebApplicationBuilderJJO d
builderJJe l
)JJl m
{KK 	!
ArgumentNullExceptionLL !
.LL! "
ThrowIfNullLL" -
(LL- .
builderLL. 5
)LL5 6
;LL6 7
builderOO 
.OO 
ServicesOO 
.OO 
	ConfigureOO &
<OO& '
JwtSettingsOO' 2
>OO2 3
(OO3 4
builderOO4 ;
.OO; <
ConfigurationOO< I
.OOI J

GetSectionOOJ T
(OOT U
$strOOU Z
)OOZ [
)OO[ \
;OO\ ]
builderPP 
.PP 
ServicesPP 
.PP 
	ConfigurePP &
<PP& '
CadsSettingsPP' 3
>PP3 4
(PP4 5
builderPP5 <
.PP< =
ConfigurationPP= J
.PPJ K

GetSectionPPK U
(PPU V
$strPPV _
)PP_ `
)PP` a
;PPa b
builderQQ 
.QQ 
ServicesQQ 
.QQ 
	ConfigureQQ &
<QQ& '+
EPSiniestroPorAseguradoSettingsQQ' F
>QQF G
(QQG H
builderQQH O
.QQO P
ConfigurationQQP ]
.QQ] ^

GetSectionQQ^ h
(QQh i
$str	QQi á
)
QQá à
)
QQà â
;
QQâ ä
builderRR 
.RR 
ServicesRR 
.RR 
	ConfigureRR &
<RR& '*
EPGetdatosdelsiniestroSettingsRR' E
>RRE F
(RRF G
builderRRG N
.RRN O
ConfigurationRRO \
.RR\ ]

GetSectionRR] g
(RRg h
$str	RRh Ä
)
RRÄ Å
)
RRÅ Ç
;
RRÇ É
returnSS 
builderSS 
;SS 
}TT 	
}UU 
}VV 