// Typescript Version of ChildFactory.js
var ChildFactory = (function () {
    // Constructor
    function ChildFactory(selectorPlaceHolder, childType, childActionName, controllerName, childSelectorId, parentActionName, selectionControlId) {
        this.selectorPlaceHolder = selectorPlaceHolder;
        this.childType = childType;
        this.childActionName = childActionName;
        this.controllerName = controllerName;
        this.childSelectorId = childSelectorId;
        this.parentActionName = parentActionName;
        this.selectionControlId = selectionControlId;
    }
    // Functions
    ChildFactory.prototype.GetParents = function () {
        var urlString = "/" + this.selectionControlId + "/" + this.parentActionName;
        $.ajax({
            url: urlString,
            success: function (result) {
                $("#" + this.selectionControlId + "Parent").html(result);
            }
        });
    };
    return ChildFactory;
}());
