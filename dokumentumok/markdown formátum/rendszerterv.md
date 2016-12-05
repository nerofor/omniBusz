#I. Bevezetés
#II. Architektúra
#III. Jogosultsági körök
	
Alapvetően 2 féle környezet különböztetünk meg a projekt során: 
* webes
	* regisztrálatlan felhasználó
		- letöltheti a játékot
		- kép vagy videógalériát nézhet
		- regisztrálhat
		- a játék eddigi történetét tekintheti meg
	* regisztrált felhasználó
		- beléphet a saját felhasználói felületére
		- a saját adatait módosíthatja
		- fórumot használhat
		- üzenhet a felhasználóknak és az adminisztrátornak
		- pontokat szerezhetsz
		- vitatémát indíthat
	* adminisztrátor
		- regisztrálhat, törölhet(logikai), figyelmeztethet felhasználót
		- törölhet vitatémát
* játék
	* játékos
		- bejelentkezhet
		- pontot szerezhet
		- meghalhat
#IV. Képernyőtervek
#V. Funkciók
#VI. Adatmodell - ábra
#VII. Adatmodett - részletes
#VIII. Biztonság
A mai világban nagy hangsúly kell fektetnünk a biztonságra. Manapság rengeteg adatot tárolunk szervereken és (szerintem) senki sem szeretné, hogy ezek az adatok illetéktelenek kezébe kerüljül. Például, hogy a szerelmes üzeneteinken vagy más magánéleti dolgainkon csámcsogjanak a szomszédok. A projekt során cégünk saját szerverein tárolódnak a felhasználók adatai amelyeket bizalmasan kezelünk és a mindenkoron aktuális törvényi szabályozásnak megfelelően.
Mivel az interneten keresztül kommunikálunk a célközönséggel így fontos a biztonság. A szervereinket helyben fizikailag is beépített behatolásgátló (tűzfal) rendszerek védik. Ezt tovább növele, az adattárolókról készítünk rendszeresen biztonsági mentéseket. A szervertermeket riasztóval védett klimatizált helyiségben tartjuk. A rendszer üzembiztosságnál ezekre a területekre is figyelmet kell fordítani.
A fizikai biztonságon felül szoftveres védelemről is szó kell essen, mert a vállalati környezetben az adatlopás is súlyos károkat tud okozni. A fizikai tűzfalakon mellett szoftveresen is gondoskodunk az adatok védelméről, mind szerver, mind pedig az egyes végpontokon.
Végül, de nem utolsó sorban a biztonságos kód sem elhanyagolható. Ez is ugyanolyan veszélyt jelent egy rendszer. Ezért tartjuk az általunk készített kódot naprakészen, hogy az ügyfeleinknek megfelelő biztonságban érezhessék magukat.