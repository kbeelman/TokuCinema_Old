// Send the result of an ajax call to an element id
    function ajaxMethodToElement(ActionName, ControllerName, ElementId, OptionalId) {
        // Populate variable if an Id is submitted
        if (OptionalId !== null || OptionalId !== "") {
            var id = OptionalId;
        }
        
        var urlString = "/" + ControllerName + "/" + ActionName + "?" + id;

        $.ajax({
            url: urlString,
            data: { 'id': id },
            success: function (result) {
                $("#" + ElementId).html(result);
            }
        });
    }