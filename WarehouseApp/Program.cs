var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

//Dobra dobra, idziemy po kolei. Zrobi³em trochê inaczej. Stworzy³em projekt ASP.NET Core który jest PUSTY. Tzn posiadam tam appsettings.json Properties (folder) oraz Porgram.cs. Do rozwi¹zania stworzy³em nasze 3 warstwy (Application, Domain, Infrastructure) oraz doda³em referencje miêdzy tymi 4 projektami (bo jeszcze mamy g³ówny projekt "WebAPI") Doda³em tak¿e do WebAPI pakiety NUGET które proponowa³eœ. Teraz musimy iœæ krok po kroku ¿eby stworzyæ nasz¹ aplikacjê webow¹ do zarz¹dzania magazynem. Trzeba przemyœleæ najpierw g³ówne cechy. I zacznijmy mo¿e od tworzenia naszych encji oraz bazy danych. Za³o¿enie mam takie: Magazyn: id pojemnoœæ(ile mieœci w sobie rega³ów) typ magazynu(tutaj zrobimy enum) rodzaj magazynu(tutaj zrobimy enum) Rega³: id pojemnoœæ(ile mieœci na sobie produktów) Produkt: id nazwa waga wartosc data wa¿noœci typ prod. (zrobimy enum) rodzaj prod. (zrobimy enum) Robimy powoli ma³ymi krokami ale DOK£ADNIE ¿eby wszystko siê zgadza³o z Clean Architecture