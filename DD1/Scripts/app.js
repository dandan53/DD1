var app = angular.module("DDApp", ['ngRoute']).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: MainCtrl, templateUrl: 'main.html' }).
            otherwise({ redirectTo: '/' });
    });

//TodoApp.controller(ListCtrl);

var MainCtrl = function ($scope, $location, contactService) {
    $scope.form = {};
   // $scope.form.name = "dan daniel";
   // $scope.form.phone = "052-1234561";
   
    $scope.title = "dan daniel";

    $scope.send = function() {
     //   alert($scope.form.name);
        $scope.sendMsg();
    };
    

    ///// http ////
    
    $scope.sendMsg = function () {

        contactService.sendMsg($scope.bid_id)
                        .then(
                            loadData,
                            function (errorMessage) {

                                console.warn(errorMessage);

                            }
                        )
        ;
    };

    function loadData(data) {
        // $scope.item = data;
        alert(data);
    };


   // $scope.sendMsg();
};


app.service("contactService", function ($http, $q) {

    // Return public API.
    return ({
        sendMsg: sendMsg
    });

    // ---
    // PUBLIC METHODS.
    // ---

    function sendMsg(id) {

        var request = $http({
            method: "get",
            url: "/api/values/",
            params: {
                //id: id
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

