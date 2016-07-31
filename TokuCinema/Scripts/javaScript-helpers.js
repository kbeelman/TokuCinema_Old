// Function to call redirect to view from javaScript
function goToView(actionName, controllerName, queryString) {

    var desired = queryString.replace(/[^\w\s]/gi, '');

    var targetUrl = '/' + controllerName + '/' + actionName + '/' + desired;
    window.location.href=targetUrl;
}

