/* 

Script to be executed upon loading of the _Layout_Front partial view

- Handles features associated with front navigation / UI
    - Quick nav sidebar
    - '<' back and '>' forward buttons for navigating forward and backward throug ajax requests

*/
$(document)

    // object literal to encapsulate nav requests
    var frontNav = {
        currentTab: 0,
        requsts: []
    };

    $(document).ready(function () {
        // reset nav - prevents other uses of the ajaxMethodToElement ajax helper from affecting front end nav context
        frontNav.currentTab = 0;
        frontNav.requsts.length = 0;
        addRequestToNav("/VideoMedias/MovieIndex/");
    });

    // go back to the last ajax request - like browser back button, but for ajax requests
    $("#goBack").click(function () {
        if (frontNav.currentTab >= 1) {
            ajaxRequestToElement(frontNav.requsts[frontNav.currentTab - 1], 'bodyContainer');
            frontNav.currentTab -= 1;
        }
    });

    // go forward to the next ajax request in the requests array - like browser forward button, but for ajax requests
    $("#goForward").click(function () {
        if (frontNav.requsts.length - 1 > frontNav.currentTab) {
            ajaxRequestToElement(frontNav.requsts[frontNav.currentTab + 1], 'bodyContainer');
            frontNav.currentTab += 1;
        }
    });

    // helper function to add a request the nav object
    function addRequestToNav(requestString) {
        // slice if necessary - remove forward options for pages on a different drilling context 
        // ( going back and making a different selection - don't keep the original selection's pages just ones prior )
        if (frontNav.requsts.length > frontNav.currentTab) {
            frontNav.requsts.slice(0, frontNav.currentTab);
        }
        frontNav.requsts.push(requestString);
        frontNav.currentTab = frontNav.requsts.length - 1;
    }

    