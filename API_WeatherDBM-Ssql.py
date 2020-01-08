import csv
import datetime
import requests
import sqlite3
import time

import pymssql
from pymssql import Error
import json

# TODO:: DSN Verbindung aufbauen über den ODBC-
#  driver
# TODO:: Methode erstellen für ODC-requests


def create_connectionSqlite(db_file):
    """ create a database connection to the SQLite database
        specified by db_file
    :param db_file: database file
    :return: Connection object or None
    """
    conn = None
    try:
        conn = sqlite3.connect(db_file)
    except Error as e:
        print(e)
    return conn

def create_connection():
    """ create a database connection to the SQLite database
        specified by db_file
    :param -------
    :return: Connection object or None
    """
    conn = None
    try:
        conn = pymssql.connect(database='stations', user="SA", password='D0ckerR0gue99@@', host='172.17.0.1', port=1433)
    except Error as e:
        print(e)
    return conn

def split_list(alist, wanted_parts):
    length = len(alist)
    #print(alist)
    print("Es sind:", len(alist), "Stationen in der Liste")
    return [alist[i*length // wanted_parts: (i+1)*length // wanted_parts] for i in range(wanted_parts)]

def IDsRanHolenCsv():
    """
    return:: splitedList
    """
    csvPfad = ['Z:/Programme/Projekt_TiT/Projectdata/stations.csv',
               '/home/jezzn/home/jezzn/Coding_PROJEKTE/Pycharm/Project_TIT/DATA/stations.csv']
    with open(csvPfad[1], encoding="utf8", newline='') as csvfile:
        spamreader = csv.reader(csvfile, delimiter=',')
        ids = []            # TODO:: halte alle IDs aber return immmer nur in einer länger von 200
        for station in spamreader:
            """Nehme die erste Spalte auf"""
            #if len(ids) <= 10:
            ids.append(station[0])
        #splitedList.append(split_list(ids, wanted_parts=15000))
        splitedList = split_list(ids, wanted_parts=153)
        print(splitedList)
        print("länger der ersten Liste: ", len(splitedList[0]))
        print("länger der letzten Liste: ", len(splitedList[-1]))



    #for i in ids:
     # print(len(ids),i)
    return splitedList


def SQL_StationIDs():
    pass


def ApiRequest(apikey, startdate, enddate, station_id):
    """"
    Parm::API-Key  # https://open.meteostat.net/daily/
    startdate = "2019-05-03"
    enddate = "2019-05-03"
    station = "station_id"
    -------------
    return::JSON-String["data"]
    """
    #try:

    r = requests.get(
    'https://api.meteostat.net/v1/history/daily?station={3}&start={1}&end={2}&time_zone=Europe/London&time_format=Y-m-d%20H:i&key={0}'.format(
    apikey, startdate, enddate, station_id))

    # print(r.status_code)

    if r.status_code == 400:
        print("Die Abfrage war nicht erfolgreich! Status-Code: 400")
    else:
        print("Die Abfrage war erfolgreich! Status-Code: 200")
    try:
        print(r.json())
    except json.decoder.JSONDecodeError:
        print("N'est pas JSON")

    jsonstring = r.json()["data"]

    return jsonstring



"""
CREATE TABLE StationsDaten (id INTEGER NOT NULL, _date DATETIME, _temperatur DOUBLE, _temperature_min DOUBLE, _temperature_max DOUBLE, _precipitation DOUBLE, _snowfall INTEGER, _snowdepth INTEGER, _winddirection INTEGER, _windspeed DOUBLE, _peakgust INTEGER, _sunshine DOUBLE, _pressured DOUBLE)
"""

def scheissNone(non_item):
    if non_item is None:
        # "'" + str(non_item) + "'" <--backup-Str-methode
        return "NULL"
    else:
        return non_item

def create_weatherset(conn, weatherset,stationID):
    """
    iteriere die JSON:"data"-Elemente durch und erstelle draus Datensätze
    :param conn:
    :param weatherset:Dict
    :return: lezte weatherset id
    """
    def JsonToDB(dataJson,cur):
        # TODO:: Eine Dictenary anders durch iterieren https://www.python-forum.de/viewtopic.php?t=3018
        for i in dataJson:
            # print("'" + i["date"] + "'")
            # print("Single Dataset: ", i)

            # [dbo].[StationMeteoData]
            # [dbo].[rerf]

            #lastID = "SELECT id FROM [dbo].[rerf] WHERE id = (SELECT MAX(id) FROM [dbo].[rerf])"
            #lastrow = cur.execute(lastID)
            #cur.fetchall()
            #print(lastrow)

            #cur.fetchall()


            sqlQuerry = '''
                        INSERT INTO [dbo].[rerf]
                       ([STATION_ID]
                       ,[_date]
                       ,[_temperatur]
                       ,[_temperature_min]
                       ,[_temperature_max]
                       ,[_precipitation]
                       ,[_snowfall]
                       ,[_snowdepth]
                       ,[_winddirection]
                       ,[_windspeed]
                       ,[_peakgust]
                       ,[_sunshine]
                       ,[_pressured]
                       ,[FLG_FILLD]
                       ,[AIR_HMTY]
                       ,[WTH_CODE])
                 VALUES
                       ({12}
                       ,{0}
                       ,{1}
                       ,{2}
                       ,{3}
                       ,{4}
                       ,{5}
                       ,{6}
                       ,{7}
                       ,{8}
                       ,{9}
                       ,{10}
                       ,{11}
                       ,2142
                       ,54
                       ,34);
                '''.format(
                "'" + i["date"] + "'",
                scheissNone(i["temperature"]),
                scheissNone(i["temperature_min"]),
                scheissNone(i["temperature_max"]),
                scheissNone(i["precipitation"]),
                scheissNone(i["snowfall"]),
                scheissNone(i["snowdepth"]),
                scheissNone(i["winddirection"]),
                scheissNone(i["windspeed"]),
                scheissNone(i["peakgust"]),
                scheissNone(i["sunshine"]),
                scheissNone(i["pressure"]),
                stationID
                )
            #print(sqlQuerry)



            cur.execute(sqlQuerry)
            # TODO:: ein brauchbaren return zurüchgeben, lastrowid?
        return print("SQL-LastRowID: ",cur.lastrowid)

    cur = conn.cursor()
    JsonToDB(weatherset, cur)
    conn.commit()
    # print(str(weatherset[0]))
    # print(sql)
    # cur = conn.cursor()
    # cur.execute(sql)

    return "", cur.lastrowid



def datetime_to_float(d):
    epoch = datetime.datetime.utcfromtimestamp(0)
    total_seconds = (d - epoch).total_seconds()
    # total_seconds will be in decimals (millisecond precision)
    return total_seconds

def float_to_datetime(fl):
    return datetime.datetime.fromtimestamp(fl)



def main():
    database = r"/home/jezzn/Projects/TiT/TiTDB.db"
    # MS_Database = database='stations', user="SA", password='D0ckerR0gue99@@', host='172.17.0.1', port=1433

    """
    API-Keys:
    GF2pp1rP
    mMMOQxHR
    """

    conn = create_connection()      # create a database connection
    stationIDs = IDsRanHolenCsv()

    apiKeys = ['GF2pp1rP', 'mMMOQxHR']
    Timestamp = []

    def creatStamp():
        pass




    timeStamp_ApiKey = [[], []]

    def UseApiKey():
        # TODO:: https://stackoverflow.com/questions/38276130/python-adding-one-hour-to-time-time
        # print(time.time(),  timedelta(hours=9)) # TODO:: https://stackoverflow.com/questions/47043841/converting-time-to-a-float#47043887

        OneHour = datetime.timedelta(hours=1)
        timeStamp_ApiKey[0] = datetime.datetime.now() - datetime.timedelta(hours=0.99)
        timeStamp_ApiKey[1] = datetime.datetime.now() - datetime.timedelta(hours=1)
        print("Die Timestamps!:3",timeStamp_ApiKey)
        print(timeStamp_ApiKey[0])

        # TimeTimestamp = datetime.datetime.now() - timeStamp_ApiKey[0]

        while not datetime.datetime.now() - timeStamp_ApiKey[0] >= OneHour:

            waittime = OneHour - (datetime.datetime.now() - timeStamp_ApiKey[0])
            print("Der Apikey muss noch warten: ", type(waittime))
            print("Warte auf volle stunde", datetime.datetime.now() - timeStamp_ApiKey[0])
            waittimesec = waittime.total_seconds()
            print("Warte auf API-Key-refresh \t Warten:", waittimesec, "Seconds")
            time.sleep(waittimesec) # TODO:: Die wartezeit Modolo ==>> % (1h - (timeNow - timeStamp))

        if datetime.datetime.now() - timeStamp_ApiKey[0] >= OneHour:
            print("BOOM!!!!!!!", timeStamp_ApiKey[0])
        elif datetime.datetime.now() - timeStamp_ApiKey[1] >= OneHour:
            print("BOOM2222!!!!!!!", timeStamp_ApiKey[1])
        else:
            print("Der Timestamp ist noch zu jung")

        print(timeStamp_ApiKey)
        return apiKeys[0]

    with conn:
        #for api_key in apiKeys, :
        #    print("Nutze Api-key: {0}".format(api_key))


        for List in range(0,len(stationIDs)):
            apiKEY = UseApiKey() # eine Liste oder eine gültigen Api-key ziehen

            for i in stationIDs[List]: # TODO::LEZTER STAND:: Die List beinhalet jetzt <= 200 Stations, API-Key muss bereitgestellt werden "UseApiKey()"
                weatherset = ApiRequest(apiKEY, "1930-05-03", "2019-12-08", i)
                print("Lade die Daten von der Station: " + str(i) + " " + "Enthaltene Datensätze: " + str(len(weatherset)))

                # create a new weatherset
                create_weatherset(conn, weatherset, i)






if __name__ == '__main__':
    main()
