function childFactory(childType, actionName, controllerName, childCounter, childHolderId, childSelectorId, selectedChildrendDivId, selectionControlId) {
    // Properties
    this.numOfSelected = 0;
    
    // Properties sourced by parameters
    this.actionName = actionName;
    this.controllerName = controllerName;
    this.childCounter = childCounter;
    this.childHolderId = childHolderId;
    this.childSelectorId = childSelectorId;
    this.childType = childType;
    this.selectionControlId = selectionControlId;

    // Functions
    this.getChildren = function () {
        this.selectedId = document.getElementById(this.selectionControlId);
        this.id = this.selectedId.options[this.selectedId.selectedIndex].value;

        this.urlString = "/" + this.controllerName + "/" + this.actionName + "?" + this.id;

        $.ajax({
            url: this.urlString,
            data: { 'id': this.id },
            success: function (result) {
                $("#" + childHolderId).html(result);
            }
        });
    };

    this.modifyNumOfSelected = function(number) {
        this.numOfSelected = this.numOfSelected + number;
    };
    
    this.cancel = function () {
        $("#" + this.childHolderId).html("");
        $("#" + this.selectionControlId).val($("#" + this.selectionControlId + ' option:first').val());
    };

    this.addChild = function () {
        this.modifyNumOfSelected(1);
        var outerDivId = 'child' + this.numOfSelected;
        var selectedId = "selected" + this.childType + this.numOfSelected;
        var innerDivId = "innerDivId" + this.numOfSelected;
        var outerDiv = "<div class='form-group' id='" + outerDivId + "'></div>";
        var newLabel = '<label class="control-label col-md-2" for="' + selectedId + '">Selected Child ' + this.numOfSelected + '</label>';
        var innerDiv = '<div class="col-md-10" id="' + innerDivId + '"></div>';
        var childSelect = '<select class="form-control" id="' + selectedId + '" name="' + selectedId + '">';
        var guid = $("#" + this.childSelectorId).val();
        var childName = $('#' + this.childSelectorId + ' option:selected').text();
        var selectedChild = '<option value="' + guid + '">' + childName + '</option>';
        //var deleteButton = '<button type="button" class="btn btn-default" onclick="deleteVersion(' + numOfSelected + ')">Delete</button>';
        $('#' + selectedChildrendDivId).append(outerDiv);
        $('#' + outerDivId).append(newLabel);
        $('#' + outerDivId).append(innerDiv);
        $('#' + innerDivId).append(childSelect);
        $('#' + selectedId).append(selectedChild);
        //$('#' + innerDivId).append(deleteButton);
        $('#' + this.childCounter).prop("value", this.numOfSelected);
    };
    
    // Not used
    //this.deleteChild = function (number) {
    //    for (i = number; i < numOfSelected; i++) {
    //        var nextChild = $('#' + "selectedChild" + (i + 1)).html();
    //        $('#' + "selectedChild" + i).html(nextChild);
    //        $("label[for='selectedChild" + (i + 1) + "']").text("Selected Child" + i);
    //        $('#innerDivId' + (i + 1)).attr("id", "innerDivId");
    //        $('#' + "selectedChild" + (i + 1)).attr("id", "selectedChild"+ i);

    //    }
    //    modifyNumOfSelected(-1);
    //    $('#' + this.child + this.numOfSelected).remove();
    //};
    
    this.restart = function () {
        this.numOfSelected = 0;
        $('#' + this.childCounter).prop("value", this.numOfSelected);
        $('#'+selectedChildrendDivId).html("");
    };
}

/*
<script>
            var numOfSelected = 0;

function getVideoVersions() {
    var selectedId = document.getElementById("videoMediaId");
    var id = selectedId.options[selectedId.selectedIndex].value;

    $.ajax({
        url: '@Url.Action("GetVersions", "VideoReleases")',
        data: { 'id': id },
        success: function (result) {
            $("#VideoVersionId").html(result);
        }
    });
}

function modifyNumOfSelected(number) {
    numOfSelected = numOfSelected + number;
}

function cancel() {
    $("#VideoVersionId").html("");
    $("#videoMediaId").val($("#videoMediaId option:first").val());
}

function deleteVersion(number) {
    for (i = number; i < numOfSelected; i++) {
        var nextVersion = $('#version' + (i + 1)).html();
        $('#version' + i).html(nextVersion);
        $("label[for='selectedVersion" + (i + 1) + "']").text("Selected Version" + i);
        $('#innerDivId' + (i + 1)).attr("id", "innerDivId");
        $('#version' + (i + 1)).attr("id", "version" + i);
                    
    }
    modifyNumOfSelected(-1);
    $('#version' + numOfSelected).remove();
}

function restart() {
    numOfSelected = 0;
    $('#numberOfVersions').prop("value", numOfSelected);
    $(selectedVersions).html("");
}

function addVersion() {
    modifyNumOfSelected(1);
    var outerDivId = "version" + numOfSelected;
    var selectedId = "selectedVersion" + numOfSelected;
    var innerDivId = "innerDivId" + numOfSelected;
    var outerDiv = "<div class='form-group' id='" + outerDivId + "'></div>";
    var newLabel = '<label class="control-label col-md-2" for="' + selectedId + '">Selected Version ' + numOfSelected + '</label>';
    var innerDiv = '<div class="col-md-10" id="' + innerDivId + '"></div>';
    var versionSelect = '<select class="form-control" id="' + selectedId + '" name="' + selectedId + '">';
    var guid = $("#VideoVersionTypeId").val();
    var versionName = $("#VideoVersionTypeId option:selected").text();
    var selectedVersion = '<option value="' + guid + '">' + versionName + '</option>';
    var deleteButton = '<button type="button" class="btn btn-default" onclick="deleteVersion(' + numOfSelected + ')">Delete</button>';
    $('#selectedVersions').append(outerDiv);
    $('#' + outerDivId).append(newLabel);
    $('#' + outerDivId).append(innerDiv);
    $('#' + innerDivId).append(versionSelect);
    $('#' + selectedId).append(selectedVersion);
    //$('#' + innerDivId).append(deleteButton);
    $('#numberOfVersions').prop("value", numOfSelected);
}
</script>*/