var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

//Dobra dobra, idziemy po kolei. Zrobi�em troch� inaczej. Stworzy�em projekt ASP.NET Core kt�ry jest PUSTY. Tzn posiadam tam appsettings.json Properties (folder) oraz Porgram.cs. Do rozwi�zania stworzy�em nasze 3 warstwy (Application, Domain, Infrastructure) oraz doda�em referencje mi�dzy tymi 4 projektami (bo jeszcze mamy g��wny projekt "WebAPI") Doda�em tak�e do WebAPI pakiety NUGET kt�re proponowa�e�. Teraz musimy i�� krok po kroku �eby stworzy� nasz� aplikacj� webow� do zarz�dzania magazynem. Trzeba przemy�le� najpierw g��wne cechy. I zacznijmy mo�e od tworzenia naszych encji oraz bazy danych. Za�o�enie mam takie: Magazyn: id pojemno��(ile mie�ci w sobie rega��w) typ magazynu(tutaj zrobimy enum) rodzaj magazynu(tutaj zrobimy enum) Rega�: id pojemno��(ile mie�ci na sobie produkt�w) Produkt: id nazwa waga wartosc data wa�no�ci typ prod. (zrobimy enum) rodzaj prod. (zrobimy enum) Robimy powoli ma�ymi krokami ale DOK�ADNIE �eby wszystko si� zgadza�o z Clean Architecture