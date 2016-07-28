// Scripts to execute when loading the layout_partial view - aka the right side navbar

$(document).ready(function () {
    $("#tags, #tagsHome").on("keydown", function search(e) {
        if (e.keyCode === 13) {
            goToView('SearchIndex', 'VideoMedias', $(this).val());
        }
    });

    // Dynamically pull autocomplete options from VideoVersionType titles
    var availableTags = [];

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/VideoVersionTypes/GetVideoVersionTypeTitleList',
        success: function (outputfromserver) {
            for (var i = 0; i < outputfromserver.length; i++) {
                availableTags[i] = outputfromserver[i];
            }
        }
    });

    $("#tags, #tagsHome").autocomplete({

        source: availableTags

    });
    // Show and hide Ajax spinner based on whether or not an ajax query is loading.
    $(document)
        .ajaxStart(function () {
            $("#ajaxSpinnerImage").show();
        })
        .ajaxStop(function () {
            $("#ajaxSpinnerImage").hide();
        });
});
