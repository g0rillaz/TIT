Tit Python3 Grabber-script and write to Database
=
Requirements:
  - Python3.x
  - MS-Sql-Server 2017-2019 mit User- credentials oder Sqlite-Server
  - 
 

Das Tool besorgt sich ersteinmal die Stations IDs aus der stations.csv, der Hompage https://open.meteostat.net/#stations,

- die List an IDs wird in maximal 200 Ids pro liste gesplitted
  wenn diese sich nicht auf genau 200 aufgeteilt werden kann wird diese um 1 veringert.

- diese werden an die Api über ein Get übergeben samt start-Datum und End-Datum. und wir werhalten die Datensätze des gesamten Zeitraum zu ein Statiopns-ID.-
- Wir erhalten die Datensätze in form von Json-Strings und convertieren diese zur gewünschten Datenbank hinzu
- Diese Daten werden dann in die Datenbank geschrieben.

- Ein API-Key ist maximal für 200 calls per hour gültig danach muss man eine Std warten bis dieser resettet wird.
- Diese Methode ist zum Teil umgesetzt und sollte weiter entwickelt werden. 
  
- Die Datenbank  verbindet sich über User-credentials mit  einer MS-Sql 2019 Datnebank

TODO:
- die Methode: UseApiKey() sollt noch weiter ausgebaut werden um das Programm rund zu machen.


Get started:
Um das Script auszuführen muss folgender Befehl eingegeben werden samt Pfad der Datei:

# python ~/Csv_WeatherGrabber.py
