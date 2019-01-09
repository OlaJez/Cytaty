function losujCytat() {
    //podloga - odcina/ random od 0....1/* ilosc cytatow
    var wylosowany_cytat = Math.floor(Math.random() * $("div.opakowany-cytat").length);
    //ktory wylosowany
    console.log(wylosowany_cytat);
    //$ - wywołanie jQuery
    $("div.opakowany-cytat").hide();
    //konwertuje obiekt html wylosowany cyt do obiektu jQuery
    $($("div.opakowany-cytat")[wylosowany_cytat]).show();
}

losujCytat();

//samo sie odswieza po 10 sek
setInterval(losujCytat, 3000);
