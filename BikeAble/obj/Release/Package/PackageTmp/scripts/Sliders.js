$(document).ready(function () {

    function GetGrosseur(nb){
        switch(nb){
            case 1:
                return "Lettre";
                break;
            case 2:
                return "Petit";
                break;
            case 3:
                return "Moyen";
                break;
            case 4:
                return "Gros";
                break;
        }
    }

    function ChangeBtn() {
        var btn = $("#ParamAvancé");
        $("#Annuler").attr('class', 'btn btn-primary Bar-Btn UpdatedMiddle');
        btn.attr('class', 'btn btn-primary Bar-Btn UpdatedBtn');
        $("#UpdateBtn").append(btn);
    }

    function RedoBtn() {
        var btn = $("#ParamAvancé");
        $("#Annuler").attr('class', 'btn btn-primary BarBtnMiddle BarBtn');
        btn.attr('class', 'btn btn-primary BarBtnRight BarBtn');
        $(".btn-group").append(btn);
    }

    function CheckWidth() {
        if ($(window).width() <= 414) {
            ChangeBtn();
        }
        else if ($(window).width() > 414) {
            RedoBtn();
        }
    }

    $("#Distance-range").slider({
        range: true,
        min: 1,
        max: 50,
        values: [1, 10],
        slide: function (event, ui) {
            $("#Distance").text("Limite de distance : " + ui.values[0] + " Km" + " - " + ui.values[1] + " Km");
        }
    });
    $("#Distance").text("Limite de distance : " + $("#Distance-range").slider("values", 0) + " Km - " + $("#Distance-range").slider("values", 1) + " Km");

    $("#Grosseur-range").slider({
        range: true,
        min: 1,
        max: 4,
        values: [1, 4],
        slide: function (event, ui) {
            $("#Grosseur").text("Limite de Grosseur : " + GetGrosseur(ui.values[0]) + " - " + GetGrosseur(ui.values[1]));
        }
    });
    $("#Grosseur").text("Limite de Grosseur : " + GetGrosseur($("#Grosseur-range").slider("values", 0)) + " - " + GetGrosseur($("#Grosseur-range").slider("values", 1)));

    $(window).resize(function () {
        CheckWidth();
    });

    CheckWidth();
    
});