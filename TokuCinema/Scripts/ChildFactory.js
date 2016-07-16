/* ChildFactory Prototype - Last Updated 7/12/16 */

function childFactory(selectedPlaceHolder /*span id for markup to be appended to*/,
    childType /*Child Type (i.e. Version, MediaFile, etc...)*/,
    childActionName /*name of the action (partial view result) the Ajax query calls to get children*/,
    controllerName /*name of the controller where the action is found*/,
    childSelectorId /*Id of the control returned by Ajax call to select child record*/,
    parentActionName /*name of the action (partial view result) the Ajax query calls to get parents*/,
    selectionControlId /*Id of the control that sorts child records - optional*/) {

    // Properties
    this.numOfSelected = 0;
    this.countHolderExists = false;
    this.selectedChildrenDivId = /*"selectedVersions"*/ "selected" + childType + "s";
    var childHolderId = childType.toLowerCase() + "SelectorDiv";
    
    // Properties sourced by parameters
    this.selectedPlaceHolder = selectedPlaceHolder;
    this.childActionName = childActionName;
    this.controllerName = controllerName;
    this.childSelectorId = childSelectorId;
    this.childType = childType;
    this.parentActionName = parentActionName;
    this.selectionControlId = selectionControlId;

    // Functions

    // gets the parent records that can be used to filter child results
    this.getParents = function () {
        this.urlString = "/" + this.controllerName + "/" + this.parentActionName;

        $.ajax({
            url: this.urlString,
            success: function (result) {
                $("#" + selectionControlId + "Parent").html(result);
            }
        });
    };

    // gets the children desired - filtered by parent object if applicable
    this.getChildren = function () {
        // Call to create count holder only if it doesn't exist
        if (this.countHolderExists === false) {
            this.createCountHolder();
            this.countHolderExists = true;
        }

        this.selectedId = document.getElementById(this.selectionControlId);
        if (this.selectedId !== null) { // Implementation of the 'optionality' of the the "selectionControlId"
            this.id = this.selectedId.options[this.selectedId.selectedIndex].value;
        }

        this.urlString = "/" + this.controllerName + "/" + this.childActionName + "?" + this.id;

        $.ajax({
            url: this.urlString,
            data: { 'id': this.id },
            success: function (result) {
                $("#" + childHolderId).html(result);
            }
        });
    };

    // Changes the numOfSelected variable by the number passed
    this.modifyNumOfSelected = function(number) {
        this.numOfSelected = this.numOfSelected + number;
    };
    
    // Resets child selector, but does not remove selected that were made
    this.cancel = function () {
        $("#" + childHolderId).html("");
        $("#" + this.selectionControlId).val($("#" + this.selectionControlId + ' option:first').val());
    };

    this.createChildSelector = function () {
        // Create child selector div - delimiting field (i.e. dropdown list for Video Media) and dropdown list to display child options.
        var childSelectorDiv = "<div class='form-group' id='" + this.childType.toLowerCase() + "Selector'></div>";

        // add to span
        $(/*'#versionSelectorPlaceHolder'*/ '#' + this.selectedPlaceHolder).append(childSelectorDiv);

        // add label and selection control for delimitting field (i.e. parent records - video media) to childSelectorDiv
        $('#' + this.childType.toLowerCase() + 'Selector').append("<label class='control-label col-md-2 required-field'>" + this.selectionControlId + "</label>" +
            "<div class='col-md-4' id='" + this.selectionControlId + "Parent" + "'></div>");

        // add label and div for selecting child elements
        $('#' + this.childType.toLowerCase() + 'Selector').append("<label class='control-label col-md-2 required-field'>" + this.childType + "</label>" +
            "<div class='col-md-4' id='" + childHolderId + "'></div>");

        // Create div that will contain the selected children
        var selectedChildHolder = "<div class='form-group' id='" + this.selectedChildrenDivId + "'></div>";

        this.getParents();
        
    };

    this.createCountHolder = function () {
        // Create element
        inputCounter = "<input type='hidden' name='" + "numberOf" + this.childType + "s' id='" + "numberOf" + this.childType + "s'>";
        // Add element to parent div element ***Convention is this.childType.toLowerCase() + 'Selector' - not a parameter *** 
        $('#' + this.childType.toLowerCase() + 'Selector').append(inputCounter);
    };

    // Adds a child to the selected children div, increments the num of selected variable
    this.addChild = function () {
        this.modifyNumOfSelected(1);
        var outerDivId = this.childType + this.numOfSelected;
        var selectedId = "selected" + this.childType + this.numOfSelected;
        var innerDivId = "innerDivId" + this.numOfSelected;
        var outerDiv = "<div class='form-group' id='" + outerDivId + "'></div>";
        var newLabel = '<label class="control-label col-md-2" for="' + selectedId + '">Selected '+this.childType + ' ' + this.numOfSelected + '</label>';
        var innerDiv = '<div class="col-md-10" id="' + innerDivId + '"></div>';
        var childSelect = '<select class="form-control" id="' + selectedId + '" name="' + selectedId + '">';
        var guid = $("#" + this.childSelectorId).val();
        var childName = $('#' + this.childSelectorId + ' option:selected').text();
        var selectedChild = '<option value="' + guid + '">' + childName + '</option>';
        //var deleteButton = '<button type="button" class="btn btn-default" onclick="deleteVersion(' + numOfSelected + ')">Delete</button>';
        $('#' + this.selectedChildrenDivId).append(outerDiv);
        $('#' + outerDivId).append(newLabel);
        $('#' + outerDivId).append(innerDiv);
        $('#' + innerDivId).append(childSelect);
        $('#' + selectedId).append(selectedChild);
        //$('#' + innerDivId).append(deleteButton);
        $('#' + 'numberOf' + this.childType + 's').prop("value", this.numOfSelected);
    };

    // Removes the selected versions
    this.restart = function () {
        this.numOfSelected = 0;
        $('#' + this.childCounter).prop("value", this.numOfSelected);
        $('#' + selectedChildrenDivId).html("");
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
}

//  Original Script
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