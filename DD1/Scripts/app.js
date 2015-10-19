var app = angular.module("DDApp", ['ngRoute']).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: MainCtrl, templateUrl: 'main.html' }).
            otherwise({ redirectTo: '/' });
    });


var MainCtrl = function ($scope, $location, contactService) {

    $scope.contacts = {};

    $scope.isAdmin = false;

    $scope.form = {};
 
    $scope.send = function() {

        $scope.isAdmin = false;

        if ($scope.form.name === "1") {
            $scope.getContacts();
        } else {
            $scope.postContact();
        }
    };
    
   
    ///// http ////
    
    $scope.postContact = function () {

        contactService.postContact($scope.form)
                        .then(
                            loadPostContactData,
                            function (errorMessage) {
                                console.warn(errorMessage);
                            }
                        );
    };

    function loadPostContactData(data) {
//        alert(data);
    };
    

    $scope.getContacts = function () {

        contactService.getContacts($scope.form.phone)
                        .then(
                            loadGetContactsData,
                            function (errorMessage) {
                                console.warn(errorMessage);
                            }
                        );
    };

    function loadGetContactsData(data)
    {
        $scope.contacts = data;

        $scope.isAdmin = true;
    };


};


app.service("contactService", function ($http, $q) {

    // Return public API.
    return ({
        getContacts: getContacts,
        postContact: postContact
    });

    // ---
    // PUBLIC METHODS.
    // ---

    function postContact(contact) {

        var request = $http({
            method: "post",
            url: "/api/values/",
            data:
            {
                Name: contact.name,
                Phone: contact.phone,
                Mail: contact.email,
                Content: contact.content
            }
        });

        return (request.then(handleSuccess, handleError));
    }

    function getContacts(phone) {

        var request = $http({
            method: "get",
            url: "/api/values/",
            params: {
                Phone: phone
            }
        });

        return (request.then(handleSuccess, handleError));
    }

  

    // ---
    // PRIVATE METHODS.
    // ---


    // I transform the error response, unwrapping the application dta from
    // the API response payload.
    function handleError(response) {

        // The API response from the server should be returned in a
        // nomralized format. However, if the request was not handled by the
        // server (or what not handles properly - ex. server error), then we
        // may have to normalize it on our end, as best we can.
        if (
            !angular.isObject(response.data) ||
            !response.data.message
            ) {

            return ($q.reject("An unknown error occurred."));

        }

        alert("handleError");

        // Otherwise, use expected error message.
        return ($q.reject(response.data.message));


    }


    // I transform the successful response, unwrapping the application data
    // from the API response payload.
    function handleSuccess(response) {

        // alert("handleSuccess");

        return (response.data);

    }

}
);

